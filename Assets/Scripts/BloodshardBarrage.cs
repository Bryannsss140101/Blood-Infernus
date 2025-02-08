using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BloodshardBarrage : Ability
{
    protected override void HandleActivation()
    {
        Debug.Log($"Script: {name}");
    }
}