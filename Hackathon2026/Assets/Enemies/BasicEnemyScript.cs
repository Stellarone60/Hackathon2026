using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    public float speed;
    public Transform player;

    public GameObject circlePrefab;   // Assign in Inspector
    private GameObject attack = null;
    public float spawnDistance = 1f;  // How far in front
    public float attackDuration = 1f; // How long it stays
    public float attackCooldown = 2f; // Time between spawns
    public float enemyAttackRange = 2f;

    private float lastAttackTime = -Mathf.Infinity; // Initialize to allow immediate attack

    //%%%%%%%%%%%%%%//
    // Enemy Stats //
    private float currentHealth = 20f;
    private float maxHealth = 20f;
    private float damage = 5f;
    private float movementSpeed = 2.5f;
    //%%%%%%%%%%%%%//

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
        if (distanceToPlayer < enemyAttackRange || attack != null)
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
                //wait a moment before spawning the attack to give the player a chance to react
                Invoke(nameof(LaunchAttack), 0.5f);
                lastAttackTime = Time.time;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void LaunchAttack()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        Vector2 spawnPosition = (Vector2)transform.position + direction * spawnDistance;

        attack = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);

        Destroy(attack, attackDuration);
    }

    public float getEnemyStats(string stat)
    {
        switch (stat)
        {
            case "currentHealth":
                return(currentHealth);
            case "maxHealth":
                return(maxHealth);
            case "damage":
                return(damage);
            case "movementSpeed":
                return(movementSpeed);
            default:
                Debug.Log("Invalid stat requested");
        }
        return(-Mathf.Infinity);
    }

    public void setEnemyStats(string stat, float value)
    {
        switch (stat)
        {
            case "currentHealth":
                currentHealth = value;
                break;
            case "maxHealth":
                maxHealth = value;
                break;
            case "damage":
                damage = value;
                break;
            case "movementSpeed":
                movementSpeed = value;
                break;
            default:
                Debug.Log("Invalid stat change requested");
                break;
        }
    }

    public void addToStats(string stat, float value)
    {
        switch (stat)
        {
            case "currentHealth":
                currentHealth += value;
                break;
            case "maxHealth":
                maxHealth += value;
                break;
            case "damage":
                damage += value;
                break;
            case "movementSpeed":
                movementSpeed += value;
                break;
            default:
                Debug.Log("Invalid stat change requested");
                break;
        }
    }

    public void multToStats(string stat, float value)
    {
        switch (stat)
        {
            case "currentHealth":
                currentHealth *= value;
                break;
            case "maxHealth":
                maxHealth *= value;
                break;
            case "damage":
                damage *= value;
                break;
            case "movementSpeed":
                movementSpeed *= value;
                break;
            default:
                Debug.Log("Invalid stat change requested");
                break;
        }
    }

    public void divToStats(string stat, float value)
    {
        switch (stat)
        {
            case "currentHealth":
                currentHealth /= value;
                break;
            case "maxHealth":
                maxHealth /= value;
                break;
            case "damage":
                damage /= value;
                break;
            case "movementSpeed":
                movementSpeed /= value;
                break;
            default:
                Debug.Log("Invalid stat change requested");
                break;
        }
    }

    public void subtractFromStats(string stat, float value)
    {
        switch (stat)
        {
            case "currentHealth":
                currentHealth -= value;
                break;
            case "maxHealth":
                maxHealth -= value;
                break;
            case "damage":
                damage -= value;
                break;
            case "movementSpeed":
                movementSpeed -= value;
                break;
            default:
                Debug.Log("Invalid stat change requested");
                break;
        }
    }

}