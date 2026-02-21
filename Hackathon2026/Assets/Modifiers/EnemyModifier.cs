using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Modifiers
{
    public abstract class EnemyModifier : Modifier<List<BasicEnemyScript>>
    {
        // By this much our modifier will change the trait.
        public float valueModfier;
    }
}
