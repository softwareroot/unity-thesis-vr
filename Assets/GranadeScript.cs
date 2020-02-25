using System;
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
        ExplosionDamage(transform.position, 4);
    }

    private void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;

        while (i < hitColliders.Length)
        {
            if (CheckForTags(hitColliders, i)) {
                    hitColliders[i].gameObject.SendMessage("Die");
            }

            i++;
        }
    }

    private bool CheckForTags(Collider[] colls, int index)
    {
        if (colls[index].gameObject.tag == "enemy_runner" || colls[index].gameObject.tag == "enemy_scratcher" ||
            colls[index].gameObject.tag == "enemy_shooter")
        {
            return true;
        }

        return false;
    }

}
