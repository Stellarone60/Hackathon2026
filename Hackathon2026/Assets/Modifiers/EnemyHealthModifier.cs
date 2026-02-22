using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Modifiers
{
    public class EnemyHealthModifier : EnemyModifier
    {
        public EnemyHealthModifier()
        {
            this.modifierName = "Enemy Health Modifier";
            Debug.Log("Name set");
            try
            {
                this.modifierSprite = Resources.Load<Sprite>("traxigor");
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load sprite: " + e.Message);
            }
        }
        public override void ApplyModifier(List<BasicEnemyScript> enemies)
        {
            foreach (BasicEnemyScript enemy in enemies)
            {
                // change the health of the enemy here.
            }
        }
    }
}
