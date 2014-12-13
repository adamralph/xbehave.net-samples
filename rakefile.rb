require 'albacore'

$msbuild_command = "C:/Program Files (x86)/MSBuild/12.0/Bin/MSBuild.exe"
xunit_command_net40 = "src/packages/xunit.runners.2.0.0-beta5-build2785/tools/xunit.console.exe"
nuget_command = "src/packages/NuGet.CommandLine.2.8.3/tools/NuGet.exe"
$solution = "src/XBehave.Samples.sln"
logs = "artifacts/logs"

samples = [
  { :command => xunit_command_net40, :assembly => "src/Xbehave.Samples.Net45/bin/Debug/Xbehave.Samples.dll" },
  { :command => xunit_command_net40, :assembly => "src/Xbehave.Samples.FSharp.Net45/bin/Release/Xbehave.Samples.FSharp.dll" }
]

Albacore.configure do |config|
  config.log_level = :verbose
end

desc "Execute default tasks"
task :default => [:sample]

desc "Restore NuGet packages"
exec :restore do |cmd|
  cmd.command = nuget_command
  cmd.parameters "restore #{$solution}"
end

desc "Clean solution"
task :clean do
  FileUtils.mkpath logs
  run_msbuild "Clean"
end

desc "Build solution"
task :build => [:clean, :restore] do
  FileUtils.mkpath logs
  run_msbuild "Build"
end

desc "Execute samples"
task :sample => [:build] do
  execute_xunit samples
end

def run_msbuild(target)
  cmd = Exec.new
  cmd.command = $msbuild_command
  cmd.parameters "#{$solution} /target:#{target} /p:configuration=Release /nr:false /verbosity:minimal /nologo /fl /flp:LogFile=artifacts/logs/#{target}.log;Verbosity=Detailed;PerformanceSummary"
  cmd.execute
end

def execute_xunit(tests)
  tests.each do |test|
    xunit = XUnitTestRunner.new
    xunit.command = test[:command]
    xunit.assembly = test[:assembly]
    xunit.options "-html", test[:assembly] + ".TestResults.html", "-xml", test[:assembly] + ".TestResults.xml"
    xunit.execute  
  end
end
