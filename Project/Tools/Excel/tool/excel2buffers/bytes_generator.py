# -*- coding:utf8 -*-
import xlrd
from datetime import date, datetime
import sys
import os
import json
import numpy as np
import csv
import re

def __get_assign_code(mod_name, field_name, field_value, field_type, index):
	if field_type == 'string' or field_type == '[byte]' or field_type == '[int32]' or field_type == '[int64]' or field_type == '[float]' or field_type == '[string]':
		#print("888888888",field_name)
		value_code = """{}{}""".format(field_name, index)
	else:
		value_code = field_value
	code = """{ModName}.{ModName}Add{FieldName}(builder, {ValueCode})""".format(
				ModName = mod_name, FieldName = field_name, ValueCode = value_code)
	#print(code)
	return code


def __get_single_data_code(mod_name, row_data, index):
	code = \
"""
{VariableCreate}
{ModName}.{ModName}Start(builder)
{AssignCode}
single_data{Index} = {ModName}.{ModName}End(builder)
"""
	
	variable_create_code = ''
	for field in row_data:
		if field['field_type'] == 'string':
			if field['field_value'] != None:
				variable_create_code += """{}{} = builder.CreateString('''{}''')""".format(field['field_name'], index, field['field_value'])
				variable_create_code += '\n'
		elif field['field_type'] == '[byte]':
			if field['field_value'] != None:
				valueArrs = field['field_value'].rstrip(';').split(';');
				valueArrsLen = len(valueArrs)
				variable_create_code += "{ModName}.{ModName}Start{FieldName}Vector(builder, {ValueLen})".format(
				    ModName = mod_name, FieldName = field['field_name'], ValueLen = valueArrsLen)
				variable_create_code += '\n'
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = __get_real_value('byte', valueArrs[curIndex])
				    variable_create_code += """builder.PrependByte({})""".format(fieldvalue)
				    variable_create_code += '\n'
				variable_create_code += """{}{} = builder.EndVector({})""".format(field['field_name'], index, valueArrsLen)
				variable_create_code += '\n'
		elif field['field_type'] == '[int16]':
			if field['field_value'] != None:
				valueArrs = field['field_value'].rstrip(';').split(';');
				valueArrsLen = len(valueArrs)
				variable_create_code += "{ModName}.{ModName}Start{FieldName}Vector(builder, {ValueLen})".format(
				    ModName = mod_name, FieldName = field['field_name'], ValueLen = valueArrsLen)
				variable_create_code += '\n'
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = __get_real_value('int16', valueArrs[curIndex])
				    variable_create_code += """builder.PrependInt16({})""".format(fieldvalue)
				    variable_create_code += '\n'
				variable_create_code += """{}{} = builder.EndVector({})""".format(field['field_name'], index, valueArrsLen)
				variable_create_code += '\n'
		elif field['field_type'] == '[uint16]':
			if field['field_value'] != None:
				valueArrs = field['field_value'].rstrip(';').split(';');
				valueArrsLen = len(valueArrs)
				variable_create_code += "{ModName}.{ModName}Start{FieldName}Vector(builder, {ValueLen})".format(
				    ModName = mod_name, FieldName = field['field_name'], ValueLen = valueArrsLen)
				variable_create_code += '\n'
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = __get_real_value('uint16', valueArrs[curIndex])
				    variable_create_code += """builder.PrependUint16({})""".format(fieldvalue)
				    variable_create_code += '\n'
				variable_create_code += """{}{} = builder.EndVector({})""".format(field['field_name'], index, valueArrsLen)
				variable_create_code += '\n'
		elif field['field_type'] == '[int32]':
			if field['field_value'] != None:
				valueArrs = field['field_value'].rstrip(';').split(';');
				valueArrsLen = len(valueArrs)
				variable_create_code += "{ModName}.{ModName}Start{FieldName}Vector(builder, {ValueLen})".format(
				    ModName = mod_name, FieldName = field['field_name'], ValueLen = valueArrsLen)
				variable_create_code += '\n'
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = __get_real_value('int32', valueArrs[curIndex])
				    variable_create_code += """builder.PrependInt32({})""".format(fieldvalue)
				    variable_create_code += '\n'
				variable_create_code += """{}{} = builder.EndVector({})""".format(field['field_name'], index, valueArrsLen)
				variable_create_code += '\n'
		elif field['field_type'] == '[uint32]':
			if field['field_value'] != None:
				valueArrs = field['field_value'].rstrip(';').split(';');
				valueArrsLen = len(valueArrs)
				variable_create_code += "{ModName}.{ModName}Start{FieldName}Vector(builder, {ValueLen})".format(
				    ModName = mod_name, FieldName = field['field_name'], ValueLen = valueArrsLen)
				variable_create_code += '\n'
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = __get_real_value('uint32', valueArrs[curIndex])
				    variable_create_code += """builder.PrependUint32({})""".format(fieldvalue)
				    variable_create_code += '\n'
				variable_create_code += """{}{} = builder.EndVector({})""".format(field['field_name'], index, valueArrsLen)
				variable_create_code += '\n'
		elif field['field_type'] == '[int64]':
			if field['field_value'] != None:
				valueArrs = field['field_value'].rstrip(';').split(';');
				valueArrsLen = len(valueArrs)
				variable_create_code += "{ModName}.{ModName}Start{FieldName}Vector(builder, {ValueLen})".format(
				    ModName = mod_name, FieldName = field['field_name'], ValueLen = valueArrsLen)
				variable_create_code += '\n'
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = __get_real_value('int64', valueArrs[curIndex])
				    variable_create_code += """builder.PrependInt64({})""".format(fieldvalue)
				    variable_create_code += '\n'
				variable_create_code += """{}{} = builder.EndVector({})""".format(field['field_name'], index, valueArrsLen)
				variable_create_code += '\n'
		elif field['field_type'] == '[uint64]':
			if field['field_value'] != None:
				valueArrs = field['field_value'].rstrip(';').split(';');
				valueArrsLen = len(valueArrs)
				variable_create_code += "{ModName}.{ModName}Start{FieldName}Vector(builder, {ValueLen})".format(
				    ModName = mod_name, FieldName = field['field_name'], ValueLen = valueArrsLen)
				variable_create_code += '\n'
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = __get_real_value('uint64', valueArrs[curIndex])
				    variable_create_code += """builder.PrependUint64({})""".format(fieldvalue)
				    variable_create_code += '\n'
				variable_create_code += """{}{} = builder.EndVector({})""".format(field['field_name'], index, valueArrsLen)
				variable_create_code += '\n'
		elif field['field_type'] == '[float]':
			if field['field_value'] != None:
				valueArrs = field['field_value'].rstrip(';').split(';');
				valueArrsLen = len(valueArrs)
				variable_create_code += "{ModName}.{ModName}Start{FieldName}Vector(builder, {ValueLen})".format(
				    ModName = mod_name, FieldName = field['field_name'], ValueLen = valueArrsLen)
				variable_create_code += '\n'
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = __get_real_value('float', valueArrs[curIndex])
				    variable_create_code += """builder.PrependFloat32({})""".format(fieldvalue)
				    variable_create_code += '\n'
				variable_create_code += """{}{} = builder.EndVector({})""".format(field['field_name'], index, valueArrsLen)
				variable_create_code += '\n'
		elif field['field_type'] == '[string]':
			if field['field_value'] != None:
				valueArrs = field['field_value'].rstrip(';').split(';');
				valueArrsLen = len(valueArrs)
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = valueArrs[curIndex]
				    variable_create_code += """{}Str{} = builder.CreateString('''{}''')""".format(field['field_name'], curIndex,fieldvalue)
				    variable_create_code += '\n'
				variable_create_code += "{ModName}.{ModName}Start{FieldName}Vector(builder, {ValueLen})".format(
				    ModName = mod_name, FieldName = field['field_name'], ValueLen = valueArrsLen)
				variable_create_code += '\n'
				for curIndex in range(valueArrsLen-1,-1,-1):
				    fieldvalue = valueArrs[curIndex]
				    variable_create_code += """builder.PrependUOffsetTRelative({}Str{})""".format(field['field_name'], curIndex)
				    variable_create_code += '\n'
				variable_create_code += """{}{} = builder.EndVector({})""".format(field['field_name'], index, valueArrsLen)
				variable_create_code += '\n'
	assign_code = ''
	for field in row_data:
		if field['field_def'] == "NULL" and field['field_value'] != None:
		   #print("888888",field['field_value'])
		   assign_code += __get_assign_code(
											mod_name, 
											field['field_name'],
											field['field_value'],
											field['field_type'],
											index
										)
		   assign_code += '\n'
		#else:
		   #print("跳过不用序列化到二进制文件因为有默认值或为空",field['field_name'],field['field_value'])

	assign_code = assign_code[:-1]
	code = code.format(VariableCreate = variable_create_code, ModName = mod_name, AssignCode = assign_code, Index = index)
	return code


def __get_list_data_code(mod_name, single_mod_name, list_data):
	row_count = len(list_data)
	all_assign_code = ''
	index = 0
	for row_data in list_data:
		all_assign_code += __get_single_data_code(single_mod_name, row_data, index)
		index += 1
		all_assign_code += '\n'

	offset_code = ''
	for index in range(0, row_count):
		data_name = "single_data{}".format(index)
		offset_code += "builder.PrependUOffsetTRelative({})".format(data_name)
		offset_code += '\n'

	code = \
"""
import generated_python.{SingleModName} as {SingleModName}
import generated_python.{ModName} as {ModName}
import flatbuffers

builder = flatbuffers.Builder(1)

{AllAssignCode}
{ModName}.{ModName}StartDatalistVector(builder, {DataCount})
{OffsetCode}
data_array = builder.EndVector({DataCount})

{ModName}.{ModName}Start(builder)
{ModName}.{ModName}AddDatalist(builder, data_array)
final_data = {ModName}.{ModName}End(builder)
builder.Finish(final_data)
buf = builder.Output()
""".format(
		SingleModName = single_mod_name,
		ModName = mod_name,
		AllAssignCode = all_assign_code,
		DataCount = row_count,
		OffsetCode = offset_code
	)
	
	return code


def __generate_bytes(mod_name, single_mod_name, bytes_file_root_path, excel_row_list):
	list_code = __get_list_data_code(mod_name, single_mod_name, excel_row_list)
	byte_file_path = os.path.join(bytes_file_root_path, "{}.bytes".format(mod_name))
	byte_file_path = byte_file_path.replace('\\', '/')
	code = """
{ListCode}

with open('{ByteFilePath}', 'wb') as f:
	f.write(buf)
""".format(ListCode = list_code, ByteFilePath = byte_file_path)
	exec(code)
	print('生成: ', byte_file_path)


# Bytes 生成代码

# bytes_root_path = os.path.join(os.getcwd(), 'generated_bytes')
# mod_name = 'TShowMusicsConfig'
# single_mod_name = 'TShowMusicsConfigRowData'

# __generate_bytes(mod_name, single_mod_name, bytes_root_path, excel_row_list)


# ================================== Excel 数据读取 ==================================

def _remove_point(string_value):
	if string_value[-2:] == '.0' :
		return string_value.replace('.0','')
	else:
		return string_value

def __get_real_value(data_type, raw_value):
	# print('data_type: ', data_type, 'raw_value:', raw_value)
	if data_type == 'string':
		if not raw_value :
		   return None
		else:
		   #print("string",raw_value)
		   #j = raw_value.split('\n')
		   #for t in j:
		   #    print("11111111换行字符串",t)
		   #value = value.replace('\n', '\\')
		   value = str(raw_value)
		   value = value.replace('\\', '\\\\')
		   value = _remove_point(value)
		   return '''{}'''.format(value)
	elif data_type == 'byte':
		if not raw_value :
		   return None
		else:
		   #print("byte",raw_value)
		   #return bytes(raw_value)
		   return np.int8(raw_value)
	elif data_type == 'int16':
		if not raw_value :
		   return None
		else:
		   raw_value = _remove_point(raw_value)
		   return np.int16(raw_value)
	elif data_type == 'uint16':
		if not raw_value :
		   return None
		else:
		   raw_value = _remove_point(raw_value)
		   return np.uint16(raw_value)
	elif data_type == 'int32':
		if not raw_value :
		   return None
		else:
		   raw_value = _remove_point(raw_value)
		   return np.int32(raw_value)
	elif data_type == 'uint32':
		if not raw_value :
		   return None
		else:
		   raw_value = _remove_point(raw_value)
		   return np.uint32(raw_value)
	elif data_type == 'int64':
		if not raw_value :
		   return None
		else:
		   raw_value = _remove_point(raw_value)
		   return np.int64(raw_value)
	elif data_type == 'uint64':
		if not raw_value :
		   return None
		else:
		   raw_value = _remove_point(raw_value)
		   return np.uint64(raw_value)
	elif data_type == 'float':
		if not raw_value :
		   return None
		else:
		   return float(raw_value)
	elif data_type == '[int16]':
		if not raw_value :
		   return None
		else:
		   return str(raw_value)
	elif data_type == '[uint16]':
		if not raw_value :
		   return None
		else:
		   return str(raw_value)
	elif data_type == '[int32]':
		if not raw_value :
		   return None
		else:
		   return str(raw_value)
	elif data_type == '[uint32]':
		if not raw_value :
		   return None
		else:
		   return str(raw_value)
	elif data_type == '[int64]':
		if not raw_value :
		   return None
		else:
		   return str(raw_value)
	elif data_type == '[uint64]':
		if not raw_value :
		   return None
		else:
		   return str(raw_value)
	elif data_type == '[byte]':
		if not raw_value :
		   return None
		else:
		   return str(raw_value)
	elif data_type == '[float]':
		if not raw_value :
		   return None
		else:
		  return str(raw_value)
	elif data_type == '[string]':
		if not raw_value :
		   return None
		else:
		   return str(raw_value)
	else:
		return None


def __read_excel_sheet(sheet,sheet_name):
	variable_dict = {}
	index_dict = {}
	variable_defaultValue_dict = {}
	mod_name = sheet_name
	single_mod_name = mod_name + 'RowData'
	# row_table_name = sheet_name + 'RowData'
	# group_table_name = sheet_name;
	data_col_count = sheet.ncols#列数
	for col_num in range(0, data_col_count):
		name_data = sheet.cell_value(3, col_num)
		type_data = sheet.cell_value(2, col_num).split(':')
		target_data = sheet.cell_value(1,col_num)

		if type_data == "" or name_data == "":
			continue

		variable_name = name_data[0].upper() + name_data[1:]
		row_type_data = type_data[0]
		if variable_name in variable_dict:
			print('存在相同的字段名: ', variable_name)
			print('异常退出')
			sys.exit()

		if not row_type_data in __support_datatypes:
			print('字段', variable_name, '的数据类型', row_type_data,'不在支持的列表中')
			print('异常退出')
			sys.exit()
		variable_dict[variable_name] = row_type_data
		index_dict[variable_name] = col_num
		
		typeLen = len(type_data)
		if typeLen == 2:
		   variable_defaultValue_dict[variable_name] = type_data[1]
		   print(variable_name,"此处有默认值")
		else:
		   variable_defaultValue_dict[variable_name] = "NULL"

	data_row_count = sheet.nrows

	sheet_row_data_list = []
	#for x in range(1, data_row_count):
	for x in range(data_row_count-1, 3,-1):
		row_data = sheet.row(x)
		# 存储每一个字段的字段名，数值，类型
		single_row_data = []
		

		for variable_name in variable_dict:
			variable_type = variable_dict[variable_name]
			rowIndex = index_dict[variable_name]
			#print(variable_name, variable_type, row_data[rowIndex].value)
			variable_value = __get_real_value(variable_type, str(row_data[rowIndex].value))
			variable_def_calue = variable_defaultValue_dict[variable_name]
			if variable_def_calue == "NULL":
			   variable_def_calue = variable_defaultValue_dict[variable_name]
			else:
			   variable_def_calue = __get_real_value(variable_type, variable_def_calue)
			   if variable_def_calue != variable_value:
			      variable_def_calue = "NULL"
			# print(variable_name, variable_type, variable_value)

			data_dict = {
				'field_name': variable_name,
				'field_value': variable_value,
				'field_type': variable_type,
				'field_def': variable_def_calue
			}
			single_row_data.append(data_dict)
		sheet_row_data_list.append(single_row_data)
	__generate_bytes(mod_name, single_mod_name, bytes_root_path, sheet_row_data_list)


def __generate_excel_data(excel_path, file):
	fieldName = file.split(".")[0]
	wb = xlrd.open_workbook(excel_path)
	sheet1 = wb.sheet_by_index(0)
	__read_excel_sheet(sheet1,fieldName)


def __generate_all_excel_byte_data():
	for root, dirs, files in os.walk(excel_root_path):
		for file in files:
			print(">>>>>> file",file)
			excel_file_path = os.path.join(root, file)
			if excel_file_path.endswith(__excel_extension) and not file.startswith('~'):
				__generate_excel_data(excel_file_path,file)


def __read_csv_sheet(sheet,fileName):
	variable_dict = {}
	variable_defaultValue_dict = {}
	variable_index_dict = {}
	sheet_name = fileName
	mod_name = sheet_name
	single_mod_name = mod_name + 'RowData'
	print("文件名",fileName)
	result = list(sheet)
	nameRow = result[3]#第一行
	typeRow = result[2]#第二行
	targetRow = result[1]#第三行
	data_col_count = len(nameRow)#列数
	for i in range(data_col_count):
		if targetRow[i] != "Both" and targetRow[i] != target:
			continue

		name_data = nameRow[i]
		type_data = typeRow[i].split(':')
		variable_name = name_data[0].upper() + name_data[1:]
		row_type_data = type_data[0]
		if variable_name in variable_dict:
			print('存在相同的字段名: ', variable_name)
			print('异常退出')
			sys.exit()

		if not row_type_data in __support_datatypes:
			print('字段', variable_name, '的数据类型', row_type_data,'不在支持的列表中')
			print('异常退出')
			sys.exit()
		variable_dict[variable_name] = row_type_data
		variable_index_dict[variable_name] = i
		
		typeLen = len(type_data)
		if typeLen == 2:
		   variable_defaultValue_dict[variable_name] = type_data[1]
		   print(variable_name,"此处有默认值")
		else:
		   variable_defaultValue_dict[variable_name] = "NULL"
	data_row_count = len(result)#行数
	print("列数和行数",data_col_count,data_row_count)
	sheet_row_data_list = []
	#for x in range(1, data_row_count):
	for x in range(data_row_count-1, 4,-1):
		row_data = result[x]
		# 存储每一个字段的字段名，数值，类型
		single_row_data = []
		
	
		for variable_name in variable_dict:
			index = variable_index_dict[variable_name]
			variable_type = variable_dict[variable_name]
			#print("字段",variable_name, variable_type, row_data[index])
			variable_value = __get_real_value(variable_type, row_data[index])
			variable_def_calue = variable_defaultValue_dict[variable_name]
			if variable_def_calue == "NULL":
			   variable_def_calue = variable_defaultValue_dict[variable_name]
			else:
			   variable_def_calue = __get_real_value(variable_type, variable_def_calue)
			   if variable_def_calue != variable_value:
			      variable_def_calue = "NULL"
			# print(variable_name, variable_type, variable_value)
	
			data_dict = {
				'field_name': variable_name,
				'field_value': variable_value,
				'field_type': variable_type,
				'field_def': variable_def_calue
			}
			single_row_data.append(data_dict)
		sheet_row_data_list.append(single_row_data)
	__generate_bytes(mod_name, single_mod_name, bytes_root_path, sheet_row_data_list)

def __generate_csv_data(excel_path,fileName):
	with open(excel_path, 'r',encoding='utf-8') as f:
		reader = csv.reader(f)
		header_row = csv.reader(f)
		__read_csv_sheet(reader,fileName)


def __generate_all_csv_byte_data():
	for root, dirs, files in os.walk(excel_root_path):
		for file in files:
			excel_file_path = os.path.join(root, file)
			if excel_file_path.endswith(__csv_extension) and not file.startswith('~'):
				filename = file.split('.')
				__generate_csv_data(excel_file_path,filename[0])

# excel_path = './excel/TestExcel.xlsx'
# __generate_excel_data(excel_path)


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

work_root = os.path.dirname(os.path.abspath(__file__))
bytes_root_path = os.path.join(work_root, 'generated_bytes')
excel_root_path = os.path.join(work_root, 'excel')

def run(argv):
	print('---------------- 将excel生成flatbuffers二进制数据 ----------------')
	__generate_all_excel_byte_data()
	__generate_all_csv_byte_data()