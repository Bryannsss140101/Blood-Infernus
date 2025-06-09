using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Component")]
        [SerializeField] private float speed;
        private CharacterMovement movement;

        [Header("Animator Component")]
        private CharacterAnimator animator;

        private void Start()
        {
            movement = new PlayerMovement(speed);
            animator = new PlayerAnimator(GetComponent<Animator>());
        }

        private void Update()
        {
            movement.Move(transform);
            animator.Move(movement);
        }
    }
}