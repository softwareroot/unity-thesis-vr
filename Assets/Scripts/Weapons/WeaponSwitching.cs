using System.Collections;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////

    public static int selectedWeapon = 1;
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

    public void SelectWeapon() {

        int i = 0;
        
        foreach (Transform weapon in transform) {

            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }

    public static void SwitchWeapons(Transform transform_wep_0, Transform transform_wep_1, Transform transform_wep_2)
    {
        if (selectedWeapon == 0 && HAS_MACHINE_GUN)
        {
            transform_wep_0.gameObject.SetActive(true);
            transform_wep_1.gameObject.SetActive(false);
            transform_wep_2.gameObject.SetActive(false);
        }
        
        if (selectedWeapon == 1 && HAS_SNIPER_RIFLE)
        {
            transform_wep_0.gameObject.SetActive(false);
            transform_wep_1.gameObject.SetActive(true);
            transform_wep_2.gameObject.SetActive(false);
        }
        
        if (selectedWeapon == 2 && HAS_GRANADE_LAUNCHER)
        {
            transform_wep_0.gameObject.SetActive(false);
            transform_wep_1.gameObject.SetActive(false);
            transform_wep_2.gameObject.SetActive(true);
        }
    }
    
    
    public static int index = 0;
    void Update()
    {
        if (HAS_SNIPER_RIFLE || HAS_MACHINE_GUN || HAS_GRANADE_LAUNCHER) { hasWeapons = true; }

        if (hasWeapons)
        {
            int previousSelectedWeapon = selectedWeapon;
            
            // Different types of switching
            ControllerWeaponSwitch();
            ScrollWheelWeaponSwitch();
            NumpadWeaponSwitch();
            
            if (previousSelectedWeapon != selectedWeapon) SelectWeapon();
            if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (index == 0 && HAS_MACHINE_GUN) { selectedWeapon = 0; }
                if (index == 1 && HAS_SNIPER_RIFLE) { selectedWeapon = 1; }
                if (index == 2 && HAS_GRANADE_LAUNCHER) { selectedWeapon = 2; }
            }
            
            // Auto rifle
            if (selectedWeapon == 0 || selectedWeapon == 2) { scope_script.OnUscoped(); }
        }
    }

    private void ControllerWeaponSwitch()
    {
        if (Input.GetButtonDown("JoyButton3")) { IncreaseScroll(); }
    }

    private void ScrollWheelWeaponSwitch()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) { IncreaseScroll(); }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) { DecreaseScroll(); }
    }

    private void NumpadWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && HAS_MACHINE_GUN) selectedWeapon      = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2) && HAS_SNIPER_RIFLE) selectedWeapon     = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && HAS_GRANADE_LAUNCHER) selectedWeapon = 2;
    }

    
    private void DecreaseScroll()
    {
        if (HAS_MACHINE_GUN && HAS_SNIPER_RIFLE && HAS_GRANADE_LAUNCHER) {
                
            if (index <= 0) index = transform.childCount - 1;
            else index--;

            if (index == 0 && HAS_MACHINE_GUN)
            {
                selectedWeapon = 0;
            }

            if (index == 1 && HAS_SNIPER_RIFLE)
            {
                selectedWeapon = 1;
            }

            if (index == 2 && HAS_GRANADE_LAUNCHER)
            {
                selectedWeapon = 2;
            }
        } else if (HAS_MACHINE_GUN && HAS_SNIPER_RIFLE)
        {
            if (index <= 0) index = transform.childCount - 2;
            else index--;

            if (index == 0 && HAS_MACHINE_GUN)
            {
                selectedWeapon = 0;
            }

            if (index == 1 && HAS_SNIPER_RIFLE)
            {
                selectedWeapon = 1;
            }
                    
        } else
        {
            if (index <= 0) index = transform.childCount - 3;
            else index--;

            if (index == 0 && HAS_MACHINE_GUN)
            {
                selectedWeapon = 0;
            }
                    
        }
        
        
    }

    private void IncreaseScroll()
    {
        if (HAS_MACHINE_GUN && HAS_SNIPER_RIFLE && HAS_GRANADE_LAUNCHER) {
                
            if (index >= transform.childCount - 1) index = 0;
            else index++;

            if (index == 0 && HAS_MACHINE_GUN)
            {
                selectedWeapon = 0;
            }

            if (index == 1 && HAS_SNIPER_RIFLE)
            {
                selectedWeapon = 1;
            }

            if (index == 2 && HAS_GRANADE_LAUNCHER)
            {
                selectedWeapon = 2;
            }
        } else if (HAS_MACHINE_GUN && HAS_SNIPER_RIFLE)
        {
            if (index >= transform.childCount - 2) index = 0;
            else index++;

            if (index == 0 && HAS_MACHINE_GUN)
            {
                selectedWeapon = 0;
            }

            if (index == 1 && HAS_SNIPER_RIFLE)
            {
                selectedWeapon = 1;
            }
                    
        } else
        {
            if (index >= transform.childCount - 3) index = 0;
            else index++;

            if (index == 0 && HAS_MACHINE_GUN)
            {
                selectedWeapon = 0;
            }
                    
        }
    }
}
