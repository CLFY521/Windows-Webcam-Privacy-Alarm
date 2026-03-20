# Windows-Webcam-Privacy-Alarm
基于注册表监控的 Windows 摄像头隐私保护工具。当摄像头硬件被调用时，通过系统底层接口触发即时物理蜂鸣报警，旨在公共计算环境下提醒用户隐私状态。仅限教育与个人隐私研究用途。
针对新手的下载与使用指南
1. 下载程序
在 GitHub 仓库主页右侧找到 Releases 栏目（标有 Latest 绿色标签）。

点击进入后，在 Assets 列表中直接点击 WebcamMonitor.exe 下载。

注意：不要点击 Source code，那个是代码，新手直接下载 .exe 成品即可。

2. 放置与启动
存放位置：如果是学校白板环境，建议将下载的文件存放在 D 盘，防止重启后被系统还原抹除。

双击运行：

由于程序没有数字签名，Windows 会弹出蓝色警告窗（“Windows 已保护你的电脑”）。

点击 “更多信息”（More info）。

点击右下角出现的 “仍要运行”（Run anyway）。

静默工作：双击后不会有窗口弹出，程序已直接进入后台运行。

3. 测试与验证
确保电脑系统音量已开启（非静音）。

打开电脑自带的 “相机” 应用。

如果预览画面出现的瞬间，你听到了两声短促的蜂鸣报警，说明程序运行成功。

4. 如何关闭
按下 Ctrl + Shift + Esc 唤出任务管理器。

切换到 “详细信息”（Details）选项卡。

找到 WebcamMonitor.exe，右键选择 “结束任务”。

如何自行编译
在 CMD 中执行以下命令即可生成成品：
C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /target:winexe /out:WebcamMonitor.exe WebcamMonitor.cs
