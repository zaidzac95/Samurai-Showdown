using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Walk(bool walk)
    {
        animator.SetBool(Anim.walk, walk);
    }
    public void Run(bool run)
    {
        animator.SetBool(Anim.run, run);
    }
    public void Attack()
    {
        animator.SetTrigger(Anim.attack);
    }
    public void Death()
    {
        animator.SetTrigger(Anim.death);
    }
}
