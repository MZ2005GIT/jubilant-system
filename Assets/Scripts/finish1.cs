using UnityEngine;
using UnityEngine.SceneManagement;

public class finish1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Load2();
        }
    }
    
    public void Load2()
    {
        SceneManager.LoadScene("Level2");
    }

}
