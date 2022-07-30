using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider : MonoBehaviour
{
    public GameObject spider;
    public Transform spawnPoint;
    int cantSpiders = 0;
    float timerSecs = 7f;

    void soltarSpider()
    {
        Instantiate(spider, spawnPoint.position, spawnPoint.rotation);
    }


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        timerSecs -= Time.deltaTime;
        Debug.Log("Timer " + timerSecs);
        if (timerSecs <= 0 && cantSpiders <= 3)
            
        {
            soltarSpider();
            Debug.Log ("Cant Spiders " + cantSpiders);
            timerSecs = 7f;
            cantSpiders += 1;
        }

    }
}
