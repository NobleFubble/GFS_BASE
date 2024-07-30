using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDetect : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Smoke")
        {
            Debug.Log("Smoke Detected");
        }
    }
}
