using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Modifiers
{
    public class EnemyDamageModifier : EnemyModifier
    {
        public EnemyDamageModifier()
        {
            this.modifierName = "Enemy Damage Modifier";
            this.modifierSprite = Resources.Load<Sprite>("AttackModifier");
            this.description = $"Alters the enemies' damage by {valueModfier}.";
        }
        public override void ApplyModifier(List<BasicEnemyScript> enemies)
        {
            foreach (BasicEnemyScript enemy in enemies)
            {
                enemy.setEnemyStats("damage", enemy.getEnemyStats("damage") * valueModfier);
            }
        }
    }
}
