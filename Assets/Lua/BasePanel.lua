Object:subClass("BasePanel")

BasePanel.panelObj = nil
BasePanel.controls = {}
BasePanel.isInitEvent = false --UI组件事件添加标识

function BasePanel:Init(name)
    if self.panelObj == nil then
        self.panelObj = ABMgr.GetInstance():LoadRes("ui", name, typeof(GameObject))
        self.panelObj.transform:SetParent(Canvas, false)

        --寻找所有UI控件
        local allControls = self.panelObj:GetComponentsInChildren(typeof(UIBehaviour))

        for i = 0, allControls.Length - 1 do
            local controlName = allControls[i].name
            --按照名字规则查找控件
            if string.find(controlName, "btn") ~= nil or
                string.find(controlName, "tog") ~= nil or
                string.find(controlName, "img") ~= nil or
                string.find(controlName, "sv") ~= nil or
                string.find(controlName, "txt") ~= nil then
                --得到控件类名
                local typeName = allControls[i]:GetType().Name

                --避免出现一个对象上 挂载多个UI控件 出现覆盖问题
                --让其都会被存到一个容器中
                if self.controls[controlName] ~= nil then
                    self.controls[controlName][typeName] = allControls[i]
                else
                    self.controls[controlName] = { [typeName] = allControls[i] }
                end
            end
        end
    end
end

--根据控件名和类型 获取控件
function BasePanel:GetControl(name, typeName)
    if self.controls[name] ~= nil then
        local sameNameControls = self.controls[name]
        if sameNameControls[typeName] ~= nil then
            return sameNameControls[typeName]
        end
    end
    return nil
end

function BasePanel:ShowSelf(name)
    self:Init(name)
    self.panelObj:SetActive(true)
end

function BasePanel:HideSelf()
    self.panelObj:SetActive(false)
end
