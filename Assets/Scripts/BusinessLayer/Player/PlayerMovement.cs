using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerMovement : CharacterMovement
    {
        public PlayerMovement(float speed)
        {
            this.speed = speed;
        }

        public override void Move(Transform transform)
        {
            direction = new(
                Input.GetAxisRaw("Horizontal"), 0f,
                Input.GetAxisRaw("Vertical"));

            if (direction.magnitude > 1)
                direction.Normalize();

            velocity = speed * Time.deltaTime * direction;

            transform.position += velocity;
        }
    }
}