using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the UI visualization for abilitiesUI.
/// </summary>
public class AbilityUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image icon;
    [SerializeField] private Image fill;

    private AbilitySO data;

    /// <summary>
    /// SettupUI the component with a specified data.
    /// </summary>
    /// <param name="data">The data to be used.</param>
    public void SettupUI(AbilitySO data)
    {
        this.data = data;
        icon.sprite = data.icon;
        fill.fillAmount = 0;
    }

    /// <summary>
    /// Reset the component by default.
    /// </summary>
    public void ResetUI()
    {
        data = null;
        icon.sprite = default;
        fill.fillAmount = 0;
    }

    /// <summary>
    /// Time the cooldown of a UI button.
    /// </summary>
    public async void Timer()
    {
        fill.fillAmount = 1;
        button.interactable = false;

        while (fill.fillAmount > 0)
        {
            fill.fillAmount -= 1 / data.cooldown * Time.deltaTime;
            await UniTask.Yield();
        }

        fill.fillAmount = 0;
        button.interactable = true;
    }
}