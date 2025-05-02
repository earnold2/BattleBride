using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
    public class Boss4 : MonoBehaviour
    {
        private bool HasBeenHit = false;

        // Start is called before the first frame update
        void Start()
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, 180));
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Boss4OnDeath()
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, 180));

            this.transform.Find("Spawner").gameObject.SetActive(false);

            MMEventManager.TriggerEvent<MMGameEvent>(new MMGameEvent { EventName = "Boss4Death" });

            Destroy(this.gameObject, 5);
        }

        public void Boss4OnHit()
        {
            if (!HasBeenHit)
            {
                MMEventManager.TriggerEvent<MMGameEvent>(new MMGameEvent { EventName = "Boss4Hit" });

                HasBeenHit = true;
            }
        }
    }
}
