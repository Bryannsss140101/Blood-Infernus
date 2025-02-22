using UnityEngine;

/// <summary>
/// Represents an ability in the game, stored as a ScriptableObject.
/// </summary>
[CreateAssetMenu(fileName = "NewAbility", menuName = "Abilities/Ability")]
public class AbilitySO : ScriptableObject
{
    public string abilityName;
    public string description;
    public float cooldown;
    public AbilityBehaviour behaviour;
    public Sprite icon;
}