# MifareOneTool
A GUI Mifare Classic tool on Windows
# 本文档需要更新

## 安装
1. [下载最新发布](https://github.com/xcicode/MifareOneTool/releases/latest)
2. 解压M1T-Release.zip到独立目录（建议目录中不要出现空格）  
3. 就绪！

## 兼容设备
PN532-UART

## 功能
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
后门读： 读取UID卡，忽视扇区密钥  
后门写： 写入UID卡，忽视扇区密钥  
清空终端： 清空终端缓冲区显示的文本  
保存日志： 将终端缓冲区的文本保存至m1t.log文件中  
停止运行： 强行停止正在运行的功能  
