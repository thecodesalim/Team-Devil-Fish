using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileShooter : MonoBehaviour {

    public GameObject prefab;
    private float timer;
    public Transform target;
    public GameObject[] enemies;
    public Transform[] enemyPos;
    public float minDist = Mathf.Infinity;
    public Transform tMin = null;

    // Start is called before the first frame update
    void Start () {
        //prefab = Resources.Load("projectile") as GameObject;
        timer = 30;
    }

    // Update is called once per frame
    void Update () {
        timer--;

        enemies = GameObject.FindGameObjectsWithTag ("Enemy");

        for (int i = 0; i < enemies.Length; i++) {

            float dist = Vector3.Distance (enemies[i].transform.position, transform.position);
            tMin = enemies[i].transform;
            if (dist < minDist) {
                
                //minDist = dist;

                if (timer <= 0) {
                    timer = 30;

                    if (dist <= 1.25f) {
                        Vector2 targetDir = tMin.position - transform.position;
                        targetDir = targetDir.normalized;

                        float distancebetween = Vector3.Distance (transform.position, target.position);

                        GameObject projectile = Instantiate (prefab) as GameObject;
                        projectile.transform.position = transform.position;
                        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D> ();

                       
                        transform.Rotate (Vector3.forward * 90);

                        rb.AddForce (targetDir * 100);
                        Destroy(projectile, 2f);

                    }

                }
            }

        }

    }
}