using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public int itemAmount;
    public string itemType;
    public Sprite icon;
    public int stacksize;
    
    [TextArea]
    public string description;
}
