using UnityEngine;

public class Tile : MonoBehaviour
{
    TextMesh text; 
    public int _id { get; private set; }

    void Awake()
    {
        text = GetComponentInChildren<TextMesh>();
    }

    public void ChangeId(int id)
    {
        if (id == -1)
            text.text = "";
        else
        {
            text.text = id.ToString();
        }

    }

    void OnMouseDown()
    {
        if (GameManager.ingamemanager.curGm.CheckoutCorrectId(this))
            ChangeId(-1);
        else
            GameManager.ingamemanager.Damage();
      
    }
}
