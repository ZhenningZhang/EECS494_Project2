using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighInput : MonoBehaviour
{
    GameObject torchLight;
    // Start is called before the first frame update
    void Start()
    {
        torchLight = GetComponentInChildren<Light>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            torchLight.SetActive(true);
        }
        else
        {
            torchLight.SetActive(false);
        }
    }
}
