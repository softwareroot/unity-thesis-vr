using UnityEngine;

public class Scope : MonoBehaviour {

    // Variables

    public const float NORMAL_SCOPED_FOV = 45f;
    public const float SCOPED_FOV = 30f;

    public static bool isScoped = false;
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weapon;

    void Update() {
        if (Input.GetMouseButtonDown(1)  || Input.GetKeyDown(KeyCode.Joystick1Button4)) {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);
        }

        /*
        if (animator.GetBool("Scoped")) {
            Camera.main.fieldOfView = SCOPED_FOV;
        } else {
            Camera.main.fieldOfView = NORMAL_SCOPED_FOV;
        }
        */
    }
}
