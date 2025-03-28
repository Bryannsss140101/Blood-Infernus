using UnityEngine;

/// <summary>
/// Handles player power.
/// </summary>
public class PlayerPower : MonoBehaviour
{
    [SerializeField] private PowerUI powerUIController;

    private Power power;
    private float radius;

    public void HandlePower()
    {
        if (powerUIController.IsReady)
        {
            if (Input.GetButtonDown("Button Square"))
                power.UseAbility(0);

            if (Input.GetButtonDown("Button L1"))
                powerUIController.ResetUI(power);
        }
    }

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power"))
        {
            if (!this.power)
                powerUIController.ResetUI(this.power);

            if (other.TryGetComponent(out Power power))
            {
                this.power = power;
                powerUIController.SettupUI(this.power);
            }
        }
    }
}