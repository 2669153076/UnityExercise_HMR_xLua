PlayerData = {}

PlayerData.equips = {}
PlayerData.items = {}
PlayerData.gems = {}

--为玩家数据写一个初始化方法
function PlayerData:Init()
    --道具信息不管存本地、还是服务器、都只会存id和数量

    --因为没有服务器，所以先写死
    table.insert(self.equips, { id = 1, num = 1 })
    table.insert(self.equips, { id = 2, num = 1 })
    table.insert(self.items, { id = 3, num = 1 })
    table.insert(self.items, { id = 4, num = 1 })
    table.insert(self.gems, { id = 5, num = 1 })
    table.insert(self.gems, { id = 6, num = 1 })
end
