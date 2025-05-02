using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class TreadmillHelper : MonoBehaviour
    {
        public float xForce;
        public float yForce;

        private Vector2 force;

        public Rigidbody2D rb2d;

        // Start is called before the first frame update
        void Start()
        {
            force = new Vector2(xForce, yForce);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                //rb2d = collision.gameObject.GetComponent<Rigidbody2D>();

                rb2d.linearVelocity = force;
            }

            Debug.Log("Stay" + this.gameObject.name);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                rb2d = collision.gameObject.GetComponent<Rigidbody2D>();

                rb2d.linearVelocity = force;
            }

            Debug.Log("Enter" + this.gameObject.name);
        }
    }
}
