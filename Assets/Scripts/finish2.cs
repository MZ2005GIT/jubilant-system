using UnityEngine;
using UnityEngine.SceneManagement;

public class finish2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadWin();
        }
    }

    public void LoadWin()
    {
        SceneManager.LoadScene("Win");
    }

}
