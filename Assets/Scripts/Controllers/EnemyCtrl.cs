
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour {
    // Enums

    public enum ENEMY_TYPE {
        SCRATCHER,
        RUNNER,
        SHOOTER
    }

    // Constants

    private const float CONST_LOOK_RADIUS = 100.0f;

    // Scratcher constants
    private const float SCRATCHER_SPEED = 2.0f;
    private const float SCRATCHER_ACCELERATION = 20.0f;
    private const float SCRATCHER_STOPPING_DISTANCE = 2.3f;
    private const float SCRATCHER_RADIUS = 0.99f;
    private const float SCRATCHER_HEIGHT = 2.0f;

    // Shooter constants
    private const float SHOOTER_SPEED = 3.0f;
    private const float SHOOTER_ACCELERATION = 20.0f;
    private const float SHOOTER_STOPPING_DISTANCE = 6.7f;
    private const float SHOOTER_RADIUS = 0.99f;
    private const float SHOOTER_HEIGHT = 2.0f;

    // Runner constants
    private const float RUNNER_SPEED = 10.0f;
    private const float RUNNER_ACCELERATION = 8.0f;
    private const float RUNNER_STOPPING_DISTANCE = 2.5f;
    private const float RUNNER_RADIUS = 0.99f;
    private const float RUNNER_HEIGHT = 2.0f;

    // Variables

    public float lookRadius;
    public int hp;

    

    Transform target;
    NavMeshAgent agent;
    public ENEMY_TYPE type;

    void Start() {
        // Initialization
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        //SelectRandomEnemyType();
        SetStats(type, agent);
        SelectTexture(type);
    }

    void Update() {
        
        // Calculate the distance to the target (player)
        float distance = Vector3.Distance(target.position, transform.position);

        // Start moving towards the player using agent logic
        if (distance <= lookRadius) {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance) FaceTarget();
        }

        // Remove the object if HP is less than 0
        if (hp <= 0) GameObject.Destroy(gameObject);
    }

    private void SelectRandomEnemyType() {

        int number = Random.Range(0, 3);

        switch (number) {
            case 0:
                type = ENEMY_TYPE.SCRATCHER;
            break;

            case 1:
                type = ENEMY_TYPE.SHOOTER;
            break;

            case 2:
                type = ENEMY_TYPE.RUNNER;
            break;
        }

        SelectTexture(type);
    }

    private void SelectTexture(ENEMY_TYPE type) {
        switch (type) {
            case ENEMY_TYPE.SCRATCHER:
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            break;

            case ENEMY_TYPE.SHOOTER:
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            break;

            case ENEMY_TYPE.RUNNER:
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            break;
        }
    }

    private void SetStats(ENEMY_TYPE type, NavMeshAgent agent) {
        switch (type) {
            case ENEMY_TYPE.SCRATCHER:
                hp = 15;

                SetAgent(
                    agent,
                    SCRATCHER_SPEED,
                    SCRATCHER_ACCELERATION,
                    SCRATCHER_STOPPING_DISTANCE,
                    SCRATCHER_RADIUS,
                    SCRATCHER_HEIGHT
                );
            break;

            case ENEMY_TYPE.RUNNER:
                hp = 10;

                SetAgent(
                    agent,
                    RUNNER_SPEED,
                    RUNNER_ACCELERATION,
                    RUNNER_STOPPING_DISTANCE,
                    RUNNER_RADIUS,
                    RUNNER_HEIGHT
                );
            break;

            case ENEMY_TYPE.SHOOTER:
                hp = 20;

                SetAgent(
                    agent,
                    SHOOTER_SPEED,
                    SHOOTER_ACCELERATION,
                    SHOOTER_STOPPING_DISTANCE,
                    SHOOTER_RADIUS,
                    SHOOTER_HEIGHT
                );
            break;
        }
    }

    private void SetAgent(NavMeshAgent agent, float speed, float acceleration, 
        float stopping_distance, float radius, float height) {

        //lookRadius = CONST_LOOK_RADIUS;
        agent.speed = speed;
        agent.acceleration = acceleration;
        agent.stoppingDistance = stopping_distance;
        agent.radius = radius;
        agent.height = height;

    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
