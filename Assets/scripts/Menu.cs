using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    [SerializeField]
    GameObject MenuUI;

    enum MenuStates { Playing, Pause}
    MenuStates currentState;

    private void Update()
    {
        if (Input.GetKeyDown("escape") && currentState == MenuStates.Pause)
        {
            currentState = MenuStates.Playing;
        }else if (Input.GetKeyDown("escape") && currentState == MenuStates.Playing)
        {
            currentState = MenuStates.Pause;
        }

        switch (currentState)
        {
            case MenuStates.Playing:
                currentState = MenuStates.Playing;
                MenuUI.SetActive(false);
                Time.timeScale = 1;
                break;
            case MenuStates.Pause:
                MenuUI.SetActive(true);
                Time.timeScale = 0;
                break;
        }
            
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        currentState = MenuStates.Playing;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
