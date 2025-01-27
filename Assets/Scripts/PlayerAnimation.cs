using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    public void HandleAnimation()
    {
        var direction = new Vector3(
            Input.GetAxisRaw("Horizontal"), 0f,
            Input.GetAxisRaw("Vertical")).normalized;

        animator.SetFloat("Direction X", direction.x);
        animator.SetFloat("Direction Z", direction.z);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}