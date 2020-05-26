using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject painelCompleto;

    public bool isPaused = false;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Pause()
    {
        if (isPaused)
        {
            painelCompleto.SetActive(false);
            isPaused = false;
        }
        else
        {
            painelCompleto.SetActive(true);
            isPaused = true;
        }
        
    }
}
