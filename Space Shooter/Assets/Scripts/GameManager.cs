using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int score = 0;
    public bool isGameOver = false;

    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverText;

    [SerializeField] int maxHealth = 100;
    [SerializeField] TextMeshProUGUI healthText;
    int currentHealth;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void InitiateGameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);

    }

    public void ApplyDamage(int amount)
    {
        if (isGameOver)
        {
            return;
        }

        currentHealth = Mathf.Max(0, currentHealth - amount);
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }

        if (currentHealth <= 0)
        {
            InitiateGameOver();
        }
    }
}
