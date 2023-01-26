using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialData : ScriptableObject
{
    public string Name;

    public enum MaterialTypeEnum { Wall, Floor, Celling }
    public MaterialTypeEnum MaterialType = new MaterialTypeEnum();

    public Material material;
       
}
