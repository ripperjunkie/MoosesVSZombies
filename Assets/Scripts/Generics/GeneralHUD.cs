using UnityEngine;
using TMPro;

public class GeneralHUD : MonoBehaviour
{
    public TextMeshProUGUI healthUI;   

    public void UpdateHealth(float _health) => healthUI.text = _health.ToString();
}
