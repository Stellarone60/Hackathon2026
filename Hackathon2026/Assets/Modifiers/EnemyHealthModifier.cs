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
            this.modifierSprite = Resources.Load<Sprite>("HealthModifier");
            // Get a random value modifier between 0.5 and 1.5, rounded to the nearest tenth. Avoid getting 1.
            do
            {
                valueModfier = (float)Math.Round(UnityEngine.Random.Range(0.5f, 1.5f), 1);
            } while (valueModfier == 1);
            this.description = $"Alters the enemies' health by {valueModfier}.";
        }
        public override void ApplyModifier(List<BasicEnemyScript> enemies)
        {
            foreach (BasicEnemyScript enemy in enemies)
            {
                enemy.setEnemyStats("maxHealth", enemy.getEnemyStats("maxHealth") * valueModfier);
                enemy.setEnemyStats("currentHealth", enemy.getEnemyStats("currentHealth") * valueModfier);
            }
        }
    }
}
