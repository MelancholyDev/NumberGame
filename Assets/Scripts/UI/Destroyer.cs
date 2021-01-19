using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Start()
    {
        float sign = Random.Range(-20f, 20f);
        StartCoroutine(DestroyerCour());
        gameObject.GetComponent<Rigidbody2D>().AddTorque(sign); 
    }
    IEnumerator DestroyerCour()
    {
        while (true)
        {

            if(gameObject.transform.position.y<=-6)
            Destroy(gameObject);
            yield return new WaitForSeconds(0.2f);
        }
    }
   
}
