using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AnimationStates { standing, walking, running, punching, jumping };
    
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
    private bool isGoingToJump;

    public float shortJumpHeight = 2f;
    public float longJumpHeight = 4f;

    public bool _jump;

    public PlayerHealth health;

    public float knockBackForce = 5f;
    public float knockBackTime;
    private float knockBackCounter;

    private bool isLanding;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    void Start()
    {
        health.GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        playerAudio = GetComponent<PlayerAudio>();

        GameObject.FindGameObjectsWithTag("Ground");
    }

    void Update()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (IsGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -2f;
            _animator.SetBool("IsGrounded", true);
        }

        if (!IsGrounded)
        {
            _animator.SetBool("IsGrounded", false);
        }

        if (knockBackCounter <= 0)
        {

           if(health.IsDead == false)
          { 
            PlayerMovement();
            ShortJumpAnimation();
            LongJumpAnimation();
          }
       
            PlayerGravity();
        
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
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

        movementSpeed = movementInput.magnitude * 6f;
       
        if (direction.magnitude >= 0.1f && !playerCombat.isPunching && !isLanding)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _characterController.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);

            _animator.SetFloat("Speed", movementInput.magnitude);

            if (_animator.GetFloat("Speed") < 0.6f)
            {
                _animationStates = AnimationStates.walking;
            }
            else if (_animator.GetFloat("Speed") > 0.6f)
            {
                _animationStates = AnimationStates.running;
            }
        }
        else
        {
            _animator.SetFloat("Speed", 0f);
            _animationStates = AnimationStates.standing;
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
       if(_playerControls.Land.Jump.triggered && IsGrounded && _animationStates == AnimationStates.running)
        {
            _animator.SetTrigger("ShortJump");
        }
        
    }

   /// <summary>
   /// Método que ejecuta el salto corto del jugador mientras corre, llamado por un Animator Event en la animación de salto correspondiente.
   /// </summary>
    public void ShortPlayerJump()
    {
        gravityVelocity.y = Mathf.Sqrt(shortJumpHeight * -2f * gravity);
    }

    /// <summary>
    /// Método que activa la animación de salto.
    /// </summary>
    private void LongJumpAnimation()
    {
        if (_playerControls.Land.Jump.triggered && IsGrounded && _animationStates == AnimationStates.standing)
        {
           
            _animator.SetTrigger("LongJump");
        }

    }

    /// <summary>
    /// Método que ejecuta el salto largo del jugador estando de pie, llamado por un Animator Event en la animación de salto correspondiente.
    /// </summary>
    public void LongPlayerJump()
    {
        gravityVelocity.y = Mathf.Sqrt(longJumpHeight * -2f * gravity);
    }


    /// <summary>
    /// Método que ejecuta el retroceso del jugador al ser dañado
    /// </summary>
    /// <param name="direction">Dirección a la que sera lanzado el jugador al ser dañado por un enemigo.</param>
    public void PlayerKnockBack(Vector3 direction)
    {
        _characterController.Move(direction * knockBackForce * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            playerAudio.CoinSound();
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
    /// Método que registra si el jugador ya ha aterrizado, si es así, podra continuar moviendose, llamado por un Animator Event al final de la animación del aterrizaje.
    /// </summary>
    public void HasLanded()
    {
        isLanding = false;
    }
}
