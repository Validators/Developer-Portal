# Developer-Portal
Run your own Developer portal with HMAC API-Keys, user registration, and usage analytics.

Open the project in Visual Studio 2017 or later to compile the project. Or use the command line (dotnet CLI) with the following command:

`dotnet publish Validators.IO.Developers\\Validators.IO.Developers.csproj -c release -o c:\\YourFolder /p:EnvironmentName=Production`


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
		"PolkadotMainnetUrl": "http://polkadot.mainnet.validators.io:9933",
		"PolkadotTestnetUrl": "http://polkadot.testnet.validators.io:9933"
	}

}
```
You only need to change the PolkadotMainnetUrl and PolkadotTestnetUrl setting to match your own domain or IP.

##

*This software is release as open source under the Apache license version 2.0. Use at own risk.*