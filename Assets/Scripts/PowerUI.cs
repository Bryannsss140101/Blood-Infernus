using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Controls the UI elements for displaying power abilitiesUI.
/// </summary>
public class PowerUI : MonoBehaviour
{
    [SerializeField] private AbilityUI[] abilitiesUI;

    private bool isCreated;

    public bool IsReady { get => isCreated; }


    /// <summary>
    /// Settup UI elements for the given power's abilitiesUI.
    /// </summary>
    /// <param name="power">The power containing abilitiesUI.</param>
    public void SettupUI(Power power)
    {
        if (isCreated)
            return;

        for (int i = 0; i < abilitiesUI.Length; i++)
        {
            var ability = power.GetAbility(i);
            var abilityUI = abilitiesUI[i];

            abilityUI.SettupUI(ability.Data);
            ability.OnAbilityCreated += abilityUI.Timer;
        }

        isCreated = true;
    }

    /// <summary>
    /// Reset all UI elements.
    /// </summary>
    /// <param name="power">The power containing abilitiesUI.</param>
    public void ResetUI(Power power)
    {
        if (!isCreated)
            return;

        for (int i = 0; i < abilitiesUI.Length; i++)
        {
            var ability = power.GetAbility(i);
            var abilityUI = abilitiesUI[i];

            abilityUI.ResetUI();
            ability.OnAbilityCreated -= abilityUI.Timer;
            Cooldown.Reset(ability.Data.abilityName);
        }

        isCreated = false;
    }
}