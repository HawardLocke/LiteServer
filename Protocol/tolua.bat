rem �л���.protoЭ�����ڵ�Ŀ¼
cd  protos
rem ����ǰ�ļ����е�����Э���ļ�ת��Ϊlua�ļ�
for %%i in (*.proto) do (  
echo %%i
"..\protoc.exe" --plugin=protoc-gen-lua="..\protoc-gen-lua\plugin\protoc-gen-lua.bat" --lua_out=..\lua\ %%i

)
echo end
pause