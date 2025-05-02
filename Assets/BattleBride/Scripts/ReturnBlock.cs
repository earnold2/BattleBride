using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBlock : MonoBehaviour
{
    public Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
        start = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(this.transform.localPosition.y < -7)
        {
            this.gameObject.transform.position = start + new Vector3(0, 3, 0);
        }
    }
}
