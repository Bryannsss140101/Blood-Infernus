using UnityEngine;

/// <summary>
/// Controls the UI elements for displaying power abilities.
/// </summary>
public class PowerUIController : MonoBehaviour
{
    [SerializeField] private GameObject abilityUIPrefab;
    [SerializeField] private GameObject panel;

    private bool isCreated;

    /// <summary>
    /// Creates UI elements for the given power's abilities.
    /// </summary>
    /// <param name="power">The power containing abilities.</param>
    public void CreateUI(Power power)
    {
        if (isCreated)
            return;

        var abilities = power.GetAbilities();

        for (int i = 0; i < abilities.Count; i++)
        {
            var abilityUI = Instantiate(abilityUIPrefab,
                panel.transform).GetComponent<AbilityUI>();

            var ability = power.GetAbility(i);

            abilityUI.name = $"AbilityUI - {i}";

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

        var abilities = power.GetAbilities();

        for (int i = 0; i < abilities.Count; i++)
        {
            var abilityUI = panel.transform.GetChild(i).GetComponent<AbilityUI>();

            power.GetAbility(i).AbilityActivated -= abilityUI.OnActivated;

            Destroy(abilityUI.gameObject);
        }

        isCreated = false;
    }
}