﻿using System;
using System.Collections;
using UnityEngine;

public class GunScript : MonoBehaviour {

    // Variables

    public Camera fpsCam;
    public Transform cam;
    public Recoil recoilComponent;
    public GameObject impactEffectSolid;
    public GameObject impactEffectEnemy;

    private Animator animator;
    private float lastFired;
    private float timestamp;
    private GameObject muzzle_gun_0;
    public int currentAmmo;
    private bool isReloading = false;

    public float damage             =       10f;
    public float range              =       100f;
    public float GUN_TYPE           =       0;
    public float timeBetweenShots   =       0.3333f;
    private float fireRate          =       10;

    // Constants

    public const int W_AUTOMATIC    =       0;
    public const int W_SNIPER       =       1;
    public const int W_GLANUCHER    =       2;
    public const int W_FIREWEAPON   =       3;

    public const int DMG_AUTOMATIC  =       2;
    public const int DMG_SNIPER     =       10;
    public int maxAmmo              =       10;
    public float reloadTime         =       1f;
    public Animator animatorReload;
    public int mags = 3;

    void Start() {
        // Initiate animator object for 'scoping animations'
        animator = gameObject.GetComponentInParent<Animator>();

        // Initiate impact effects
        impactEffectEnemy = GameObject.FindGameObjectWithTag("ie_enemy");
        impactEffectSolid = GameObject.FindGameObjectWithTag("ie_solid");

        // Set initial ammo count
        currentAmmo = maxAmmo;

        // Initiate and set up other variables
        switch (GUN_TYPE) {
            case W_AUTOMATIC:
                cam = GameObject.FindWithTag ("Gun0").transform;
                recoilComponent = cam.parent.GetComponent<Recoil>();

                muzzle_gun_0 = GameObject.Find("MuzzleGun0");
                muzzle_gun_0.SetActive(false);
            break;

            case W_SNIPER:
                cam = GameObject.FindWithTag ("Gun1").transform;
                recoilComponent = cam.parent.GetComponent<Recoil>();

                muzzle_gun_0 = GameObject.Find("MuzzleGun0");
                muzzle_gun_0.SetActive(false);
            break;
        }
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Delete)) {
            mags++;
        }

        if (mags <= 0) {
            muzzle_gun_0.SetActive(false);
        }

        if (isReloading)
            return;

        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(Reload());
            return;
        }

        // Controlling individual weapons based on gun type
        switch (GUN_TYPE) {
            case W_AUTOMATIC:
                if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Joystick1Button5))  && (mags > 0)) {
                    muzzle_gun_0.SetActive(true);
    
                    if (Time.time - lastFired > 1 / fireRate) {
                        lastFired = Time.time;
                        Shoot(W_AUTOMATIC);
                    }
                } else muzzle_gun_0.SetActive(false);

            break;

            case W_SNIPER:
            if (Time.time >= timestamp && (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Joystick1Button5))) {
                Shoot(W_SNIPER);
                StartCoroutine(WaitGun1Muzzle());
                timestamp = Time.time + timeBetweenShots;
                Scope.isScoped = false;
            } else muzzle_gun_0.SetActive(false);
            break;
        }
    }

    private IEnumerator Reload() {
        mags--;

        if (mags > -1) {
            isReloading = true;
            Debug.Log("Reloading...");

            muzzle_gun_0.SetActive(false);
            animatorReload.SetBool("Reloading", true);

            yield return new WaitForSeconds(reloadTime - 0.25f);

            animatorReload.SetBool("Reloading", false);
            yield return new WaitForSeconds(0.25f);
            currentAmmo = maxAmmo;
            isReloading = false;
        } else {
            isReloading = false;
        }
        
    }

    private void OnEnable() {
        isReloading = false;
        animatorReload.SetBool("Reloading", false);
    }

    // Controlling the weapon muzzle
    IEnumerator WaitGun1Muzzle() {
        
        muzzle_gun_0.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        muzzle_gun_0.SetActive(false);
        
    }

    void Shoot(float weapon_type) {

        currentAmmo--;

        if (weapon_type == W_SNIPER)
            animator.SetBool("Scoped", false);

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {

            string hit_tag = hit.transform.gameObject.tag;

            switch (hit_tag) {
                case "Enemy":
                Instantiate(impactEffectEnemy, hit.point, Quaternion.LookRotation(hit.normal));
                break;

                case "enemy_runner":
                Instantiate(impactEffectEnemy, hit.point, Quaternion.LookRotation(hit.normal));
                break;

                case "enemy_scratcher":
                Instantiate(impactEffectEnemy, hit.point, Quaternion.LookRotation(hit.normal));
                break;

                case "enemy_shooter":
                Instantiate(impactEffectEnemy, hit.point, Quaternion.LookRotation(hit.normal));
                break;

                default:
                    Instantiate(impactEffectSolid, hit.point, Quaternion.LookRotation(hit.normal));
                break;
            }

            // Get the gameobject from the object that was hit
            GameObject obj = hit.collider.gameObject;
            // Get the enemyctrl script from current object to check if it's really enemy type
            var script = obj.GetComponent<EnemyCtrl>();
            // Get the enemy type (SCRATCHER, SHOOTER, RUNNER)
            //EnemyCtrl.ENEMY_TYPE enemy_type = script.type;
            
            // Check if has a texture attatched (if not, can't be destroyed)
            if (obj.transform.childCount > 0) {
                // Check if is enemy
                if (script != null) {
                    switch (weapon_type) {
                        case W_AUTOMATIC:
                            script.hp -= DMG_AUTOMATIC;
                        break;

                        case W_SNIPER:
                            script.hp -= DMG_SNIPER;
                        break;
                    }
                }
            }
        }

        // Weapon recoil
        switch (GUN_TYPE) {
            case W_AUTOMATIC:
                recoilComponent.StartRecoil(0.018f, 0.018f, 20f);
            break;

            case W_SNIPER:
                recoilComponent.StartRecoil(0.075f, 0.075f, 10f);
            break;
        }
        
    }
}
