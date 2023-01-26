using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchroPosRot : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float lookHeight = 1;

    [SerializeField] private GameObject PosSource;
    [SerializeField] private GameObject PosFollower;

    [SerializeField] private GameObject RotSource;
    [SerializeField] private GameObject RotFollower;
    #endregion Variables

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //    lookHeight = characterController.height - 0.20f;
        Vector3 pos = new Vector3 (PosSource.transform.position.x, PosSource.transform.position.y+ (lookHeight), PosSource.transform.position.z);
        Quaternion rot = Quaternion.LookRotation(RotSource.transform.forward);

        PosFollower.transform.position = pos;
        RotFollower.transform.rotation = rot;

    }
}
