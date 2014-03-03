require 'albacore'

xunit_command_net40 = "src/packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe"
nuget_command = "src/packages/NuGet.CommandLine.2.8.0/tools/NuGet.exe"
solution = "src/XBehave.Samples.sln"

samples = [
  { :command => xunit_command_net40, :assembly => "src/Xbehave.Samples.Net40/bin/Debug/Xbehave.Samples.Net40.dll" },
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
  cmd.parameters "restore #{solution}"
end

desc "Clean solution"
msbuild :clean do |msb|
  msb.properties = { :configuration => :Release }
  msb.targets = [:Clean]
  msb.solution = solution
end

desc "Build solution"
msbuild :build => [:clean, :restore] do |msb|
  msb.properties = { :configuration => :Release }
  msb.targets = [:Build]
  msb.solution = solution
end

desc "Execute samples"
task :sample => [:build] do
  execute_xunit samples
end

def execute_xunit(tests)
  tests.each do |test|
    xunit = XUnitTestRunner.new
    xunit.command = test[:command]
    xunit.assembly = test[:assembly]
    xunit.options "/html", test[:assembly] + ".TestResults.html", "/xml", test[:assembly] + ".TestResults.xml"
    xunit.execute  
  end
end
