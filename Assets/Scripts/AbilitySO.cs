using UnityEngine;

/// <summary>
/// Represents an ability in the game, stored as a ScriptableObject.
/// </summary>
[CreateAssetMenu(fileName = "NewAbility", menuName = "Abilities/Ability")]
public class AbilitySO : ScriptableObject
{
    public string abilityName;
    [TextArea] public string description;
    public Sprite icon;
    public AbilityBehaviour behaviour;
    public float cooldown;
    public float range;
}