--生成一个table 集成Object 主要不低是要它里面实现的 继承方法subClass和new
Object:subClass("ItemGrid")
--成员变量
ItemGrid.obj = nil
ItemGrid.icon = nil
ItemGrid.num = nil

function ItemGrid:Init(father, posX, posY)
    self.obj = ABMgr.GetInstance():LoadRes("ui", "ItemGrid", typeof(GameObject))
    self.obj.transform:SetParent(father, false)
    self.obj.transform.localPosition = Vector3(posX, posY, 0)
    self.icon = self.obj.transform:Find("imgIcon"):GetComponent(typeof(Image))
    self.num = self.obj.transform:Find("txtNum"):GetComponent(typeof(Text))
end

--传入道具信息
function ItemGrid:InitData(data)
    local _data = ItemData[data.id]
    local strs = string.split(_data.icon, "_")
    local spriteAtlas = ABMgr.GetInstance():LoadRes("ui", strs[1], typeof(SpriteAtlas))
    self.icon.sprite = spriteAtlas:GetSprite(strs[2])
    self.num.text = data.num
end

function ItemGrid:Destroy()
    GameObject.Destroy(self.obj)
    self.obj = nil
end
