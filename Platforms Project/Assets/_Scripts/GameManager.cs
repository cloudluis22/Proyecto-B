using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   private bool isPaused;
   private PlayerControls _playerControls;
    
   public PlayerHealth _playerHealth;

   public Image pauseIcon;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        pauseIcon.enabled = false;

    }

    private void Start() {
        Cursor.visible = false;
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
        if (_playerControls.Land.Pause.triggered && !isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseIcon.enabled = true;
        }
        else if(_playerControls.Land.Pause.triggered && isPaused){
            Time.timeScale = 1f;
            isPaused = false;
            pauseIcon.enabled = false;
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
