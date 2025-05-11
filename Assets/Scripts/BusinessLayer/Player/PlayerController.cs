using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controller Component")]
    [SerializeField] private CharacterController controller;

    [Header("Movement Component")]
    [SerializeField] private float speed;
    private CharacterMovement movement;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        movement = new PlayerMovement(speed);
    }

    private void Update()
    {
        controller.Move(movement.Velocity());
    }
}