using UnityEngine;

public class LookAt : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////

    public GameObject player;

    ////////////////////////////////////////////////////////////////////////////////////

    void Update() {
        var target = Camera.main.transform.position;
        target.y = transform.position.y - 1;
        transform.LookAt(target);
    }
}
