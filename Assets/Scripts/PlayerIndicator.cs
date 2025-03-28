using UnityEngine;

public class PlayerIndicator : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    public Power Power { get; set; }

    public void HandleIndicator()
    {
    }


}