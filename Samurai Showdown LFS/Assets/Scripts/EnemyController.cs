using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}
public class EnemyController : MonoBehaviour
{

    private EnemyAnimator enemyAnim;
    private NavMeshAgent agent;

    private EnemyState enemyState;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float chaseDistance;

    private float currentChaseDistance;
    [SerializeField] float attackDistance;
    [SerializeField] float chaseAfterAttackDistance;

    [SerializeField] float patrolRadiusMin;
    [SerializeField] float patrolRadiusMax;
    [SerializeField] float patrolForThisTime;

    private float patrolTimer;
    [SerializeField] float waitBeforeAttack;
    private float attackTimer;

    private Transform target;

    private void Awake()
    {
        enemyAnim = GetComponent<EnemyAnimator>();
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag(Tags.player).transform;
    }
    void Start()
    {
        enemyState = EnemyState.PATROL;

        patrolTimer = patrolForThisTime;
        attackTimer = waitBeforeAttack;

        currentChaseDistance = chaseDistance;
    }

    void Update()
    {
        if (enemyState == EnemyState.PATROL)
            Patrol();
        if (enemyState == EnemyState.CHASE)
            Chase();
        if (enemyState == EnemyState.ATTACK)
            Attack();
    }
    private void Patrol()
    {
        agent.isStopped = false;
        agent.speed = walkSpeed;

        patrolTimer += Time.deltaTime;

        if (patrolTimer > patrolForThisTime)
        {
            SetNewRandomDestination();
            patrolTimer = 0f;
        }

        if(agent.velocity.sqrMagnitude > 0)
        {
            enemyAnim.Walk(true);
        }
        else
        {
            enemyAnim.Walk(false);
        }

        if(Vector3.Distance(transform.position, target.position) <= chaseDistance)
        {
            enemyAnim.Walk(false);
            enemyState = EnemyState.CHASE;
        }
    }
    private void Chase()
    {
        agent.isStopped = false;
        agent.speed = runSpeed;

        agent.SetDestination(target.position);
        if (agent.velocity.sqrMagnitude > 0)
        {
            enemyAnim.Run(true);
        }
        else
        {
            enemyAnim.Run(false);
        }

        if (Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            enemyAnim.Run(false);
            enemyState = EnemyState.ATTACK;

            if (chaseDistance != currentChaseDistance)
                chaseDistance = currentChaseDistance;
        }
        else if(Vector3.Distance(transform.position, target.position) > chaseDistance)
        {
            enemyAnim.Run(false);
            enemyState = EnemyState.PATROL;

            patrolTimer = patrolForThisTime;

            if (chaseDistance != currentChaseDistance)
                chaseDistance = currentChaseDistance;
        }
    }
    private void Attack()
    {
        agent.velocity = Vector3.zero;
        agent.isStopped = true;

        attackTimer += Time.deltaTime;

        if(attackTimer > waitBeforeAttack)
        {
            enemyAnim.Attack();
            attackTimer = 0;
        }
        if(Vector3.Distance(transform.position, target.position) > attackTimer + chaseAfterAttackDistance)
        {
            enemyState = EnemyState.CHASE;
        }
    }

    private void SetNewRandomDestination()
    {
        float randomRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);

        Vector3 randomDirection = Random.insideUnitSphere * randomRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, randomRadius, -1);

        agent.SetDestination(navHit.position);
    }
}
