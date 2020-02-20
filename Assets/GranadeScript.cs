using System.Collections;
using UnityEngine;

public class GranadeScript : MonoBehaviour
{

    private bool activateExplosionAnimation;
    [SerializeField] public GameObject explosionObject;
    public float timeDelay = 2f;
    private float startTimer;
    [SerializeField] private float lifetime;

    public int damage = 10;
    public float explosiveForce = 20f;
    public float explosiveRadius = 15f;
    [SerializeField] public GameObject fireball;

    void Start()
    {
        activateExplosionAnimation = false;
        StartCoroutine(WaitForExplode());
    }

    private void Update()
    {
        if (activateExplosionAnimation)
            explosionObject.SetActive(true);
        else
        {
            explosionObject.SetActive(false);
        }
    }

    private IEnumerator WaitForExplode()
    {
        yield return new WaitForSeconds(2);
        Explode();
        yield return new WaitForSeconds(1);
        activateExplosionAnimation = false;
        Destroy(gameObject);
    }

    private void Explode()
    {
        //Debug.Log("EXPLODE!");
        activateExplosionAnimation = true;
        // Check for nearby collisions with enemies -> kill those in range
        
        
    }

}
