using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerScript : MonoBehaviour
{
    public float knockbackDecay = 5f;
    
    private Rigidbody2D rb;
    private Vector2 knockbackVelocity = Vector2.zero;

    public float runSpeed = 20.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Smoothly reduce knockback over time
        knockbackVelocity = Vector2.Lerp(
            knockbackVelocity,
            Vector2.zero,
            Time.deltaTime * knockbackDecay
        );
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
}