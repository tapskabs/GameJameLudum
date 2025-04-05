using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AImovement : MonoBehaviour
{
    public Transform playerTransforms;
    public float maxTime = 1.0f;
    public float minDistance = 1.0f;

    NavMeshAgent agent;
    Animator animator;
    float timer = 0.4f;

   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f) {
            float sqDistance = (playerTransforms.position - agent.destination).sqrMagnitude;
            if (sqDistance > minDistance*minDistance) {
                agent.destination = playerTransforms.position;
            }
            timer = maxTime;
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
