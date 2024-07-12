# -*- coding:utf8 -*-
import os
import re
import shutil
# 处理java代码的package路径
work_root = os.path.dirname(os.path.abspath(__file__))
schemedir = os.path.join(work_root, "Data/java")
def __ProcessLuaRequirePath(f):

	fileFront = f.split(".")[0]
	fileName = fileFront + "RowData"

	file = os.path.join(work_root, "generated_java", f)

	lines = ""
	with open(file, "r", encoding="utf-8") as f1:
		lines = f1.readlines()


	if not os.path.exists(schemedir):
		os.makedirs(schemedir)

	wfile = os.path.join(schemedir, f)

	with open(wfile, "w", encoding="utf-8") as f1:
		for line in lines:
			if line.find("import java.nio.*;") != -1:
				line=re.sub(r'import java.nio.*;',r'package com.shenghe.jiuchen.empire.flatbuffers;\n\nimport java.nio.*;',line)

			string = "public final class {} extends Table".format(fileFront)
			finalString = "final class {} extends Table".format(fileFront)
			if line.find(string) != -1:
				line = re.sub(string,finalString,line)

			f1.write(line)

	fileNew = os.path.join(schemedir, fileName + "." + "java")
	os.rename(wfile,fileNew)

def run():
	g = os.walk(os.path.join(work_root, "generated_java"))
	for path,dir_list,file_list in g:
		for file_name in file_list:
			__ProcessLuaRequirePath(file_name)
