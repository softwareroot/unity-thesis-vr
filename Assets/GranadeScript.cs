using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;

public class GranadeScript : MonoBehaviour
{

    public float timeDelay = 2f;
    private float startTimer;

    public int damage = 10;
    public float explosiveForce = 20f;
    public float explosiveRadius = 15f;

    void Start() { startTimer = 0; }

    void Update() {
        startTimer += Time.deltaTime;

        if (startTimer >= timeDelay)
        {
            startTimer = 0;
            Explode();
        }
    }

    private void Explode()
    {
        
    }
}
