# -*- coding:utf8 -*-
import os
import re
import shutil
# 处理lua代码的require路径
work_root = os.path.dirname(os.path.abspath(__file__))
schemedir = os.path.join(work_root, "Data/scheme")
bytesDir = os.path.join(work_root, "Data/bytes")
def __ProcessLuaRequirePath(f):
	file = os.path.join(work_root, "generated_lua", f)
	lines = ""
	with open(file, "r", encoding="utf-8") as f1:
		lines = f1.readlines()	

    
	if not os.path.exists(schemedir):
		os.makedirs(schemedir)

	wfile = os.path.join(schemedir, f)

	with open(wfile, "w", encoding="utf-8") as f1:
		for line in lines:
			if line.find("local flatbuffers = require") != -1:
				line=re.sub(r"require\('","require('flatbuffers/",line)
				# print(line)
			elif line.find("local obj = require") != -1 :
				line=re.sub(r"require\('","require('Config/Data/scheme/",line)
				# print(line)
			f1.write(line)

def run():
	g = os.walk(os.path.join(work_root, "generated_lua"))  
	for path,dir_list,file_list in g:
		for file_name in file_list:
			__ProcessLuaRequirePath(file_name)

	if os.path.exists(bytesDir):
		shutil.rmtree(bytesDir)
	os.makedirs(bytesDir)

	g = os.walk(os.path.join(work_root, "generated_bytes"))
	for path, dir_list, file_list in g :
		for file_name in file_list:
			print(file_name)
			shutil.copyfile(work_root+"/generated_bytes/"+file_name, bytesDir + "/" + file_name)  


