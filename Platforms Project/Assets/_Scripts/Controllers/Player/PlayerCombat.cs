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
    }

    public void PlayerAttack(){

        if(_playerControls.Combat.Attack.triggered){

            Debug.Log("Ataque presionado");
            Debug.Log(_animator.GetBool("Holds Weapon"));
            Debug.Log(_animator.GetFloat("Speed"));

            if(_animator.GetBool("Holds Weapon") && _animator.GetFloat("Speed") < 0.01f){
                _animator.SetTrigger("Melee 1");
            }
   
        } 
        
    }
 
}