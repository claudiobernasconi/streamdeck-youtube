rmdir dist /s /q
mkdir dist
dotnet publish -c Release --self-contained
xcopy ".\bin\Release\netcoreapp2.2\win-x64\publish\*.*" ".\dist\ch.claudiobernasconi.youtube.sdPlugin\*.*" /sy
xcopy ".\lib\DistributionTool.exe" ".\dist\" /sy
cd dist
mkdir Release
DistributionTool.exe -b -i ch.claudiobernasconi.youtube.sdPlugin -o Release
del DistributionTool.exe
cd ..
rmdir "dist\ch.claudiobernasconi.youtube.sdPlugin\" /s /q
xcopy ".\dist\Release\*" .\"dist\"
rmdir "dist\Release" /s /q