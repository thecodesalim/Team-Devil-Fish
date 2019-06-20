using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int hit = 0;
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.position, 0.5f * Time.deltaTime);
        agent.SetDestination(target.position);

    }

    

    private void OnCollisionStay2D(Collision2D other) {
        hit++;
        if(hit == 150) {
            hit = 0;
            Destroy(other.gameObject);
        }
    }
}
