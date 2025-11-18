using UnityEngine;
using TMPro;

public class SceneTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float elapsedTime = 0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);
        timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }
}
