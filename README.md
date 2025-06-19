<p align="left" dir="auto">
  <a href="https://opensource.ganweicloud.com" rel="nofollow">
    <img style="width:130px;height:130px;" src="https://github.com/ganweisoft/GrpcServer/blob/main/src/logo.jpg">
  </a>
</p>

[![GitHub license](https://camo.githubusercontent.com/5eaf3ed8a7e8ccb15c21d967b8635ac79e8b1865da3a5ccf78d2572a3e10738a/68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f6c6963656e73652f646f746e65742f6173706e6574636f72653f636f6c6f723d253233306230267374796c653d666c61742d737175617265)](https://github.com/ganweisoft/GrpcServer/blob/main/LICENSE) [![Build Status](https://github.com/ganweisoft/TOMs/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ganweisoft/TOMs/actions) [![NuGet](https://img.shields.io/nuget/v/IoTCenterHost.Core.Abstraction.svg)](https://www.nuget.org/packages/IoTCenterHost.Core.Abstraction/) ![](https://img.shields.io/badge/join-discord-infomational)

English | [简体中文](README-CN.md)

GrpcServer builds a lightweight, high-performance proxy service framework using the gRPC (Google Remote Procedure Call) protocol. It models communication interfaces using the Protocol Buffers (protobuf) interface definition language, and supports cross-language and cross-platform service integration and invocation.

# Source Code Structure
```bash
|-- Directory.Build.props        # MSBuild global properties (versioning, constants)
|-- Directory.Build.targets      # MSBuild global targets (build pipeline customization)
|-- Directory.Packages.props     # NuGet package version management
|-- GWHost                       # Host application executable
|   |-- GWRES1.dll               # Main application DLL
|   `-- Properties               # Assembly info/configuration
|-- IoTCenterHost.AppServices    # Application services layer
|   |-- Application              # Business logic implementation
|   |   `-- Readme.md            # Layer documentation
|   |-- Interfaces               # Service contracts/interfaces
|   |-- Properties               # Layer-specific settings
|   `-- Resources                # Localization resources
|       |-- LocalizationResource.en-US.resx  # English translations
|       |-- LocalizationResource.resx        # Neutral language fallback
|       `-- LocalizationResource.zh-CN.resx  # Chinese translations
|-- IoTCenterHost.Build          # Build configuration
|   |-- Dependencies.AspNetCore.props      # ASP.NET Core dependencies
|   |-- Dependencies.props                 # Shared dependency versions
|   |-- IoTCenterCore.Commons.props        # Core library build settings
|   `-- IoTCenterCore.Commons.targets      # Core library build tasks
|-- IoTCenterHost.Core           # Core business logic
|   |-- Cache                    # Caching mechanisms
|   |-- IotModels                # IoT-specific data models
|   |-- ModelAdapter             # Data model adapters/converters
|   |-- ProxyModels              # External service proxy models
|   `-- ServerInterfaces         # Server-side API contracts
|-- IoTCenterHost.Core.Abstraction  # Abstract core components
|   |-- BaseModels               # Base class definitions
|   |-- EnumDefine               # Shared enumerations
|   |-- Interfaces               # Core service interfaces
|   |   |-- AppServices          # Application service contracts
|   |   `-- Services             # Domain service contracts
|   `-- IoTCenterHost.Core.Abstraction.xml  # XML documentation for IntelliSense
|-- IoTCenterHost.Core.Extension    # Extensibility points/plugins
|-- IoTCenterHost.Domain           # Domain-driven design components
|   `-- Domain                   # Domain logic layer
|       |-- DO                    # Domain Objects (business entities)
|       |-- DomainBase            # Base domain classes
|       |-- PO                    # Persistence Objects (database entities)
|       `-- VO                    # Value Objects (immutable values)
|-- IoTCenterHost.GrpcConstract    # gRPC service definitions
|   |-- GrpcConstract             # Contracts (likely should be "Contract")
|   |   `-- IotHostService        # gRPC service interface
|   `-- StartUp                   # gRPC server configuration
|       `-- Interceptors          # gRPC middleware/interceptors
|-- IoTCenterHost.Infrastructure  # Infrastructure implementations
|   |-- IotCenter                 # IoT-specific infrastructure
|   |   `-- Interface             # IoT device interfaces
|   `-- Token                     # Authentication/token services
|-- IoTCenterHost.Protos           # Protocol Buffer definitions (gRPC)
|-- compile.bat                   # Windows build script
|-- config                        # Configuration files
|   |-- data                      # Runtime data files
|   |   `-- AlarmCenter           # Alarm system configuration
|   |-- database                  # Database artifacts
|   |   |-- Database.db           # SQLite database file
|   |   `-- IoTCenter_MySQL.sql   # MySQL schema/data script
|   `-- dll                       # Third-party dependencies
|       `-- BCDataSimu.STD.dll    # Data simulation library
`-- logo.jpg                      # Application icon/logo

```

### Source Code Build Instructions  
For information on how to build GrpcServer from source, please refer to the [Wiki](https://github.com/ganweisoft/GrpcServer/wiki).

### License  
GrpcServer is licensed under the very permissive MIT License. For details, see [License](https://github.com/ganweisoft/GrpcServer/blob/main/LICENSE).

### Installation Guide  
Please refer to the [Installation Guide](https://github.com/ganweisoft/GrpcServer/wiki).

### How to Contribute  
We warmly welcome contributions from developers. If you find a bug or have any ideas you'd like to share, feel free to submit an [issue](https://github.com/ganweisoft/GrpcServer/blob/main/CONTRIBUTING.md).
