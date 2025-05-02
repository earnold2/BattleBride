using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueDetect : MonoBehaviour
{
    private bool bride = false;
    private bool groom = false;

    public GameObject portals;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BridalBlock"))
        {
            if(collision.gameObject.name == "BrideBlock")
            {
                bride = true;
            }
            if (collision.gameObject.name == "GroomBlock")
            {
                groom = true;
            }

            if(bride == true && groom == true)
            {
                portals.SetActive(true);
            }
        }
    }
}
