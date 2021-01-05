using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
   private bool isPaused;
   private PlayerControls _playerControls;
    
   public PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    void Update()
    {
        GameExit();
        
        GamePause();
        GameUnpause();
        GameRestart();
        DebugHealthTest();
    }

    private void GameExit()
    {
        if (_playerControls.Land.Quit.triggered)
        {
            Application.Quit();
        }
    }

    private void GamePause()
    {
        if (_playerControls.Land.Pause.triggered)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    private void GameUnpause()
    {
        if (_playerControls.Land.Unpause.triggered && isPaused == true)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    private void GameRestart()
    {
        if (_playerControls.Land.Restart.triggered)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void DebugHealthTest()
    {
        if (_playerControls.Land.DebugHP.triggered)
        {
            int damage = 5;
            _playerHealth.TakeDamage(damage);
        } 
    }
}
