using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Global Game State Manager. Contains all functions and functions for leveled games
 and endless games.*/
public class GGSM : MonoBehaviour
{
    //COMMON
    private bool timefreezed;

    //Fires up whenever player opens the application. Refires whenever the scene contains that script reloads.
    public static event Action OnGameOpened = delegate { };

    //Fires when game is freezed and resumed.
    public static event Action OnGameFreezed = delegate { };
    public static event Action OnGameResumed = delegate { };

    //Fires right before quitting the application.
    public static event Action OnGameQuit = delegate { };

    public void UnfreezeTime()
    {
        if (timefreezed)
        {
            Time.timeScale = 1f;
            timefreezed = false;
        }
    }

    public void FreezeTime()
    {
        if (!timefreezed)
        {
            Time.timeScale = 0f;
            timefreezed = true;
        }
    }

    public void FireOnGameFreezed()
    {
        FreezeTime();
        OnGameFreezed();
        Debug.Log("Game Freezed");
    }

    public void FireOnGameResumed()
    {
        UnfreezeTime();
        OnGameResumed();
        GGSMSceneLoader.isFreezeOpen = false;
        Debug.Log("Game Resumed");
    }

    public void FireOnGameQuit()
    {
        OnGameQuit();
        Application.Quit();
        Debug.Log("Application Quitted");
    }

    //Singleton
    public static GGSM Instance;
    private void Awake()
    {
        //Singleton
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            OnGameOpened();
        }
    }

    //LEVELED
    //Fires whenever the level starts, ends or restarted.
    public static event Action OnLevelStarted = delegate { };
    public static event Action OnLevelEnded = delegate { };
    public static event Action OnRestartLevel = delegate { };
    public static event Action OnLoadLevelMenu = delegate { };

    public void FireOnRestartLevel()
    {
        OnRestartLevel();
    }
    public void FireOnLevelStarted()
    {
        OnLevelStarted();
    }
    public void FireOnLevelEnded()
    {
        OnLevelEnded();
    }
    public void FireOnLoadLevelMenu()
    {
        OnLoadLevelMenu();
    }

    //Endless Game Functions
    public static event Action OnRestartGame = delegate { };
    public static event Action OnGameEnded = delegate { };
    public static event Action OnGameStarted = delegate { };

    public void FireOnRestartGame()
    {
        OnRestartGame();
    }
    public void FireOnGameEnded()
    {
        OnGameEnded();
        Debug.Log("Game Ended");
    }
    public void FireOnGameStarted()
    {
        OnGameStarted();
        Debug.Log("Game Started");
    }
}
