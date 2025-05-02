using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class ActivateGate : MonoBehaviour
    {
        private MovingPlatform thisGateScript;


        // Start is called before the first frame update
        void Start()
        {
            thisGateScript = this.gameObject.GetComponent<MovingPlatform>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OpenGate()
        {
            thisGateScript.AuthorizeMovement();
        }
    }
}
