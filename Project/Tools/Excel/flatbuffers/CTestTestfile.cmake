# CMake generated Testfile for 
# Source directory: H:/flatbufferstool/flatbuffers-vs
# Build directory: H:/flatbufferstool/flatbuffers-vs
# 
# This file includes the relevant testing commands required for 
# testing this directory and lists subdirectories to be tested as well.
if("${CTEST_CONFIGURATION_TYPE}" MATCHES "^([Dd][Ee][Bb][Uu][Gg])$")
  add_test(flattests "H:/flatbufferstool/flatbuffers-vs/Debug/flattests.exe")
  set_tests_properties(flattests PROPERTIES  _BACKTRACE_TRIPLES "H:/flatbufferstool/flatbuffers-vs/CMakeLists.txt;644;add_test;H:/flatbufferstool/flatbuffers-vs/CMakeLists.txt;0;")
elseif("${CTEST_CONFIGURATION_TYPE}" MATCHES "^([Rr][Ee][Ll][Ee][Aa][Ss][Ee])$")
  add_test(flattests "H:/flatbufferstool/flatbuffers-vs/Release/flattests.exe")
  set_tests_properties(flattests PROPERTIES  _BACKTRACE_TRIPLES "H:/flatbufferstool/flatbuffers-vs/CMakeLists.txt;644;add_test;H:/flatbufferstool/flatbuffers-vs/CMakeLists.txt;0;")
elseif("${CTEST_CONFIGURATION_TYPE}" MATCHES "^([Mm][Ii][Nn][Ss][Ii][Zz][Ee][Rr][Ee][Ll])$")
  add_test(flattests "H:/flatbufferstool/flatbuffers-vs/MinSizeRel/flattests.exe")
  set_tests_properties(flattests PROPERTIES  _BACKTRACE_TRIPLES "H:/flatbufferstool/flatbuffers-vs/CMakeLists.txt;644;add_test;H:/flatbufferstool/flatbuffers-vs/CMakeLists.txt;0;")
elseif("${CTEST_CONFIGURATION_TYPE}" MATCHES "^([Rr][Ee][Ll][Ww][Ii][Tt][Hh][Dd][Ee][Bb][Ii][Nn][Ff][Oo])$")
  add_test(flattests "H:/flatbufferstool/flatbuffers-vs/RelWithDebInfo/flattests.exe")
  set_tests_properties(flattests PROPERTIES  _BACKTRACE_TRIPLES "H:/flatbufferstool/flatbuffers-vs/CMakeLists.txt;644;add_test;H:/flatbufferstool/flatbuffers-vs/CMakeLists.txt;0;")
else()
  add_test(flattests NOT_AVAILABLE)
endif()
