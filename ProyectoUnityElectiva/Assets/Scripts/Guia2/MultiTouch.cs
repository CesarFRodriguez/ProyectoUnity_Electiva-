using UnityEngine;
using TMPro;

public class MultiTouch : MonoBehaviour
{
    public TextMeshProUGUI InfoDisplay;
    private int maxtapcount = 0;
    private string multiTouchInfo;
    private Touch theTouch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InfoDisplay.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        maxtapcount = Input.touchCount;
        multiTouchInfo = string.Format("Número de dedos: "+ maxtapcount + "\n");
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                theTouch = Input.GetTouch(i);
                string info = "Touch " + i.ToString() + "\nCordenadas: \nX: " + theTouch.position.x + "\nY: " + theTouch.position.y + "\n";
                multiTouchInfo += info;
            }
        }
        InfoDisplay.SetText(multiTouchInfo);
    }
}
