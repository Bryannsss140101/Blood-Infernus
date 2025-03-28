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
        if (characterController == null)
            return;

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
        float horizontal = Input.GetAxisRaw("Joystick Horizontal");
        float vertical = Input.GetAxisRaw("Joystick Vertical");

        direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude > 1)
            direction.Normalize();

        velocity = speed * Time.deltaTime * direction;
        characterController.Move(velocity);
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