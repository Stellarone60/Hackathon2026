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
