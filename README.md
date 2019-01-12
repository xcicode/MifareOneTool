# MifareOneTool
A GUI Mifare Classic tool on Windows

## 文档版本
- v1.5.0

## 安装
1. [下载最新发布](https://github.com/xcicode/MifareOneTool/releases/latest)
2. 解压M1T-Release.zip到独立目录（建议目录中不要出现空格）  
3. 就绪！

## 兼容设备
PN532-UART  
ACR122U(需要手动打开支持)

## 高级界面功能说明
检测：检测NFC设备连接状态  
手动扫描： 扫描读卡器上的卡片并显示基本信息  
手动CLI： 打开cmd，切换到nfc-bin/下，可手动调用命令行工具  
读卡： 读取普通卡片，需要指定KeyA/B，如果不是默认密码或空白卡片，需要指定密钥文件  
写卡： 写入普通卡片，需要指定KeyA/B，如果不是默认密码或空白卡片，需要指定密钥文件  
选择key.mfd： 指定密钥文件  
UID重置： 将UID卡的UID重置为随机数  
UID全格： 执行[UID重置]并清空所有扇区数据、恢复访问控制位  
UID写号： 将UID卡的UID设置为指定号码  
MFOC： 执行半加密卡Nested破解(仅建议针对SAK=08的卡片使用）  
`注：按住Ctrl点击该按钮可添加已知密钥。`
后门读： 读取UID卡，忽视扇区密钥  
后门写： 写入UID卡，忽视扇区密钥  
清空终端： 清空终端缓冲区显示的文本  
保存日志： 将终端缓冲区的文本保存至m1t.log文件中  
停止运行： 强行停止正在运行的功能  
MFCUK爆密钥： 调用MFCUK工具爆破全加密卡的密钥  
CUID写： 写入CUID卡(一种使用普通指令写0块的卡片)  
锁Ufuid： 锁定Ufuid卡片的0扇区使其不可再写入  
清M1卡： 使用选择的key.mfd清空卡内数据
启用ACR122U支持： 打开对ACR122U的支持  
`注：打开后可能会导致运行速度变慢。`  
Hex编辑器： 打开集成编辑器S50HTool  
检加密：查看M1卡的加密情况
