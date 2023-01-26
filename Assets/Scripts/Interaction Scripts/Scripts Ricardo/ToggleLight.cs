using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour, UsableObjectInterface
{
    public UIMenuManager menuManager;

    public ObjectSpawner ControledSpawner;

    public void OnEnable()
    {      
        if (menuManager == null) menuManager = FindObjectOfType<UIMenuManager>();
    }

    public void UseObject(GameObject hitObj)
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToogleLights();
        }
    }   

    public void ToogleLights()
    {
        menuManager.contextualMenu.SelectedObjectSpawner = ControledSpawner;
        if (ControledSpawner.SpawnersGroup.Count > 0)
        {
            for (int i = 0; i < ControledSpawner.SpawnersGroup.Count; i++)
            {
                if (ControledSpawner.SpawnersGroup[i].spawnedGameObject != null) {
                    InteractableLight iL = ControledSpawner.SpawnersGroup[i].spawnedGameObject.GetComponent<InteractableLight>();
                    if (iL != null)
                    {
                        if (iL.light.enabled == true)
                        {
                            iL.light.enabled = !iL.light.enabled;
                            iL.EmissionRenderer.material.DisableKeyword("_EMISSION");
                        }
                        else
                        {
                            iL.light.enabled = !iL.light.enabled;
                            iL.EmissionRenderer.material.EnableKeyword("_EMISSION");
                        }
                    }
                }
            }
        }
        menuManager.contextualMenu.SelectedObjectSpawner = null;
    }

    
}
