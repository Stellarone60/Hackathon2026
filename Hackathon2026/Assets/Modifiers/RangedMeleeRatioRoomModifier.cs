using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Modifiers
{
    public class RangedMeleeRatioRoomModifier : RoomModifier
    {
        public RangedMeleeRatioRoomModifier()
        {
            this.modifierName = "Ranged/Melee Ratio";
            this.modifierSprite = Resources.Load<Sprite>("EnemyRatioModifier");
            this.description = $"Alters the ratio of ranged to melee enemies in the room.";
        }
        public override void ApplyModifier(int roomData)
        {
            // Need room data.
        }
    }
}
