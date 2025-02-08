using System;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType
{
    BLOOD_BULLET, BLOOD_BLADE, BLOOD_PUMP
}

public class Power : MonoBehaviour
{
    [SerializeField] private PowerType powerType;

    private Dictionary<int, Ability> abilities;

    public Ability GetAbility(int id)
    {
        if (!abilities.ContainsKey(id))
            throw new KeyNotFoundException($"The key '{id}' does not exist.");

        return abilities[id];
    }

    public List<Ability> GetAbilities()
    {
        if (abilities.Count <= 0)
            throw new InvalidOperationException("The dictionary is empty.");

        return new(abilities.Values);
    }

    private void Start()
    {
        abilities = new();

        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.TryGetComponent<Ability>(out var temp))
                abilities.TryAdd(i, temp);
        }
    }
}