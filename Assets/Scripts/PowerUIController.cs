using UnityEngine;

public class PowerUIController : MonoBehaviour
{
    [SerializeField] private GameObject abilityUIPrefab;
    [SerializeField] private GameObject panel;

    private bool isCreated;

    public void CreateUI(Power power)
    {
        if (isCreated)
            return;

        var abilities = power.GetAbilities();

        for (int i = 0; i < abilities.Count; i++)
        {
            var abilityUI = Instantiate(abilityUIPrefab, panel.transform).GetComponent<AbilityUI>();
            abilityUI.name = $"AbilityUI - {i}";
            abilityUI.Timer = power.GetAbility(i).Data.cooldown;

            power.GetAbility(i).AbilityActivated += abilityUI.OnActivated;
        }

        isCreated = true;
    }

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