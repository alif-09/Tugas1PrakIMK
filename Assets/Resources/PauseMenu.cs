using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public Button resumeButton;
    public Button mainMenuButton;
    private bool isPaused = false;
    private bool canPause = true; // Cegah ESC langsung diproses setelah resume

    void Start()
    {
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Pastikan tombol Resume berfungsi
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeGame);
        }

        // Pastikan tombol Main Menu berfungsi
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(() => LoadMainMenu("MainMenu"));
        }
    }

    void Update()
    {
        if (canPause && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Cursor langsung diaktifkan tanpa delay
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Cursor langsung disembunyikan
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Cegah ESC langsung aktif setelah resume
        StartCoroutine(EnablePauseAfterDelay());
    }

    IEnumerator EnablePauseAfterDelay()
    {
        canPause = false;
        yield return new WaitForSecondsRealtime(0.2f); // Tunggu sebentar sebelum ESC bisa digunakan lagi
        canPause = true;
    }

    public void LoadMainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
