using System.Collections;
using UnityEngine;

public class Scope : MonoBehaviour {

    // Variables

    public const float NORMAL_SCOPED_FOV = 45f;
    public const float SCOPED_FOV = 30f;

    public static bool isScoped = false;
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weapon;

    public GameObject scope_ui;
    [SerializeField] private GameObject sniper_gun_model;
    private MeshRenderer[] render_sniper;
    [SerializeField] private GameObject muzzle;


    void Start() {
        render_sniper = sniper_gun_model.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer mesh in render_sniper) {
            mesh.enabled = true;
        }
    }
    
    
    void Update() {
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Joystick1Button4)) {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);
            
            if (isScoped)
                StartCoroutine(OnScoped());
            else
                OnUscoped();
        }

        /*
        if (animator.GetBool("Scoped")) {
            Camera.main.fieldOfView = SCOPED_FOV;
        } else {
            Camera.main.fieldOfView = NORMAL_SCOPED_FOV;
        }
        */
    }

    public IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);
        
        foreach (MeshRenderer mesh in render_sniper) {
            mesh.enabled = false;
            muzzle.SetActive(false);
        }

        scope_ui.SetActive(true);
    }

    public void OnUscoped()
    {
        scope_ui.SetActive(false);
        
        if (render_sniper != null) {
            foreach (MeshRenderer mesh in render_sniper) {
                mesh.enabled = true;
            }
        }

        isScoped = false;

    }
}
