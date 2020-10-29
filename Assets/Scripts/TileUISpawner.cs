using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUISpawner : MonoBehaviour
{
    [SerializeField]GameObject prefab;
    [SerializeField]Sprite[] sprites;
    float leftborderspawn = -2.5f;
    float rightborderspawn = 2.5f;
    float ycord=6;
    float delay=0.3f;
    System.Random rnd=new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTiles());
    }

    IEnumerator SpawnTiles()
    {
        GameObject spawned;
        while (true)
        {

            float xcord=Random.Range(leftborderspawn,rightborderspawn);
            spawned=Instantiate(prefab);
            spawned.transform.position = new Vector3(xcord,ycord,1);
            spawned.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 8)];
        
            yield return new WaitForSeconds(delay);
        }
    }
}
