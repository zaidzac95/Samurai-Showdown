using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] int damageValue;
    private void OnEnable()
    {
        this.Wait(1.3f, () =>{this.gameObject.SetActive(false);});
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.enemy)
        {
            Debug.Log("Enemy hit");
            other.GetComponent<HealthScript>().TakeDamage(damageValue);//maybe add blood particles

            // Enable and play the particle system
            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            particleSystem.gameObject.SetActive(true);
            particleSystem.Play();

        }
        if (other.tag == Tags.boss)
        {
            Debug.Log("Boss hit");
            other.GetComponentInParent<HealthScript>().TakeDamage(damageValue);


            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            particleSystem.gameObject.SetActive(true);
            particleSystem.Play();
        }
    }
}
