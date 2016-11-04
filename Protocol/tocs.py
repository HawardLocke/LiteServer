
# protobuff gen csharp

import os
import os.path
import sys
import string
import shutil


def gen_cs(src_path, dst_path):
	abs_src_path = os.path.abspath('.') + src_path
	abs_dst_path = os.path.abspath('.') + dst_path
	if os.path.exists(abs_dst_path):
		shutil.rmtree(abs_dst_path)
	os.mkdir(abs_dst_path)
	for file_name in os.listdir(abs_src_path):
		print('  %s' % file_name)
		os.system('protoc --csharp_out=.%s .%s%s' % (dst_path, src_path, file_name))
	pass
pass


def copy_cs(src_path,  dst_path):
	abs_src_path = os.path.abspath('.') + src_path
	abs_dst_path = os.path.abspath('.') + dst_path
	for file in os.listdir(abs_src_path):
		sourceFile = os.path.join(abs_src_path,  file)
		targetFile = os.path.join(abs_dst_path,  file)
		if os.path.isfile(sourceFile) and sourceFile.find('.cs') > 0:
			open(targetFile, "wb").write(open(sourceFile, "rb").read())
			print('  %s' % file)
	shutil.rmtree(abs_src_path)
pass


src = '/protos/'
gen_tmp = '/auto_gen/cs/'
cpy = '/../LiteServer/LiteServer/Source/Protobuf/'

print('\n-----Begin Gen CS-----')
gen_cs(src, gen_tmp)
print('-----End Gen CS-----')
#print('\n')
#print('-----Begin Copy-----')
#copy_cs(gen_tmp, cpy)
#print('-----End Copy-----\n')
