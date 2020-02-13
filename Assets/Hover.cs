using UnityEngine;

public class Hover : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////

    private Vector3 startPosition;

    ////////////////////////////////////////////////////////////////////////////////////

    void Start() { startPosition = transform.position; }
    void Update() { transform.position = startPosition + new Vector3(0.0f, Mathf.Sin(4 * Time.time) * 0.2f, 0.0f); }
}
