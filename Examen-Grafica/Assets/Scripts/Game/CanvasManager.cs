using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas endCanvas;
    [SerializeField] private TMP_Text hudScoreText;
    [SerializeField] private TMP_Text finalScoreText;

    void Awake()
    {
        endCanvas.enabled = false;
        UpdateScore(0);
    }

    void OnEnable()
    {
        GameManager.OnScoreChanged += UpdateScore;
        GameManager.OnGameWon += ShowEndScreen;
    }

    void OnDisable()
    {
        GameManager.OnScoreChanged -= UpdateScore;
        GameManager.OnGameWon -= ShowEndScreen;
    }

    private void UpdateScore(int score)
    {
        hudScoreText.text = $"Puntos: {score}";
    }

    private void ShowEndScreen(int finalScore)
    {
        finalScoreText.text = $"Puntaje final: {finalScore}";
        endCanvas.enabled = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}