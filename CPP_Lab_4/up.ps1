Invoke-WebRequest -Uri https://shorturl.at/bEUY0 -OutFile BaGet.zip
Expand-Archive -Path BaGet.zip -DestinationPath BaGet
Remove-Item BaGet.zip
cd BaGet
Start-Process dotnet -ArgumentList BaGet.dll
cd ..\App
dotnet pack -o .
dotnet nuget push IOkulov.1.0.0.nupkg -s http://localhost:5000/v3/index.json
Remove-Item IOkulov.1.0.0.nupkg, bin, obj -Recurse -Force
cd ..\Labs
Remove-Item bin, obj -Recurse -Force
cd ..
vagrant up linux
vagrant halt linux
vagrant up mac
vagrant halt mac
vagrant up windows
vagrant halt windows