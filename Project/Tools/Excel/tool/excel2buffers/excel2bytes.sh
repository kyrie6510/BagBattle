#!/bin/bash

gitConfig="ssh://git@10.0.1.234/empire/config.git"
gitPlan="ssh://git@10.0.1.234/empire/plan.git"

# 本地测试
if [ ! -n "$WORKSPACE" ]; then
	WORKSPACE=$(dirname $(dirname $(pwd)))
	notGit=false
	language="cn"
fi
echo $WORKSPACE

excelPath="$WORKSPACE/plan/excel"        #excel配表文件夹
toolPath="$WORKSPACE/tool/excel2buffers" #转表工具文件夹
configPath="$WORKSPACE/config"           #最终文件夹
branchBytes=$branch #转表后分支
branchExcel=$branch #配表分支
source $WORKSPACE/tool/common/funs.sh

if [ ! -n "$notGit" ]; then
	echo "更新策划配表"
	if [ ! -d ${excelPath} ]; then
		echo "Clone now ..."
		git clone $gitPlan
	fi

	clean_git_repository $excelPath
	cd $excelPath
	checkout_branch $branchExcel
	cd $WORKSPACE

	echo "更新客户端配表"
	if [ ! -d ${configPath} ]; then
		echo "Clone now ..."
		git clone $gitConfig
	fi
	clean_git_repository $configPath
	cd $configPath
	checkout_branch $branchBytes
	cd ..
fi



# 拷贝plan中的excel文件夹
cp -rf $excelPath $toolPath
rm -rf "$toolPath/excel/Language"

echo "开始解析数据表"
python3 "$toolPath/run.py"

if [[ $? != 0 ]]; then
	echo "解析数据表失败"
	exit 1
fi

targetBytes="$configPath/bytes"
targetCSharp="$configPath/csharp"
# targetJava="$configPath/java"

tempBytesPath="$toolPath/generated_bytes"
tempCSharpPath="$toolPath/generated_csharp"
tempLanguagePath="$tempBytesPath/language"
# tempJavaPath="$toolPath/generated_java"

# 清理bytes配表文件， 如果曾经删除过excel文件，则需要执行此操作
if [[ $cleanBytes == "true" ]]; then
	rm -rf $targetBytes
	rm -rf $targetCSharp
	# rm -rf $targetJava
fi

if [[ ! -d $targetBytes ]]; then
	mkdir $targetBytes
fi
if [[ ! -d $targetCSharp ]]; then
	mkdir $targetCSharp
fi
if [[ ! -d $tempLanguagePath ]]; then
	mkdir $tempLanguagePath
fi
# if [[ ! -d $tempJavaPath ]]; then
# 	mkdir $tempJavaPath
# fi

echo "开始解析多语言表"
python3 "$toolPath/language.py" "$excelPath/Language" "$toolPath/generated_bytes/language" $language

if [[ $? != 0 ]]; then
	echo "解析多语言表失败"
	exit 1
fi


echo "移动文件"
rm -rf $configPath/language
mv $tempLanguagePath $configPath
mv -f $tempBytesPath/* $targetBytes
mv -f $tempCSharpPath/* $targetCSharp

echo "编译dll文件"
mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono
exc=$toolPath/BuildConfig.exe 
flat=$toolPath/FlatBuffers.dll
$mono $exc $flat $targetCSharp $targetCSharp/"config-flat.dll"
rm $targetCSharp/*.cs



if [ ! -n "$notGit" ]; then
	cd $configPath
	git add .
	git commit -m "auto excel2bytes"
	git push

	echo "清理tool文件夹"
	cd "$WORKSPACE/tool"
	git checkout . && git clean -fd
fi