using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Start()   
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if( slider.value <= slider.minValue )
        {
            fillImage.enabled = false;
        }

        if( slider.value > slider.minValue && !(fillImage.enabled) )
        {
            fillImage.enabled = true;
        }
        //  float fillValue = playerHealth.currenthealth / PlayerHealthBar.maxhealth  *need  to reference player script*
        

        if( fillvalue <= slider.maxValue / 3 )
        {
            fillImage.color = Color.red;
        }

        else if( fillValue > slider.maxValue / 3 )
        {
            fillImage.color = Color.blue;
        }
        // slider.value = fillValue;
    }
