using System.Collections;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////

    public static int selectedWeapon = 2;
    public static bool HAS_MACHINE_GUN = false, HAS_SNIPER_RIFLE = false, 
        HAS_GRANADE_LAUNCHER = false;
    [SerializeField] public GameObject recoil_gun1;
    private Scope scope_script;
    private bool hasWeapons;
    
    ////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        if (!HAS_MACHINE_GUN && !HAS_SNIPER_RIFLE && !HAS_GRANADE_LAUNCHER)
        {
            hasWeapons = false;
        } else
        {
            hasWeapons = true;
        }
        
        scope_script = recoil_gun1.GetComponent<Scope>();
        
        if (hasWeapons) {
            SelectWeapon();
        }
    }

    void SelectWeapon() {

        int i = 0;
        
        foreach (Transform weapon in transform) {

            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }

    IEnumerator PrintHasWeapons()
    {
        //Debug.Log("Has Weapons:" + hasWeapons + "\nHas AK: " + HAS_MACHINE_GUN);
        yield return new WaitForSeconds(1000f);
    }
    
    void Update()
    {
        StartCoroutine(PrintHasWeapons());
        
        
        if (HAS_SNIPER_RIFLE || HAS_MACHINE_GUN || HAS_GRANADE_LAUNCHER)
        {
            hasWeapons = true;
        }

        if (hasWeapons)
        {
            int previousSelectedWeapon = selectedWeapon;
            
            /*
            if (Input.GetButtonDown("JoyButton3"))
            {
                if (selectedWeapon <= 0) selectedWeapon = transform.childCount - 1;
                else selectedWeapon--;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon >= transform.childCount - 1) selectedWeapon = 0;
                else selectedWeapon++;
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon <= 0) selectedWeapon = transform.childCount - 1;
                else selectedWeapon--;
            }
            */

            if (Input.GetKeyDown(KeyCode.Alpha1) && HAS_MACHINE_GUN) selectedWeapon = 0;
            if (Input.GetKeyDown(KeyCode.Alpha2) && HAS_SNIPER_RIFLE) selectedWeapon = 1;
            if (Input.GetKeyDown(KeyCode.Alpha3) && HAS_GRANADE_LAUNCHER) selectedWeapon = 2;
            if (previousSelectedWeapon != selectedWeapon) SelectWeapon();

            // Auto rifle
            if (selectedWeapon == 0 || selectedWeapon == 2)
            {
                scope_script.OnUscoped();
            }
        }
    }
}
