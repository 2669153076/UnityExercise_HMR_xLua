print("准备就绪")
require("InitClass")
require("ItemData")
--玩家信息
--1.从本地读取  PlayerPrefs、Json、XML、二进制
--2.网络读取
require("PlayerData")
PlayerData:Init()

require("BasePanel")
require("MainPanel")
require("BagPanel")
require("ItemGrid")
MainPanel:ShowSelf("MainPanel")
