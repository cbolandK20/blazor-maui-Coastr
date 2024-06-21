# CoastR

This is a sample and play Projekt for a MAUI Blazor App.
Its goals are the use of some technical aspects of MAUI and Blazor like:

- Database Use
- Use of Entity Framework Core
- Use of Entity Framework Core Migrations
- Hardware Sensor Access
- Use of System Apps (Maps, Camera, etc.)
- Use of the UI Framework Mudblazor
  
It's work in progress .... BUT I does what it should do.

## Whats it's all about?
Its an Beer Coaster App for Windows, Mac, iOS and Andoid.
I'm testing it an Windows and Android. On Mac / iOS it should work, but I haven't tested ist yet.
I think it's about 70% done, but who knows ;-)


## Project Structure

| Project | Description |
| ----------- | ----------- |
| CoastR | Main Projekt / Application |
| CoastR.Model | Data model of the Application |
| CoastR.Persistence | Database Access |
| CoastR.Persistence.Migrator | Projekt for the Use of EF Core Migrations |

### Why is the structure like this?

At the Moment, EF Migrations aren't well supportet under MAUI. Thatswhy a 'Migrator' Projekt is needed. <br/>
Normally I work on large Applications, with modularity as one design principle and I prefer that design. Thatswhy the other projecte exist - It's in my DNA ;-) 



## EF Core Migration commands (Package Manager Console)

### Create Migration
`add-migration InitialCreate -StartupProject CoastR.Persistence.Migrator -Project CoastR.Persistence -Context CoastR.Persistence.Impl.CoasterDBContext -Verbose`


## 3rd Party Tools / Frameworks
MubBlazor - https://www.mudblazor.com/ <br>
Font Awesome - https://fontawesome.com/ <br>
BlazorAnimation - https://github.com/aboudoux/BlazorAnimation <br>

## Links that helped me
https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/maps?view=net-maui-7.0&tabs=windows#using-the-map <br>
...

Always remember: it's work in progress.


