using UnityEngine;

/// <summary>
/// Handles player power.
/// </summary>
public class PlayerPower : MonoBehaviour
{
    [SerializeField] private PowerUIController powerUIController;

    private Power power;

    public void HandlePower()
    {
        if (powerUIController.IsCreated)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                power.GetAbility(0).Activate();

            if (Input.GetKeyDown(KeyCode.W))
                power.GetAbility(1).Activate();

            if (Input.GetKeyDown(KeyCode.E))
                power.GetAbility(2).Activate();

            if (Input.GetKeyDown(KeyCode.R))
                power.GetAbility(3).Activate();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
            powerUIController.DestroyUI(power);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power"))
        {
            if (!this.power)
                powerUIController.DestroyUI(this.power);

            if (other.TryGetComponent(out Power power))
            {
                this.power = power;
                powerUIController.CreateUI(this.power);
            }
        }
    }
}