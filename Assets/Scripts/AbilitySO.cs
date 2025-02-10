using UnityEngine;

/// <summary>
/// Represents an ability in the game, stored as a ScriptableObject.
/// </summary>
[CreateAssetMenu(fileName = "NewAbility", menuName = "Abilities/Ability")]
public class AbilitySO : ScriptableObject
{
    [SerializeField] private string abilityName;
    [TextArea(3, 3)][SerializeField] private string description;
    [SerializeField] private float cooldown;
    [SerializeField] private Sprite icon;

    public string AbilityName => abilityName;

    public string Description => description;

    public float Cooldown => cooldown;

    public Sprite Icon => icon;
}