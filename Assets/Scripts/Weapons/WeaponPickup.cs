using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    [SerializeField] private Transform trans_wep_0, trans_wep_1, trans_wep_2;
    
    void Start()
    {
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            if (gameObject.tag == "col_gun0")
            {
                WeaponSwitching.HAS_MACHINE_GUN = true;
                
                WeaponSwitching.index          = 0;
                WeaponSwitching.selectedWeapon = 0;
                WeaponSwitching.SwitchWeapons(trans_wep_0, trans_wep_1, trans_wep_2);
            } else if (gameObject.tag == "col_gun1")
            {
                WeaponSwitching.HAS_SNIPER_RIFLE = true;
                
                WeaponSwitching.index          = 1;
                WeaponSwitching.selectedWeapon = 1;
                WeaponSwitching.SwitchWeapons(trans_wep_0, trans_wep_1, trans_wep_2);
            } else if (gameObject.tag == "col_gun2")
            {
                WeaponSwitching.HAS_GRANADE_LAUNCHER = true;
                
                WeaponSwitching.index          = 2;
                WeaponSwitching.selectedWeapon = 2;
                WeaponSwitching.SwitchWeapons(trans_wep_0, trans_wep_1, trans_wep_2);
            }
            Destroy(gameObject);
        }
    }
}
