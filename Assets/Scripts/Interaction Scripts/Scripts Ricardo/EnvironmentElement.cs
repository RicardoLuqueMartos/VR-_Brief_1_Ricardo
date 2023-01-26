using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static MaterialData;

public class EnvironmentElement : MonoBehaviour
{
    public MaterialData.MaterialTypeEnum MaterialType = new MaterialData.MaterialTypeEnum();
    public MaterialData assignedMaterialData;
    public GameObject OriginePrefab;
    public void AssignMaterialToElement(MaterialData data)
    {
        // get parent
        EnvironmentGroup group = transform.GetComponentInParent<EnvironmentGroup>();


        assignedMaterialData = data;
        // get all children and apply mat
        List<EnvironmentElement> elementsList = group.transform.GetComponentsInChildren<EnvironmentElement>().ToList();
    //    List<EnvironmentElement> elements2List = transform.GetComponentsInParent<EnvironmentElement>().ToList();

        for (int i = 0; i < elementsList.Count; i++)
        {
            if (elementsList[i].MaterialType == data.MaterialType)
            {
                
                if (elementsList[i].GetComponent<MeshRenderer>() != null) elementsList[i].GetComponent<MeshRenderer>().material = data.material;
            }
        }

    }
}
