using System.Collections;
using System.Collections.Generic;
using Assets.Modifiers;
using UnityEngine;

// Base class for all modifiers.
public abstract class Modifier<T> : ModifierBase
{
    // Needs to know what trait(s) it's modifying, and how to modify them.

    public abstract void ApplyModifier(T t);
}
