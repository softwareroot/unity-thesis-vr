using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGranade : MonoBehaviour {

    public GameObject granadeModel;
    public Transform hand;
    public float throwForce = 10f;

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            GameObject granade = Instantiate(granadeModel, hand.position, hand.rotation) as GameObject;
            granade.GetComponent<Rigidbody>().AddForce((Quaternion.AngleAxis(-90, Vector3.up) * hand.forward), ForceMode.Impulse);
        }
    }
}
