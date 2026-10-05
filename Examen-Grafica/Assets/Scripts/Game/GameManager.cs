using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;
    public static event Action<int> OnGameWon;

    [SerializeField] private int coinsToWin = 10;
    [SerializeField] private int pointsPerCoin = 10;

    private int coinsCollected;
    private int score;
    private bool isPlaying = true;

    void OnEnable()
    {
        Coin.OnCollected += HandleCoinCollected;
    }

    void OnDisable()
    {
        Coin.OnCollected -= HandleCoinCollected;
    }

    private void HandleCoinCollected(Coin coin)
    {
        if (!isPlaying) return;

        coinsCollected++;
        score += pointsPerCoin;
        OnScoreChanged?.Invoke(score);

        if (coinsCollected >= coinsToWin)
        {
            isPlaying = false;
            OnGameWon?.Invoke(score);
        }
    }

    // Conectado al botón de reinicio desde el Inspector
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}