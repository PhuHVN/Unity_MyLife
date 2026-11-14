using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ContinueGame()
    {    
        Debug.Log("Continue Game");
    }

    public void OpenSettings()
    {
        Debug.Log("Open Settings");
    }
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
