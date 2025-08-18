using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject Creature_Model;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void RotateLeft()
    {
        Creature_Model.transform.Rotate (0.0f, 10.0f, 0.0f, Space.Self);
    }
    public void RotateRight()
    {
        Creature_Model.transform.Rotate (0.0f, -10.0f, 0.0f, Space.Self);
    }
    public void TranslateUp()
    {
        Creature_Model.transform.Translate(Vector3.up * Time.deltaTime * 20, Space. World);
    }
    public void TranslateDown()
    {
        Creature_Model.transform.Translate(Vector3.down * Time.deltaTime*20, Space.World);
    }
    public void TranslateLeft()
    {
        Creature_Model.transform.Translate(Vector3.left * Time.deltaTime * 20, Space.World);
    }
    public void TranslateRight()
    {
        Creature_Model.transform.Translate(Vector3.right * Time.deltaTime * 20, Space.World);
    }
    public void Scale(float magnitud)
    {
        Vector3 changerscale = new Vector3(magnitud, magnitud, magnitud);
        Creature_Model.transform.localScale += changerscale;
    }
        


    // Update is called once per frame
        void Update()
    {
        
    }
}




