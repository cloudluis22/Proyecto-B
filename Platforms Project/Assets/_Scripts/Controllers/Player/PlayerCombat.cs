using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CombatStates
{
    Attacking,
    Idle
}

public class PlayerCombat : MonoBehaviour
{
    public Animator _animator;
    private PlayerControls _playerControls;
    public PlayerAudio _playerAudio;
    public CharacterController _characterController;
    public CombatStates combatStates;

    bool holdsWeapon;
    int comboIndex = 0;
    bool runTimer, runCooldown, cooldown;
    float timer = 0, timer2 = 0;
    [SerializeField] bool canCombo = false;

    [SerializeField]
    float maxTime = 1.5f, maxCooldownTime = 0.5f;
    bool isAttacking;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _animator.GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Start()
    {
        combatStates = CombatStates.Idle;
    }

    private void Update()
    {
        PlayerAttack();
    }

    public void ComboActivation()
    {
        if(!canCombo)
        {
            canCombo = true;
        }
        else
        {
            canCombo = false;
        }
        
    }

    public void SetCombatState()
    {
        combatStates = CombatStates.Idle;
        isAttacking = false;
        _animator.ResetTrigger("Box 1");
    }

    public void PlayerAttack()
    {

        if (_playerControls.Combat.Attack.triggered && !runCooldown)
        {

            if (_animator.GetBool("Holds Weapon"))
            {

                switch (comboIndex)
                {

                    case 0:
                        _animator.SetTrigger("Melee 1");

                        runTimer = true;
                        combatStates = CombatStates.Attacking;
                        comboIndex++;

                        break;

                    case 1:

                        if (canCombo)
                        {
                            _animator.SetTrigger("Melee 2");
                            timer = 0;
                            comboIndex++;
                        }

                        break;

                    case 2:
                       // if (canCombo)
                       // {
                            _animator.SetTrigger("Melee 3");
                            runCooldown = true;
                        //}

                        break;
                }

            }
            else
            {

                switch (comboIndex)
                {

                    case 0:
                        _animator.SetTrigger("Box 1");

                        runTimer = true;
                        combatStates = CombatStates.Attacking;
                        comboIndex++;
                        //isAttacking = true;
                        break;

                    case 1:

                        _animator.SetTrigger("Box 2");
                        combatStates = CombatStates.Attacking;
                        //_animator.ResetTrigger("Box 1");
                        break;
                }
            }

        }

        if (runTimer)
        {

            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                timer = 0;
                comboIndex = 0;
                runTimer = false;
            }

        }

        if (runCooldown)
        {

            timer2 += Time.deltaTime;

            if (timer2 >= maxCooldownTime)
            {
                runCooldown = false;
            }
        }

    }

}