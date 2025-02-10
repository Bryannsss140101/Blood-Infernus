using UnityEngine;

/// <summary>
/// Handles player power.
/// </summary>
public class PlayerPower : MonoBehaviour
{
    [SerializeField] private KeyCode[] keys;
    [SerializeField] private Power power;
    [SerializeField] private PowerUIController powerUIController;

    public void HandlePower()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            powerUIController.CreateUI(power);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            powerUIController.DestroyUI(power);

        if (Input.GetKeyDown(keys[0]))
            power.GetAbility(0).Activate();

        if (Input.GetKeyDown(keys[1]))
            power.GetAbility(1).Activate();

        if (Input.GetKeyDown(keys[2]))
            power.GetAbility(2).Activate();

        if (Input.GetKeyDown(keys[3]))
            power.GetAbility(3).Activate();
    }
}