using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public Button[] buttons;
    private int select;
    private int buttonClick = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ButtonOn();
        buttons[0].onClick.AddListener(ButtonOneClick);
        buttons[1].onClick.AddListener(ButtonTwoClick);
        buttons[2].onClick.AddListener(ButtonThreeClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOn()
    {
        buttons[0].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(true);
        buttons[2].gameObject.SetActive(true);
    }

    public void ButtonOff()
    {
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
    }

    public int ButtonSelect()
    {
        if (buttonClick == 1)
        {
            select = buttonClick;
        }
        if (buttonClick == 2)
        {
            select = buttonClick;
        }
        if (buttonClick == 3)
        {
            select = buttonClick;
        }

        buttonClick = 0;
        return select;
    }

    private void ButtonOneClick()
    {
        Debug.Log("Balista");
        buttonClick = 1;
    }
    private void ButtonTwoClick()
    {
        Debug.Log("Cannon");
        buttonClick = 2;
    }
    private void ButtonThreeClick()
    {
        Debug.Log("Magic");
        buttonClick = 3;
    }

    public bool ButtonClicked()
    {
        if(buttonClick != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}
