using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] bool isPlayer;
    [SerializeField] bool isEnemy;
    [SerializeField] bool isBoss;
    [SerializeField] Image healthBar;

    private bool isPlayerDead, isEnemyDead, isBossDead;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        isPlayerDead = false;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (isEnemy)
            GetHit();
        if (currentHealth <= 0)
            Death();
    }
    private void GetHit()
    {
        GetComponent<Animator>().SetTrigger(Anim.hit);
    }
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    private void Death()
    {
        if (isPlayer)
            PlayerDeath();
        else if (isEnemy && !isEnemyDead)
            EnemyDeath();
        else if (isBoss && !isBossDead)
            BossDeath();

    }

    private void PlayerDeath()
    {
        isPlayerDead = true;
    }
    private void EnemyDeath()
    {
        GetComponent<Animator>().SetTrigger(Anim.death);
        Destroy(this.gameObject, 3f);
        this.GetComponent<EnemyController>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        isEnemyDead = true;
        GameObject.FindWithTag(Tags.gameManager).GetComponent<GameManager>().IncreaseEnemyKilled();
    }
    private void BossDeath()
    {
        GetComponent<Animator>().SetTrigger(Anim.death);
        this.GetComponent<BossController>().enabled = false;
        this.GetComponentInChildren<BoxCollider>().enabled = false;
        isBossDead = true;
    }

    public bool GetPlayersState()
    {
        bool isDead = isPlayerDead;
        return isDead;
    }
    public bool GetBossState()
    {
        bool isDead = isBossDead;
        return isDead;
    }
}
