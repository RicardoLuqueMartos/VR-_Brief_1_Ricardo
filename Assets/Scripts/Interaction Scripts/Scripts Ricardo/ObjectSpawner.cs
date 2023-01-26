using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectData;

public class ObjectSpawner : MonoBehaviour, UsableObjectInterface
{
    public ObjectData.ObjectTypeEnum ObjectType = new ObjectData.ObjectTypeEnum();

    [SerializeField] public ObjectData assignedObject;
    [SerializeField] public GameObject spawnedGameObject;
    [SerializeField] private ColorData assignedColorData;

    [SerializeField] private ContextualMenu contextualMenu;

    public List<ObjectSpawner> SpawnersGroup = new List<ObjectSpawner>();

    public GameObject PlaceholderIcon;
    public UIMenuManager menuManager;

    private void Start()
    {
        contextualMenu = FindObjectOfType<ContextualMenu>();
    }

    public void OnEnable()
    {
        if (spawnedGameObject == null)
            transform.GetComponent<MeshRenderer>().enabled = false;
        else transform.GetComponent<MeshRenderer>().enabled = true;
        if (menuManager == null) menuManager = FindObjectOfType<UIMenuManager>();
    }

    public void UseObject(GameObject hitObject)
    {
        if (menuManager == null) menuManager = FindObjectOfType<UIMenuManager>();
        menuManager.HighlightedObject = hitObject.transform.gameObject;
        //    hit.transform.GetComponent<MeshRenderer>().enabled = true;

        // open contextual menu
    //    if (Input.GetMouseButtonDown(0))
    //    {

        menuManager.contextualMenu.MenuType = ContextualMenu.MenuTypeEnum.Object;
        menuManager.contextualMenu.objectTypeText.text = menuManager.contextualMenu.MenuType.ToString();

        menuManager.contextualMenu.SelectedObjectSpawner = hitObject.transform.GetComponent<ObjectSpawner>();
        menuManager.OpenContextualMenu(hitObject.transform.GetComponent<ObjectSpawner>());
    //    }
        
    }

    void AssignOtherColor(ColorData colorData)
    {
        assignedColorData = colorData;
        ApplyColor();
    }

    void ApplyColor()
    {
        // TODO

    }

    public void AssignOtherObjectsToSpawnerGroup(ObjectData objectData)
    {
        if (SpawnersGroup.Contains(this) == false)        
            AssignObject(objectData);

        for (int i = 0; i < SpawnersGroup.Count; i++)
        {
            SpawnersGroup[i].AssignObject(objectData);            
        }
    }

    public void AssignOtherObject(ObjectData objectData)
    {
        if (SpawnersGroup.Count == 0)
        {
            AssignObject(objectData);
        }
        else AssignOtherObjectsToSpawnerGroup(objectData);
    }
    public void AssignObject(ObjectData objectData)
    {
        if (menuManager == null) menuManager = FindObjectOfType<UIMenuManager>();

        assignedObject = objectData;
        DestroyPreviousSpawnedGameObject();           
     //   SpawnObjectPrefab(objectData.objectPrefab);
        spawnedGameObject = (GameObject)Instantiate(objectData.objectPrefab, transform.position, transform.rotation);
        HideIcon();
        if (objectData.ObjectType == ObjectTypeEnum.Light)
        {
         //   menuManager.LightsList.Add(spawnedGameObject.GetComponentInChildren<InteractableLight>());
        }

        ApplyOffsets();
    }

  /*  void SpawnObjectPrefab(GameObject objectToSpawn)
    {
        spawnedGameObject = (GameObject)Instantiate(objectToSpawn, transform.position, transform.rotation);
        HideIcon();
    }*/

    public void RemoveAssignedObject()
    {
        if (SpawnersGroup.Count == 0)
        {
            assignedObject = null;
            DestroyPreviousSpawnedGameObject();
        }
        else
        {
            RemoveGroupObject();
        }
    }

    public void RemoveGroupObject()
    {
        if (SpawnersGroup.Contains(this) == false)
            RemoveObject();

        for (int i = 0; i < SpawnersGroup.Count; i++)
        {
            SpawnersGroup[i].RemoveObject();
        }
    }

    public void RemoveObject()
    {
        assignedObject = null;
        DestroyPreviousSpawnedGameObject();
    }

    void DestroyPreviousSpawnedGameObject()
    {
        if (spawnedGameObject != null)
            Destroy(spawnedGameObject);

        ShowIcon();
    }

    void ApplyOffsets()
    {
        spawnedGameObject.transform.position = spawnedGameObject.transform.position + assignedObject.positionOffset;

        spawnedGameObject.transform.rotation =
            new Quaternion(spawnedGameObject.transform.rotation.x + assignedObject.rotationOffset.x,
             spawnedGameObject.transform.rotation.y + assignedObject.rotationOffset.y,
              spawnedGameObject.transform.rotation.z + assignedObject.rotationOffset.z,
               spawnedGameObject.transform.rotation.w);

        float x = assignedObject.scaleOffset.x;
        float y = assignedObject.scaleOffset.y;
        float z = assignedObject.scaleOffset.z;

        if (x == 0) x = 1;
        if (y == 0) y = 1;
        if (z == 0) z = 1;

        spawnedGameObject.transform.localScale =
            new Vector3(spawnedGameObject.transform.localScale.x * x,
             spawnedGameObject.transform.localScale.y * y,
             spawnedGameObject.transform.localScale.z * z);
    }

    void HideIcon()
    {
        PlaceholderIcon.SetActive(false);
    }

    void ShowIcon()
    {
        PlaceholderIcon.SetActive(true);
    }
}
