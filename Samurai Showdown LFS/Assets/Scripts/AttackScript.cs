using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject attackPoint;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Attack();
    }
    private void Attack()
    {
        attackPoint.SetActive(true);
        animator.SetTrigger(Anim.attack);

    }
}
