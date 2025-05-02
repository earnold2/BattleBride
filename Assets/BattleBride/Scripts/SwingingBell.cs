using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingBell : MonoBehaviour
{

    public bool swinging;
    public bool swingingRight;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (swinging)
        {
            if(this.gameObject.transform.eulerAngles.z <= 300 && this.gameObject.transform.eulerAngles.z >= 100)
            {
                swingingRight = true;
            }
            if(this.gameObject.transform.eulerAngles.z >= 60 && this.gameObject.transform.eulerAngles.z <= 100)
            {
                swingingRight = false;
            }

            if (swingingRight)
            {
                this.gameObject.transform.Rotate(new Vector3(0, 0, 1 * speed * Time.deltaTime));

            }
            else
            {
                this.gameObject.transform.Rotate(new Vector3(0, 0, -1 * speed * Time.deltaTime));
            }
        }
    }
}
