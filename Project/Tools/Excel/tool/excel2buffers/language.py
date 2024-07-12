# -*- coding:utf8 -*-

import sys
import os

# python3默认编码是utf-8格式

if __name__ == '__main__':

	originDir = sys.argv[1]
	targetDir = sys.argv[2]
	language = sys.argv[3]

	if not os.path.exists(targetDir):
		os.mkdir(targetDir)

	fileList = os.listdir(originDir)
	for file in fileList:
		file_name = file.split(".")[0]
		file_tail = file.split(".")[1]
		
		if file_tail != 'csv':
			continue

		if language == "all" or language == file_name:
			origin_path = os.path.join(originDir, file_name + '.csv')
			target_path = os.path.join(targetDir, file_name + '.bytes')

			with open(origin_path, 'r', encoding = 'gbk') as f:
				
				file = open(target_path,'w+')

				for line in f.readlines():
					line = line.strip()
					file.write(line.replace(',','\t',1) + '\n')

				file.close()
