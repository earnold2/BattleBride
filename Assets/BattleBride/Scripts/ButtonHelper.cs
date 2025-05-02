using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHelper : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;

    public bool isOn;
    private bool isOnHelper = false;

    public enum buttonType { normal, set, special};
    public buttonType type;

    public ButtonHelper other1;
    public ButtonHelper other2;

    void Start()
    {
        if (!isOn)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleButtonNormal()
    {
        if (!isOn)
        {
            isOn = true;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
        }
        else
        {
            isOn = false;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
        }
    }

    public void TurnOn()
    {
        isOn = true;

        this.gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;

        if(type == buttonType.set)
        {
            other1.TurnOff();
            other2.TurnOff();
        }
    }

    public void TurnOff()
    {
        isOn = false;

        this.gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
    }

    public void ToggleSpecialButtons()
    {
        if (!isOn)
        {
            isOn = true;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
        }
        else if (isOn && !isOnHelper)
        {
            isOnHelper = true;
        }
        else if(isOn && isOnHelper)
        {
            isOn = false;
            isOnHelper = false;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
        }
    }
}
