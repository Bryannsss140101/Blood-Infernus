using UnityEngine;

/// <summary>
/// A specific ability.
/// </summary>
public sealed class BloodshardBarrage : Ability
{
    /// <summary>
    /// Handles the activation logic of the specific ability
    /// </summary>
    protected override void HandleActivation()
    {
        RaycastHit hit;

        if (Physics.Raycast(owner.transform.position, owner.transform.forward, out hit, data.range))
        {
            Debug.DrawLine(owner.transform.position, hit.point, Color.red);
        }
        else
        {
            Debug.DrawLine(owner.transform.position, owner.transform.position * data.range, Color.red);
        }
    }
}