using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    // Variables

    private float speed         =   7.5f;
    private float gravity       =   11.5f;
    private float jumpSpeed     =   5f;
    private float vSpeed        =   0;
    private int hp              =   100;

    private CharacterController controller;
    public int distanceOfRaycast;

    void Start() { controller = GetComponent<CharacterController>(); }
    void Update() { PlayerMovement(); }

    void PlayerMovement() {
        float horizontal    =   Input.GetAxis("Horizontal");
        float vertical      =   Input.GetAxis("Vertical");
        float mouse_x       =   Input.GetAxis("Right Stick X");
        
        Vector3 direction   =   new Vector3(horizontal, 0, vertical);
        Vector3 velocity    =   direction * speed;
         
        if (controller.isGrounded) {
            vSpeed = 0;

            if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.Joystick1Button0)) {
                vSpeed = jumpSpeed;
                speed += 1f;
            } else speed = 7.5f;
        }
        vSpeed -= gravity * Time.deltaTime;

        velocity    =   Camera.main.transform.TransformDirection(velocity);
        velocity.y  =   vSpeed;

        controller.Move(velocity * Time.deltaTime);
        Vector3 rotateDirection = new Vector3(0, mouse_x * Time.deltaTime * 100, 0);
        controller.transform.Rotate(rotateDirection);
    }

    public int GetHP() {
        return hp;
    }

    public void SubtractHP(int substraction_coeficient) {
        this.hp -= substraction_coeficient;
    }

    public void AddHP(int addition_coeficient) {
        this.hp += addition_coeficient;
    }
}
