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
|-- Directory.Build.props
|-- Directory.Build.targets
|-- Directory.Packages.props
|-- GWHost
|   |-- GWRES1.dll
|   `-- Properties
|-- IoTCenterHost.AppServices
|   |-- Application
|   |   `-- Readme.md
|   |-- Interfaces
|   |-- Properties
|   `-- Resources
|       |-- LocalizationResource.en-US.resx
|       |-- LocalizationResource.resx
|       `-- LocalizationResource.zh-CN.resx
|-- IoTCenterHost.Build
|   |-- Dependencies.AspNetCore.props
|   |-- Dependencies.props
|   |-- IoTCenterCore.Commons.props
|   `-- IoTCenterCore.Commons.targets
|-- IoTCenterHost.Core
|   |-- Cache
|   |-- IotModels
|   |-- ModelAdapter
|   |-- ProxyModels
|   `-- ServerInterfaces
|-- IoTCenterHost.Core.Abstraction
|   |-- BaseModels
|   |-- EnumDefine
|   |-- Interfaces
|   |   |-- AppServices
|   |   `-- Services
|   `-- IoTCenterHost.Core.Abstraction.xml
|-- IoTCenterHost.Core.Extension
|-- IoTCenterHost.Domain
|   `-- Domain
|       |-- DO
|       |-- DomainBase
|       |-- PO
|       `-- VO
|-- IoTCenterHost.GrpcConstract
|   |-- GrpcConstract
|   |   `-- IotHostService
|   `-- StartUp
|       `-- Interceptors
|-- IoTCenterHost.Infrastructure
|   |-- IotCenter
|   |   `-- Interface
|   `-- Token
|-- IoTCenterHost.Protos
|-- compile.bat
|-- config
|   |-- data
|   |   `-- AlarmCenter
|   |-- database
|   |   |-- Database.db
|   |   `-- IoTCenter_MySQL.sql
|   `-- dll
|       `-- BCDataSimu.STD.dll
`-- logo.jpg
```bash

### Source Code Build Instructions  
For information on how to build GrpcServer from source, please refer to the [Wiki](https://github.com/ganweisoft/GrpcServer/wiki).

### License  
GrpcServer is licensed under the very permissive MIT License. For details, see [License](https://github.com/ganweisoft/GrpcServer/blob/main/LICENSE).

### Installation Guide  
Please refer to the [Installation Guide](https://github.com/ganweisoft/GrpcServer/wiki).

### How to Contribute  
We warmly welcome contributions from developers. If you find a bug or have any ideas you'd like to share, feel free to submit an [issue](https://github.com/ganweisoft/GrpcServer/blob/main/CONTRIBUTING.md).
