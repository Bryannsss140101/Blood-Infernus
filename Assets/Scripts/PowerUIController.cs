using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Controls the UI elements for displaying power abilities.
/// </summary>
public class PowerUIController : MonoBehaviour
{
    private bool isCreated;

    public bool IsCreated { get => isCreated; }


    /// <summary>
    /// Creates UI elements for the given power's abilities.
    /// </summary>
    /// <param name="power">The power containing abilities.</param>
    public void CreateUI(Power power)
    {
        if (isCreated)
            return;

        for (int i = 0; i < transform.childCount; i++)
        {
            var abilityUI = transform.GetChild(i).GetComponent<AbilityUI>();
            var ability = power.GetAbility(i);

            abilityUI.Initialize(ability.Data.Icon, ability.Data.Cooldown);
            ability.AbilityActivated += abilityUI.OnActivated;
        }

        isCreated = true;
    }

    /// <summary>
    /// Destroy all UI elements.
    /// </summary>
    /// <param name="power">The power containing abilities.</param>
    public void DestroyUI(Power power)
    {
        if (!isCreated)
            return;

        for (int i = 0; i < transform.childCount; i++)
        {
            var abilityUI = transform.GetChild(i).GetComponent<AbilityUI>();
            var ability = power.GetAbility(i);

            abilityUI.Initialize(default, default);
            ability.AbilityActivated -= abilityUI.OnActivated;

            Cooldown.Reset(ability.Data.AbilityName);
        }

        isCreated = false;
    }
}