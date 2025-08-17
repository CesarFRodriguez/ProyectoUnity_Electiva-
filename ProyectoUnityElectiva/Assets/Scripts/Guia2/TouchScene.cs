using UnityEngine;
using TMPro;

public class TouchScene : MonoBehaviour
{
    public TextMeshProUGUI PhaseDisplayText;
    private Touch theTouch;
    private float TimeEnded, displayTime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhaseDisplayText.SetText("Touch Me");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            PhaseDisplayText.SetText(theTouch.phase.ToString());
            if (theTouch.phase == TouchPhase.Ended)
            {
                TimeEnded = Time.time;
            }
            else if (Time.time - TimeEnded > displayTime)
            {
                PhaseDisplayText.SetText("");
            }
        }
    }
}
