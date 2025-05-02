using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class Boss4Helper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.transform.position.x >= this.gameObject.transform.position.x)
            {
                MMEventManager.TriggerEvent<MMGameEvent>(new MMGameEvent { EventName = "Boss4SpawnStart" });
            }
            else
            {
                MMEventManager.TriggerEvent<MMGameEvent>(new MMGameEvent { EventName = "Boss4SpawnStop" });
            }
        }
    }
}
