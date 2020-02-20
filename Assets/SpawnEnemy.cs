using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    // Variables

    public GameObject physicalEnemySpawner;
    private GameObject enemy_prefab_parent;
    private GameObject enemy_prefab_texture;
    public float period = 0.1f;
    private System.Random random = new System.Random();

    private float nextActionTime = 0.0f;

    void Update() {
        if (Time.time > nextActionTime) {
            nextActionTime += period;

            Vector3 original_pos = physicalEnemySpawner.transform.position;
            float x_mod = original_pos.x;
            float y_mod = original_pos.y;
            float z_mod = original_pos.z;
            Vector3 pos_mod = new Vector3(x_mod, y_mod, z_mod);

            SelectRandomEnemy();
            
            Spawn(enemy_prefab_parent, pos_mod);
            Spawn(enemy_prefab_texture, pos_mod);
            
        }
    }

    private void Spawn(GameObject prefab, Vector3 enemySpawnerPos) {
        if (prefab != null) {
            Vector3 position = enemySpawnerPos;
            Instantiate(prefab, position, Quaternion.identity);
        }
    }

    private void SelectRandomEnemy() {
        int rand = random.Next(0, 3);

        switch (rand) {
            case 0:

            enemy_prefab_parent = GameObject.FindGameObjectWithTag("enemy_runner");
            enemy_prefab_texture = GameObject.FindGameObjectWithTag("tex_runner");
            break;

            case 1:
            enemy_prefab_parent = GameObject.FindGameObjectWithTag("enemy_scratcher");
            enemy_prefab_texture = GameObject.FindGameObjectWithTag("tex_scratcher");
            break;

            case 2:
            enemy_prefab_parent = GameObject.FindGameObjectWithTag("enemy_shooter");
            enemy_prefab_texture = GameObject.FindGameObjectWithTag("tex_shooter");
            break;
        }
    }
}
