using Assets.Modifiers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all modifiers.
public abstract class Modifier<T> : ModifierBase
{
    // Needs to know what trait(s) it's modifying, and how to modify them.

    // Holds the sprite for the modifier, which will be displayed on the trait's icon.
    [SerializeField]
    private Sprite modifierSprite;

    [SerializeField]
    public string modifierName;

    public abstract void ApplyModifier(T t);
}
