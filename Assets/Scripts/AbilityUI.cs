using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Handles the UI visualization for abilitiesUI.
/// </summary>

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;

    private AbilitySO data;
    private float timer;
    private bool hasCooldown;

    /// <summary>
    /// SettupUI the component with a specified data.
    /// </summary>
    /// <param name="data">The data to be used.</param>
    public void SettupUI(AbilitySO data)
    {
        this.data = data;
        image1.sprite = data.icon;
        timer = data.cooldown;
        hasCooldown = (data.behaviour & AbilityBehaviour.NoTarget) != 0;
    }

    /// <summary>
    /// Reset the component by default.
    /// </summary>
    public void ResetUI()
    {
        data = null;
        image1.sprite = default;
        timer = 0f;
        hasCooldown = false;
    }

    /// <summary>
    /// Called when the ability is activated.
    /// </summary>
    public void CooldownActivated()
    {
        if (hasCooldown)
        {
            ExecuteEvents.Execute(button.gameObject,
                            new PointerEventData(EventSystem.current),
                            ExecuteEvents.pointerDownHandler);

            image2.fillAmount = 1;
            button.interactable = false;
        }
    }

    private void Update()
    {
        if (!data)
            return;

        if (hasCooldown)
            Cooldown();

    }

    /// <summary>
    /// Handles the cooldown of a UI button.
    /// </summary>
    private void Cooldown()
    {
        if (image2.fillAmount > 0)
            image2.fillAmount -= 1 / timer * Time.deltaTime;
        else
            button.interactable = true;
    }
}