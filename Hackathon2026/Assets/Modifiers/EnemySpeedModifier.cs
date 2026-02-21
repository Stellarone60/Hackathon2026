using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Modifiers
{
    public class EnemySpeedModifier : EnemyModifier
    {
        public EnemySpeedModifier()
        {
            modifierName = "Enemy Speed Modifier";
            // Set sprite.
        }
        public override void ApplyModifier(List<BasicEnemyScript> enemies)
        {
            foreach (BasicEnemyScript enemy in enemies)
            {
                // edit speed of enemy.
            }
        }
    }
}
