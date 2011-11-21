# Run SWIG
swig -I./leveldb -v -O -c++ -csharp -namespace LevelDBWrapper.Native -dllimport leveldb_managed leveldb.i
# Compile c++ file
gcc -c -fpic -m32 *.cxx -o leveldb_managed.o
# Compile CSharp files with mono
gmcs *.cs -out:LevelDBWrapper.dll -target:library
