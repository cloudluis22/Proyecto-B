using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    [SerializeField] private Slider staminaSlider;
    [Range(1f, 50f)] [SerializeField] private float lossFrequency, gainFrequency;

    private GameObject player;
    private PlayerController playerController;


    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void StaminaStatus()
    {
        if(playerController._animationStates == AnimationStates.running)
        {
            staminaSlider.value -= Time.deltaTime * lossFrequency;
        }
        else
        {
            staminaSlider.value += Time.deltaTime * lossFrequency;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StaminaStatus();
    }
}
