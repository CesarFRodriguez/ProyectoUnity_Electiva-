using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;   // necesario para usar TextMeshProUGUI

public class TapHandler : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] TextMeshProUGUI tapText;  // arrastrar en inspector

    void Awake()
    {
        if (cam == null) cam = Camera.main;
    }

    public void OnTap(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 screenPos = Pointer.current != null
            ? Pointer.current.position.ReadValue()
            : Vector2.zero;

        Ray ray = cam.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            string msg = $"Tocaste: {hit.collider.name}";
            Debug.Log(msg);
            if (tapText != null) tapText.text = msg;
        }
        else
        {
            string msg = $"Tap en vacío en pantalla: {screenPos}";
            Debug.Log(msg);
            if (tapText != null) tapText.text = msg;
        }
    }
}
