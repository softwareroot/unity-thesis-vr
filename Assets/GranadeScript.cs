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

    void Update() {
        startTimer += Time.deltaTime;

        if (startTimer >= timeDelay) {
            Explode();
        }
    }

    private void Explode()
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, explosiveRadius);

        for (int i = 0; i < coll.Length; i++)
        {
            //coll[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, transform.position, explosiveRadius);
        }
    }
}
