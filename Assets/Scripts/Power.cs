using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents different power types.
/// </summary>
public enum PowerType
{
    BloodBullet,
    BloodBlade,
    BloodPump
}

/// <summary>
/// Manages a set of abilitiesUI associated with a specific power type.
/// </summary>
public class Power : MonoBehaviour
{
    [SerializeField] private PowerType powerType;

    private readonly Dictionary<int, Ability> abilities = new();

    /// <summary>
    /// Return an ability by its assigned key.
    /// </summary>
    /// <param abilityName="index">The key associated with the ability.</param>
    public Ability GetAbility(int index)
    {
        if (abilities.TryGetValue(index, out var ability))
            return ability;

        throw new KeyNotFoundException($"Ability with key '{index}' not found.");
    }

    /// <summary>
    /// Use an ability by its assigned key.
    /// </summary>
    /// <param abilityName="index">The key associated with the ability.</param>
    public void UseAbility(int index)
    {
        if (!abilities.TryGetValue(index, out var ability))
            throw new KeyNotFoundException($"Ability with key '{index}' not found.");

        ability.Use();
    }

    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Initializes the ability collection
    /// </summary>
    private void Initialize()
    {
        abilities.Clear();

        for (int i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).TryGetComponent(out Ability ability))
                abilities[i] = ability;
    }
}