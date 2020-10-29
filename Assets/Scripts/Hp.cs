using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
  
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
       

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Death",true);
            Debug.Log("asdad");
        }
        
    }

    void OnMouseDown()
    {
       // anim = GetComponent<Animator>();
       anim.Play("HpAnimation");
    }
}
