--常用别名定义

--准备之前导入的脚本
require("Object")   --面向对象相关，定义类
require("SplitTools")   --字符串拆分
Json = require("JsonUtility") --Json解析

--Unity相关
GameObject = CS.UnityEngine.GameObject
Resources = CS.UnityEngine.Resources
Transform = CS.UnityEngine.Transform
RectTransform = CS.UnityEngine.RectTransform
SpriteAtlas = CS.UnityEngine.U2D.SpriteAtlas --图集对象类
Vector3 = CS.UnityEngine.Vector3
Vector2 = CS.UnityEngine.Vector2

--UI相关
UI = CS.UnityEngine.UI
Image = UI.Image
Button = UI.Button
Text = UI.Text
Toggle = UI.Toggle
ScrollRect = UI.ScrollRect

--自己写的C#脚本相关
ABMgr = CS.ABMgr
