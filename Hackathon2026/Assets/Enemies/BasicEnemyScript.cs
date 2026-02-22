using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    public float speed;
    public Transform player;

    public GameObject circlePrefab;   // Assign in Inspector
    private GameObject circle = null;
    public float spawnDistance = 1f;  // How far in front
    public float circleLifetime = 1f; // How long it stays
    public float attackCooldown = 2f; // Time between spawns
    public float enemyAttackRange = 2f;

    private float lastAttackTime = -Mathf.Infinity; // Initialize to allow immediate attack

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(player.position, transform.position);
        Vector2 direction = (player.position - transform.position).normalized;
        rigidBody.velocity = direction * speed;
        if (distanceToPlayer < enemyAttackRange || circle != null)
        {
            rigidBody.velocity = Vector2.zero; // Stop moving when attacking
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceToPlayer < enemyAttackRange)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                //wait a moment before spawning the circle to give the player a chance to react
                Invoke(nameof(SpawnCircle), 0.5f);
                lastAttackTime = Time.time;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void SpawnCircle()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        Vector2 spawnPosition = (Vector2)transform.position + direction * spawnDistance;

        circle = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);

        Destroy(circle, circleLifetime);
    }
}