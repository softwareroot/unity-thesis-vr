using UnityEngine;

public class DisplayAmmo : MonoBehaviour {

    private TMPro.TextMeshProUGUI textMesh;
    
    [SerializeField]
    private GameObject auto_rifle, sniper_rifle, launcher_rifle;


    private GunScript auto_rifle_script, sniper_rifle_script, launcher_script;
    private int auto_rifle_ammo, sniper_rifle_ammo, launcher_ammo;
    private int auto_rifle_max_ammo, sniper_rifle_max_ammo, launcher_max_ammo;
    private int auto_rifle_mags, sniper_rifle_mags, launcher_mags;

    void Start() {
        GetAutoRifleAmmoInfo();
        GetSniperRifleAmmoInfo();
        GetLauncherRifleAmmoInfo();

        // Init text
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();

        // Print text
        PrintAmmoText();
    }

    void Update() {

        // Update vars
        auto_rifle_ammo = auto_rifle_script.currentAmmo;
        sniper_rifle_ammo = sniper_rifle_script.currentAmmo;
        auto_rifle_mags = auto_rifle_script.mags;
        sniper_rifle_mags = sniper_rifle_script.mags;
        launcher_ammo = launcher_script.currentAmmo;
        launcher_mags = launcher_script.mags;

        // Print text
        PrintAmmoText();
    }

    private void GetAutoRifleAmmoInfo() {
        // Get automatic rifle ammo info
        auto_rifle_script = auto_rifle.GetComponent<GunScript>();
        auto_rifle_max_ammo = auto_rifle_script.maxAmmo;
        auto_rifle_ammo = auto_rifle_script.currentAmmo;
        auto_rifle_mags = auto_rifle_script.mags;
    }

    private void GetSniperRifleAmmoInfo() {
        // Get sniper rifle ammo info
        sniper_rifle_script = sniper_rifle.GetComponent<GunScript>();
        sniper_rifle_max_ammo = sniper_rifle_script.maxAmmo;
        sniper_rifle_ammo = sniper_rifle_script.currentAmmo;
        sniper_rifle_mags = sniper_rifle_script.mags;
    }
    
    private void GetLauncherRifleAmmoInfo() {
        // Get automatic rifle ammo info
        launcher_script   = launcher_rifle.GetComponent<GunScript>();
        launcher_max_ammo = launcher_script.maxAmmo;
        launcher_ammo     = launcher_script.currentAmmo;
        launcher_mags     = launcher_script.mags;
    }

    private void PrintAmmoText() {
#pragma warning disable CS0618
        if (auto_rifle.gameObject.active) {
#pragma warning restore CS0618
            textMesh.text = "AMMO: " + auto_rifle_ammo + " / " + auto_rifle_max_ammo + "\n" + "MAGS: " + auto_rifle_mags;
#pragma warning disable CS0618
        } else if (sniper_rifle.gameObject.active) {
#pragma warning restore CS0618
            textMesh.text = "AMMO: " + sniper_rifle_ammo + " / " + sniper_rifle_max_ammo + "\n" + "MAGS: " + sniper_rifle_mags;
#pragma warning disable CS0618
        } else if (launcher_rifle.gameObject.active) {
#pragma warning restore CS0618
            textMesh.text = "AMMO: " + launcher_ammo + " / " + launcher_max_ammo + "\n" + "MAGS: " + launcher_mags;
        }
    }
}
