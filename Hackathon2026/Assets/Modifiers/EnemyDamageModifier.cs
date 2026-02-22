using System;
using System.Collections.Generic;
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
            // Set sprite.
        }
        public override void ApplyModifier(List<BasicEnemyScript> enemies)
        {
            foreach (BasicEnemyScript enemy in enemies)
            {
                // change the damage of the enemy here.
            }
        }
    }
}
