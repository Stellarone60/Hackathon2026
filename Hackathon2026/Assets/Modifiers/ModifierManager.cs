using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Modifiers
{
    public class ModifierManager
    {
        public ModifierManager() { }

        public ModifierBase CreateModifier(string type)
        {
            ModifierBase modifier = null;

            switch (type)
            {
                case "EnemySpeedModifier":
                    modifier = new EnemySpeedModifier();
                    break;
                case "EnemyHealthModifier":
                    modifier = new EnemyHealthModifier();
                    break;
                case "EnemyDamageModifier":
                    modifier = new EnemyDamageModifier();
                    break;
                case "AddEnemiesRoomModifier":
                    modifier = new AddEnemiesRoomModifier();
                    break;
                case "AddTrapsRoomModifier":
                    modifier = new AddTrapsRoomModifier();
                    break;
                case "RangedMeleeRatioRoomModifier":
                    modifier = new RangedMeleeRatioRoomModifier();
                    break;
            }

            return modifier;
        }
    }
}
