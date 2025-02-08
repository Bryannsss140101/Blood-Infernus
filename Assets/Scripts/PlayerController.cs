using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;
    // private PlayerPower playerAttack;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        // playerAttack = GetComponent<PlayerPower>();
    }

    private void Update()
    {
        playerMovement.HandleMovement();
        playerAnimation.HandleAnimation();
        // playerAttack.HandleAbility();
    }
}