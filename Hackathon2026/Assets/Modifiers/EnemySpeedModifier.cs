using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Modifiers
{
    public class EnemySpeedModifier : EnemyModifier
    {
        public EnemySpeedModifier()
        {
            this.modifierName = "Enemy Speed Modifier";
            this.modifierSprite = Resources.Load<Sprite>("SpeedModifier");
            // Get a random value modifier between 0.5 and 1.5, rounded to the nearest tenth. Avoid getting 1.
            do
            {
                valueModfier = (float)Math.Round(UnityEngine.Random.Range(0.5f, 1.5f), 1);
            } while (valueModfier == 1);
            this.description = $"Alters the enemies' speed by {valueModfier}.";
        }
        public override void ApplyModifier(List<BasicEnemyScript> enemies)
        {
            foreach (BasicEnemyScript enemy in enemies)
            {
                enemy.setEnemyStats("movementSpeed", enemy.getEnemyStats("movementSpeed") * valueModfier);
            }
        }
    }
}
