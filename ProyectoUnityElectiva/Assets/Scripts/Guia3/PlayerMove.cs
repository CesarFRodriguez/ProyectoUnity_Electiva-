using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    Vector2 moveInput = Vector2.zero;
    CharacterController cc;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    // llamado desde InputAction (por suscripción en PlayerInputHandler o por Send Messages/Inspector)
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        if (move.magnitude > 0.01f)
        {
            // mover relativo al mundo:
            cc.SimpleMove(move * speed);
            // si quieres rotar al personaje:
            transform.forward = Vector3.Slerp(transform.forward, move.normalized, 0.2f);
        }
    }
}
