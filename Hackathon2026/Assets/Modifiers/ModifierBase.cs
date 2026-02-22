using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Modifiers
{
    public abstract class ModifierBase
    {

        // Holds the sprite for the modifier, which will be displayed on the trait's icon.
        private Sprite modifierSprite;

        public string modifierName = "";

    }
}
