# CytoBox.Core

## 项目背景
>CytoBox.Core 源自大学时期的一个设想，能够有一个应用框架，可以满足多客户端和多资源服务的统一认证与鉴权的一个开箱即用的企业级应用框架

## 技术选型
 `ASP.NET Core`  `.net standard`
- **为什么选择 `ASP.NET Core`**
1. 【开源】`ASPNET.NET Core` 是由 ***Microsoft*** 和 ***.NET*** 社区在 ***GitHub*** 上开源并维护的一个跨平台（支持 Windows、macOS 和 Linux）的新一代高性能框架， 拥有十分广泛的社区与支持者，可用于构建 web应用、物联网IOT应用和移动端应用。
2. 【高效】Asp.net core(.net core)来源于 .net，很容易迁移，而且也很容易上手， 但是又是不同的一个框架，除了上述对 .net 开发者十分友好以外，相对于之前的 .net 项目，速度上有巨大的改进， 相比与原来的Web 《.net framework》 程序性能提升了2300%。跟 `python、java` 等相同环境比较，性能都要优越， 参考[www.techempower.com](www.techempower.com)。
3. 【跨平台】可以在 `Windows`、`Mac` 和 `Linux` 构建和运行跨平台的 `Asp.Net Core` 应用。
4. 【云原生】在云原生领域拥有天然的优势，搭配 `Azure` 云服务，配合 `K8s`，更好的实现分布式应用，以及微服务应用。
5. 【微服务】`ASP.NET Core` 尤其适用于微服务架构，也就是说 `ASP.NET Core` 不仅适合于中小型项目而且还特别适合于大型，超大型项目。
6. 【大公司】目前国内采用 `ASP.NET Core` 的大公司比如：腾讯、网易，国际的有：Bing，GoDaddy，Stackoverflow，Adobe，Microsoft 
7. 【总结】`java` 支持的 `ASPNET.Core` 都支持，而且更轻量级、更高效跨，并且对 `.net` 开发者十分友好，微服务案例成熟。

## 框架功能点
1. 丰富完整的接口文档。
2. 采用多层开发，隔离性更好，封装更完善。
3. 基于项目模板，可以一键创建自己的项目。
4. 搭配代码生成器，实现快速开发，节省成本。
5. 丰富的审计日志处理，方便线上项目快速定位异常点。
6. 支持自由切换多种数据库 Sqlite/SqlServer/MySql/PostgreSQL。

## 应用领域
1. 【对接第三方api】项目通过webapi，可以快速对接第三方api服务，实现业务逻辑。
2. 【前后端分离】 采用的是API开发模式，满足平时开发的所有需求，你可以对接任何的自定义前端项目：无论是微信小程序，还是授权APP，无论是PC网页，还是手机H5。
3. 【微服务】当然，因为采用的是API模式，所以同样适用于微服务项目，实现高并发的产品需求。

## 功能与进度

### 框架模块
- [x] 采用仓储+服务+接口的形式封装框架；
- [x] 异步 `async/await` 开发；
- [x] 多种数据库支持 Sqlite/SqlServer/MySql/PostgreSQL；
- [x] 在线API文档，可导出离线文档；
- [x] 在线日志查看；
- [x] 自动执行数据库迁移脚本 ✨；
- [x] 实现项目启动，自动生成种子数据 ✨；
- [ ] 设计4种 AOP 切面编程，功能涵盖：日志、缓存、审计、事务 ✨；
- [ ] 支持项目事务处理 ✨；
- [ ] 支持原生成器，生成分层代码 ✨；
- [ ] 统一集成 IdentityServer 认证 ✨;
- [ ] 分层服务注入 ✨;

### 组件模块
- [x] 支持 CORS 跨域；
- [ ] 封装 JWT 自定义策略授权；
- [ ] 使用 SignalR 双工通讯 ✨；
- [ ] 支持 数据库 `读写分离` 和多库操作 ✨;

## 项目复盘与思考
- 项目处于初期阶段，还有很的多不足，可主要功能点待完善
