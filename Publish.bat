set PACKAGE_UUID=ch.claudiobernasconi.youtubestats.sdPlugin
set PLATFORM=net6.0

rmdir dist /s /q
mkdir dist

dotnet build streamdeckyoutube.csproj -c Release -a x64

dotnet publish streamdeckyoutube.csproj -c Release --self-contained
xcopy ".\bin\%PLATFORM%\Release\%PLATFORM%\win-x64\publish\*.*" ".\dist\%PACKAGE_UUID%\*.*" /sy

xcopy ".\lib\DistributionTool.exe" ".\dist\" /sy
cd dist
mkdir Release
DistributionTool.exe -b -i %PACKAGE_UUID% -o Release
del DistributionTool.exe

cd ..
rmdir "dist\%PACKAGE_UUID%\" /s /q
xcopy ".\dist\Release\*" .\"dist\"
rmdir "dist\Release" /s /q
