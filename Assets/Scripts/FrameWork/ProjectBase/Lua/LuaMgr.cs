using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

namespace Custom.BaseFramework
{
    public class LuaMgr : BaseManager<LuaMgr>
    {
        private LuaEnv luaEnv;

        public LuaTable Global
        {
            get
            {
                return this.luaEnv.Global;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if(this.luaEnv != null)
            {
                return;
            }
            luaEnv = new LuaEnv();
            luaEnv.AddLoader(CustomFlieLoader);
            luaEnv.AddLoader(CustomABLoader);
        }

        /// <summary>
        /// 通过文件流获取Lua脚本
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private byte[] CustomFlieLoader(ref string filepath)
        {
            string path = Application.dataPath + "/Lua/" + filepath + ".lua";
            if(!File.Exists(path))
            {
                Debug.LogWarning("通过File加载Lua文件出错：" + filepath);
                return null;
            }

            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// 通过AB包加载Lua脚本
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private byte[] CustomABLoader(ref string filepath)
        {
            TextAsset luaText = ABMgr.GetInstance().LoadRes<TextAsset>("lua", filepath + ".lua");
            if(luaText == null)
            {
                Debug.LogWarning("通过AB包加载Lua文件出错：" + filepath);
                return null;
            }

            return luaText.bytes;
        }




        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="str">lua执行文件的命令</param>
        public void DoString(string str)
        {
            if (luaEnv == null)
            {
                Debug.LogError("解析器未初始化");
                return;
            }
            luaEnv.DoString(str);
        }
        /// <summary>
        /// 执行文件
        /// </summary>
        /// <param name="filename">lua文件名</param>
        public void DoLuaFile(string filename)
        {
            if (luaEnv == null)
            {
                Debug.LogError("解析器未初始化");
                return;
            }
            DoString(string.Format($"require('{filename}')"));
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Tick()
        {
            if (luaEnv == null)
            {
                Debug.LogError("解析器未初始化");
                return;
            }
            luaEnv.Tick();
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            if(luaEnv == null)
            {
                Debug.LogError("解析器未初始化");
                return;
            }

            luaEnv.Dispose();
            luaEnv = null;
        }
    }
}