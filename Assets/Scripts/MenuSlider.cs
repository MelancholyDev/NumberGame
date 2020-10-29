using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSlider : MonoBehaviour
{
    float leftboarder = -900;
    float rightboarder=778;
    float translatespeed=30;
    float last_state;
    Vector2 pos;
    bool moving;
    [SerializeField] GameObject menucenter; 
    [SerializeField]GameObject[] modes;
    [SerializeField] GameObject x;
    void Start()
    {
        pos = new Vector2(menucenter.gameObject.transform.position.x, menucenter.gameObject.transform.position.y);   
    }
   public void StartMove()
   {
        moving = true;
        last_state = Input.mousePosition.x;
   }
    public void EndMove()
    {
        moving = false;
        int index = 0;
        float curdist = 1000000;
        for(int i = 0; i < modes.Length; i++)
        {
            Debug.Log(Mathf.Abs(modes[i].transform.position.x - menucenter.transform.position.x));
            if (Mathf.Abs(modes[i].transform.position.x - menucenter.transform.position.x) < Mathf.Abs(curdist))
            {
                index = i;
                curdist = modes[i].transform.position.x - menucenter.transform.position.x;
            }
        }
        StartCoroutine(Replacer(curdist));
        
    }
    IEnumerator Replacer(float distance)
    {
        float sign = -1*distance / Mathf.Abs(distance);
        float last = Mathf.Abs(distance);
        while (last > 1)
        {
            x.transform.Translate(sign* translatespeed, 0, 0);
            last -= 1*translatespeed;
            yield return new WaitForEndOfFrame();
        }
    }
    void Update()
   {
        Debug.Log(x.transform.position.x);
        if (moving & EnableMove(Input.mousePosition.x - last_state))          
        {
            Debug.Log("yes");
            x.transform.Translate(new Vector3(Input.mousePosition.x-last_state, 0, 0));
            last_state = Input.mousePosition.x;
        }
   }
    bool EnableMove(float z)
    {
        if (z > 0)
            if (x.transform.position.x >= rightboarder)
                return false;
            else return true;
        else
            if (x.transform.position.x <= leftboarder)
            return false;
        else return true;
    }      


}
