using UnityEngine;

public class WeaponBob : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////

    public float bobbingSpeed   =   0.1f;
    public float bobbingAmount  =   0.3f;
    private float timer         =   0.0f;

    ////////////////////////////////////////////////////////////////////////////////////

    private float xInit, yInit;
    public float xOffset, yOffset;
    public CharacterController fpsController;

    ////////////////////////////////////////////////////////////////////////////////////

    void Start() {
        fpsController = GameObject.FindObjectOfType<CharacterController>();

        xInit       =       transform.localPosition.x;
        yInit       =       transform.localPosition.y;
        xOffset     =       xInit;
        yOffset     =       yInit;
    }

    public void Reset() {
        xOffset     =       xInit;
        yOffset     =       yInit;
    }

    void Update () {
        if(!fpsController.isGrounded)
            return;

        float xMovement             =       0.0f;
        float yMovement             =       0.0f;
        float horizontal            =       Input.GetAxis("Horizontal");
        float vertical              =       Input.GetAxis("Vertical");
        Vector3 calcPosition        =       transform.localPosition; 

        ////////////////////////////////////////////////////////////////////////////////////
        
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) { timer = 0.0f; } else {
            xMovement               =       Mathf.Sin(timer) / 2;
            yMovement               =       -Mathf.Sin(timer) / 2;
            timer                   +=      bobbingSpeed;
            if (timer > Mathf.PI * 2) timer = timer - (Mathf.PI * 2);
        }

        ////////////////////////////////////////////////////////////////////////////////////
        
        if (xMovement != 0) {
            float translateChange   =       xMovement * bobbingAmount;
            float totalAxes         =       Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes               =       Mathf.Clamp (totalAxes, 0.0f, 1.0f);
            translateChange         =       totalAxes * translateChange;
            calcPosition.x          =       xOffset + translateChange;
        } else calcPosition.x       =       xOffset;

        ////////////////////////////////////////////////////////////////////////////////////
        
        if (yMovement != 0) {
            float translateChange   =       yMovement * bobbingAmount;
            float totalAxes         =       Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes               =       Mathf.Clamp (totalAxes, 0.0f, 1.0f);
            translateChange         =       totalAxes * translateChange;
            calcPosition.y          =       yOffset + translateChange;
        } else calcPosition.y       =       yOffset;

        ////////////////////////////////////////////////////////////////////////////////////
        transform.localPosition     =       Vector3.Lerp(transform.localPosition, calcPosition, Time.deltaTime);
    }
}