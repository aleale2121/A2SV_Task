MigratePersistence:
	dotnet ef migrations add InitialCreate --project BLOGAPP.Persistence -c BLOGAPPDbContext --startup-project BLOGAPP.Api

MigrateIdentity:
	dotnet ef migrations add InitialCreate --project BLOGAPP.Identity/ -c BLOGAPPIdentityDbContext --startup-project BLOGAPP.Api

MigrateUpdatePersistence:
	dotnet ef database update --project BLOGAPP.Persistence/ -c BLOGAPPDbContext --startup-project BLOGAPP.Api
	
MigrateUpdateIdentity:
	dotnet ef database update --project BLOGAPP.Identity/ -c BLOGAPPIdentityDbContext --startup-project BLOGAPP.Api