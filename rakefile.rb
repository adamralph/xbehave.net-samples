require 'albacore'

$msbuild_command = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Enterprise/MSBuild/15.0/Bin/MSBuild.exe"
xunit_command = "src/packages/xunit.runner.console.2.1.0/tools/xunit.console.exe"
nuget_command = "src/.nuget/NuGet.exe"
$solution = "src/XBehave.Samples.sln"
logs = "artifacts/logs"

samples = [
  "src/Xbehave.Samples.FSharp.Net45.NCrunch/bin/Release/Xbehave.Samples.FSharp.net45.ncrunch.dll",
  "src/Xbehave.Samples.Net45.MSBuild/bin/Release/Xbehave.Samples.net45.msbuild.dll",
  "src/Xbehave.Samples.Net45.NCrunch/bin/Release/Xbehave.Samples.net45.ncrunch.dll",
]

Albacore.configure do |config|
  config.log_level = :verbose
end

desc "Execute default tasks"
task :default => [:build]

desc "Restore NuGet packages"
exec :restore do |cmd|
  cmd.command = nuget_command
  cmd.parameters "restore #{$solution}"
end

directory logs

desc "Clean solution"
task :clean => [logs] do
  run_msbuild "Clean"
end

desc "Build solution"
task :build => [:clean, :restore, logs] do
  run_msbuild "Build"
end

desc "Execute samples"
task :sample => [:build] do
  samples.each do |sample|
    xunit = XUnitTestRunner.new
    xunit.command = xunit_command
    xunit.assembly = sample
    xunit.options "-html", sample + ".TestResults.html", "-xml", sample + ".TestResults.xml"
    xunit.execute  
  end
end

def run_msbuild(target)
  cmd = Exec.new
  cmd.command = $msbuild_command
  cmd.parameters "#{$solution} /target:#{target} /p:configuration=Release /nr:false /verbosity:minimal /nologo /fl /flp:LogFile=artifacts/logs/#{target}.log;Verbosity=Detailed;PerformanceSummary"
  cmd.execute
end
