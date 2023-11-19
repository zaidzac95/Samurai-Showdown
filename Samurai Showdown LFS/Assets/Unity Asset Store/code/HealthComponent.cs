using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthComponent : MonoBehaviour
{
    public float Health = 100;
    public TMP_Text HealthDisplay;
    public Slider HealthBar;
    public float MaxHealth//property, which act like a variable, but in this case read only
    {
        get
        {
            return maxHealth_;
        }
    }

    float maxHealth_;
    private void Start()
    {
        //we are assuming that the initial health is the max health
        //starting health is maxhealth
        maxHealth_ = Health;
    }
    private void Update()
    {
        if (HealthDisplay != null)
        {
            HealthDisplay.text = Health.ToString();
        }
        if (HealthBar != null)
        {
            //Health / maxHealth_ will give you a value between 0 - 1
            HealthBar.value = Health / maxHealth_;
        }
        if (Health <= 0)
        {
            //is dead, so we can destroy the gameObject, destroy the gameObject after a while
            Destroy(gameObject, 0.5f);
            //will call OnKilled method on every component in this gameObject or it children
            BroadcastMessage("OnKilled", SendMessageOptions.DontRequireReceiver);
            //we disable this component as we do not want Update to be called any more
            enabled = false;
        }
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}