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
|-- GWHost                 # Gateway Host Root Directory
|   |-- Properties          # Gateway Host Properties Configuration
|-- IoTCenterHost.AppServices  # Application Service Layer
|   |-- Application         # Application Service Layer Implementation
|   |-- Interfaces          # Service Interface Definitions
|   |-- Properties          # Application Service Configuration
|   |-- Resources           # Resource Files (Localization/Icons/Templates)
|-- IoTCenterHost.Build     # Build System Configuration
|-- IoTCenterHost.Core      # Core Functionality Module
|   |-- Cache               # Core Caching Mechanism
|   |-- IotModels           # IoT Domain Models
|   |-- ModelAdapter        # Model Adaptation Layer
|   |-- ProxyModels         # Proxy Model Layer
|   |-- ServerInterfaces    # Server-Side Interface Definitions
|-- IoTCenterHost.Core.Abstraction  # Core Abstraction Layer
|   |-- BaseModels          # Base Model Abstractions
|   |-- EnumDefine          # Global Enumeration Definitions
|   |-- Interfaces          # Core Abstract Interfaces
|-- IoTCenterHost.Core.Extension  # Extension Functionality Implementation
|-- IoTCenterHost.Domain    # Domain Layer (DDD Pattern)
|-- IoTCenterHost.GrpcConstract  # gRPC Service Directory
|   |-- GrpcConstract       # gRPC Service Contract Definitions
|   |-- StartUp             # gRPC Service Startup Configuration
|-- IoTCenterHost.Infrastructure  # Infrastructure Layer
|   |-- IotCenter           # Infrastructure Core Implementation
|   |-- Token               # Token Service Implementation (JWT/OAuth)
|-- IoTCenterHost.Protos    # Protocol Definition Files
|-- config                  # Configuration Directory
    |-- data               # Runtime Configuration Files
    |-- database           # Database Connection Configuration
    |-- dll                # Dependency Library Files
```

### Source Code Build Instructions  
For information on how to build GrpcServer from source, please refer to the [Wiki](https://github.com/ganweisoft/GrpcServer/wiki).

### License  
GrpcServer is licensed under the very permissive MIT License. For details, see [License](https://github.com/ganweisoft/GrpcServer/blob/main/LICENSE).

### Installation Guide  
Please refer to the [Installation Guide](https://github.com/ganweisoft/GrpcServer/wiki).

### How to Contribute  
We warmly welcome contributions from developers. If you find a bug or have any ideas you'd like to share, feel free to submit an [issue](https://github.com/ganweisoft/GrpcServer/blob/main/CONTRIBUTING.md).
