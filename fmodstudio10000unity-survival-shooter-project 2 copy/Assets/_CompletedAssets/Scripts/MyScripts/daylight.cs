using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daylight : MonoBehaviour
{
    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        
    }

    public void FadeLight()
    {
        StartCoroutine("FadeSkybox");
        //intensity = 3;
    }

    IEnumerator FadeSkybox()
    {
        float exposure = 0;
        for (int i = 0; i <= 30; i++)
        {
            
            yield return new WaitForSeconds(0.5f);
            exposure += 0.1f;
            
            myLight.intensity = exposure;

        }
    }
}
