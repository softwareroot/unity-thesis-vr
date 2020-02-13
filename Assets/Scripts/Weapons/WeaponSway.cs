using UnityEngine;

public class WeaponSway : MonoBehaviour {

    // Variables

    public float amount         =       0.1f;
    public float maxAmount      =       0.3f;
    public float smoothAmount   =       6.0f;
    
    private Vector3 initPos;

    void Start() { initPos = transform.localPosition; }

    void Update() {
        float moveX             =       -Input.GetAxis("Mouse X") * amount;
        float moveY             =       -Input.GetAxis("Mouse Y") * amount;
        moveX                   =       Mathf.Clamp(moveX, -maxAmount, maxAmount);
        moveY                   =       Mathf.Clamp(moveY, -maxAmount, maxAmount);

        Vector3 finalPosToMove  =       new Vector3(moveX, moveY, 0);
        transform.localPosition =
            Vector3.Lerp(transform.localPosition, finalPosToMove + initPos, Time.deltaTime * smoothAmount);
        
        float moveXVR           =       -Input.GetAxis("Horizontal") * amount;
        float moveYVR           =       -Input.GetAxis("Vertical") * amount;
        moveXVR                 =       Mathf.Clamp(moveXVR, -maxAmount, maxAmount);
        moveYVR                 =       Mathf.Clamp(moveYVR, -maxAmount, maxAmount);

        Vector3 finalPosToMoveVR = new Vector3(moveXVR, moveYVR, 0);
        transform.localPosition =
        Vector3.Lerp(transform.localPosition, finalPosToMoveVR + initPos, Time.deltaTime * smoothAmount);
    }
}
