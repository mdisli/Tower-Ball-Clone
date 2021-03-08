using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightControllerScript : MonoBehaviour
{
    bool isTouching;
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION ---> " + other.transform.tag);
    }

}
