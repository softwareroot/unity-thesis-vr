using UnityEngine;

public class DisplayAmmo : MonoBehaviour {

    private TMPro.TextMeshProUGUI textMesh;
    
    [SerializeField]
    private GameObject auto_rifle, sniper_rifle;


    private GunScript auto_rifle_script, sniper_rifle_script;
    private int auto_rifle_ammo, sniper_rifle_ammo;
    private int auto_rifle_max_ammo, sniper_rifle_max_ammo;
    private int auto_rifle_mags, sniper_rifle_mags;

    void Start() {
        
        // Get automatic rifle ammo info
        auto_rifle_script = auto_rifle.GetComponent<GunScript>();
        auto_rifle_max_ammo = auto_rifle_script.maxAmmo;
        auto_rifle_ammo = auto_rifle_script.currentAmmo;
        auto_rifle_mags = auto_rifle_script.mags;

        // Get sniper rifle ammo info
        sniper_rifle_script = sniper_rifle.GetComponent<GunScript>();
        sniper_rifle_max_ammo = sniper_rifle_script.maxAmmo;
        sniper_rifle_ammo = sniper_rifle_script.currentAmmo;


        textMesh = GetComponent<TMPro.TextMeshProUGUI>();

        if (auto_rifle.gameObject.activeSelf) {
            Debug.Log("AMMO: " + auto_rifle_ammo + " / " + auto_rifle_max_ammo);
            textMesh.text = "AMMO: " + auto_rifle_ammo + " / " + auto_rifle_max_ammo;
        } else if (sniper_rifle.gameObject.activeSelf) {
            Debug.Log("AMMO: " + sniper_rifle_ammo + " / " + sniper_rifle_max_ammo);
            textMesh.text = "AMMO: " + sniper_rifle_ammo + " / " + sniper_rifle_max_ammo;
        }
    }

    void Update() {
        auto_rifle_ammo = auto_rifle_script.currentAmmo;
        sniper_rifle_ammo = sniper_rifle_script.currentAmmo;

        auto_rifle_mags = auto_rifle_script.mags;

        if (auto_rifle.gameObject.activeSelf) {
            textMesh.text = "AMMO: " + auto_rifle_ammo + " / " + auto_rifle_max_ammo + "\n" + "MAGS: " + auto_rifle_mags;
        } else if (sniper_rifle.gameObject.activeSelf) {
            textMesh.text = "AMMO: " + sniper_rifle_ammo + " / " + sniper_rifle_max_ammo;
        }
    }
}
