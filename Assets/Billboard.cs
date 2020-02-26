using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        transform.forward = new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z);
    }
}
