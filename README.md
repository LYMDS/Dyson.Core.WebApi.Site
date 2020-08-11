# Dyson.Core.WebApi.Site
用.Net Core搭建的WebApi站点

Dyson.Core.WebApi ==> WebApi站点,通过依赖注入控制器

Dyson.Core.Controller.业务分类 ==> 控制器类项目,在站点的配置文件上依赖注入控制器程序集

Dyson.Core.DataBase.ORM ==> 基于sqlSugarCore5.0.0.15的ORM框架,管理数据库操作逻辑,可按数据库表创建文件夹分类逻辑文件

Dyson.Core.DataBase.Entity ==> 数据库实体项目

Dyson.Core.业务分类 ==> 业务逻辑代码

以上三种项目代码的程序集（.dll文件）,以逻辑类的依赖注入到主机服务上