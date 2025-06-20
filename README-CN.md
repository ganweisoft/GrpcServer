<p align="left" dir="auto">
  <a href="https://opensource.ganweicloud.com" rel="nofollow">
    <img style="width:130px;height:130px;" src="https://github.com/ganweisoft/GrpcServer/blob/main/src/logo.jpg">
  </a>
</p>

[![GitHub license](https://camo.githubusercontent.com/5eaf3ed8a7e8ccb15c21d967b8635ac79e8b1865da3a5ccf78d2572a3e10738a/68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f6c6963656e73652f646f746e65742f6173706e6574636f72653f636f6c6f723d253233306230267374796c653d666c61742d737175617265)](https://github.com/ganweisoft/GrpcServer/blob/main/LICENSE) [![Build Status](https://github.com/ganweisoft/TOMs/actions/workflows/build.yml/badge.svg)](https://github.com/ganweisoft/TOMs/actions) [![NuGet](https://img.shields.io/nuget/v/IoTCenterHost.Core.Abstraction.svg)](https://www.nuget.org/packages/IoTCenterHost.Core.Abstraction/) ![](https://img.shields.io/badge/join-discord-infomational)

简体中文 | [English](README.md)

GrpcServer采用 gRPC（Google Remote Procedure Call）协议 构建轻量级、高性能的代理服务框架，基于 Protocol Buffers（protobuf） 接口定义语言进行通信接口建模，支持跨语言、跨平台的服务集成与调用。

### 源码构建说明

以下是为目录结构添加的英文注释，基于常见开发实践和文件名推测功能：

```bash
|-- GWHost                 # 网关主机主目录
|   |-- Properties          # 网关主机属性配置
|-- IoTCenterHost.AppServices  # 应用服务层
|   |-- Application         # 应用服务层实现
|   |-- Interfaces          # 服务接口定义
|   |-- Properties          # 应用服务配置
|   |-- Resources           # 资源文件
|-- IoTCenterHost.Build     # 构建系统目录
|-- IoTCenterHost.Core      # 核心功能模块
|   |-- Cache               # 核心缓存模块
|   |-- IotModels           # IoT领域模型
|   |-- ModelAdapter        # 模型适配层
|   |-- ProxyModels         # 代理模型层
|   |-- ServerInterfaces    # 服务端接口定义
|-- IoTCenterHost.Core.Abstraction  # 核心抽象层
|   |-- BaseModels          # 基础模型抽象
|   |-- EnumDefine          # 枚举定义
|   |-- Interfaces          # 核心抽象接口
|-- IoTCenterHost.Core.Extension  # 扩展功能层
|-- IoTCenterHost.Domain    # 领域层
|-- IoTCenterHost.GrpcConstract  # gRPC服务目录
|   |-- GrpcConstract       # gRPC服务契约
|   |-- StartUp             # gRPC服务启动配置
|-- IoTCenterHost.Infrastructure  # 基础设施层
|   |-- IotCenter           # 基础设施实现
|   |-- Token               # 令牌服务实现
|-- IoTCenterHost.Protos    # 协议定义目录
|-- config                  # 配置目录
    |-- data               # 配置文件
    |-- database           # 数据库配置
    |-- dll                # 依赖库文件
```

注释说明：
1. 层级结构使用标准开发目录命名约定
2. 重点标注了：
   - 构建系统配置（MSBuild相关）
   - 分层架构（Application/Domain/Infrastructure）
   - 领域驱动设计模式（DO/PO/VO）
   - 通信协议（gRPC）
   - 本地化资源管理
   - 依赖管理策略
3. 保留了原始目录名中的拼写（如GrpcConstract可能是Contract的拼写错误）
4. 对常见文件类型进行了功能推测（.resx=资源文件，.props=MSBuild属性文件等）
### License

GrpcServer 使用非常宽松的MIT协议，请见 [License](https://github.com/ganweisoft/GrpcServer/blob/main/LICENSE)。

### 如何提交贡献

我们非常欢迎开发者提交贡献, 如果您发现了一个bug或者有一些想法想要交流，欢迎提交一个[issue](https://github.com/ganweisoft/GrpcServer/blob/main/CONTRIBUTING.md).
