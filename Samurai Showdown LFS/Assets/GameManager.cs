using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] GameObject gameOverUI;
    [Header("Kill Count")]
    [SerializeField] int killTarget;
    [SerializeField] TextMeshProUGUI killCountText;
    [SerializeField] TextMeshProUGUI killTargetText;
    private int enemiesKilled;
    [Header("Boss")]
    [SerializeField] GameObject bossUI;
    [SerializeField] GameObject boss;
    [Header("Win")]
    [SerializeField] GameObject winUI;
    


    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag(Tags.player);

        enemiesKilled = 0;
        killTargetText.text = "/" + killTarget.ToString();
        killCountText.text = enemiesKilled.ToString();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (player.GetComponent<HealthScript>().GetPlayersState())
            GameOver();

        if (boss.GetComponent<HealthScript>().GetBossState())
            WinGame();
    }
    private void GameOver()
    {
        gameOverUI.SetActive(true);
        player.SetActive(false);
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void WinGame()
    {
        winUI.SetActive(true);
        if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void IncreaseEnemyKilled()
    {
        enemiesKilled += 1;//display to  UI
        killCountText.text = enemiesKilled.ToString();
        if (enemiesKilled == killTarget)
            SummonBoss();
    }

    private void SummonBoss()
    {
        bossUI.SetActive(true);
        boss.SetActive(true);
    }
}
