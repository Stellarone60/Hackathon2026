using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Modifiers
{
    public class AddEnemiesRoomModifier : RoomModifier
    {
        public AddEnemiesRoomModifier()
        {
            this.modifierName = "Add Enemies";
            this.modifierSprite = Resources.Load<Sprite>("AddEnemiesModifier");
            this.description = $"Adds enemies to the room.";
        }
        public override void ApplyModifier(int roomData)
        {
            // Need room data.
        }
    }
}
