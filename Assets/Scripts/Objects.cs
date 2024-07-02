using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public float points;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        gameManager.Point(other.gameObject, this.gameObject, points);
    }

    void OnParticleCollision(GameObject other)
    {
        gameManager.Point(other, this.gameObject, points);
    }   
}
