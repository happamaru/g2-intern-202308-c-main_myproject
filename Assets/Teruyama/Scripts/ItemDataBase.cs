using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class ItemDataBase : ScriptableObject
{
   public List<ItemData> itemDatas;
}

[Serializable]
public class ItemData{
    public string Name;
    public Sprite Image;
    public GameObject Prefab;
    public float Mass;
    public int Score;
    public float scale = 0.3f;
}
