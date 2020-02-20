using UnityEngine;

public class Hover : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////

    private Vector3 startPosition = new Vector3();
    private Vector3 pos2 = new Vector3();

    ////////////////////////////////////////////////////////////////////////////////////

    void Start() {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = startPosition + new Vector3(0.0f, Mathf.Sin(4 * Time.time) * 0.2f, 0.0f); 
        //transform.RotateAround(transform.position, transform.up, Time.deltaTime * 40);
    }
}
