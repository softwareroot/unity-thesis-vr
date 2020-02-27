using UnityEngine;

public class CanvasWeaponsController : MonoBehaviour
{

    private Vector3 pos_0, pos_1, pos_2;
    [SerializeField] private GameObject spr_wep_0, spr_wep_1, spr_wep_2;
    [SerializeField] private GameObject selector;
    
    void Start()
    {
        pos_0 = new Vector3(-0.599f, -0.263f, -0.076f);
        pos_1 = new Vector3(-0.416f, -0.263f, -0.076f);
        pos_2 = new Vector3(-0.236f, -0.263f, -0.076f);
        
        spr_wep_0.SetActive(false);
        spr_wep_1.SetActive(false);
        spr_wep_2.SetActive(false);
    }

    void Update()
    {
        if (WeaponSwitching.HAS_MACHINE_GUN || WeaponSwitching.HAS_SNIPER_RIFLE || WeaponSwitching.HAS_GRANADE_LAUNCHER)
        {
            selector.SetActive(true);
            
            if (WeaponSwitching.HAS_MACHINE_GUN) { spr_wep_0.SetActive(true); }
            else { spr_wep_0.SetActive(false); }
            
            if (WeaponSwitching.HAS_SNIPER_RIFLE) { spr_wep_1.SetActive(true); }
            else { spr_wep_1.SetActive(false); }
            
            if (WeaponSwitching.HAS_GRANADE_LAUNCHER) { spr_wep_2.SetActive(true); }
            else { spr_wep_2.SetActive(false); }

            if (WeaponSwitching.selectedWeapon == 0) 
            { selector.GetComponent<RectTransform>().localPosition = pos_0; }
            if (WeaponSwitching.selectedWeapon == 1) 
            { selector.GetComponent<RectTransform>().localPosition = pos_1; }
            if (WeaponSwitching.selectedWeapon == 2) 
            { selector.GetComponent<RectTransform>().localPosition = pos_2; }
            
        } else
        {
            selector.SetActive(false);
        }
    }
}
