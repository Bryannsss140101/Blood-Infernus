using UnityEngine;
using UnityEngine.EventSystems;

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
        if (characterController == null)
            return;

        Translate();

        // Dash();
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Cooldown.Set("Dash", 0.5f);
    }

    /// <summary>
    /// Moves the player based on input.
    /// </summary>
    private void Translate()
    {
        float horizontal = Input.GetAxisRaw("PHorizontal");
        float vertical = Input.GetAxisRaw("PVertical");

        if (horizontal != 0 || vertical != 0)
        {
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            velocity = speed * Time.deltaTime * direction;

            characterController.Move(velocity);
        }
    }

    /*private void Dash()
    {
        if (Input.GetButtonDown("PDash") && Cooldown.IsReady("Dash"))
        {
            Cooldown.Use("Dash");

            characterController.Move(direction * 50f * Time.fixedDeltaTime);
        }
    }*/
}