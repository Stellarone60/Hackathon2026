using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 7.5f;
    public float lifetime = 2f;
    public Vector2 direction = Vector2.zero;

    private Rigidbody2D rg;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Player")
    {
        Destroy(gameObject);
        Debug.Log("hit");
    }
}
}
