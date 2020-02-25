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
    public int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    public float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;
    public Transform[] spawnPoints;

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
        Debug.Log("Wave completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed all waves! Looping...");
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
        Debug.Log("Spawning wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        
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
        Debug.Log("Spawning enemy: " + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
