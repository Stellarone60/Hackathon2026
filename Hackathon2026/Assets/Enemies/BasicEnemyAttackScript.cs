using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAttackScript : MonoBehaviour
{
    public float knockbackForce = 1.0f;
    // public connection to the enemy script to get damage value
    public GameObject enemyScript;

    // if player is in the circle, apply knockback
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript player = other.GetComponent<PlayerScript>();
           // BasicEnemyScript enemy = enemyScript.GetComponent<BasicEnemyScript>();

            if (player != null)
            {
                Vector2 knockbackDirection =
                    ((other.transform.position - transform.position)).normalized;
               // Debug.Log("Damage" + enemy.getEnemyStats("damage"));
               // player.subtractFromStats("health", 5f);
                player.ApplyKnockback(knockbackDirection, knockbackForce);
            }
        }
    }
}