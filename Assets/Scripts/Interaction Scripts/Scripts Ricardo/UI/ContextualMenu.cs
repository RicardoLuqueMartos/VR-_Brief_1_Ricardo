using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextualMenu : MonoBehaviour
{
    public enum MenuTypeEnum { Object, Light, Environment }
    public MenuTypeEnum MenuType = new MenuTypeEnum();

    public GameManagerData gameManager;
//
    public Text objectTypeText;

    public float CurrentRotation;

    public GameObject ListContent;
    public GameObject ObjectContentPrefab;
    public GameObject MaterialContentPrefab;
    public GameObject RotationMenu;

    public ObjectSpawner SelectedObjectSpawner;
    public EnvironmentElement SelectedEnvironmentElement;

    public List<GameObject> ChoicesList = new List<GameObject>();

    public GameObject RemoveButton;

    public void CreateListContent(ObjectSpawner selectedSpawner)
    {
        ManageRemoveButton();

        CleanChoices();
        for (int i = 0; i < gameManager.ObjectsList.Count; i++)
        {
            if (selectedSpawner.ObjectType == gameManager.ObjectsList[i].ObjectType)
            {
                GameObject content = (GameObject)Instantiate(ObjectContentPrefab);
                content.transform.parent = ListContent.transform;
                ObjectData data = gameManager.ObjectsList[i];

                content.GetComponent<LinkToObject>().LinkedObject = data;

                ChoicesList.Add(content);

                content.GetComponent<Image>().sprite = data.Icon;
                content.SetActive(true);
            }
        }
    }

    private void ManageRemoveButton()
    {
        if (SelectedObjectSpawner != null && SelectedObjectSpawner.assignedObject != null)
            RemoveButton.SetActive(true);
        else if(SelectedObjectSpawner != null && SelectedObjectSpawner.assignedObject == null)
            RemoveButton.SetActive(false);
    }

    public void CreateListContent(EnvironmentElement element)
    {
        RemoveButton.SetActive(false);

        CleanChoices();
        for (int i = 0; i < gameManager.MaterialsList.Count; i++)
        {
            if (element.MaterialType == gameManager.MaterialsList[i].MaterialType)
            {
                GameObject content = (GameObject)Instantiate(MaterialContentPrefab);
                content.transform.parent = ListContent.transform;
                MaterialData data = gameManager.MaterialsList[i];

                content.GetComponent<LinkToMaterial>().LinkedMaterial = data;

                ChoicesList.Add(content);

            //    data.

                content.GetComponent<LinkToMaterial>().rawImage.texture = data.material.mainTexture;
                content.SetActive(true);
            }
        }
    }

    void CleanChoices()
    {
        for (int i = 0; i < ChoicesList.Count; i++)
        {
            Destroy(ChoicesList[i]);
        }
        ChoicesList.Clear();
    }

    public void AssignObjctToSelectedSpawner(LinkToObject linkToObject)
    {
        SelectedObjectSpawner.AssignOtherObject(linkToObject.LinkedObject);
        RemoveButton.SetActive(true);

    }

    public void AssignMaterialToSelectedElement(LinkToMaterial link)
    {
        SelectedEnvironmentElement.AssignMaterialToElement(link.LinkedMaterial);

    }

    public void RemoveAssignedObject()
    {
        SelectedObjectSpawner.RemoveAssignedObject();
    }
}
