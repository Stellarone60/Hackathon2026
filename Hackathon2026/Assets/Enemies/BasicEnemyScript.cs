using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    public float speed;
    public Transform player;
 
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rigidBody.velocity = direction * speed;
    }

    void Update()
    {
        Vector2 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude < 1.5f)
        {
            //insert code to damage player here
            transform.GetComponent<SpriteRenderer>().color = Color.yellow; // Change enemy color to yellow when close
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().color = Color.red; // Reset enemy color when not close
        }

    }
}
