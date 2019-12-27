# SmarterMail .NET Core 3.1 examples

## Requirements
- [Visual Studio 2019 (v16.4 or later)](https://visualstudio.microsoft.com/vs/)
- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Getting started
- Open [appsettings.json](SmarterMailCodeSamples/appsettings.json) and replace `SmarterMailBaseUrl` with your server's URL.
- Open [AuthenticationController.cs](SmarterMailCodeSamples/Controllers/AuthenticationController.cs) and replace the username and password with your own. This will be used to authenticate against your SmarterMail server.
- Run the application with IIS Express, and you should get JSON output with the authentication result, like `accessToken` etc.
