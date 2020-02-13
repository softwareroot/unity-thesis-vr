using UnityEngine;

public class DisplayEnemies : MonoBehaviour {

    private TMPro.TextMeshProUGUI textMesh;
    private int totalEnemyCount;
    private GameObject[] getCountScratcher, getCountRunner, getCountShooter;

    void Start() {
        getCountScratcher = GameObject.FindGameObjectsWithTag("enemy_scratcher");
        getCountRunner = GameObject.FindGameObjectsWithTag("enemy_runner");
        getCountShooter = GameObject.FindGameObjectsWithTag("enemy_shooter");

        totalEnemyCount = getCountScratcher.Length + getCountRunner.Length + getCountShooter.Length - 3;
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        textMesh.text = "NPC: " + totalEnemyCount;
    }

    void Update() {
        getCountScratcher = GameObject.FindGameObjectsWithTag("enemy_scratcher");
        getCountRunner = GameObject.FindGameObjectsWithTag("enemy_runner");
        getCountShooter = GameObject.FindGameObjectsWithTag("enemy_shooter");

        totalEnemyCount = getCountScratcher.Length + getCountRunner.Length + getCountShooter.Length - 3;
        textMesh.text = "NPC: " + totalEnemyCount;
    }
}
