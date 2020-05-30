set PACKAGE_UUID=ch.claudiobernasconi.youtubestats.sdPlugin
set PLATFORM=netcoreapp2.2

rmdir dist /s /q
mkdir dist

dotnet publish -c Release --self-contained
xcopy ".\bin\Release\%PLATFORM%\win-x64\publish\*.*" ".\dist\%PACKAGE_UUID%\*.*" /sy

xcopy ".\lib\DistributionTool.exe" ".\dist\" /sy
cd dist
mkdir Release
DistributionTool.exe -b -i %PACKAGE_UUID% -o Release
del DistributionTool.exe

cd ..
rmdir "dist\%PACKAGE_UUID%\" /s /q
xcopy ".\dist\Release\*" .\"dist\"
rmdir "dist\Release" /s /q
