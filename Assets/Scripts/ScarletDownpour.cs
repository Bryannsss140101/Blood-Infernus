using UnityEngine;

/// <summary>
/// A specific ability.
/// </summary>
public sealed class ScarletDownpour : Ability
{
    /// <summary>
    /// Handles the activation logic of the specific ability
    /// </summary>
    protected override void HandleActivation()
    {
        Debug.Log($"{data.abilityName} activated!");
    }
}