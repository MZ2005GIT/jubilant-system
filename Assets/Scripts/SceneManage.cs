using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void Load1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLose()
    {
        SceneManager.LoadScene("Lose");
    }
    public void Load2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadWin()
    {
        SceneManager.LoadScene("Win");
    }


}
