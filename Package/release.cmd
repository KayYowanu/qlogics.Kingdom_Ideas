"..\..\KingdomProject\oqtane.package\nuget.exe" pack qlogics.Kingdom_Ideas.nuspec 
XCOPY "*.nupkg" "..\..\KingdomProject\Oqtane.Server\wwwroot\Modules\" /Y
