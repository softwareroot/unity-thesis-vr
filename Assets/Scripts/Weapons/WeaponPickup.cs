using UnityEngine;

public class WeaponPickup : MonoBehaviour {

    // Variables
    
    public GameObject weapon;
    public bool weaponEquipped;

    // Constants

    private const int   WP_MACHINE_GUN = 0,
                        WP_SNIPER_RIFLE = 1;

    void Start() { weapon.gameObject.SetActive(false); }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            if (weapon.gameObject.tag == "Gun0") WeaponSwitching.selectedWeapon = 0;
            else if (weapon.gameObject.tag == "Gun1") WeaponSwitching.selectedWeapon = 1;
        
            weapon.gameObject.SetActive(true);
            weaponEquipped = true;
            Destroy(gameObject);
        }
    }
}
