# 远程桌面管理工具 

基于 MSTSC 连接 Windows 远程桌面，并对其进行封装实现管理多个远程桌面配置的小工具

关键字：`AxMsRdpClient` `Dapper` `SQLite` `Winforms-Modernui`

效果图如下：

![效果-主界面](https://github.com/wang9563/RemoteDesktopManage/blob/master/Images/%E6%95%88%E6%9E%9C-%E4%B8%BB%E7%95%8C%E9%9D%A2.png)

![效果-打开远程连接](https://github.com/wang9563/RemoteDesktopManage/blob/master/Images/%E6%95%88%E6%9E%9C-%E6%89%93%E5%BC%80%E8%BF%9C%E7%A8%8B%E8%BF%9E%E6%8E%A5.png)


## 1、什么是 MSTSC (Microsoft terminal services client) ？
创建与终端服务器或其他远程计算机的连接，适用于 Windows XP 及以上的 Windows 操作系统

MSTSC 还有一种说法，Microsoft Telnet Screen Control ，即“微软远程桌面控制”。

**PS.** 相信对本项目感兴趣的朋友肯定熟悉下面微软的官方工具，本项目也是基于其 ActiveX 控件进行的封装，实现对远程桌面的管理与使用

![MSTSC](https://github.com/wang9563/RemoteDesktopManage/blob/master/Images/MSTSC.png)

## 2、赶紧来添加第一个远程桌面连接 ？
点击左下角的 `添加远程主机` 来，开启 `是否为父级` 选项，起个 `名字` 并 `保存` 来添加您的一个父级(分组)节点，譬如

![样例-添加父节点](https://github.com/wang9563/RemoteDesktopManage/blob/master/Images/%E6%A0%B7%E4%BE%8B-%E6%B7%BB%E5%8A%A0%E7%88%B6%E8%8A%82%E7%82%B9.png)

再次点击点击左下角的 `添加远程主机` 来新建您的第一个连接，假定您已熟悉 MSTSC 相关设置，那么下面这个配置也难不住您了

![样例-添加子节点](https://github.com/wang9563/RemoteDesktopManage/blob/master/Images/%E6%A0%B7%E4%BE%8B-%E6%B7%BB%E5%8A%A0%E5%AD%90%E8%8A%82%E7%82%B9.png)

![样例-显示新增的配置](https://github.com/wang9563/RemoteDesktopManage/blob/master/Images/%E6%A0%B7%E4%BE%8B-%E6%98%BE%E7%A4%BA%E6%96%B0%E5%A2%9E%E7%9A%84%E9%85%8D%E7%BD%AE.png)

单击此方块即可连接服务器，请确保网络无阻哦，一般来说 MSTSC 能连上，本工具同样可以

![样例-正在连接](https://github.com/wang9563/RemoteDesktopManage/blob/master/Images/%E6%A0%B7%E4%BE%8B-%E6%AD%A3%E5%9C%A8%E8%BF%9E%E6%8E%A5.png)

![样例-连接成功](https://github.com/wang9563/RemoteDesktopManage/blob/master/Images/%E6%A0%B7%E4%BE%8B-%E8%BF%9E%E6%8E%A5%E6%88%90%E5%8A%9F.png)

好了，基本上您已经掌握如何使用此工具了

## 3、还有其他功能应用？

* 支持拖动页签头来改变其位置 (同时连接了多个远程可能会有些用)

* 当你不想打开远程桌面，而只想打开远程服务器上的某个程序时，请在 `仅启动程序` 时填写需要启动程序的路径，如 `C:\Windows\System32\calc.exe` ，如果该目录已配置到环境变量的 `PATH` 中，如本示例使用程序名 `calc` 亦同

* 右击页面头会有菜单选项，比如可执行 `关闭` 操作，右击连接方块可进行 `编辑`、`删除` 等操作
* 切换主题，偶尔换换口味吧
* 编辑时可以点击右上角的 `复制` 则保留该连接信息，点保存时换创建一个新的连接
* 鼠标中键关闭页签 (远程桌面)
* 键盘映射，当窗口处于活动状态远程桌面将获得键盘事件，当窗口不处于活动状态则本机获得键盘事件，建议点击远程窗口和本机任务栏来进行键盘映射的切换

以上功能均是出于我个人使用习惯，可能对您并不实用，所以文档也含糊一下啦，抱歉！

**PS. 假如您对本项目有兴趣，欢迎提 Pull Request 一起来完善它**

## 4、开始作死

[下载最新的 Releases 程序玩一把？](https://github.com/wang9563/RemoteDesktopManage/releases)

或者

直接下载本项目源码，本项目使用 [WTFPL 开源协议](https://github.com/wang9563/RemoteDesktopManage/blob/master/LICENSE)，所以。。您怎么喜欢怎么来吧！
