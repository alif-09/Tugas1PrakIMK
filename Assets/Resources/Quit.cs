using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Quit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
    public void QuitGame()
    {
        Application.Quit();

        // Jika sedang di mode editor, hentikan play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
