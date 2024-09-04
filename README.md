# analyzers-demo
Supporting materials for a talk

## Prerequisity
* Download NET 9 RC1 from https://github.com/dotnet/sdk/blob/main/documentation/package-table.md
* Either install it globaly, or unpack to local path that will then be used in 'UseCustomSdk.ps1' scripts

## Notes
Custom MSBuild BuildCheck is not yet that straightforward to make workable - you need exact matching version of referenced template package and hosting build process loading the check.