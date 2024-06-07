using TMPro;
using UnityEngine;

public class FrogInventoryDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _strawberryText;

    public void DisplayStrawberryValue(int value)
    {
        _strawberryText.text = value.ToString();
    }
}
