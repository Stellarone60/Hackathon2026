using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerScript : MonoBehaviour
{
    public GameObject attackPrefab;
    public float knockbackDecay = 5f;
    public float spawnDistance = 1f;  // How far in front
    public float dashCooldown = 2f;
    private GameObject attack = null;   
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    private Vector2 knockbackVelocity = Vector2.zero;
    private float attackDuration = 1f;
    private Vector2 LastMoveDirection = Vector2.zero;
    private float lastDashTime = -Mathf.Infinity; // Initialize to allow immediate dash
    private SpriteRenderer sr;

    public float runSpeed = 20.0f;

    Animator animator;

    //%%%%%%%%%%%%%%//
    // Player Stats //
    private float currentHealth = 20f;
    private float maxHealth = 20f;
    private float damage = 5f;
    private float movementSpeed = 2.5f;
    private int level = 1;
    private float experience = 0f;
    //%%%%%%%%%%%%%//

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        animator = GetComponentInChildren<Animator>();


    }

    void Update()
    {
        // Smoothly reduce knockback over time
        knockbackVelocity = Vector2.Lerp(
            knockbackVelocity,
            Vector2.zero,
            Time.deltaTime * knockbackDecay
        );
        checkAttack();
        checkDash();

        ApplyAnimation();
    }

    void checkAttack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Key Pressed");
            Invoke(nameof(LaunchAttack), 0f);
        }
        else{
            Debug.Log("Key Not Pressed");
        }
    }

    void checkDash()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Dash Key Pressed");
            if (Time.time >= lastDashTime + dashCooldown)
            {
                knockbackVelocity = LastMoveDirection.normalized * 10f; // Adjust dash force as needed
                lastDashTime = Time.time;
            }
        }
        else{
            Debug.Log("Dash Key Not Pressed");
        }
    }

    void LaunchAttack()
    {
        Vector2 direction = LastMoveDirection != Vector2.zero ? LastMoveDirection : Vector2.up; // Default to up if no movement
        Vector2 spawnPosition = (Vector2)transform.position + direction * spawnDistance;

        attack = Instantiate(attackPrefab, spawnPosition, Quaternion.identity);

        Destroy(attack, attackDuration);
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 inputDirection = new Vector2(x, y).normalized;

        if (inputDirection != Vector2.zero)
        {
            LastMoveDirection = inputDirection;
        }

        rb.velocity = inputDirection * runSpeed + knockbackVelocity;
    }
    public void ApplyKnockback(Vector2 direction, float force)
    {
        knockbackVelocity = direction.normalized * force;
    }
    public Vector3 getVelocity()
    {
        return rb.velocity;
    }

    public float getCooldownPercent()
    {
        return 1f - (dashCooldown - (Time.time - lastDashTime));
    }
    
    public float getPlayerStats(string stat)
    {
        switch (stat)
        {
            case "health":
                return(currentHealth);
            case "maxHealth":
                return(maxHealth);
            case "damage":
                return(damage);
            case "movementSpeed":
                return(movementSpeed);
            case "level":
                return((float)level);
            case "experience":
                return(experience);
            default:
                Debug.Log("Invalid stat requested");
                break;
        }
        return(-Mathf.Infinity);
    }

    public void setPlayerStats(string stat, float value)
    {
        switch (stat)
        {
            case "health":
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
            case "level":
                level = (int)value;
                break;
            case "experience":
                experience = value;
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
            case "health":
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
            case "level":
                level += (int)value;
                break;
            case "experience":
                experience += value;
                break;
            default:
                Debug.Log("Invalid stat change requested");
                break;
        }
    }

    public void substractFromStats(string stat, float value)
    {
        switch (stat)
        {
            case "health":
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
            case "level":
                level -= (int)value;
                break;
            case "experience":
                experience -= value;
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
            case "health":
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
            case "level":
                level = (int)(level * value);
                break;
            case "experience":
                experience *= value;
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
            case "health":
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
            case "level":
                level = (int)(level / value);
                break;
            case "experience":
                experience /= value;
                break;
            default:
                Debug.Log("Invalid stat change requested");
                break;
        }
    }

    private void ApplyAnimation()
    {
        bool running = false;
        bool idling = false;

        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            running = true;
            if (rb.velocity.x > 0)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        }
        else
        {
            idling = true;
        }

        animator.SetBool("Idling", idling);
        animator.SetBool("Walking", running);
    }
}