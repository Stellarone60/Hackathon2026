using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public float knockbackForce = 1.0f;
    // if player is in the circle, apply knockback
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            BasicEnemyScript enemy = other.GetComponent<BasicEnemyScript>();

            if (enemy != null)
            {
                Vector2 knockbackDirection =
                    (enemy.getVelocity() + (other.transform.position - transform.position)).normalized;

               enemy.ApplyKnockback(knockbackDirection, knockbackForce);
               Destroy(gameObject);
            }
        }

        // check collision with prop
        if (other.CompareTag("Obstacle"))
        {
            ObstacleScript obstacle = other.GetComponent<ObstacleScript>();

            if(obstacle.getIsBreakable())
            {
                obstacle.destroy();
            }
        }
    }
}
