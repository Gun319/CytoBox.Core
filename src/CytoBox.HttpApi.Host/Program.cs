using CytoBox.HttpApi.Host.ServiceRegister;


var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

WebApplication.CreateBuilder(args)
    .RegisterService(config)
    .Build()
    .RegisterMiddleware(config)
    .Run();