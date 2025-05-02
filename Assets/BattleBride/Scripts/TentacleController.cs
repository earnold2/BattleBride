using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

    public class TentacleController : MonoBehaviour
    {
        public float speed;
        public float maxHeight;
        public float tentacleSpeed;
        public float tentacleMaxHeight;

        public GameObject tentacle1;
        public GameObject tentacle2;
        public GameObject tentacle3;
        public GameObject tentacle4;

        private Vector3 tentacle1StartPos;
        private Vector3 tentacle2StartPos;
        private Vector3 tentacle3StartPos;
        private Vector3 tentacle4StartPos;

        private bool isActive;
        [HideInInspector]
        public Vector3 startPosition;
        [HideInInspector]
        public bool tentacle1IsActive, tentacle2IsActive, tentacle3IsActive, tentacle4IsActive;

        // Start is called before the first frame update
        void Start()
        {
            startPosition = this.gameObject.transform.localPosition;
            tentacle1StartPos = tentacle1.transform.localPosition;
            tentacle2StartPos = tentacle2.transform.localPosition;
            tentacle3StartPos = tentacle3.transform.localPosition;
            tentacle4StartPos = tentacle4.transform.localPosition;

            isActive = false;
            this.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            //All tentacles move
            if (isActive)
            {
                this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }

            //All tentacles stop
            if (this.gameObject.transform.localPosition.y >= maxHeight)
            {
                isActive = false;
            }

            //Individual tentacles move
            if (tentacle1IsActive)
            {
                if (tentacle1.transform.localPosition.y < tentacleMaxHeight)
                {
                    tentacle1.transform.position += new Vector3(0, tentacleSpeed * Time.deltaTime, 0);
                }
                else
                {
                    tentacle1IsActive = false;
                }
            }

            if (tentacle2IsActive)
            {
                if (tentacle2.transform.localPosition.y < tentacleMaxHeight)
                {
                    tentacle2.transform.position += new Vector3(0, tentacleSpeed * Time.deltaTime, 0);
                }
                else
                {
                    tentacle2IsActive = false;
                }
            }

            if (tentacle3IsActive)
            {
                if (tentacle3.transform.localPosition.y < tentacleMaxHeight)
                {
                    tentacle3.transform.position += new Vector3(0, tentacleSpeed * Time.deltaTime, 0);
                }
                else
                {
                    tentacle3IsActive = false;
                }
            }

            if (tentacle4IsActive)
            {
                if (tentacle4.transform.localPosition.y < tentacleMaxHeight)
                {
                    tentacle4.transform.position += new Vector3(0, tentacleSpeed * Time.deltaTime, 0);
                }
                else
                {
                    tentacle4IsActive = false;
                }
            }
        }

        public void Activate()
        {
            isActive = true;
            this.gameObject.SetActive(true);
        }

        public void DeactivateTentacle(GameObject tentacle)
        {
            tentacle.SetActive(false);
        }

        public void ResetTentacles()
        {
            this.gameObject.transform.localPosition = startPosition;

            tentacle1.SetActive(true);
            tentacle2.SetActive(true);
            tentacle3.SetActive(true);
            tentacle4.SetActive(true);

            tentacle1.transform.localPosition = tentacle1StartPos;
            tentacle2.transform.localPosition = tentacle2StartPos;
            tentacle3.transform.localPosition = tentacle3StartPos;
            tentacle4.transform.localPosition = tentacle4StartPos;

            isActive = false;
            this.gameObject.SetActive(false);
        }
    }
