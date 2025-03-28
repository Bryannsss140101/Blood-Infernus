using System;
using UnityEngine;

/// <summary>
/// Enum for all abilitiesUI behaviour.
/// </summary>
[Flags]
public enum AbilityBehaviour
{
    NoTarget = 1 << 0,      // No indicator, activates instantly.
    Target = 1 << 2,        // Highlights the target unit.
    Point = 1 << 3,         // Green circle at the target location.
    Directional = 1 << 4,   // Arrow showing the projectile path.
    AOE = 1 << 5            // Green circle showing the affected area.
}

/// <summary>
/// Base class for all abilities in the game.
/// </summary>
public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected AbilitySO data;

    protected GameObject owner;

    public AbilitySO Data => data;

    public AbilityBehaviour Behaviour => data.behaviour;

    public event Action OnAbilityCreated;

    /// <summary>
    /// Activates the ability.
    /// </summary>
    /// <param name="onActivated">A callback to be executed after the activation process is complete.</param>
    public void Use()
    {
        if (!Cooldown.IsReady(data.abilityName))
            return;

        // Events
        OnAbilityCreated?.Invoke();

        // Logic
        HandleActivation();

        // Cooldown
        Cooldown.Use(data.abilityName);
    }

    protected virtual void Start()
    {
        Cooldown.Set(data.abilityName, data.cooldown);
    }

    /// <summary>
    /// Handles the specific logic for the ability.
    /// Must be implemented in derived classes.
    /// </summary>
    protected abstract void HandleActivation();
}