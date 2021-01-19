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
        }
        
    }

    void OnMouseDown()
    {
        anim.Play("HpAnimation");
    }
}
