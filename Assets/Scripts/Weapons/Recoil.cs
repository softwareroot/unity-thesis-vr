using UnityEngine;
using System.Collections;
 
public class Recoil : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////

    public float recoil         =   0.0f;
    public float maxRecoil_x    =   -0.005f;
    public float maxRecoil_y    =   0.005f;
    public float recoilSpeed    =   0.001f;

    ////////////////////////////////////////////////////////////////////////////////////

    public void StartRecoil(float recoilParam, float maxRecoil_xParam, float recoilSpeedParam) {
        recoil          =   recoilParam;
        maxRecoil_x     =   maxRecoil_xParam;
        recoilSpeed     =   recoilSpeedParam;
        maxRecoil_y     =   Random.Range(-maxRecoil_xParam, maxRecoil_xParam);
    }
 
    void Recoiling() {
        if (recoil > 0f) {
            Quaternion maxRecoil = Quaternion.Euler (maxRecoil_x, maxRecoil_y, 0f);
            transform.localRotation = Quaternion.Slerp (transform.localRotation, maxRecoil, Time.deltaTime * recoilSpeed);
            recoil -= Time.deltaTime;
        } else {
            recoil = 0f;
            transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.identity, Time.deltaTime * recoilSpeed / 2);
        }
    }
 
    void Update() { Recoiling(); }
}