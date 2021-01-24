using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AnimationStates { standing, walking, running, punching, jumping, falling, crouching, crouchWalking};
    
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

    private bool runTimer, isHoldingWalk = false, takeFallDamage;

    private PlayerHealth _playerHealth;
    private PlayerAudio _playerAudio;

    [SerializeField]
    private ParticleSystem blood;

    private bool isCrouched;

    [SerializeField]
    private float crouchSpeed = 2, defaultSpeed = 8;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerAudio = GetComponent<PlayerAudio>();
        _playerControls = new PlayerControls();
        _characterController = GetComponent<CharacterController>();
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

            if(takeFallDamage){
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

        if(runTimer){
            if(timeRemaining >= 0){
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

        if(_playerControls.Land.WalkStart.triggered){
            isHoldingWalk = true;
        }
        else if(_playerControls.Land.WalkFinish.triggered){
            isHoldingWalk = false;
        }

        FallDistance();
        PlayerCrouching();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }

   /* public void SetRagdollParts()
    {
       Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

       foreach(Collider colls in colliders)
       {
           colls.isTrigger = true;
       }
    } */

    /// <summary>
    /// Método que crea el movimiento y rotación del jugador.
    /// </summary>
    private void PlayerMovement()
    {

        Vector2 movementInput = _playerControls.Land.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(movementInput.x, 0f, movementInput.y);

        //if(_playerControls.Land.Walk.)

        movementSpeed = movementInput.magnitude * speedNumber;

        if (direction.magnitude >= 0.1f && !playerCombat.isPunching && !isLanding)
        {

            if(isHoldingWalk){

            _animator.SetFloat("Speed", 0.5f);
             movementSpeed = 0.5f * speedNumber;   
            }else{
                _animator.SetFloat("Speed", movementInput.magnitude);   
            }
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _characterController.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);

           

            if (_animator.GetFloat("Speed") < 0.6f)
            {
                if(!isCrouched){
                    _animationStates = AnimationStates.walking;
                }
                else
                    _animationStates = AnimationStates.crouching;
            }
            else if (_animator.GetFloat("Speed") > 0.6f)
            {
                if(!isCrouched){
                    _animationStates = AnimationStates.running;
                }
                else{
                    _animationStates = AnimationStates.crouchWalking;
                }
            }
        }
        else
        {
            _animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
            
            if(!isCrouched){
                _animationStates = AnimationStates.standing;
            }
            else{
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
       if(_playerControls.Land.Jump.triggered && IsGrounded && _animationStates == AnimationStates.running && !isJumping)
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
            if(!runTimer){
                runTimer = true;
            }
            else{
                currentPitch += 0.1f;
                timeRemaining = coinTimer;
                if(currentPitch >= maxPitch){
                    currentPitch = maxPitch;
                }
            }
            
            Destroy(other.gameObject);
            playerAudio.CoinSound(currentPitch);
        }

        if(other.gameObject.CompareTag("Spikes")){
            _playerHealth.TakeDamage(100);
            _playerAudio.ImpaleSound();
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
    public void FallDistance(){

        if(gravityVelocity.y < -20){
            takeFallDamage = true;
        }

    }

    /// <summary>
    /// Método que realiza la acciíon de agacharse de Benny.
    /// </summary>
    private void PlayerCrouching(){

        if(_playerControls.Land.Crouch.triggered){
            
            if(!isCrouched){
                
                if(_animationStates == AnimationStates.standing){
                    isCrouched = true;
                    _animator.SetBool("IsCrouched", true);
                    speedNumber = crouchSpeed;
                }
             
            }
            else{
                
                if(_animationStates != AnimationStates.crouchWalking){
                    isCrouched = false;
                    _animator.SetBool("IsCrouched", false);
                    speedNumber = defaultSpeed;
                } 
                
            }
             
        }
    }

}
