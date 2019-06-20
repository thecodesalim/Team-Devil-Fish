using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if( timer < 0) {
            Instantiate(enemy,new Vector3(transform.position.x, transform.position.y + Random.Range(-1, 2.5f), 0 ), Quaternion.identity);
            timer = 100;
        }
    }
}
