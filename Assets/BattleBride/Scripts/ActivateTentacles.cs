using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;


    public class ActivateTentacles : MonoBehaviour
    {
        //0 for all tentacles, then 1, 2, 3, 4 for the individual numbered tentacles
        public int ID;
        public bool activated;
        public TentacleController tentacles;

        // Start is called before the first frame update
        void Start()
        {
            activated = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !activated)
            {

                if (ID == 0)
                {
                    tentacles.Activate();

                    activated = true;
                }
                else if (ID == 1)
                {
                    tentacles.tentacle1IsActive = true;

                    activated = true;
                }
                else if (ID == 2)
                {
                    tentacles.tentacle2IsActive = true;

                    activated = true;
                }
                else if (ID == 3)
                {
                    tentacles.tentacle3IsActive = true;

                    activated = true;
                }
                else if (ID == 4)
                {
                    tentacles.tentacle4IsActive = true;

                    activated = true;
                }
            }
        }
    }


