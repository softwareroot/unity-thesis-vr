using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////

    public static int selectedWeapon = 0;
    public static bool HAS_MACHINE_GUN = false, HAS_SNIPER_RIFLE = false;
    [SerializeField] public GameObject recoil_gun1;
    private Scope scope_script;
    
    ////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        scope_script = recoil_gun1.GetComponent<Scope>();
        
        SelectWeapon();
        
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

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetButtonDown("JoyButton3"))
        {
            if (selectedWeapon <= 0) selectedWeapon = transform.childCount - 1;
            else selectedWeapon--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1) selectedWeapon = 0;
            else selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0) selectedWeapon = transform.childCount - 1;
            else selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) selectedWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) selectedWeapon = 1;
        if (previousSelectedWeapon != selectedWeapon) SelectWeapon();

        // Auto rifle
        if (selectedWeapon == 0) {
            scope_script.OnUscoped();
            //scope_script.scope_ui.SetActive(false);
        }
    }
}
