using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformToggler : MonoBehaviour
{

    private GameObject obj;
    public bool isActive;


    private void Awake()
    {
        obj = this.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isActive)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePlatform()
    {
        if (isActive)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        isActive = true;

        obj.GetComponent<BoxCollider2D>().enabled = true;
        obj.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void TurnOff()
    {
        isActive = false;

        obj.GetComponent<BoxCollider2D>().enabled = false;
        obj.GetComponent<SpriteRenderer>().color = new Color32(150, 150, 150, 255);
    }
}
