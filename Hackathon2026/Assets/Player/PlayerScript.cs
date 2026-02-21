using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class SC_TopDownController : MonoBehaviour
{
    Rigidbody2D rb;

    public float runSpeed = 20.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(x * runSpeed, y * runSpeed);
    }
}