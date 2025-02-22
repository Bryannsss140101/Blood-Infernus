using System;
using UnityEngine;

/// <summary>
/// Enum for all abilitiesUI behaviour.
/// </summary>
[Flags]
public enum AbilityBehaviour
{
    None = 0,
    Passive = 1 << 0,
    NoTarget = 1 << 1,
}

/// <summary>
/// Base class for all abilitiesUI in the game.
/// </summary>
public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected AbilitySO data;

    public AbilitySO Data => data;

    public AbilityBehaviour behaviour => data.behaviour;

    /// <summary>
    /// Event triggered when the ability is activated.
    /// </summary>
    public event Action AbilityActivated;

    /// <summary>
    /// Activates the ability.
    /// </summary>
    public void Activate()
    {
        if (Cooldown.Get(data.abilityName))
        {
            if (!Cooldown.IsReady(data.abilityName)) return;
            Cooldown.Use(data.abilityName);
        }

        HandleActivation();
        AbilityActivated?.Invoke();
    }

    protected virtual void Start()
    {
        if (HasAnyFlags(AbilityBehaviour.NoTarget))
            Cooldown.Set(data.abilityName, data.cooldown);
    }

    /// <summary>
    /// Handles the specific logic for the ability.
    /// Must be implemented in derived classes.
    /// </summary>
    protected abstract void HandleActivation();

    /// <summary>
    /// Checks if the ability has at least one of the specified flags.
    /// </summary>
    /// <param name="flags">The flags to check.</param>
    private bool HasAnyFlags(AbilityBehaviour flags)
    {
        return (behaviour & flags) != 0;
    }
}