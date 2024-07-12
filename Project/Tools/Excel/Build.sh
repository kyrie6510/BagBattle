current_dir=$(pwd)
echo "当前项目文件夹路径：$current_dir"

excelPath="$current_dir/plan/excel"        #excel配表文件夹
toolPath="$current_dir/tool/excel2buffers" #转表工具文件夹
configPath="$current_dir/config"  

#buildConfig 文件路径
buildConfigPath="$current_dir/BuildConfig/BuildConfig/bin/Debug/csharp"

# 拷贝plan中的excel文件夹
cp -rf $excelPath $toolPath
rm -rf "$toolPath/excel/Language"

echo "开始解析数据表"
python "$current_dir/tool/excel2buffers/run.py"

if [[ $? != 0 ]]; then
	echo "解析数据表失败"
	exit 1
fi

targetBytes="$configPath/bytes"
targetCSharp="$configPath/csharp"


tempBytesPath="$toolPath/generated_bytes"
tempCSharpPath="$toolPath/generated_csharp"
tempLanguagePath="$tempBytesPath/language"

echo "开始清理bytes配表文件"
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

echo "移动文件"
rm -rf $configPath/language
mv $tempLanguagePath $configPath
mv -f $tempBytesPath/* $targetBytes
mv -f $tempCSharpPath/* $targetCSharp

echo "拷贝BuildConfig"
echo "当前项目buildConfigPath文件夹路径：$buildConfigPath"
cp -f $targetCSharp/* $buildConfigPath


# echo "编译dll文件"
# mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono
# exc=$toolPath/BuildConfig.exe 
# flat=$toolPath/FlatBuffers.dll
# $mono $exc $flat $targetCSharp $targetCSharp/"config-flat.dll"
#rm $targetCSharp/*.cs



read -n 1 -s -r -p "按任意键关闭窗口..."