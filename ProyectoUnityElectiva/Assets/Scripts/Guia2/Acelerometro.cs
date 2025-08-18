using UnityEngine;
using TMPro;

public class Acelerometro : MonoBehaviour
{
    public TextMeshProUGUI AccelerometerDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AccelerometerDisplay.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        AccelerometerDisplay.SetText("Aceleration X: " + Input.acceleration.x + "\nAceleration Y: " + Input.acceleration.y + "\nAceleration Z: " + Input.acceleration.z);
    }
}
