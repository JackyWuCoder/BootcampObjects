using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerHealthText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to action
        player.OnHealthUpdate += UpdateHealth;
    }

    private void OnDisable()
    {
        // Unsubscribe from the action
        player.OnHealthUpdate -= UpdateHealth;
    }

    public void UpdateHealth(float currentHealth)
    {
        playerHealthText.SetText("Health : " + currentHealth.ToString());
    }

    public void UpdateScore()
    {
        scoreText.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
    }
}
