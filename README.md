# QuietRss
A an api that displays a list feeds that have had no activity for some time.
This app exists for the sole purpose to prove the nuget package that does the heavy lifting both exists and works. 

The nuget package resides in a personal artifact repo, but the code exists here https://github.com/cachapman/quiet_rss_nuget





## Assumptions
I could have built and attached a docker db with this, but figured that may have been overkill for the ask. 

I could have seperated out the application into multiple layers if this was a full blown app (ideally, using DI to inject my connections), but, trying to be pragmatic in the ask

Authorization is possible (of course, you may know why I didn't put it in!) but left it out as this is a test app - commented out the tags, but if we wanted to put specific scopes on who can do what, that's another enhancement

Logging for now is going to a console - It's an easy lift to move it to a file, but since even the DB is non persistant, I figure the logs should only relate to the running instance as well. 
If we need a persistant db, we can add persistant logs at that time too. 