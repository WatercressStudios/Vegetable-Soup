using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTile : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Object entered the trigger");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is within trigger");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited the trigger");
    }
}
