using TMPro;
using UnityEngine;

[RequireComponent(typeof(FrogInventory))]
public class FrogInventoryDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _strawberryText;

    private FrogInventory _inventory;

    private void Awake()
    {
        _inventory = GetComponent<FrogInventory>();
    }

    private void OnEnable()
    {
        _inventory.StrawberryValueChanged += DisplayStrawberryValue;
    }

    private void OnDisable()
    {
        _inventory.StrawberryValueChanged -= DisplayStrawberryValue;
    }

    private void DisplayStrawberryValue(int value)
    {
        _strawberryText.text = value.ToString();
    }
}
