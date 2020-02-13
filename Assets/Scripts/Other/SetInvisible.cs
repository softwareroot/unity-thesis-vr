using UnityEngine;

public class SetInvisible : MonoBehaviour {
    void Update() { gameObject.GetComponent<Renderer>().enabled = false; }
}
