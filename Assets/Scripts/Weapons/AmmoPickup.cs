using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

    [SerializeField]
    private GameObject gun;
    private GunScript gunScript;
    
    private void Start() {
        gunScript = gun.GetComponent<GunScript>();
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            gunScript.addMag();
            Destroy(gameObject);
        }
    }

}
