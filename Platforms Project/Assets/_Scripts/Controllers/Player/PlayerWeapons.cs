using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatStates {idle, moving, attacking, none};

public class PlayerWeapons : MonoBehaviour
{
    public Animator _animator;
    
    [SerializeField]
    private GameObject[] weapons;

    [SerializeField]
    private GameObject back, hand;

    [Header("Bat Configuration")]
    [SerializeField]
    private float batRotX, batRotY, batRotZ, 
    batPosX, batPosY, batPosZ, batHandPosX,
    batHandPosY, batHandPosZ, batHandRotX,
    batHandRotY, BatHandRotZ;
    
    [Space]

    private Vector3 batPosition, bateRotation, bateHandPosition, bateHandRotation;

    private PlayerControls _playerControls;

    private GameObject currentWeapon;

    bool hasWeapon, holdsWeapon, canEquipWeapon;

    CombatStates _combatStates;

    private void Awake() {
        _playerControls = new PlayerControls();
    }

    private void OnEnable() {
        _playerControls.Enable();
    }

    private void OnDisable() {
        _playerControls.Disable();
    }

    private void Start() {
        GenerateWeaponPositions();
        _combatStates = CombatStates.none;
    }

    private void Update() {
        EquipWeapon();
        CheckMovement();
    }

    /// <summary>
    /// Método que se encarga de instanciar el arma para Benny.
    /// </summary>
    /// <param name="index"> Según el número del índice, el arma correspondiente.</param>
    public void InstantiateWeapon(int index){

        switch(index){
            case 0:
               GameObject bate = Instantiate(weapons[0]);
                bate.transform.parent = back.transform;
                bate.transform.localEulerAngles = bateRotation;
                bate.transform.localPosition = batPosition;
                hasWeapon = true;
                canEquipWeapon = true;
                currentWeapon = bate;
                break;
        }

    }

    /// <summary>
    /// Método que se encarga de genererar las posiciones y rotaciones correspondientes para las armas.
    /// </summary>
    private void GenerateWeaponPositions(){

        // Bate de baseball.
        batPosition = new Vector3(batPosX, batPosY, batPosZ);
        bateRotation = new Vector3(batRotX, batRotY, batRotZ);
        bateHandPosition =  new Vector3(batHandPosX, batHandPosY, batHandPosZ);
        bateHandRotation = new Vector3(batHandRotX, batHandRotY, batHandPosZ);

    }

    /// <summary>
    /// Método que se encarga de equipar el arma en la mano de Juan Benjamín Vázquez Delgado.
    /// </summary>
    private void EquipWeapon(){
        
        if(_playerControls.Land.GetWeapon.triggered){
            
            if(hasWeapon){

                if(canEquipWeapon){

                    if(_animator.GetFloat("Speed") <= 0.1f){
                    
                        _animator.SetBool("Holds Weapon", true);
                        holdsWeapon = true;
                        canEquipWeapon = false;

                    }
                }
                else{

                    if(_animator.GetFloat("Speed") <= 0.1f){
                    
                        _animator.SetBool("Holds Weapon", false);
                        holdsWeapon = false;
                        canEquipWeapon = true;

                    }

                }
            }
        }
    }


    /// <summary>
    /// Método que se encarga de tomar el arma, llamado por un Animator Event si EquipWeapon se ejecuta correctamente.
    /// </summary>
    private void TakeWeapon(){
        
        currentWeapon.transform.parent = hand.transform;
        currentWeapon.transform.localEulerAngles = bateHandRotation;
        currentWeapon.transform.localPosition = bateHandPosition;
        
    }

    private void SaveWeapon(){

          currentWeapon.transform.parent = back.transform;
          currentWeapon.transform.localEulerAngles = bateRotation;
          currentWeapon.transform.localPosition = batPosition;

    }

    private void CheckMovement(){
        
        if(holdsWeapon){

            _combatStates = CombatStates.idle;

            if(_animator.GetFloat("Speed") >= 0.01f){
                _combatStates = CombatStates.moving;
            }
            else{
                _combatStates = CombatStates.idle;
            }
        }
    }
}