using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Modifiers
{
    public class AddTrapsRoomModifier : RoomModifier
    {
        public AddTrapsRoomModifier()
        {
            this.modifierName = "Add Traps";
            this.modifierSprite = Resources.Load<Sprite>("AddTrapsModifier");
            this.description = $"Adds traps to the room.";
        }
        public override void ApplyModifier(int roomData)
        {
            // Need room data.
        }
    }
}
