using UnityEngine;

/// <summary>
/// Handles player movement.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private CharacterController characterController;
    private Vector3 velocity;
    private Vector3 direction;

    /// <summary>
    /// Manages player movement logic.
    /// </summary>
    public void HandleMovement()
    {
        Translate();
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Moves the player based on input.
    /// </summary>
    private void Translate()
    {
        if (characterController == null)
            return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            velocity = speed * Time.deltaTime * direction;

            characterController.Move(velocity);
        }
    }
}