using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{

    [SerializeField] public GameObject canvasGamplay;

    void Update()
    {
        if (Scope.isScoped)
        {
            canvasGamplay.SetActive(false);
        } else
        {
            canvasGamplay.SetActive(true);
        }
    }
}
