# dotnet-utilities
A collection of handy utilities.


* Config Services

    When injected via an IOC container, IConfigSerice implemented services provide a means to get web.config or app.config configuration values. IConfigService can also be mocked out for testing when injected to other classes. Two implementations of this interface are provided, the first, ApplicationConfigService takes values from web.config or app.config for the running assmebly. The second CloudConfigService is a wrapper around [Microsoft Azure Configuration Manager](https://www.nuget.org/packages/Microsoft.WindowsAzure.ConfigurationManager/3.2.3) which takes configurations from a variety of places whether hosted in the cloud or on-premises, more infromation on this can be found on their site.
