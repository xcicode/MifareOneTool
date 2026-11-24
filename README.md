# MifareOneTool 1.7（Windows 优化版）

本仓库是 [xcicode/MifareOneTool](https://github.com/xcicode/MifareOneTool) 的 Fork，针对 Windows 版做了窗口与界面优化，预编译包请从 Releases 页面下载。

## 下载

请到 [Releases](https://github.com/lyx7725/MifareOneTool/releases) 页面下载 `M1T-Release-Optimized.zip`（完整运行包）。

- 内容：本 Fork 重新编译的 `MifareOneTool.exe`，以及运行所需的全部文件（`nfc-bin`、`auto_keys`、`libnfc.conf`、`mff08_empty.kmf`、`Newtonsoft.Json.dll`、`winhex.exe`）
- 用法：解压后进入 `M1T-Release-Optimized` 目录，直接运行 `MifareOneTool.exe`。**无需另行下载原版**，整个目录可随意拷贝到其他电脑使用。

## 本次优化

1. **窗口可缩放**：移除固定边框，最小尺寸保持原版布局；日志区随窗口高度伸缩。
2. **记住窗口状态**：关闭时保存位置、大小与最大化状态，下次启动自动恢复；显示器变化导致位置不可见时回退默认。
3. **界面刷新**：扁平化主色按钮、统一蓝色调、深色日志区、浅色状态栏。
4. **构建适配**：目标框架从 .NET Framework 4.0 Client Profile 调整为 4.8（Windows 11 自带），便于使用当前 Visual Studio 工具链。

## 说明

- 版本 1.7.0.0，x86，.NET Framework 4.8（Windows 10/11 已自带）。
- 完整运行包已包含原版所需的全部第三方工具与配置，可脱离原版独立运行。
- 新版按可执行文件路径保存界面偏好，首次运行会使用默认设置；`libnfc.conf` 与 `auto_keys` 不受影响。
- 原项目已停止更新；本 Fork 仅做 Windows 使用体验优化，未改动读写卡逻辑。

## 构建

在 `MifareOneTool/` 目录执行：

```powershell
msbuild MifareOneTool.csproj -p:Configuration=Release -p:Platform=x86
```

## 许可

GPL-3.0，与原项目一致。上游项目：https://github.com/xcicode/MifareOneTool
