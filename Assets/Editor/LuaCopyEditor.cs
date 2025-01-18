using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LuaCopyEditor : Editor
{
    [MenuItem("XLua/自动生成txt后缀的Lua文件")]
    public static void CopyLuaToTxt()
    {
        string path = Application.dataPath + "/Lua/";
        if (!Directory.Exists(path))
        {
            Debug.LogError("文件夹不存在");
            return;
        }
        string[] strs = Directory.GetFiles(path, "*.lua");
        string newPath = Application.dataPath + "/LuaTxt/";
        if (!Directory.Exists(newPath))
        {
            Directory.CreateDirectory(newPath);
        }
        else
        {
            string[] oldFileStrs = Directory.GetFiles(newPath, "*.txt");
            for (int i = 0; i < oldFileStrs.Length; i++)
            {
                File.Delete(oldFileStrs[i]);
            }
        }

        List<string> newFileNameList = new List<string>();
        string fileName;
        for (int i = 0; i < strs.Length; i++)
        {
            fileName = newPath + strs[i].Substring(strs[i].LastIndexOf("/" )+ 1) + ".txt";
            newFileNameList.Add(fileName);
            File.Copy(strs[i], fileName);
        }

        AssetDatabase.Refresh();

        for (int i = 0; i < newFileNameList.Count; i++)
        {
            //该API传入的路径 必须是 相对Assets文件夹的 Assets/.../...
            AssetImporter importer = AssetImporter.GetAtPath(newFileNameList[i].Substring(newFileNameList[i].IndexOf("Assets")));
            if (importer != null)
            {
                importer.assetBundleName = "lua";
            }
        }
    }
}
