gRPC custom serialization
=========================

BACKGROUND
-------------
Example projects depend on the [Grpc](https://www.nuget.org/packages/Grpc/), [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/)
and [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf/) NuGet packages
which have been already added to the project for you.

PREREQUISITES
-------------

- Windows: .NET Framework 4.5+, Visual Studio 2013 or 2015
- Linux: Mono 4+, MonoDevelop 5.9+ (with NuGet add-in installed)
- Mac OS X: Xamarin Studio 5.9+

BUILD
-------

- Open solution `Greeter.sln` with Visual Studio, Monodevelop (on Linux) or Xamarin Studio (on Mac OS X)

- Build the solution (this will automatically download NuGet dependencies)

Try it!
-------

- Run the server

  ```
  > cd GreeterServer/bin/Debug
  > GreeterServer.exe
  ```

- Run the client

  ```
  > cd GreeterClient/bin/Debug
  > GreeterClient.exe

  ```

- Run all 

  ```
  > start.bat

  ```

You can also run the server and client directly from the IDE.

On Linux or Mac, use `mono GreeterServer.exe` and `mono GreeterClient.exe` to run the server and client.

Recommended content
--------

[gRPC Basics: C#](http://www.grpc.io/docs/tutorials/basic/csharp.html)

[Using gRPC with custom serializers](https://bartoszsypytkowski.com/c-using-grpc-with-custom-serializers/)
