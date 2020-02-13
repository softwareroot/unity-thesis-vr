using System.Collections;
using UnityEngine;

public class DeleteAftermath : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////

    public float period = 1f;
    public float interpolationPeriodSolid = 0.1f;
    private float time = 0.0f;

    ////////////////////////////////////////////////////////////////////////////////////

    void Update() {
        time += Time.deltaTime;

        if (time >= interpolationPeriodSolid) {
            time = time - interpolationPeriodSolid;

            GameObject klonyBulletEffektu = (GameObject)GameObject.Find("BulletEffekt(Clone)");
            GameObject.Destroy(klonyBulletEffektu);
            GameObject klonyBulletBloodEffektu = (GameObject)GameObject.Find("BloodEffekt(Clone)");
            GameObject.Destroy(klonyBulletBloodEffektu);
        }
    }

    IEnumerator VymazAftermath() {
        yield return new WaitForSeconds(3f);
        GameObject klonyBulletEffektu = (GameObject)GameObject.Find("BulletEffekt(Clone)");
        GameObject klonyBulletBloodEffektu = (GameObject)GameObject.Find("BloodEffekt(Clone)");
        GameObject.Destroy(klonyBulletEffektu);
        GameObject.Destroy(klonyBulletBloodEffektu);
    }
}
