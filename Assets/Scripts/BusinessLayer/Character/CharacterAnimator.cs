using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public abstract class CharacterAnimator
    {
        public abstract void Move(CharacterMovement movement);
    }
}