using UnityEngine;

namespace Character
{
    public class PlayerMovement : CharacterMovement
    {
        private float speedMultiplier;

        public PlayerMovement(float speed)
        {
            this.speed = speed;
        }

        public override void Movement(Transform transform)
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