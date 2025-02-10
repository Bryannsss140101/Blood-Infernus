using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Represents different power types.
/// </summary>
public enum PowerType
{
    BLOOD_BULLET,
    BLOOD_BLADE,
    BLOOD_PUMP
}

/// <summary>
/// Manages a set of abilities associated with a specific power type.
/// </summary>
public class Power : MonoBehaviour
{
    [SerializeField] private PowerType powerType;

    private readonly Dictionary<int, Ability> abilities = new();

    /// <summary>
    /// Return an ability by its assigned key.
    /// </summary>
    /// <param abilityName="id">The key associated with the ability.</param>
    public Ability GetAbility(int id)
    {
        if (abilities.TryGetValue(id, out var ability))
            return ability;

        throw new KeyNotFoundException($"Ability with key '{id}' not found.");
    }

    /// <summary>
    /// Return all abilities stored in this power.
    /// </summary>
    public List<Ability> GetAbilities()
    {
        return abilities.Count > 0 ? abilities.Values.ToList() :
            throw new InvalidOperationException("No abilities available.");
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