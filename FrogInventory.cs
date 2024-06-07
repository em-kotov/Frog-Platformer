using UnityEngine;

public class FrogInventory : MonoBehaviour
{
    private FrogInventoryDisplay _display;
    private int _strawberryValue = 0;

    private void Start()
    {
        _display = GetComponent<FrogInventoryDisplay>();
    }

    private void Update()
    {
        _display.DisplayStrawberryValue(_strawberryValue);
    }

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
        _strawberryValue++;
    }
}
