using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    //public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        GetSlider();
        slider.minValue = 0;
        Debug.Log("bar");
    }

    void GetSlider()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealthBar(int max)
    {
        if (!slider)
        {
            GetSlider();
        }
        slider.maxValue = max;
    }

    public void SetHealthBar(int health)
    {
        slider.value = health;
        if (slider.value > slider.maxValue / 3)
        {
            slider.fillRect.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            slider.fillRect.GetComponent<Image>().color = Color.red;
        }
    }
}