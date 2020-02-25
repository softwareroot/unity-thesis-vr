using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy_runner, enemy_shooter, enemy_scratcher;
        public int count_runner, count_shooter, count_scratcher;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;
    public Transform[] spawnPoints;
    public Transform weapon1_pickup_spawn, weapon2_pickup_spawn;
    public GameObject weapon_pickup1, weapon_pickup2, weapon_pickup0;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("Error: No Spawnpoints!");
        }
        
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            // Check if player killed all enemies
            if (!EnemyIsAlive())
            {
                // Begin a new round
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if (state == SpawnState.COUNTING)
        {
            
        }
        
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                // Start spawning a wave
                
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private void WaveCompleted()
    {
        //Debug.Log("Wave completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            //Debug.Log("Completed all waves! Looping...");
            // In future make a game end here after 10 waves.
            // For presentation purposes, set it to a lower number like 3 || 4.
        } else
        {
            nextWave++;
        }
    }

    private bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("enemy_scratcher") == null && 
                GameObject.FindGameObjectWithTag("enemy_runner") == null && 
                GameObject.FindGameObjectWithTag("enemy_shooter") == null)
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("Spawning wave: " + _wave.name);
        state = SpawnState.SPAWNING;
      
        // Po druhej wave sa spawne sniperka
        if (nextWave == 1)
        {
            float   x        = weapon1_pickup_spawn.position.x;
            float   y        = weapon1_pickup_spawn.position.y - 1;
            float   z        = weapon1_pickup_spawn.position.z;
            Vector3 spawnPos = new Vector3(x, y, z);
            
            Instantiate(weapon_pickup1, spawnPos, Quaternion.Euler(0, 0, 0));
            weapon1_pickup_spawn.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        
        // Po stvrtej vlne sa spawne granatomet
        if (nextWave == 2)
        {
            float   x        = weapon2_pickup_spawn.position.x;
            float   y        = weapon2_pickup_spawn.position.y - 0.65f;
            float   z        = weapon2_pickup_spawn.position.z;
            Vector3 spawnPos = new Vector3(x, y, z);
            Instantiate(weapon_pickup2, spawnPos, Quaternion.Euler(0, 0, 0));
            weapon2_pickup_spawn.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        
        // Spawn enemy
        for (int i = 0; i < _wave.count_runner; i++)
        {
            Spawn(_wave.enemy_runner);
            yield return new WaitForSeconds(1.0f / _wave.rate);
        }
        
        for (int i = 0; i < _wave.count_shooter; i++)
        {
            Spawn(_wave.enemy_shooter);
            yield return new WaitForSeconds(1.0f / _wave.rate);
        }
        
        for (int i = 0; i < _wave.count_scratcher; i++)
        {
            Spawn(_wave.enemy_scratcher);
            yield return new WaitForSeconds(1.0f / _wave.rate);
        }
        
        
        
        state = SpawnState.WAITING;
        
        
        yield break;
    }

    private void Spawn(Transform _enemy)
    {
        // Spawn enemy
        //Debug.Log("Spawning enemy: " + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
