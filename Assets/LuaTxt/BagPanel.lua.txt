-- BagPanel = {}
BasePanel:subClass("BagPanel")

-- BagPanel.panelObj = nil
-- BagPanel.btnClose = nil
-- BagPanel.togEquip = nil
-- BagPanel.togItem  = nil
-- BagPanel.togGem   = nil
-- BagPanel.svBag    = nil
BagPanel.Content = nil

BagPanel.items   = {} --存储当前显示的格子
BagPanel.nowType = -1

function BagPanel:Init(name)
    -- if self.panelObj ~= nil then
    --     return
    -- end
    self.base:Init(name)

    -- self.panelObj = ABMgr.GetInstance():LoadRes("ui", "BagPanel", typeof(GameObject))
    -- self.panelObj.transform:SetParent(Canvas, false)
    -- self.btnClose = self.panelObj.transform:Find("BtnClose"):GetComponent(typeof(Button))
    -- local toggleGroup = self.panelObj.transform:Find("Toggles")
    -- self.togEquip = toggleGroup:Find("ToggleEquip"):GetComponent(typeof(Toggle))
    -- self.togItem = toggleGroup:Find("ToggleItem"):GetComponent(typeof(Toggle))
    -- self.togGem = toggleGroup:Find("ToggleGem"):GetComponent(typeof(Toggle))
    -- self.svBag = self.panelObj.transform:Find("Scroll View"):GetComponent(typeof(ScrollRect))
    -- self.Content = self.svBag.transform:Find("Viewport"):Find("Content")
    self.Content = self:GetControl("svBag", "ScrollRect").transform:Find("Viewport"):Find("Content")

    if self.isInitEvent == false then
        self:GetControl("btnClose", "Button").onClick:AddListener(function()
            self:HideSelf()
        end)
        --toggle 对应委托时 UnityAction<Bool>
        self:GetControl("togEquip", "Toggle").onValueChanged:AddListener(function(v)
            if v == true then
                self:ChangeType(1)
            end
        end)
        self:GetControl("togItem", "Toggle").onValueChanged:AddListener(function(v)
            if v == true then
                self:ChangeType(2)
            end
        end)
        self:GetControl("togGem", "Toggle").onValueChanged:AddListener(function(v)
            if v == true then
                self:ChangeType(3)
            end
        end)
        self.isInitEvent = true
    end
end

function BagPanel:ShowSelf(name)
    -- self:Init()
    -- self.panelObj:SetActive(true)
    self.base.ShowSelf(self, name)
    --第一次打开
    if self.nowType == -1 then
        self:ChangeType(1) --更新为装备
    end
end

function BagPanel:HideSelf()
    self.panelObj:SetActive(false)
end

--type 1装备 2道具 3宝石
function BagPanel:ChangeType(t)
    if self.nowType == t then
        return
    end

    --更新前，删除老的格子
    for i = 1, #self.items do
        -- GameObject.Destroy(self.items[i].obj)
        self.items[i]:Destroy()
    end
    self.items = {}

    local nowItems = nil
    if t == 1 then
        nowItems = PlayerData.equips
    elseif t == 2 then
        nowItems = PlayerData.items
    else
        nowItems = PlayerData.gems
    end

    for i = 1, #nowItems do
        -- local grid = {}
        -- --用一张新表 存储格子对象属性
        -- grid.obj = ABMgr.GetInstance():LoadRes("ui", "ItemGrid");
        -- grid.obj.transform:SetParent(self.Content, false)
        -- --设置位置
        -- grid.obj.transform.localPosition = Vector3((i - 1) % 4 * 175, math.floor((i - 1) / 4) * 175, 0)
        -- --找控件
        -- grid.icon = grid.obj.transform:Find("Icon"):GetComponent(typeof(Image))
        -- grid.num = grid.obj.transform:Find("Num"):GetComponent(typeof(Text))
        -- --根据id获取数据
        -- local data = ItemData[nowItems[i].id]
        -- --通过data中Icon属性，根据名字加载图集 再加载图集中的图标信息
        -- local strs = string.split(data.icon, "_")
        -- local spriteAtlas = ABMgr.GetInstance():LoadRes("ui", strs[1], typeof(SpriteAtlas))
        -- grid.icon.sprite = spriteAtlas:GetSprite(strs[2])
        -- --设置道具数量
        -- grid.num.text = nowItems[i].num
        --存起来
        local grid = ItemGrid:new()
        grid:Init(self.Content, (i - 1) % 4 * 175, math.floor((i - 1) / 4) * 175)
        grid:InitData(nowItems[i])

        table.insert(self.items, grid)
    end
end
