# MifareOneTool 1.7（Windows 优化版）

本仓库是 [xcicode/MifareOneTool](https://github.com/xcicode/MifareOneTool) 的 Fork，针对 Windows 版做了窗口与界面优化，并提供可直接使用的预编译文件。

## 预编译文件

- 文件：[`prebuilt/MifareOneTool-1.7.0-window-ui-fix-win-x86.zip`](prebuilt/MifareOneTool-1.7.0-window-ui-fix-win-x86.zip)
- SHA-256：`99132fc9c0309d435073a83e803be6c1667dd733253080f178d46f143c689428`
- 内容：`MifareOneTool.exe`、`MifareOneTool.exe.config`（仅本 Fork 重新编译的文件；不含 `nfc-bin`、`winhex.exe` 等第三方工具）
- 用法：备份现有 `M1T-Release` 目录后，将压缩包内两个文件解压覆盖到该目录（与 `nfc-bin`、`auto_keys`、`libnfc.conf` 同级），运行 `MifareOneTool.exe`。

## 本次优化

1. **窗口可缩放**：移除固定边框，最小尺寸保持原版布局；日志区随窗口高度伸缩。
2. **记住窗口状态**：关闭时保存位置、大小与最大化状态，下次启动自动恢复；显示器变化导致位置不可见时回退默认。
3. **界面刷新**：扁平化主色按钮、统一蓝色调、深色日志区、浅色状态栏。
4. **构建适配**：目标框架从 .NET Framework 4.0 Client Profile 调整为 4.8（Windows 11 自带），便于使用当前 Visual Studio 工具链。

## 说明

- 版本 1.7.0.0，x86，.NET Framework 4.8。
- 新版按可执行文件路径保存界面偏好，首次运行会使用默认设置；`libnfc.conf` 与 `auto_keys` 不受影响。
- 原项目已停止更新；本 Fork 仅做 Windows 使用体验优化，未改动读写卡逻辑。

## 构建

在 `MifareOneTool/` 目录执行：

```powershell
msbuild MifareOneTool.csproj -p:Configuration=Release -p:Platform=x86
```

## 许可

GPL-3.0，与原项目一致。上游项目：https://github.com/xcicode/MifareOneTool
