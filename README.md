# 环境变量设置工具

## 介绍

一个简单的环境变量设定工具，可以自动检测电脑已安装的jdk和python，并一键设定其环境变量，也可以平时作为一个java或者python的版本切换工具使用，还可以把指定目录加入到`Path`环境变量中去。

可以自动搜索到以下已安装的JDK：
- [Oracle JDK](https://www.oracle.com/java/technologies/javase-downloads.html)
- [Adopt OpenJDK (Hotspot or OpenJ9)](https://adoptopenjdk.net/)
- [Microsoft Build Of OpenJDK](https://www.microsoft.com/openjdk) 
- [Azul Zulu OpenJDK](https://azul.com/downloads)
- [BellSoft Liberica OpenJDK](https://bell-sw.com/libericajdk/)

也可以自动搜索已安装的Python，不过只有是安装给电脑上所有用户的Python（安装时选择了Install for all users）才能被检测到。

## 下载地址

在右侧发行版/Releases处下载即可。

## 主要功能

- 一键检测并设定JDK或者Python环境变量
- 将自定义的目录追加至`Path`系统环境变量
- `Path`变量整理
- `Path`变量快速管理
- 系统环境变量的备份还原脚本导出

## 使用说明

若下载了该软件却发现无法运行，说明没有安装`.NET Framework`运行环境，请下载安装运行环境：

[官网下载](https://dotnet.microsoft.com/download/dotnet-framework/net48)

软件的使用方法很简单，下载后双击`exe`即可打开，是单文件应用程序。软件会自动探测已安装的JDK和Python，然后选择版本设定即可。

如果已经设定过了JDK/Python环境变量，并且你的电脑安装了多个版本的JDK/Python，仍然可以使用本程序重新设定为别的版本的JDK/Python环境变量以达到切换版本的效果，也可以选择手动指定位置。

少数电脑设定了环境变量可能需要重启系统才会生效。

> 最后更新：2024.4.19