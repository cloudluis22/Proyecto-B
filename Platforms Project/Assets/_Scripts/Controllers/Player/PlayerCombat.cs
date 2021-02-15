using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Animator _animator;
    private PlayerControls _playerControls;
    public PlayerAudio _playerAudio;

    bool holdsWeapon;
    int comboIndex = 0;
    bool runTimer;
    float timer = 0;

    [SerializeField]
    float maxTime = 1.5f;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _animator.GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    
    private void Update() {
        PlayerAttack();
        Debug.Log(comboIndex);
    }

    public void PlayerAttack(){

        if(_playerControls.Combat.Attack.triggered){

            if(_animator.GetBool("Holds Weapon") && _animator.GetFloat("Speed") < 0.01f){
                
                switch(comboIndex){

                    case 0:
                        _animator.SetTrigger("Melee 1");
                        comboIndex++;
                        runTimer = true;
                    break;
                        
                    case 1:
                        _animator.SetTrigger("Melee 2");
                        comboIndex++;
                        timer = 0;
                    break;

                    case 2:
                        _animator.SetTrigger("Melee 3");
                    break;
                }
                
            }

        }

        if(runTimer){

            timer += Time.deltaTime;

            if(timer >= maxTime){
                timer = 0;
                comboIndex = 0;
                runTimer = false;
            }

        }
        
    }
 
}