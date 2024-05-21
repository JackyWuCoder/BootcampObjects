using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] private TMP_Text playerHealthText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    [Header("Menu")]
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject lblGameOver;
    [SerializeField] private TMP_Text txtMenuHighScore;

    private Player player;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager gameManager = GameManager.GetInstance();
        if (gameManager == null)
        {
            Debug.LogError("GameManager instance is null.");
            return;
        }
        scoreManager = GameManager.GetInstance().scoreManager;
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager instance is null.");
            return;
        }

        // Subscribe to action
        //player.health.OnHealthUpdate += UpdateHealth;
        GameManager.GetInstance().OnGameStart += GameStarted;
        GameManager.GetInstance().OnGameOver += GameOver;
    }

    /*private void OnDisable()
    {
        // Unsubscribe from the action
        player.health.OnHealthUpdate -= UpdateHealth;
    }*/

    public void UpdateHealth(float currentHealth)
    {
        playerHealthText.SetText("Health : " + currentHealth.ToString());
    }

    public void UpdateScore()
    {
        scoreText.SetText(scoreManager.GetScore().ToString());
    }

    public void UpdateHighScore()
    {
        highScoreText.SetText(scoreManager.GetHighScore().ToString() + " : High Score");
        txtMenuHighScore.SetText($"High Score : {scoreManager.GetHighScore()}");
    }

    public void GameStarted()
    {
        player = GameManager.GetInstance().GetPlayer();
        player.health.OnHealthUpdate += UpdateHealth;

        menuCanvas.SetActive(false);
    }

    public void GameOver()
    {
        lblGameOver.SetActive(true);
        menuCanvas.SetActive(true);
    }
}
