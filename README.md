# QuietRss
An api that displays a list feeds that have had no activity for some time.

This api exists for the sole purpose to prove the nuget package that does the heavy lifting both exists and works. 

The nuget package resides in a personal artifact repo, but the code exists here https://github.com/cachapman/quiet_rss_nuget

## To Run

```
dotnet build ./quiet_rss.sln -o ./app/publish
cd ./app/publish
dotnet QuietRssApi.dll
```
Docker runs currently through Visual Studio (I had recently reset my main computer, so my Docker <-> WSL 2 isn't quite ironed out).
## Assumptions
Most of my assumptions below are because this particular repo is built to be a throwaway, to show off the nuget package which is the ask. 

 - Could have used DI
 - Could have seperated out layers of responsibility
 - Didn't require authorization (shows use of tags if required)
 - Logging is local to console when used, as the app is non-persistant 