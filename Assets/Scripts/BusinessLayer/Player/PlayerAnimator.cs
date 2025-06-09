using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerAnimator: CharacterAnimator
    {
        private Animator animator;

        public PlayerAnimator(Animator animator)
        {
            this.animator = animator;
        }

        public override void Move(CharacterMovement movement)
        {
            animator.SetBool("On move", movement.Velocity.magnitude > 0);
            animator.SetFloat("Direction x", movement.Direction.x);
            animator.SetFloat("Direction z", movement.Direction.z);
        }
    }
}