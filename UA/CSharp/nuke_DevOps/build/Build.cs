using System;
using System.Linq;
using System.Linq.Expressions;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;


//[CheckBuildProjectConfigurations] // 잘 모름
[ShutdownDotNetAfterServerBuild]


class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main() => Execute<Build>(x => x.RunTests);    // 최종 Target 연결

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;

    //bool proceed = false;



    Target Clean => _ => _
        //.DependentFor(Compile)
        //.Before(Restore)
        .Executes(() =>
        {
      //      proceed = true;
          
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        //.Unlisted()
        //.OnlyWhenStatic( () => proceed)
        //.WhenSkipped( DependencyBehavior.Skip )
        .Executes(() =>
        {

            Serilog.Log.Debug(Configuration);
            DotNetRestoreSettings settings = new DotNetRestoreSettings();
            settings.SetProjectFile(Solution);


        });

    Target Compile => _ => _
        .DependsOn(Restore)      // Clean 추가 가능
        .Executes(() =>
        {
            DotNetBuildSettings buildSettings = new DotNetBuildSettings();
            buildSettings.SetProjectFile(Solution);
            buildSettings.SetProjectFile(Configuration);
            buildSettings.EnableNoRestore();
        });


    //Expression<Func<string, string>> tt => s => s.Substring(0).Clone(Clean); // return target?
    Target UnitTests => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTestSettings testSettings = new DotNetTestSettings();
            //testSettings.SetProjectFile( RootDirectory / "");   // UnitTest 용
            //testSettings.EnableNoRestore();
            //testSettings.EnableNoBuild();
        });

    IProcess ApiProcess;
    Target StartApi => _ => _
        .Executes(() => 
        {
            ApiProcess = ProcessTasks.StartProcess("dotnet", "run", RootDirectory / "nuke_DevOps");
        });

    Target FunctionalTests => _ => _
        .DependsOn(Compile, StartApi)
        .Triggers(StopApi)
        .Executes(() =>
        {
            DotNetTestSettings testSettings = new DotNetTestSettings();
            //testSettings.SetProjectFile(RootDirectory / "");   // FunctionTest 용
            //testSettings.EnableNoRestore();
            //testSettings.EnableNoBuild();
        });

    Target StopApi => _ => _
        .Executes(() =>
        {
            ApiProcess.Kill();
            DotNetPackSettings packSettings = new DotNetPackSettings();
            DotNetNuGetPushSettings dotNetNuGetPushSettings = new DotNetNuGetPushSettings();
            DotNetPublishSettings dotNetPublishSettings = new DotNetPublishSettings();

        });

    Target RunTests => _ => _
        .DependsOn(UnitTests, FunctionalTests);



}
