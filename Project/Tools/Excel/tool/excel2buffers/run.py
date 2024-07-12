# -*- coding:utf8 -*-

import fbs_generator
import bytes_generator
import lua_process
import java_process
import sys

if __name__ == '__main__':
	fbs_generator.run(sys.argv)		# 必须先生成代码
	bytes_generator.run(sys.argv)	# 然后将excel数据打包成 flatbuffers 的二进制
	# java_process.run() # 后处理
	# lua_process.run()  # 后处理