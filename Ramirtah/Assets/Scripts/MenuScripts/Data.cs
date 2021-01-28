using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//This is code on what exact data to retrieve from the database
public class Data
{
    public string stringFunText;

    public Data()
    {
        stringFunText = MenuFunnyText.menuStringText;
    }
}
