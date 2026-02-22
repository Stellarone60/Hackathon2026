using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Assets.Modifiers;
public enum EnemyModifierType
{
    EnemySpeedModifier,
    EnemyHealthModifier,
    EnemyDamageModifier,

}

public enum RoomModifierType
{

    AddEnemiesRoomModifier,
    AddTrapsRoomModifier,
    RangedMeleeRatioRoomModifier
}

public class ChestController : MonoBehaviour
{
    private static readonly System.Random _random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // deploy this class when the level ends to 
    // spawn a chest with modifiers in it.
    // drops the modifiers when broken.

    public List<ModifierBase> BreakChest(int level)
    {
        List<ModifierBase> modifiers = new List<ModifierBase>();
        for (int i = 0; i < level; i++)
        {
            int modifierType = GetRandomNumber();
            ModifierBase modifier = new ModifierManager().CreateModifier(modifierType.ToString());
            modifiers.Add(modifier);
        }

        // need to randomly spawn a number of modifiers based on the level.

        return modifiers;

    }

    public static int GetRandomNumber()
{
    System.Random random = new System.Random();
    return random.Next(0, 3); // 1 inclusive, 4 exclusive
}
}
