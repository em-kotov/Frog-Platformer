using System;
using UnityEngine;

public class FrogInventory : MonoBehaviour
{
    public event Action<int> StrawberryValueChanged;

    public int StrawberryValue { get; private set; } = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Strawberry strawberry) && strawberry.CanCollect)
        {
            AddStrawberry();
            strawberry.DestroyWithEffect();
        }
    }

    private void AddStrawberry()
    {
        StrawberryValue++;
        StrawberryValueChanged?.Invoke(StrawberryValue);
    }
}
