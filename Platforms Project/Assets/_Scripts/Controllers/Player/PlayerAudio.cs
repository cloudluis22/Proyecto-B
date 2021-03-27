using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;

public class PlayerAudio : MonoBehaviour
{

    public PlayerController playerController;
   // private FMOD.Studio.EventInstance footstepEvtInstance;

   // [FMODUnity.EventRef]
    public string footstepEvent;

    [SerializeField] [Range (-3f, 3f)] private float minPitch, maxPitch;
    private float pitch;

    private void Start() {
        playerController = GetComponent<PlayerController>();
    }

    public void Footstep(){

        pitch = Random.Range(minPitch, maxPitch);
      //  footstepEvtInstance = FMODUnity.RuntimeManager.CreateInstance(footstepEvent);
     //   footstepEvtInstance.start();
      //  footstepEvtInstance.setParameterByName("Pitch", pitch);
               

     /*   if(playerController._animationStates == AnimationStates.crouchWalking){
            footstepEvtInstance.setParameterByName("Volume", 0.5f);  
        }

        */


    }

}