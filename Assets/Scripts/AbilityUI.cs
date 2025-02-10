using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the UI visualization for abilities.
/// </summary>

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;

    /// <summary>
    /// The cooldown duration in seconds.
    /// </summary>
    private float timer;

    /// <summary>
    /// Initializes the component with a specified icon and timer.
    /// </summary>
    /// <param name="icon">The sprite to be displayed as the icon.</param>
    /// <param name="timer">The duration or countdown value to be set.</param>
    public void Initialize(Sprite icon, float timer)
    {
        image1.sprite = icon;
        this.timer = timer;
    }

    /// <summary>
    /// Called when the ability is activated.
    /// </summary>
    public void OnActivated()
    {
        image2.fillAmount = 1;
        button.enabled = false;
    }

    private void Start()
    {
        button ??= GetComponentInChildren<Button>();
        image1 ??= GetComponentInChildren<Image>();
        image2 ??= GetComponentInChildren<Image>();
    }

    private void Update()
    {
        if (image2.fillAmount > 0)
            image2.fillAmount -= 1 / timer * Time.deltaTime;
        else
            button.enabled = true;
    }
}