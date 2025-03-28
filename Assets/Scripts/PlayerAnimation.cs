using UnityEngine;

/// <summary>
/// Handles player animation.
/// </summary>
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    /// <summary>
    /// Updates animation parameters based on player input.
    /// </summary>
    public void HandleAnimation()
    {
        if (animator == null)
            return;

        var direction = new Vector3(
            Input.GetAxisRaw("Joystick Horizontal"), 0f,
            Input.GetAxisRaw("Joystick Vertical"));

        if (direction.sqrMagnitude > 1)
            direction.Normalize();

        animator.SetFloat("Direction X", direction.x);
        animator.SetFloat("Direction Z", direction.z);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}