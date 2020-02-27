using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeScript : MonoBehaviour
{

    [SerializeField] private GameObject gameplayCanvas;
    
    void Start()
    {
        if (Scope.isScoped)
        {
            gameplayCanvas.SetActive(false);
        } else
        {
            gameplayCanvas.SetActive(true);
        }
    }

    
    void Update()
    {
        if (Scope.isScoped)
        {
            gameplayCanvas.SetActive(false);
        } else
        {
            gameplayCanvas.SetActive(true);
        }        
    }
}
