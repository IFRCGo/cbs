# Infrastructure

## Logging

Collecting logs from an application is very important. All running applications just need to output logs in a specific
JSON format into Stdout / Stderr. The format is described [here](./Logging/LogMessage.cs).
The format holds a correlation Id that the infrastructure will try to deduct from running context. This correlation Id
makes it possible to follow through requests going through the system.

### Serilog

Inside the infrastructure sits a general setup for using Serilog in the context of an ASP.NET Core project.
The [Initialization.cs](./AspNet/Initialization.cs) file contains a setup for this that is reused throughout.
It is setup with our own logging sink that outputs a specific JSON format and is easy for us to index.

```csharp
var loggerConfiguration = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("System", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.JsonConsole(); // our logging sink
```

### .NET Core Console Application

If you want to use it from a regular .NET application and don't need the semantic logging capabilities of Serilog, you can do that as well.
Using the logging in a regular .NET Core Console Application, you need to add a reference to the Logging project and configure
logging by configuring the `LoggerFactory` in the following way.

```csharp
var loggerFactory = new LoggerFactory()
    .AddJson("devicetomqtt",LogLevel.Trace);
```

### ASP.NET Core

If you want to use it from a "vanilla" ASP.NET application and don't need the semantic logging capabilities of Serilog, you can do that as well.
Configuring an ASP.NET application, you add a reference to the Logging project and configure the `WebHostBuilder`in the
following way.

```csharp
var host = new WebHostBuilder()
.ConfigureLogging((webhostContext, builder) =>
{
    builder.AddProvider(new JsonLoggerProvider("<bounded context>", (_, logLevel) => logLevel >= LogLevel.Trace));
})
```

### Fluentd

Inside the Kubernetes cluster we need to collect all logs from all running pods by capturing the Stdout and Stderr of these.
Fluentd runs as a Daemon on each Kubernetes cluster - deploying it can be done by running

```shell
$ kubectl create -f ./deploy/fluentd-security.yml
$ kubectl create -f ./deploy/fluentd-daemons.yml
```

### Logging Infrastructure

The logging infrastructure consists of ElasticSearch as an index for all log messages and Grafana for visualization on top.

To get it running, you need to deploy the following to the cluster:

```shell
$ kubectl create -f ./deploy/logging-volumes-azure.yml
$ kubectl create -f ./deploy/logging-persistent-volumes.yml
$ kubectl create -f ./deploy/logging-services.yml
$ kubectl create -f ./deploy/logging-deployments.yml
```