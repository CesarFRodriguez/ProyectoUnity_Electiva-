using UnityEngine;
using UnityEngine.InputSystem;
// Importamos UnityEngine para trabajar en Unity
// e InputSystem para usar el nuevo sistema de entrada (toques, botones, etc.)

public class TapHandler : MonoBehaviour
{
    [Header("Arrastra desde el .inputactions")]
    public InputActionReference tapAction; 
    // Acción que detecta el toque (Tap). Se configura en el asset de Input Actions.

    public InputActionReference pointerPositionAction; 
    // Acción que da la posición del dedo/mouse en la pantalla.

    [Header("Opcional")]
    public Camera cam; 
    // Cámara que vamos a usar
    // Si no se asigna, usará Camera.main

    public LayerMask raycastLayers = ~0; 
    // Permite filtrar en qué capas queremos detectar el toque.
    // ~0 significa "todas las capas".

    void OnEnable()
    {
        // Se ejecuta cuando el objeto se activa en la escena.

        if (tapAction != null)
        {
            // Nos suscribimos al evento "performed" para ejecutar el método OnTap.
            tapAction.action.performed += OnTap;
            tapAction.action.Enable(); 
            // Activamos la acción para que empiece a escuchar entradas.
        }

        if (pointerPositionAction != null)
        {
            pointerPositionAction.action.Enable(); 
            // También activamos la acción que da la posición del dedo.
        }
    }

    void OnDisable()
    {
        // Se ejecuta cuando el objeto se desactiva o destruye.

        if (tapAction != null)
        {
            tapAction.action.performed -= OnTap; 
            // Importante: nos desuscribimos del evento para evitar errores o fugas de memoria.
            tapAction.action.Disable(); 
            // La desactivamos para liberar recursos.
        }

        if (pointerPositionAction != null)
        {
            pointerPositionAction.action.Disable(); 
            // Igual desactivamos la acción de posición.
        }
    }

    private void OnTap(InputAction.CallbackContext ctx)
    {
        // Este método se ejecuta cada vez que ocurre un tap en la pantalla.
        Camera cameraToUse = cam != null ? cam : Camera.main;
        // Usamos la cámara asignada o, si no hay, la cámara principal.

        if (cameraToUse == null) return;
        //si no hay camaras disponibles, salios sin hacer nada

        Vector2 screenPos = pointerPositionAction.action.ReadValue<Vector2>();
        // Leemos la posición de la pantalla donde el usuario tocó.

        Ray ray = cameraToUse.ScreenPointToRay(screenPos);
        // Convertimos la posición en pantalla en un rayo 3D.


        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, raycastLayers))
        {
            // Si el rayo golpea algo en menos de 100 unidades y en las capas permitidas:

            Debug.Log($"Tap sobre: + { hit.collider.gameObject.name}");
            // Mostramos en consola el objeto que fue tocado.

            // Ejemplo extra: instanciar una esfera en el punto tocado
            // GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // sphere.transform.position = hit.point;
        }
        else
        {
            Debug.Log("Tap en vacío (no golpeó nada)");
            // Si el toque no golpeó nada en la escena.
        }
    }
}
