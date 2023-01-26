using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class GameManagerData : ScriptableObject
{


    public List<ColorData> ColorsList = new List<ColorData>();
    public List<ObjectData> ObjectsList = new List<ObjectData>();
    public List<MaterialData> MaterialsList = new List<MaterialData>();

#if UNITY_EDITOR
    [MenuItem("Window/MyEditor/Detect All Datas")]
    public void DetectAllDatas()
    {
        InitLists();

        DetectAllColorsDatas();
        DetectAllObjectsDatas();
        DetectAllMaterialsDatas();

        Save();
    }

    private void InitLists()
    {
        if (ColorsList == null)        
            ColorsList = new List<ColorData>();
        if (ObjectsList == null)
            ObjectsList = new List<ObjectData>();
    }

    public void DetectAllColorsDatas()
    {
        string[] guids = AssetDatabase.FindAssets("t:ObjectData", null);
        foreach (string guid in guids)
        {
            ObjectData asset = (ObjectData)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(ObjectData));

            if (ObjectsList.Contains(asset) == false){
                ObjectsList.Add(asset);
            }
        }
    }

    public void DetectAllMaterialsDatas()
    {
        string[] guids = AssetDatabase.FindAssets("t:MaterialData", null);
        foreach (string guid in guids)
        {
            MaterialData asset = (MaterialData)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(MaterialData));

            if (MaterialsList.Contains(asset) == false)
            {
                MaterialsList.Add(asset);
            }
        }
    }

    public void DetectAllObjectsDatas()
    {
        string[] guids = AssetDatabase.FindAssets("t:ColorData", null);
        foreach (string guid in guids)
        {
            ColorData asset = (ColorData)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(ColorData));

            if (ColorsList.Contains(asset) == false)
            {
                ColorsList.Add(asset);
            }
        }
    }


    public void Save()
    {
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
#endif
}
