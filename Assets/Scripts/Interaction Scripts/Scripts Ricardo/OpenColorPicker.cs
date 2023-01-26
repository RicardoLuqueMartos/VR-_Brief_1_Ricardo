using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenColorPicker : MonoBehaviour, UsableObjectInterface
{
    public UIMenuManager menuManager;

    public ObjectSpawner ControledSpawner;

    public void UseObject(GameObject hitObject)
    {
        if (ControledSpawner.SpawnersGroup.Count > 0
            && ControledSpawner.SpawnersGroup[0].spawnedGameObject != null)
        {
            menuManager.contextualMenu.SelectedObjectSpawner = ControledSpawner;
            OpenPickColor();
        }
    }

    void OpenPickColor()
    {
        menuManager.OpenPickColor(ControledSpawner);
    }
}
