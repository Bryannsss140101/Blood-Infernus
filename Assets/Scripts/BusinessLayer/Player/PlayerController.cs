using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Component")]
        [SerializeField] private float speed;
        [SerializeField] private float speedMultiplier;
        private CharacterMovement movement;

        [Header("Animator Component")]
        private CharacterAnimator animator;

        private void Start()
        {
            movement = new PlayerMovement(speed);
            // animator = new PlayerAnimator(GetComponent<Animator>());
        }

        private void Update()
        {
            movement.Movement(transform);
            // animator.Move(movement);
        }
    }
}