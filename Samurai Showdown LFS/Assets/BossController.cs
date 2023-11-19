using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] float attackDistance;
    [SerializeField] float waitBeforeAttack;
    [SerializeField] float waitForScream;
    [SerializeField] float damping;
    private float attackTimer;

    private Transform target;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag(Tags.player).transform;
        animator = GetComponent<Animator>();

        attackTimer = waitBeforeAttack;

        StartCoroutine(Scream());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < attackDistance)
        {
            Attack();
            RotateTowardsPlayer();
        }
            
    }
    private void Attack()
    {

        attackTimer += Time.deltaTime;

        if (attackTimer > waitBeforeAttack)
        {//rotate boss towards player
            animator.SetTrigger(Anim.attack);
            attackTimer = 0;
        }
    }
    private void RotateTowardsPlayer()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
    IEnumerator Scream()
    {
        while (!target.GetComponent<HealthScript>().GetPlayersState())
        {
            animator.SetTrigger(Anim.scream);
            yield return new WaitForSeconds(waitForScream);
        }
    }
}
