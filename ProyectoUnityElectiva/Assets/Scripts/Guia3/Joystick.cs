using UnityEngine;
using UnityEngine.InputSystem;
// Importamos UnityEngine para trabajar en Unity y el nuevo sistema InputSystem.

public class PlayerMover : MonoBehaviour
{
    [Header("Acción Move (Vector2) desde el .inputactions")]
    public InputActionReference moveAction; 
    // Referencia a la acción "Move" que se configuró en el asset de Input Actions.
    // Devuelve un Vector2 con la dirección (-1..1 en x e y).

    [Header("Movimiento")]
    public float speed = 3.5f; 
    // Velocidad de movimiento del objeto.

    public bool moveInCameraPlane = true; 
    // Si es true, el movimiento se calcula relativo a la cámara principal (útil para juegos en 3ra persona).

    void OnEnable()
    {
        // Cuando el objeto se activa, habilitamos la acción para que empiece a recibir valores.
        if (moveAction != null) moveAction.action.Enable();
    }

    void OnDisable()
    {
        // Cuando el objeto se desactiva, deshabilitamos la acción para liberar recursos.
        if (moveAction != null) moveAction.action.Disable();
    }

    void Update()
    {
        // Este método se llama cada frame.
        if (moveAction == null) return; // Si no hay acción asignada, salimos.

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        // Leemos el valor de la acción "Move" (ejes X e Y del joystick o stick virtual).

        Vector3 dir = new Vector3(input.x, 0f, input.y);
        // Convertimos el Vector2 en un Vector3 para mover en el plano XZ (horizontal).

        if (moveInCameraPlane && Camera.main)
        {
            // Si queremos que el movimiento sea relativo a la cámara principal:
            // Calculamos la dirección de la cámara en el plano horizontal (ignoramos el eje Y).
            Vector3 camFwd = Camera.main.transform.forward;
            camFwd.y = 0f; camFwd.Normalize();

            Vector3 camRight = Camera.main.transform.right;
            camRight.y = 0f; camRight.Normalize();

            // Ajustamos la dirección del movimiento según la orientación de la cámara.
            dir = camFwd * dir.z + camRight * dir.x;
        }

        // Aplicamos el movimiento multiplicando por la velocidad y el tiempo entre frames (para suavidad).
        transform.position += dir * speed * Time.deltaTime;
    }
}
