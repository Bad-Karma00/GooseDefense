using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable] // This makes the class able to be serialized into a JSON
public class User
{
    public string name;
    public int level;

    public User(string name, int level)
    {
        this.name = name;
        this.level = level;
       
    }
}
