using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;

    NavMeshAgent navMeshAgent;
    float distanceToPlayer = Mathf.Infinity;

    bool isProvoked = false;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (isProvoked)
        {
            AttackTarget();
        }

        else if(distanceToPlayer < chaseRange)
        {
            isProvoked = true;
        }
        
    }

    private void AttackTarget()
    {
        if(distanceToPlayer >= navMeshAgent.stoppingDistance)
        {
            ChasePlayer();
        }
        if(distanceToPlayer <= navMeshAgent.stoppingDistance)
        {
            ShootTarget();
        }
    }

    private void ShootTarget()
    {
        Debug.Log(name + " hit " + player.name);
    }

    private void ChasePlayer()
    {
        navMeshAgent.SetDestination(player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
