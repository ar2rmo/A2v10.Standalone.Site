@echo off

if "%1"=="-p" (
	set src=%2
	goto :srcset
)

if "%1"=="-f" (
	if not exist "%2" (
		echo File "%2" does not exists!
		goto :fail
	)
	set /p src=<"%2"
	goto :srcset
)

if defined A2V10VUE_ASSEMBLIES_SOURCE (
	set src=%A2V10VUE_ASSEMBLIES_SOURCE%
	goto :srcset
)

if exist .\A2V10VUE_ASSEMBLIES_SOURCE.txt (
	set /p src=<.\A2V10VUE_ASSEMBLIES_SOURCE.txt
	goto :srcset
)


echo The path to source is not defined!

:fail

exit /B 1

:srcset

if not exist %src%\A2v10\A2v10.sln (
	echo There is no solution at "%src%\"
	goto :fail
)
if not exist %src%\A2v10.Data\A2v10.Data.sln (
	echo There is no solution at "%src%\"
	goto :fail
)

echo COPYING FROM "%src%\"

echo on

copy %src%\A2v10.Data\A2v10.Data\bin\Debug\A2v10.Data.dll .\debug\A2v10.Data.dll
copy %src%\A2v10.Data\A2v10.Data\bin\Debug\A2v10.Data.pdb .\debug\A2v10.Data.pdb
copy %src%\A2v10.Data\A2v10.Data\bin\Release\A2v10.Data.dll .\release\A2v10.Data.dll

copy %src%\A2v10.Data\A2v10.Data.Interfaces\bin\Debug\A2v10.Data.Interfaces.dll .\debug\A2v10.Data.Interfaces.dll
copy %src%\A2v10.Data\A2v10.Data.Interfaces\bin\Debug\A2v10.Data.Interfaces.pdb .\debug\A2v10.Data.Interfaces.pdb
copy %src%\A2v10.Data\A2v10.Data.Interfaces\bin\Release\A2v10.Data.Interfaces.dll .\release\A2v10.Data.Interfaces.dll

copy %src%\A2v10\Shared\A2v10.Infrastructure\obj\Debug\A2v10.Infrastructure.dll .\debug\A2v10.Infrastructure.dll
copy %src%\A2v10\Shared\A2v10.Infrastructure\obj\Debug\A2v10.Infrastructure.pdb .\debug\A2v10.Infrastructure.pdb
copy %src%\A2v10\Shared\A2v10.Infrastructure\obj\Release\A2v10.Infrastructure.dll .\release\A2v10.Infrastructure.dll

copy %src%\A2v10\Shared\A2v10.Request\bin\Debug\A2v10.Request.dll .\debug\A2v10.Request.dll
copy %src%\A2v10\Shared\A2v10.Request\bin\Debug\A2v10.Request.pdb .\debug\A2v10.Request.pdb
copy %src%\A2v10\Shared\A2v10.Request\bin\Release\A2v10.Request.dll .\release\A2v10.Request.dll

copy %src%\A2v10\Web\A2v10.Web.Config\bin\Debug\A2v10.Web.Config.dll .\debug\A2v10.Web.Config.dll
copy %src%\A2v10\Web\A2v10.Web.Config\bin\Debug\A2v10.Web.Config.pdb .\debug\A2v10.Web.Config.pdb
copy %src%\A2v10\Web\A2v10.Web.Config\bin\Release\A2v10.Web.Config.dll .\release\A2v10.Web.Config.dll
