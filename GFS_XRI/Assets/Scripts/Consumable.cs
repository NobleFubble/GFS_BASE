using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] GameObject[] portions;
    [SerializeField] int index = 0;

    public bool IsFinished => index == portions.Length;
    AudioSource _audioSource;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        SetVisuals();
    }

    void OnValidate()
    {
        SetVisuals();
    }

    [ContextMenu(itemName:"Consume")]

    public void Consume()
    {
        if(!IsFinished)
        {
            _audioSource.Play();
            index++;
            SetVisuals();
        }
    }


    void SetVisuals()
    {
        for (int i = 0; i < portions.Length; i++)
        {
            portions[i].SetActive(i == index);
        }
    }
}
