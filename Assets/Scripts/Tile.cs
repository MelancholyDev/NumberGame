using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    TextMesh text; 
    public float _id { get; private set; }

    void Awake()
    {
        text = GetComponentInChildren<TextMesh>();
    }

    public void ChangeId(string id)
    {
        if (id[2] != '0')
        {
            string cur = id.Substring(3);
            int x = 0;
            int.TryParse(cur, out x);
            _id = x;
            if (x != 0)
                text.text = x.ToString();
            else
                text.text = "";
        }else
        {
            Debug.Log("ID:" + id);
            char symbol = id[3];
            string cur = id.Substring(4);
            int x = 0;
            int.TryParse(cur, out x);
            _id = x;
            if (x != 0)
                text.text = ""+symbol;
            else
                text.text = "";
        }

    }

    void OnMouseDown()
    {

        if (GameManager.ingamemanager.initializer.CurGM.CheckoutCorrectId(this))
            ChangeId("id10");
        else
            GameManager.ingamemanager.Damage();
      
    }
}
