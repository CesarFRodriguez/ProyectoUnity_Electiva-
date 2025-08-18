using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Gestos : MonoBehaviour
{
    private Touch theTouch;
    public GameObject rotationPivot;
    public GameObject Camera;
    private Vector3 rotation = new Vector3(0, 0, 0);
    private Vector3 zoom = new Vector3(0, 0, 0);
    private Vector3 position = new Vector3(0, 0, 0);
    public float sensibility = 5.0f;
    public float zoomSpeed = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zoom = Camera.transform.localPosition;
        position = rotationPivot.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                Vector2 delta = theTouch.deltaPosition;
                float x = delta.x;
                float y = delta.y;
                rotation = rotation + new Vector3(-sensibility * y, sensibility * x, 0f);
            }
            if (Input.touchCount == 2)
            {
                Touch Touch1 = Input.GetTouch(0);
                Touch Touch2 = Input.GetTouch(1);

                Vector2 Touch1Current = Touch1.position;
                Vector2 Touch2Current = Touch2.position;
                Vector2 Touch1Prev = Touch1.position - Touch1.deltaPosition;
                Vector2 Touch2Prev = Touch2.position - Touch2.deltaPosition;

                float difference = Vector2.Distance(Touch1Current, Touch2Current) - Vector2.Distance(Touch1Prev, Touch2Prev);
                zoom.z = difference * zoomSpeed;
                position.x = Touch1.position.x;
                position.y = Touch1.position.y;
            }
        }
        rotationPivot.transform.localRotation = Quaternion.Euler(rotation);
        rotationPivot.transform.localPosition = position;
        Camera.transform.localPosition = zoom;
    }
}
