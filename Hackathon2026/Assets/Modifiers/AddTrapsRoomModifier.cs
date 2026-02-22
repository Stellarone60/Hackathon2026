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
        private int numberOfTrapsToAdd;
        public AddTrapsRoomModifier()
        {
            this.modifierName = "Add Traps";
            this.modifierSprite = Resources.Load<Sprite>("AddTrapsModifier");
            numberOfTrapsToAdd = UnityEngine.Random.Range(1, 4); // Randomly add between 1 and 3 traps.

            this.description = $"Adds up to {numberOfTrapsToAdd} traps to the room.";
        }
        public override void ApplyModifier(RoomManager manager)
        {
            // Add a trap prop prefab to the room's prop prefabs.
            while (numberOfTrapsToAdd > 0)
            {
                GameObject trapPrefab = Resources.Load<GameObject>("testTrap");
                manager.propPrefabs.Add(trapPrefab);
                numberOfTrapsToAdd--;
            }
        }
    }
}
