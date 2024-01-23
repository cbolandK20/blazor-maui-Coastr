# Coastr

This is a sample and play Projekt for a MAUI Blazor App.
Its goals are the use of some technical aspects of MAUI and Blazor like:

- Database Use
- Use of Entity Framework Core
- Use of Entity Framework Core Migrations
- Hardware Sensor Access
- Use of System Apps (Maps, Camera, etc.)
- Use of the UI Framework Mudblazor


## Projekt Structure

| Project | Description |
| ----------- | ----------- |
| CoastR | Main Projekt / Application |
| CoastR.Model | Data model of the Application |
| CoastR.Persistence | Database Access |
| CoastR.Persistence.Migrator | Projekt for the Use of EF Core Migrations |

### Why is the structure like this?

At the Moment, EF Migrations aren't well supportet under MAUI. Thatswhy a 'Migrator' Projekt is needed and well... the rest is a result of this.



## EF Core Migration commands (Package Manager Console)

### Create Migration
`add-migration InitialCreate -StartupProject CoastR.Persistence.Migrator -Project CoastR.Persistence -Context CoastR.Persistence.Impl.CoasterDBContext -Verbose`

### Add Migration

## 3rd Party Tools / Frameworks
https://www.mudblazor.com/

## Links that helped me


https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/maps?view=net-maui-7.0&tabs=windows#using-the-map



