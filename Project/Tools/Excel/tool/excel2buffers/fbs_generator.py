# -*- coding:utf8 -*-
import xlrd
from datetime import date, datetime
import sys
import os
import shutil
import time
import csv


__excel_extension = 'xlsx'
__csv_extension = 'csv'
__support_datatypes = [
	'string',
	'int16',
	'uint16',
	'int32',
	'uint32',
	'int64',
	'uint64',
	'float',
	'byte',
	'[int16]',
	'[uint16]',
    '[int32]',
	'[uint32]',
    '[int64]',
	'[uint64]',
    '[float]',
    '[byte]',
    '[string]',
    
]
__fileList_keysIndex = {}

__row_code = """
table %s {
    %s
}
"""

__group_code = """
table %s {
    datalist:[%s];
}
"""

def __clean_directory(target_path):
	if not os.path.isdir(target_path):
		os.mkdir(target_path)
	try:
		for root, dirs, files in os.walk(target_path):
			for file in files:
				path = os.path.join(root, file)
				os.remove(path)
				print('清理文件: ', path)
	except:
		print('旧数据清理失败，请关掉已打开的旧文件')
		sys.exit(1)



def __export_all_excel_to_fbs():
	__fileList_keysIndex = {}
	for root, dirs, files in os.walk(excel_root_path, topdown=True):
		for name in files:
			file_path = os.path.join(root, name)
			if file_path.endswith(__excel_extension) and not name.startswith('~'):
				__export_excel_to_fbs(file_path, name)

def __export_excel_to_fbs(excel_path, name):
	# 打开excel，分别将每一个sheet导出fbs
	fileName = name.split(".")[0]
	wb = xlrd.open_workbook(excel_path)
	sheet1 = wb.sheet_by_index(0)
	__export_sheet_to_fbs(sheet1,excel_path,fileName)


def __export_sheet_to_fbs(sheet,path,sheet_name):
	variable_dict = {}
	variable_defaultValue_dict = {}
	row_table_name = sheet_name + 'RowData'
	group_table_name = sheet_name;
	data_col_count = sheet.ncols #列数
	fristKeyName = sheet.cell_value(3, 0) #key
	if fristKeyName.lower() == "id":
		__fileList_keysIndex[sheet_name] = 1
	else:
		__fileList_keysIndex[sheet_name] = 0
	for col_num in range(0, data_col_count):
		name_data = sheet.cell_value(3, col_num) #第3行是name
		type_data = sheet.cell_value(2, col_num).split(':') #第2行是类型和默认值
		target_data = sheet.cell_value(1,col_num)

		if type_data == "" or name_data == "":
			continue

		variable_name = name_data[0].upper() + name_data[1:]
		row_type_data = type_data[0]
		if variable_name in variable_dict:
			print('')
			print('路径: ', path)
			print('存在相同的字段名: ', variable_name)
			print('异常退出')
			sys.exit(1)

		if not row_type_data in __support_datatypes:
			print('')
			print('路径: ', path)
			print('字段', variable_name, '的数据类型', row_type_data,'不在支持的列表中')
			print('异常退出')
			sys.exit(1)
		variable_dict[variable_name] = row_type_data
		typeLen = len(type_data)
		if typeLen == 2:
		   variable_defaultValue_dict[variable_name] = type_data[1]
		   print(variable_name,"此处有默认值")
		else:
		   variable_defaultValue_dict[variable_name] = "NULL"

	# 组合变量定义代码字符串
	variables_str = ''
	for variable in variable_dict:
		if variable_defaultValue_dict[variable] == "NULL":
		   data_type = variable_dict[variable]
		   variables_str += '    %s:%s;\n' % (variable, data_type)
		else:
		   data_type = variable_dict[variable]
		   data_def = variable_defaultValue_dict[variable]
		   variables_str += '    %s:%s = %s;\n' % (variable, data_type, data_def)

	variables_str = variables_str.strip(' \t\n\t')

	row_data_table_code_str = __row_code % (row_table_name, variables_str)

	# 组合列表代码字符串
	group_data_table_code_str = __group_code % (group_table_name, row_table_name)

	# 写入文件
	fbs_file_path = os.path.join(fbs_root_path, group_table_name + '.fbs')
	print('生成: ', fbs_file_path)
	write_str = row_data_table_code_str + '\n' + group_data_table_code_str
	with open(fbs_file_path, 'w') as f:
		f.write(write_str)


#csv格式
def __export_all_csv_to_fbs():
	__fileList_keysIndex = {}
	for root, dirs, files in os.walk(excel_root_path, topdown=True):
		for name in files:
			file_path = os.path.join(root, name)
			if file_path.endswith(__csv_extension) and not name.startswith('~'):
				filename = name.split('.')
				print(filename[0],"开始生成fbs")
				__export_csv_to_fbs(file_path,filename[0])

def __export_csv_to_fbs(excel_path,name):
	with open(excel_path, 'r',encoding='utf-8') as f:
		reader = csv.reader(f)
		header_row = csv.reader(f)
		__read_csv_to_fbs(reader,name,excel_path)


def __read_csv_to_fbs(sheet,fileName,path):
	variable_dict = {}
	variable_defaultValue_dict = {}
	sheet_name = fileName
	row_table_name = sheet_name + 'RowData'
	group_table_name = sheet_name;
	result = list(sheet)

	targetRow = result[1]#客户端 服务器
	nameRow = result[3]#name
	typeRow = result[2]#类型默认值
	data_col_count = len(nameRow)#列数
	fristKeyName = nameRow[0]
	if fristKeyName.lower() == "id":
		__fileList_keysIndex[sheet_name] = 1
	else:
		__fileList_keysIndex[sheet_name] = 0

	for i in range(data_col_count):
		if targetRow[i] != "Both" and targetRow[i] != target :
			continue

		name_data = nameRow[i]
		type_data = typeRow[i].split(':')
		variable_name = name_data[0].upper() + name_data[1:]
		row_type_data = type_data[0]
		if variable_name in variable_dict:
			print('')
			print('路径: ', path)
			print('存在相同的字段名: ', variable_name)
			print('异常退出')
			sys.exit(1)

		if not row_type_data in __support_datatypes:
			print('')
			print('路径: ', path)
			print('字段', variable_name, '的数据类型', row_type_data,'不在支持的列表中')
			print('异常退出')
			sys.exit(1)
		variable_dict[variable_name] = row_type_data
		
		typeLen = len(type_data)
		if typeLen == 2:
		   variable_defaultValue_dict[variable_name] = type_data[1]
		   print(variable_name,"此处有默认值")
		else:
		   variable_defaultValue_dict[variable_name] = "NULL"
	# 组合变量定义代码字符串
	variables_str = ''
	for variable in variable_dict:
		if variable_defaultValue_dict[variable] == "NULL":
		   data_type = variable_dict[variable]
		   variables_str += '    %s:%s;\n' % (variable, data_type)
		else:
		   data_type = variable_dict[variable]
		   data_def = variable_defaultValue_dict[variable]
		   variables_str += '    %s:%s = %s;\n' % (variable, data_type, data_def)

	variables_str = variables_str.strip(' \t\n\t')

	row_data_table_code_str = __row_code % (row_table_name, variables_str)

	# 组合列表代码字符串
	group_data_table_code_str = __group_code % (group_table_name, row_table_name)

	# 写入文件
	fbs_file_path = os.path.join(fbs_root_path, group_table_name + '.fbs')
	print('生成: ', fbs_file_path)
	write_str = row_data_table_code_str + '\n' + group_data_table_code_str
	with open(fbs_file_path, 'w') as f:
		f.write(write_str)

def __get_all_fbs_file(root_path):
	file_list = []
	for root, dirs, files in os.walk(root_path):
		for file in files:
			file_path = os.path.join(root, file)
			file_list.append(file_path)
	return file_list


def __generate_target_file(fbs_file, target_path, language_sign):
	filename = os.path.basename(fbs_file)
	filename = filename.split('.')[0]
	keysIndex = __fileList_keysIndex[filename]
	if keysIndex == 1:
		command = '{} --{} -o {} {}    --gen-onefile'.format(flatc_path, language_sign, target_path, fbs_file)
	else:
		command = '{} --{} -o {} {}    --gen-onefile'.format(flatc_path, language_sign, target_path, fbs_file)
		#command = '{} --{} -o {} {} --gen-onefile --nogenkeysindex'.format(flatc_path, language_sign, target_path, fbs_file)
	os.system(command)


def __generate_target(target_path, language_sign):
	print('生成 {} 代码'.format(language_sign))
	fbs_path_list = __get_all_fbs_file(fbs_root_path)
	for file_path in fbs_path_list:
		__generate_target_file(file_path, target_path, language_sign)


def __clean():
	__clean_directory(fbs_root_path)
	__clean_directory(bytes_root_path)
	__clean_directory(python_root_path)
	__clean_directory(java_root_path)
	__clean_directory(csharp_root_path)
	#__clean_directory(go_root_path)
	#__clean_directory(rust_root_path)
	# __clean_directory(lua_root_path)


# 本工具的根目录
# work_root = os.getcwd()
work_root = os.path.dirname(os.path.abspath(__file__))

# flatc.exe所在目录
# flatc_path = os.path.join(work_root, 'flatc/flatc.exe')
flatc_path ="flatc"

# 存放excel的目录
excel_root_path = os.path.join(work_root, 'excel')

# 存放excel生成的flatbuffers二进制文件的目录
bytes_root_path = os.path.join(work_root, 'generated_bytes')

# 生成的 fbs 文件的目录
fbs_root_path = os.path.join(work_root, 'generated_fbs')

# fbs 生成的 python 代码目录
python_root_path = os.path.join(work_root, 'generated_python')

# fbs 生成的 java 代码目录
java_root_path = os.path.join(work_root, 'generated_java')

# fbs 生成的 c# 代码目录
csharp_root_path = os.path.join(work_root, 'generated_csharp')

# fbs 生成的 go 代码目录
go_root_path = os.path.join(work_root, 'generated_go')

# fbs 生成的 rust 代码目录
rust_root_path = os.path.join(work_root, 'generated_rust')

# fbs 生成的 lua 代码目录
lua_root_path = os.path.join(work_root, 'generated_lua')


def run(argv):
	print('---------------- 清理旧文件 ----------------')
	__clean()

	print('---------------- 生成fbs文件, 生成不同语言代码 ----------------')
	__export_all_excel_to_fbs()
	__export_all_csv_to_fbs()
	__generate_target(python_root_path, 'python')	# 生成Python代码是必须的，因为要用来打包数据
	__generate_target(java_root_path, 'java')
	__generate_target(csharp_root_path, 'csharp')
	#__generate_target(go_root_path, 'go')
	#__generate_target(rust_root_path, 'rust')
	# __generate_target(lua_root_path, 'lua')
	# 还可以自己扩展，生成指定语言的代码
	#../Assets/Config/fbs/