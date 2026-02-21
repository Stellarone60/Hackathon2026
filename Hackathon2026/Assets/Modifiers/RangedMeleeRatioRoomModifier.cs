using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Modifiers
{
    public class RangedMeleeRatioRoomModifier : RoomModifier
    {
        public RangedMeleeRatioRoomModifier()
        {
            this.modifierName = "Ranged/Melee Ratio";
            // Set sprite.
        }
        public override void ApplyModifier(int roomData)
        {
            // Need room data.
        }
    }
}
