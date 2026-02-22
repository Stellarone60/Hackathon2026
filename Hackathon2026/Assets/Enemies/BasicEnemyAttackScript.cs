using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAttackScript : MonoBehaviour
{
    public float knockbackForce = 1.0f;
    // if player is in the circle, apply knockback
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript player = other.GetComponent<PlayerScript>();

            if (player != null)
            {
                Vector2 knockbackDirection =
                    (player.getVelocity() + (other.transform.position - transform.position)).normalized;
                player.subtractFromStats("health", 10f);
                player.ApplyKnockback(knockbackDirection, 5f);
            }
        }
    }
}