using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private AbilitySO data;

    public AbilitySO Data => data;

    public event Action AbilityActivated;

    public void Activate()
    {
        if (!Cooldown.IsReady(data.name))
            return;

        Cooldown.Use(data.name);

        HandleActivation();

        AbilityActivated?.Invoke();
    }

    protected virtual void Start()
    {
        Cooldown.SetCooldown(data.name, data.cooldown);
    }

    protected abstract void HandleActivation();
}