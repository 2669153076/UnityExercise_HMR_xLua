--只要是一个新的对象（面板）就新建一张表
-- MainPanel = {}
BasePanel:subClass("MainPanel")

--不是必须写 因为lua的特性 不存在声明变量的概念
--声明的目的 是为了别人看代码时，知道这个表（对象）
--关联的面板对象
-- MainPanel.panelObj = nil
--对应的面板控件
-- MainPanel.btnRole = nil
-- MainPanel.btnSkill = nil

--初始化方法
-- function MainPanel:Init()
function MainPanel:Init(name)
    -- if self.panelObj ~= nil then
    --     return
    -- end
    self.base.Init(self, name)
    --实例化面板对象
    -- self.panelObj = ABMgr.GetInstance():LoadRes("ui", "MainPanel", typeof(GameObject))
    -- self.panelObj.transform:SetParent(Canvas, false)
    --找控件
    -- self.btnRole = self.panelObj.transform:Find("RoleBtn"):GetComponent(typeof(Button))
    -- self.btnSkill = self.panelObj.transform:Find("SkillBtn"):GetComponent(typeof(Button))
    --添加监听
    --如果直接.传入自己的函数 那么在函数内部，无法使用self获取内容
    -- self.btnRole.onClick:AddListener(function()
    if self.isInitEvent == false then
        self:GetControl("btnRole", "Button").onClick:AddListener(function()
            self:BtnRoleClick()
        end)
        self.isInitEvent = true
    end
end

-- function MainPanel:ShowSelf()
--     self:Init()
--     self.panelObj:SetActive(true)
-- end

-- function MainPanel:HideSelf()
--     self.panelObj:SetActive(false)
-- end

function MainPanel:BtnRoleClick()
    BagPanel:ShowSelf("BagPanel")
end
