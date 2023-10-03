using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public bool isPaused = false;
    public GameObject gamewin;


    private PlayerControls playerControl;
    private InputAction menu;

    private void Awake()
    {
        playerControl = new PlayerControls();
    }

    void Start()
    {
        
        pausemenu.SetActive(false);
        gamewin.SetActive(false);
    }

    private void OnEnable()
    {
        menu = playerControl.Player.Pause;
        menu.Enable();
        menu.performed += Pause;
    }

    public void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
        if(isPaused) 
        {
            PauseGame();
        }
        else
        {
            ResumeGame();   
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        isPaused = true;

    }

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isPaused = false;
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
