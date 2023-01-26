using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : ScriptableObject
{
    public string Name;

    public enum ObjectTypeEnum { Sitting, LightStand, Table, Detail, plant, Light, Tools}
    public ObjectTypeEnum ObjectType = new ObjectTypeEnum();

    public Sprite Icon;
    public GameObject objectPrefab;
    public Vector3 positionOffset = new Vector3();
    public Vector3 rotationOffset = new Vector3();
    public Vector3 scaleOffset = new Vector3();
}
