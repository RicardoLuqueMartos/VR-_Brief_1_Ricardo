using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateDatas : MonoBehaviour
{
    [MenuItem("Window/MyEditor/Create New Material Data")]
    public static void CreateMaterial()
    {
        // create a new Color asset
        MaterialData newData = ScriptableObject.CreateInstance<MaterialData>();
        // write new asset to the project
        AssetDatabase.CreateAsset(newData, "Assets/Datas/Materials/New MaterialData.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }


    [MenuItem("Window/MyEditor/Create New Color Data")]
    public static void CreateColor()
    {
        // create a new Color asset
        ColorData newData = ScriptableObject.CreateInstance<ColorData>();
        // write new asset to the project
        AssetDatabase.CreateAsset(newData, "Assets/Datas/Colors/New ColorData.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    [MenuItem("Window/MyEditor/Create New Game Manager DB")]
    public static void CreateGameManager()
    {
        // create a new GameManage asset
        GameManagerData newData = ScriptableObject.CreateInstance<GameManagerData>();
        // write new asset to the project
        AssetDatabase.CreateAsset(newData, "Assets/Datas/Managers/New GameManagerData.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    [MenuItem("Window/MyEditor/Create New Object Data")]
    public static void CreateObjectData()
    {
        // create a new Object asset
        ObjectData newData = ScriptableObject.CreateInstance<ObjectData>();
        // write new asset to the project
        AssetDatabase.CreateAsset(newData, "Assets/Datas/Objects/New ObjectData.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
