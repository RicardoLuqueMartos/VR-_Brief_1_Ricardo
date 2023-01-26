using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLightController : MonoBehaviour
{
    private float speed;

    [SerializeField]
    private float rotateSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(-0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.eulerAngles += new Vector3 (0f, speed * rotateSpeed,0f);
    }
}
