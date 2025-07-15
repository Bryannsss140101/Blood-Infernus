using UnityEngine;

namespace Character
{
    public abstract class CharacterMovement
    {
        protected float speed;
        protected Vector3 direction;
        protected Vector3 velocity;

        public float Speed { get => speed; }
        public Vector3 Direction { get => direction; }
        public Vector3 Velocity { get => velocity; }

        public abstract void Movement(Transform transform);
    }
}