using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[RequireComponent(typeof(Camera))]
public class PinchZoom : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float zoomSpeed = 0.01f;
    [SerializeField] float minFov = 15f;
    [SerializeField] float maxFov = 90f;
    [SerializeField] float minOrtho = 1f;
    [SerializeField] float maxOrtho = 20f;

    bool pinching = false;
    float prevDistance = 0f;

    void OnEnable()
    {
        if (cam == null) cam = Camera.main;
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {
        var touches = Touch.activeTouches; // lista de EnhancedTouch touches
        if (touches.Count >= 2)
        {
            Vector2 p0 = touches[0].screenPosition;
            Vector2 p1 = touches[1].screenPosition;
            float currDist = Vector2.Distance(p0, p1);

            if (!pinching)
            {
                pinching = true;
                prevDistance = currDist;
                return;
            }

            float delta = currDist - prevDistance;

            if (cam.orthographic)
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - delta * zoomSpeed, minOrtho, maxOrtho);
            }
            else
            {
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - delta * zoomSpeed, minFov, maxFov);
            }

            prevDistance = currDist;
        }
        else
        {
            pinching = false;
        }
    }
}
