using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] GameObject pauseMenuUI;
    void Start()
    {
        Cursor.lockState = GameIsPaused? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = GameIsPaused;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            ToggleMenu();
    }

    void ToggleMenu()
    {
        GameIsPaused = !GameIsPaused;
        pauseMenuUI.SetActive(GameIsPaused);
        Cursor.lockState = GameIsPaused? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = GameIsPaused;
        Time.timeScale = GameIsPaused? 0f : 1f;
    }
}
