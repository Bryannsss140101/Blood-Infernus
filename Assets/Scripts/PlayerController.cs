using UnityEngine;

/// <summary>
/// Handles player controller.
/// </summary>
public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;
    private PlayerPower playerPower;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerPower = GetComponent<PlayerPower>();
    }

    private void Update()
    {
        playerMovement.HandleMovement();
        playerAnimation.HandleAnimation();
        playerPower.HandlePower();
    }
}