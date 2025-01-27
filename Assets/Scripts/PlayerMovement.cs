using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private CharacterController characterController;
    private Vector3 velocity;
    private Vector3 direction;

    public void HandleMovement()
    {
        Translatation();
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Translatation()
    {
        direction = new Vector3(
            Input.GetAxisRaw("Horizontal"), 0f,
            Input.GetAxisRaw("Vertical")).normalized;

        velocity = speed * Time.deltaTime * direction;

        characterController.Move(velocity);
    }
}