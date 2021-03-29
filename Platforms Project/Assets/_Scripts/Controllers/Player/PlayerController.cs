using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AnimationStates
{
    standing,
    jogging,
    running,
    punching,
    jumping,
    falling,
    crouching,
    crouchWalking,
    attackIdle,
    attackMoving,
    attacking

};

public class PlayerController : MonoBehaviour
{
    public CharacterController _characterController;
    public Animator _animator;
    public Transform cam;
    public PlayerAudio playerAudio;
    private PlayerControls _playerControls;
    public PlayerCombat playerCombat;

    public AnimationStates _animationStates;

    public float smoothTurnTime = 0.1f;
    private float turnSmoothVelocity;

    private float movementSpeed;

    public Vector3 gravityVelocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool IsGrounded;

    public float shortJumpHeight = 2f;
    public float longJumpHeight = 4f;

    private bool isLanding;
    private bool isJumping;

    private float speedNumber;

    [SerializeField]
    private float coinTimer, minPitch, maxPitch;
    private float timeRemaining, currentPitch;

    private bool runTimer, isHoldingSprint = false, takeFallDamage;

    private PlayerHealth _playerHealth;

    [SerializeField]
    private ParticleSystem blood;

    private bool isCrouched;

    [SerializeField]
    private float crouchSpeed = 2, defaultSpeed = 8;
    

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerControls = new PlayerControls();
        _characterController = GetComponent<CharacterController>();
        playerCombat = GetComponent<PlayerCombat>();
        currentPitch = minPitch;
        timeRemaining = coinTimer;

        speedNumber = defaultSpeed;
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
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (IsGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -2f;
            _animator.SetBool("IsGrounded", true);

            if (takeFallDamage)
            {
                takeFallDamage = false;
                _playerHealth.TakeDamage(5);
            }
        }

        if (!IsGrounded)
        {
            _animator.SetBool("IsGrounded", false);
        }

        PlayerMovement();
        ShortJumpAnimation();
        LongJumpAnimation();
        PlayerGravity();

        if (runTimer)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log(timeRemaining + " seconds left!.");
            }
            else
            {
                currentPitch = minPitch;
                runTimer = false;
                timeRemaining = coinTimer;
            }
        }

        if (_playerControls.Land.SprintStart.triggered)
        {
            isHoldingSprint = true;
        }
        else if (_playerControls.Land.SprintEnd.triggered)
        {
            isHoldingSprint = false;
        }

        FallDistance();
        PlayerCrouching();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }

    /// <summary>
    /// Método que crea el movimiento y rotación del jugador.
    /// </summary>
    private void PlayerMovement()
    {

        Vector2 movementInput = _playerControls.Land.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(movementInput.x, 0f, movementInput.y);

        //if(_playerControls.Land.Walk.)

        movementSpeed = movementInput.magnitude * speedNumber;

        if (direction.magnitude >= 0.1f && !isLanding)
        {

            if (isHoldingSprint)
            {
                _animator.SetBool("Sprint", true);
                _animator.SetFloat("Speed", 1f);
                movementSpeed = 1.5f * speedNumber;
            }
            else
            {
                _animator.SetBool("Sprint", false);
                _animator.SetFloat("Speed", movementInput.magnitude);
            }

            if(isCrouched){
                movementSpeed = 0.3f * speedNumber;
            }

            if(playerCombat.combatStates != CombatStates.Attacking){
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurnTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _characterController.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
            }

            if (_animator.GetFloat("Speed") > 0.01f)
            {

                if(!_animator.GetBool("Sprint"))
                {
                    if (!isCrouched)
                    {
                    _animationStates = AnimationStates.jogging;
                    }
                else
                    {
                        _animationStates = AnimationStates.crouchWalking;
                    }
                }
                else
                {
                    _animationStates = AnimationStates.running;
                }
            }
        }
        else
        {
            _animator.SetFloat("Speed", 0f);

            if (!isCrouched)
            {
                _animationStates = AnimationStates.standing;
            }
            else
            {
                _animationStates = AnimationStates.crouching;
            }
        }

    }

    /// <summary>
    /// Método que realiza la gravedad del jugador.
    /// </summary>
    private void PlayerGravity()
    {
        gravityVelocity.y += gravity * Time.deltaTime;
        _characterController.Move(gravityVelocity * Time.deltaTime);
    }

    /// <summary>
    /// Método que activa la animación de salto.
    /// </summary>
    private void ShortJumpAnimation()
    {
        if (_playerControls.Land.Jump.triggered && IsGrounded && _animationStates == AnimationStates.running && !isJumping)
        {
            isJumping = true;
            _animator.SetTrigger("ShortJump");
        }

    }

    /// <summary>
    /// Método que ejecuta el salto corto del jugador mientras corre, llamado por un Animator Event en la animación de salto correspondiente.
    /// </summary>
    public void ShortPlayerJump()
    {
        gravityVelocity.y = Mathf.Sqrt(shortJumpHeight * -2f * gravity);
        speedNumber = 7f;
    }

    /// <summary>
    /// Método que activa la animación de salto.
    /// </summary>
    private void LongJumpAnimation()
    {
        if (_playerControls.Land.Jump.triggered && IsGrounded && _animationStates == AnimationStates.standing && !isJumping)
        {
            isJumping = true;
            _animator.SetTrigger("LongJump");
        }

    }

    /// <summary>
    /// Método que ejecuta el salto largo del jugador estando de pie, llamado por un Animator Event en la animación de salto correspondiente.
    /// </summary>
    public void LongPlayerJump()
    {
        gravityVelocity.y = Mathf.Sqrt(longJumpHeight * -2f * gravity);
        speedNumber = 3f;
    }

    //Lógica de recoger monedas al entrar en contacto con ellas.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            if (!runTimer)
            {
                runTimer = true;
            }
            else
            {
                currentPitch += 0.1f;
                timeRemaining = coinTimer;
                if (currentPitch >= maxPitch)
                {
                    currentPitch = maxPitch;
                }
            }

            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("Spikes"))
        {
            _playerHealth.TakeDamage(100);
            blood.Play();
        }

    }

    /// <summary>
    /// Método que registra si el jugador está aterrizando, si es así, no podra moverse mientras esto ocurre. Llamado por un Animator Event al inicio de la animación de aterrizaje.
    /// </summary>
    public void IsLanding()
    {
        isLanding = true;
    }

    /// <summary>
    /// Método que registra si el jugador ya ha aterrizado, si es así, podra continuar moviendose además de poder volver a saltar. Llamado por un Animator Event al final de la animación del aterrizaje.
    /// </summary>
    public void HasLanded()
    {
        speedNumber = 6f;
        isLanding = false;
        isJumping = false;
    }

    /// <summary>
    /// Calcula el daño de caída del jugador.
    /// </summary>
    public void FallDistance()
    {

        if (gravityVelocity.y < -20)
        {
            takeFallDamage = true;
        }

    }

    /// <summary>
    /// Método que realiza la acciíon de agacharse de Benny.
    /// </summary>
    private void PlayerCrouching()
    {

        if (_playerControls.Land.Crouch.triggered)
        {

            if (_playerControls.Land.Crouch.triggered)
            {

                if (IsGrounded)
                {
                    if (!isCrouched)
                    {
                        isCrouched = true;
                        _animator.SetBool("IsCrouched", true);
                        _animationStates = AnimationStates.crouching;
                        
                    }
                    else
                    {
                        isCrouched = false;
                        _animator.SetBool("IsCrouched", false);
                        _animationStates = AnimationStates.standing;
                    }

                }
            }
        }
    }

    public void FootIndex0()
    {
        _animator.SetInteger("Foot Index", 0);
    }

        public void FootIndex1()
    {
        _animator.SetInteger("Foot Index", 1);
    }

}
