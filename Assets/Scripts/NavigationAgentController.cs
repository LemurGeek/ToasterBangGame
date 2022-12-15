using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAgentController : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float chaseRange = 5.0F;
    [SerializeField]
    float rotationSpeed = 2.5F;
    [ReadOnly]
    [SerializeField]
    float distanceToTarget;
    [ReadOnly]
    [SerializeField]
    bool chaseTarget;
    NavMeshAgent navAgent;
    Animator animator;

    CounterAttackController counterAttack;
    bool isAttacking;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
        counterAttack = GetComponent<CounterAttackController>();
        counterAttack.OnAttackEnded.AddListener(OnAttackEnded);
        //animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        chaseTarget = (distanceToTarget <= chaseRange);
        if (chaseTarget)
        {
            EngageTarget();
        }
        else
        {
            StopFollowingTarget();
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    void EngageTarget()
    {
        FaceTarget();
        ChaseTarget(target.position);
        if (distanceToTarget <= navAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    void FaceTarget()
    {
        Vector3 direction = -(target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0F, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
    void ChaseTarget(Vector3 position)
    {
        //animator.SetBool("isWalking", true);
        navAgent.SetDestination(position);
    }
    void AttackTarget()
    {
        if (isAttacking) {
            return;
        }
        isAttacking = true;
        //animator.SetTrigger("attack");
        StartCoroutine(counterAttack.Attack());
    }
    void StopFollowingTarget()
    {
        if (!chaseTarget)
        {
            //animator.SetBool("isWalking", false);
            ChaseTarget(transform.position);
        }
    }
    void OnAttackEnded() {
        isAttacking = false;
    }
}