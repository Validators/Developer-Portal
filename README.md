# Developer-Portal
Run your own Developer portal with HMAC API-Keys, user registration, and usage analytics.

Open the project in Visual Studio 2017 or later to compile the project. Or use the command line (dotnet CLI) with the following command:

`dotnet publish Validators.IO.Developers\\Validators.IO.Developers.csproj -c release -o c:\\YourFolder /p:EnvironmentName=Production`


## User registration

The project uses the standard .net MVC IdentityUser as its basis for user management and registration. The basic functionality is scaffolded in the **Areas** folder.

## Configuration
There are one configuration file called appsettings.Production.json that contain the following:

```{
	"Logging": {
		"LogLevel": {
			"Default": "Error"
		}
	},
	"AllowedHosts": "*",
	"ConnectionStrings": {
		"AppDbContextConnection": "DataSource=database.db" 
	},
	"AppSettings": {
		"PolkadotMainnetUrl": "https://polkadot.nnode.io",
		"PolkadotTestnetUrl": "https://polkadot.testnet.nnode.io"
	}

}
```
You only need to change the PolkadotMainnetUrl and PolkadotTestnetUrl setting to match your own domain or IP.

##

Please notice that this solution does not contain any API endpoints to log requests for analytics purposes. This can be setup in different ways and therefor left as an exercise for the developer.
##

*This software is release as open source under the Apache license version 2.0. Use at own risk.*