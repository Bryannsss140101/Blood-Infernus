using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Abilities/Ability")]
public class AbilitySO : ScriptableObject
{
    public new string name;
    [TextArea(3, 3)] public string description;
    public float cooldown;
    public Sprite icon;
}