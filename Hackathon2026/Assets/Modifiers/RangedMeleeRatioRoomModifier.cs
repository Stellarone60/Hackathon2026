using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
\
namespace Assets.Modifiers
{
    public class RangedMeleeRatioRoomModifier : RoomModifier
    {
        public RangedMeleeRatioRoomModifier()
        {
            this.modifierName = "Ranged/Melee Ratio";
            this.modifierSprite = Resources.Load<Sprite>("EnemyRatioModifier");
            this.description = $"Alters the ratio of enemy types in the room.";
        }
        public override void ApplyModifier(RoomManager manager)
        {
            // Not implemented currently due to complexity.
        }
    }
}
