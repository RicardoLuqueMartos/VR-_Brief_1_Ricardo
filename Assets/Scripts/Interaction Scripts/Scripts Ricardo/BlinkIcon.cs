using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class BlinkIcon : MonoBehaviour
{
    public UnityEngine.UI.Image Icon;
    public float BlinkSpeed = 0.1f;
    float blinkProgress = 0f;

    bool up = true;

    private void Start()
    {
    //    Icon = GetComponent<UnityEngine.UI.Image>();
    }

    private void OnEnable()
    {
        //   Icon = GetComponent<UnityEngine.UI.Image>();
        transform.SetAsFirstSibling();
    }

    private void Update()
    {
        if (blinkProgress <= 1f && up)                   
            blinkProgress += Time.deltaTime;

        else if (blinkProgress >= 0 && !up)
            blinkProgress -= Time.deltaTime;
                    
        Icon.color = new UnityEngine.Color(Icon.color.r, Icon.color.g, Icon.color.b, blinkProgress);

        if (blinkProgress >= 1f && up)
        {
            up = false;
            blinkProgress = 1;
        }
        else if (blinkProgress <= 0 && !up)
        {
            up = true;
            blinkProgress = 0;
        }
    }
}
