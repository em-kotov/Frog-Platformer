using TMPro;
using UnityEngine;

public class FrogInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _strawberryText;

    private int _strawberryValue = 0;

    private void Update()
    {
        _strawberryText.text = _strawberryValue.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Strawberry>(out Strawberry strawberry) && strawberry.CanCollect)
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
