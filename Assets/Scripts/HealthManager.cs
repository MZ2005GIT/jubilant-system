using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] healthBars; // Assign in the Inspector
    private int currentHealthIndex;

    void Start()
    {
        currentHealthIndex = healthBars.Length - 1; // Start at full health
    }

    public void TakeDamage()
    {
        if (currentHealthIndex >= 0)
        {
            // Hide one health bar
            healthBars[currentHealthIndex].enabled = false;

            currentHealthIndex--;

            // Optionally: check for game over
            if (currentHealthIndex <= 0)
            {
                LoadLose();
            }
        }
    }

    public void LoadLose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void ResetHealth()
    {
        for (int i = 0; i < healthBars.Length; i++)
        {
            healthBars[i].enabled = true;
        }
        currentHealthIndex = healthBars.Length - 1;
    }

}
