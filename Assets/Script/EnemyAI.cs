﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    public float chaseRange = 10f;

    NavMeshAgent navMeshAgent;
    float distanceToPlayer = Mathf.Infinity;

    public float turnSpeed = 10f;

    bool isProvoked = false;

    EnemyHealth health;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
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

    public void AgroAttack()
    {
        isProvoked = true;
    }

    private void AttackTarget()
    {
        FacePlayer();
        if (distanceToPlayer >= navMeshAgent.stoppingDistance)
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
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void ChasePlayer()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(player.position);
    }

    private void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
