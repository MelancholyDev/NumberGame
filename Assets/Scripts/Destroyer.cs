using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
   
    float sign;
    
    void Start()
    {
        sign = Random.Range(-1f, 1f);
        StartCoroutine(DestroyerCour());
    }
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 5*sign));
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
