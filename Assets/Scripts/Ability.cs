using System;
using UnityEngine;

/// <summary>
/// Base class for all abilities in the game.
/// </summary>
public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected AbilitySO data;

    public AbilitySO Data => data;

    /// <summary>
    /// Event triggered when the ability is activated.
    /// </summary>
    public event Action AbilityActivated;

    /// <summary>
    /// Activates the ability.
    /// </summary>
    public void Activate()
    {
        if (data == null)
        {
            Debug.LogWarning($"Ability {name} has no assigned AbilitySO.");
            return;
        }

        if (!Cooldown.IsReady(data.AbilityName))
            return;

        Cooldown.Use(data.AbilityName);
        HandleActivation();
        AbilityActivated?.Invoke();
    }

    protected virtual void Start()
    {
        Cooldown.SetCooldown(data.AbilityName, data.Cooldown);
    }

    /// <summary>
    /// Handles the specific logic for the ability.
    /// Must be implemented in derived classes.
    /// </summary>
    protected abstract void HandleActivation();
}
