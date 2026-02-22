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
        private int enemyNum = 0;
        public AddEnemiesRoomModifier()
        {
            this.modifierName = "Add Enemies";
            this.modifierSprite = Resources.Load<Sprite>("AddEnemiesModifier");

            // Get a random number of enemies to add between 1 and 5.
            enemyNum = UnityEngine.Random.Range(1, 6);

            this.description = $"Upper limit for enemies increased by {enemyNum} for the room.";
        }
        public override void ApplyModifier(RoomManager manager)
        {
            manager.maxEnemyCount += enemyNum;
        }
    }
}
