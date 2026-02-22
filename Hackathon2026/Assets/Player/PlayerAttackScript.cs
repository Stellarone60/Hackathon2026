using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public float knockbackForce = 1.0f;
    // if player is in the circle, apply knockback
    public GameObject playerScript;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            BasicEnemyScript enemy = other.GetComponent<BasicEnemyScript>();
            PlayerScript player = playerScript.GetComponent<PlayerScript>();

            if (enemy != null)
            {
                Vector2 knockbackDirection =
                    ((other.transform.position - transform.position)).normalized;
               enemy.subtractFromStats("currentHealth", player.getPlayerStats("damage"));
               enemy.ApplyKnockback(knockbackDirection, knockbackForce);
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
