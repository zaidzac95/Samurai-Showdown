using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointEnemy : MonoBehaviour
{

    [SerializeField] int damageValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            Debug.Log("Player hit");
            other.GetComponent<HealthScript>().TakeDamage(damageValue);//maybe add blood particles 
        }
    }
}
