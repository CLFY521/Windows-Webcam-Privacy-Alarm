# Windows-Webcam-Privacy-Alarm

基于注册表监控的 Windows 摄像头隐私保护工具。当摄像头硬件被调用时，通过系统底层接口触发物理蜂鸣报警。

## Usage / 使用方法
前往 [Releases](https://github.com/CLFY521/Windows-Webcam-Privacy-Alarm/releases) 页面下载最新版二进制文件运行。

## Build / 自行编译
下载源码使用 Visual Studio 编译，或使用 .NET Framework 编译器：
`C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /target:winexe /out:WebcamMonitor.exe WebcamMonitor.cs`

## License
[MIT License](LICENSE)
