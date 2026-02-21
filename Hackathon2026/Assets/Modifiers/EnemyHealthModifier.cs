using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Modifiers
{
    public class EnemyHealthModifier : EnemyModifier
    {
        public EnemyHealthModifier()
        {
            modifierName = "Enemy Health Modifier";
            // Set sprite.
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
