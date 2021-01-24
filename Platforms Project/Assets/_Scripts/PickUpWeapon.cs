using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    private PlayerControls _playerControls;

    private bool canBePickedUp;

    [SerializeField]
    private int weaponIndex;

    public GameObject player;

    private void Awake() {
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
    
    private void OnTriggerEnter(Collider other) {
        
       if(other.gameObject.tag == "Player"){
            Debug.Log("Benny puede recoger este objeto.");
            canBePickedUp = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        canBePickedUp = false;
    }

    private void Update() {
        if(canBePickedUp){
            if(_playerControls.Land.PickUp.triggered){
                player.GetComponent<PlayerWeapons>().InstantiateWeapon(weaponIndex);
                Destroy(this.gameObject);
            }
        }
    }
}
