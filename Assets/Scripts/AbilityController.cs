using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
}

/*private Dictionary<int, Ability> abilities;

private void Start()
{
    abilities = new();
}

public void Create()
{
    for (int i = 0; i < transform.childCount; i++)
    {
        var child = transform.GetChild(i);
        if (child.TryGetComponent<Ability>(out var temp) &&
            !abilities.ContainsKey(i))
            abilities[i] = temp;
    }
}

public void Destroy()
{
    abilities.Clear();
}
}AA*/

/*private Dictionary<int, Ability> abilities;

public Ability GetAbility(int id)
{
    if (!abilities.ContainsKey(id))
        throw new KeyNotFoundException($"The key '{id}' does not exist.");

    return abilities[id];
}

public List<Ability> GetAbilities()
{
    return new(abilities.Values);
}

private void Start()
{
    // Initalize();
}

private void Initalize()
{
    abilities = new();

    for (int i = 0; i < transform.childCount; i++)
    {
        var child = transform.GetChild(i);
        if (child.TryGetComponent<Ability>(out var temp) &&
            !abilities.ContainsKey(i))
            abilities[i] = temp;
    }
}*/
