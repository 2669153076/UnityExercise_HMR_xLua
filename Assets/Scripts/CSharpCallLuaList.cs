﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public static class CSharpCallLuaList
{
    [CSharpCallLua]
    public static List<Type> cSharpCallLuaList = new List<Type>();
}