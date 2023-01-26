using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.Universal;

public class UIMenuManager : MonoBehaviour
{
    public GameObject gameMenu;
    public FlexibleColorPicker PickColorMenu;

    public ContextualMenu contextualMenu;

    public GameObject HighlightedObject;      


    public void OnEnable()
    {
        if (PickColorMenu == null)
            PickColorMenu = FindObjectOfType<FlexibleColorPicker>();

    }

    public void OpenGameMenu()
    {
        if (gameMenu != null)
        {
            gameMenu.SetActive(true); 
        }
    }

    public void CloseGameMenu()
    {
        if (gameMenu != null)
        {
            gameMenu.SetActive(false);
        }
    }

    public void OpenContextualMenu(EnvironmentElement element)
    {
        if (gameMenu != null)
        {
            contextualMenu.SelectedEnvironmentElement = element;
            contextualMenu.gameObject.SetActive(true);
            contextualMenu.CreateListContent(element);

            UnlockMouse();
        }
    }


    public void OpenContextualMenu(ObjectSpawner selectedSpawner)
    {
        if (gameMenu != null)
        {
            contextualMenu.SelectedObjectSpawner = selectedSpawner;
            contextualMenu.gameObject.SetActive(true);
            contextualMenu.CreateListContent(selectedSpawner);

            UnlockMouse();
        }
    }

    public void OpenContextualMenu(LightData selectedSpawner)
    {
        if (gameMenu != null)
        {
            /*    contextualMenu.SelectedObjectSpawner = selectedSpawner;
                contextualMenu.gameObject.SetActive(true);
                contextualMenu.CreateListContent();*/

            UnlockMouse();
        }
    }

    public void CloseContextualMenu()
    {
        contextualMenu.gameObject.SetActive(false);

        LockMouse();
    }

    public void OpenPickColor(ObjectSpawner selectedSpawner)
    {
        contextualMenu.SelectedObjectSpawner = selectedSpawner;
        PickColorMenu.gameObject.SetActive(true);

        UnlockMouse();
    }

    public void ClosePickColor()
    {
        PickColorMenu.gameObject.SetActive(false);
       LockMouse();
        contextualMenu.SelectedObjectSpawner = null;

    }

    public void ApplyColor()
    {
        ChangeLightColor(contextualMenu.SelectedObjectSpawner);
    }

    public void ChangeLightColor(ObjectSpawner spawner)
    {
        Color color = PickColorMenu.GetColorFullAlpha();

        for (int i = 0; i < spawner.SpawnersGroup.Count; i++)
        {
            if (spawner.SpawnersGroup[i].spawnedGameObject 
                && spawner.SpawnersGroup[i].spawnedGameObject.GetComponent<InteractableLight>() != null)
            {
                spawner.SpawnersGroup[i].spawnedGameObject.GetComponent<InteractableLight>().light.color = color;
                spawner.SpawnersGroup[i].spawnedGameObject.GetComponent<InteractableLight>().EmissionRenderer.material.SetColor("_EmissionColor", color);
            }
        }
    }

    public void TurnLeft()
    {
        contextualMenu.CurrentRotation = contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation.y;

        contextualMenu.CurrentRotation = contextualMenu.CurrentRotation + 45;
        if (contextualMenu.CurrentRotation >= 360) contextualMenu.CurrentRotation = 0;


        if (contextualMenu.SelectedObjectSpawner != null
            && contextualMenu.SelectedObjectSpawner.spawnedGameObject != null)
        {
            contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation =
                            new Quaternion(contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation.x,
                            contextualMenu.CurrentRotation,
                            contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation.z,
                            contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation.w);
        }
    }
    public void TurnRight()
    {
        contextualMenu.CurrentRotation = contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation.y;

        contextualMenu.CurrentRotation = contextualMenu.CurrentRotation - 45;
        if (contextualMenu.CurrentRotation >= -360) contextualMenu.CurrentRotation = 0;

        if (contextualMenu.SelectedObjectSpawner != null
            && contextualMenu.SelectedObjectSpawner.spawnedGameObject != null)
        {
            contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation =
                new Quaternion(contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation.x,
                contextualMenu.CurrentRotation,
                contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation.z,
                contextualMenu.SelectedObjectSpawner.spawnedGameObject.transform.localRotation.w);
        }
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
