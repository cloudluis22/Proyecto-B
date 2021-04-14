using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    [SerializeField] private Slider staminaSlider;
    [SerializeField] private Image sliderFill;
    
    [SerializeField] private Color sliderColor, cooldownColor;
    [Range(1f, 50f)] [SerializeField] private float lossFrequency, gainFrequency;

    private GameObject player;
    private PlayerController playerController;

    private bool cooldown;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        sliderFill.color = Color.blue;
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

        if(staminaSlider.value == 0)
        {
            cooldown = true;
        }

        if(cooldown)
        {
            sliderFill.color = Color.red;

            if(staminaSlider.value > staminaSlider.maxValue / 4)
            {
                cooldown = false;
                sliderFill.color = Color.blue;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        StaminaStatus();
    }
}
