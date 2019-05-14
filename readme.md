# POC moq ReadOnlySpan Issue

This is my repo with some code that reproduces the issue on my system.

## Usage

### Run the unit test project

From your console:

```bash
PS C:\source\poc\moq-ros-issue\src> dotnet test
```

### Run sample web api

This shows that the sample code works.

From your console

```bash
PS C:\source\poc\moq-ros-issue\src> dotnet run --project .\WebSample\WebSample.csproj
```

Once started, in a browser navigate to https://localhost:5001/api/values.

## Results of running test project

```bash
PS C:\source\poc\moq-ros-issue\src> dotnet test
Skipping running test for project C:\source\poc\moq-ros-issue\src\WebSample\WebSample.csproj. To run tests with dotnet test add "<IsTestProject>true<IsTestProject>" property to project file.
Build started, please wait...
Build completed.

Test run for C:\source\poc\moq-ros-issue\src\Test\bin\Debug\netcoreapp2.2\Test.dll(.NETCoreApp,Version=v2.2)
Microsoft (R) Test Execution Command Line Tool Version 15.9.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
[xUnit.net 00:00:01.09]     Test.ValuesControllerTest.Fails_At_Runtime [FAIL]
Failed   Test.ValuesControllerTest.Fails_At_Runtime
Error Message:
 System.NotSupportedException : Cannot create boxed ByRef-like values.
Stack Trace:
   at System.RuntimeTypeHandle.CreateInstance(RuntimeType type, Boolean publicOnly, Boolean wrapExceptions, Boolean& canBeCached, RuntimeMethodHandleInternal& ctor)
   at System.RuntimeType.CreateInstanceSlow(Boolean publicOnly, Boolean wrapExceptions, Boolean skipCheckThis, Boolean fillCache)
   at System.Activator.CreateInstance(Type type, Boolean nonPublic, Boolean wrapExceptions)
   at Moq.LookupOrFallbackDefaultValueProvider.GetDefaultValue(Type type, Mock mock) in C:\projects\moq4\src\Moq\LookupOrFallbackDefaultValueProvider.cs:line 127
   at Moq.Mock.GetDefaultValue(MethodInfo method, DefaultValueProvider useAlternateProvider) in C:\projects\moq4\src\Moq\Mock.cs:line 909
   at Moq.Return.Handle(Invocation invocation, Mock mock) in C:\projects\moq4\src\Moq\Interception\InterceptionAspects.cs:line 343
   at Moq.Mock.Moq.IInterceptor.Intercept(Invocation invocation) in C:\projects\moq4\src\Moq\Interception\Mock.cs:line 20
   at Castle.DynamicProxy.AbstractInvocation.Proceed()
   at Castle.Proxies.IFooServiceProxy.GetSomeData()
   at WebSample.Controllers.ValuesController.Get() in C:\source\poc\moq-ros-issue\src\WebSample\Controllers\ValuesController.cs:line 25
   at Test.ValuesControllerTest.Fails_At_Runtime() in C:\source\poc\moq-ros-issue\src\Test\ValuesControllerTest.cs:line 17

Total tests: 1. Passed: 0. Failed: 1. Skipped: 0.
Test Run Failed.
Test execution time: 2.1398 Seconds
```

## dotnet --info 
```bash
PS C:\source\poc\moq-ros-issue> dotnet --info
.NET Core SDK (reflecting any global.json):
 Version:   2.2.203
 Commit:    e5bab63eca

Runtime Environment:
 OS Name:     Windows
 OS Version:  10.0.14393
 OS Platform: Windows
 RID:         win10-x64
 Base Path:   C:\Program Files\dotnet\sdk\2.2.203\

Host (useful for support):
  Version: 2.2.4
  Commit:  f95848e524

.NET Core SDKs installed:
  1.0.0 [C:\Program Files\dotnet\sdk]
  1.0.1 [C:\Program Files\dotnet\sdk]
  1.0.4 [C:\Program Files\dotnet\sdk]
  2.0.0 [C:\Program Files\dotnet\sdk]
  2.0.2 [C:\Program Files\dotnet\sdk]
  2.1.4 [C:\Program Files\dotnet\sdk]
  2.1.300 [C:\Program Files\dotnet\sdk]
  2.1.302 [C:\Program Files\dotnet\sdk]
  2.2.104 [C:\Program Files\dotnet\sdk]
  2.2.203 [C:\Program Files\dotnet\sdk]

.NET Core runtimes installed:
  Microsoft.AspNetCore.All 2.1.0 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.All]
  Microsoft.AspNetCore.All 2.1.2 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.All]
  Microsoft.AspNetCore.All 2.2.2 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.All]
  Microsoft.AspNetCore.All 2.2.4 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.All]
  Microsoft.AspNetCore.App 2.1.0 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 2.1.2 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 2.2.2 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 2.2.4 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 1.0.4 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 1.0.5 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 1.1.1 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 1.1.2 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 2.0.0 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 2.0.5 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 2.1.0 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 2.1.2 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 2.2.2 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 2.2.4 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]

To install additional .NET Core runtimes or SDKs:
  https://aka.ms/dotnet-download
```