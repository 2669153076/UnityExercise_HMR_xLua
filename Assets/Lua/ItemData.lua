local itemTxtFile = ABMgr.GetInstance():LoadRes("json", "ItemData", typeof(TextAsset))
print(itemTxtFile.text)
local itemList = Json.decode(itemTxtFile.text)

--读取出来的是一个数组结构的数据
--创建一个新表转存一次
ItemData = {}
for _, value in pairs(itemList) do
    ItemData[value.id] = value
end

for key, value in pairs(ItemData) do
    print(key, value)
end
