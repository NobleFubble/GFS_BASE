using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Objects objects;

    public ProgressBar progressBar;


    void Start()
    {
        progressBar = FindObjectOfType<ProgressBar>();
    }

    public void Point(GameObject other, GameObject self ,float points)
    {
        if (other.gameObject.tag == "NPC")
        {
            Debug.Log(self.gameObject.tag + " on NPC Detected");
            progressBar.SetProgress(points * 1.3f);
        }
        else if (other.gameObject.tag == "Environment")
        {
            Debug.Log(self.gameObject.tag + " on Environment Detected");
            progressBar.SetProgress(points * 1f);
        }
        else if (other.gameObject.tag == "Electronics")
        {
            Debug.Log(self.gameObject.tag + " on Electronics Detected");
            progressBar.SetProgress(points * 1.2f);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
