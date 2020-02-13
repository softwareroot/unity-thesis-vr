using UnityEngine;

public class BulletEffectRandomizeImpact : MonoBehaviour {

    // Variables

    public float strayFactor = 1f;
    
    void Start() {
        var randomNumberX   =   Random.Range(-strayFactor, strayFactor);
        var randomNumberY   =   Random.Range(-strayFactor, strayFactor);
        var randomNumberZ   =   Random.Range(-strayFactor, strayFactor);

        gameObject.transform.position += new Vector3(
            randomNumberX,
            randomNumberY,
            randomNumberZ
        );
    }
}
