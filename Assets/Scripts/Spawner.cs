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
        timer = 50;
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if( timer < 0) {
            Instantiate(enemy,new Vector3(transform.position.x + Random.Range(0, 5),transform.position.y + Random.Range(0, 5), 0 ), Quaternion.identity);
            timer = 50;
        }
    }
}
