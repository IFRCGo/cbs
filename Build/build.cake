//////////////////////////////////////////////////////////////////////
// FETCH TOOLS
//////////////////////////////////////////////////////////////////////
#addin "Cake.Npm"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var cleanFolder = Environment.GetEnvironmentVariable("WebBinFolder") ?? "../Source/Example/Catalog/Web/bin";
var buildDir = Directory(cleanFolder) + Directory(configuration);

var slnFile = Environment.GetEnvironmentVariable("SlnFile") ?? "../Source/Example/Catalog/Catalog.sln";
var angularFolder = Environment.GetEnvironmentVariable("AngularFolder") ?? "../Source/Example/Catalog/Web.Angular";
var testsFolder = Environment.GetEnvironmentVariable("TestsFolder") ?? "../Source/Example/Catalog/Tests";


//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore(slnFile);
});

Task("Build-Backend")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    // Use MSBuild
    MSBuild(slnFile, settings =>
    settings.SetConfiguration(configuration));
});

Task("Build-Frontend")
    .IsDependentOn("Clean")
    .Does(() =>
{
    //Install NPM packages
    var npmInstallSettings = new NpmInstallSettings {
      WorkingDirectory = angularFolder,
      LogLevel = NpmLogLevel.Warn,
      ArgumentCustomization = args => args.Append("--no-save")
    };
    NpmInstall(npmInstallSettings);

    //Build Angular frontend project using Angular cli
    var runSettings = new NpmRunScriptSettings {
      ScriptName = "ng",
      WorkingDirectory = angularFolder,
      LogLevel = NpmLogLevel.Warn
    };
    runSettings.Arguments.Add("build");
    runSettings.Arguments.Add("--prod");
    runSettings.Arguments.Add("--build-optimizer");
    runSettings.Arguments.Add("--progress false");
    
    NpmRunScript(runSettings);
});

Task("Run-Backend-Tests")
    .IsDependentOn("Build-Backend")
    .Does(() =>
{
        var projects = GetFiles(testsFolder + "/**/*.csproj");
        foreach(var project in projects)
        {
            Information("Running tests for " + project.FullPath);
            DotNetCoreTest(
                project.FullPath,
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true
                });
        }
});

Task("Run-Frontend-Tests")
    .IsDependentOn("Build-Frontend")
    .Does(() =>
{
    // TODO: Set up Jasmine + Karma + Headless Chrome properly
    Information("Frontend testing framework not yet configured. Skipping this step.");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-Backend-Tests")
    .IsDependentOn("Run-Frontend-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
