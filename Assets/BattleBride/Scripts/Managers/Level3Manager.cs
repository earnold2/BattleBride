using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class Level3Manager : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {
        public static Level3Manager instance = null;

        //Bride puzzle
        [Header("Bride Puzzle")]
        public bool[] buttonStatus = new bool[9];
        public bool[] buttonStatusHelper = new bool[3];
        public GameObject[] buttons = new GameObject[9];
        public ActivateGate[] gates = new ActivateGate[3];

        public Sprite RedOn;
        public Sprite RedOff;
        public Sprite BlueOn;
        public Sprite BlueOff;
        public Sprite YellowOn;
        public Sprite YellowOff;

        //Groom puzzle
        [Header("Groom Puzzle")]
        public GameObject[] treadPlatforms = new GameObject[3];

        //Boss
        [SerializeField] private List<GameObject> _boss3;
        private List<Health> _boss3Health = new List<Health>();


        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < buttonStatus.Length; i++)
            {
                buttonStatus[i] = false;
            }

            //Get boss health
            foreach(GameObject boss in _boss3)
            {
                _boss3Health.Add(boss.GetComponent<Health>());
            }
        }

        // Update is called once per frame
        void Update()
        {
            //gate 0
            if (buttonStatus[0] == false && buttonStatus[1] == true && buttonStatus[2] == false)
            {
                gates[0].OpenGate();
            }

            //gate 1
            if (buttonStatus[3] == true && buttonStatus[4] == false && buttonStatus[5] == true)
            {
                gates[1].OpenGate();
            }

            //gate 2
            if (buttonStatus[6] == false && buttonStatus[7] == true && buttonStatus[8] == true)
            {
                if(buttonStatusHelper[1] == false && buttonStatusHelper[2] == true)
                {
                    gates[2].OpenGate();
                }
            }

        }

        public void ButtonToggle(int ID)
        {
            SpriteRenderer renderer = buttons[ID].GetComponent<SpriteRenderer>();

            //Helper for the more complicated last three buttons
            if (ID >= 6)
            {
                //set appropriate bools and renderer colors
                if(buttonStatus[ID] == false)
                {
                    //set bool
                    buttonStatus[ID] = true;
                }
                else if (buttonStatus[ID] == true && buttonStatusHelper[ID - 6] == false)
                {
                    //set bool
                    buttonStatusHelper[ID - 6] = true;

                    //play particles
                    buttons[ID].transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
                }
                else
                {
                    //set bools
                    buttonStatus[ID] = false;
                    buttonStatusHelper[ID - 6] = false;

                    //stop particles
                    buttons[ID].transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
                }

                return;
            }

            //standard for the first six simple buttons
            buttonStatus[ID] = !buttonStatus[ID];

            if (buttonStatus[ID])
            {
                //enabled
                //renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1);
            }
            else
            {
                //disabled
                //renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.25f);
            }
        }

        public void TreadmillToggle(int ID)
        {
            for(int i = 0; i < treadPlatforms.Length; i++)
            {
                if(i == ID)
                {
                    treadPlatforms[i].SetActive(true);
                }
                else
                {
                    treadPlatforms[i].SetActive(false);
                }
            }
        }

        public virtual void OnMMEvent(CorgiEngineEvent gameEvent)
        {
            CorgiEngineEventTypes eventName = gameEvent.EventType;

            switch (eventName)
            {
                case CorgiEngineEventTypes.Respawn:
                    ResetBossHealth();
                    break;
            }
        }

        private void ResetBossHealth()
        {
            foreach(var health in _boss3Health)
            {
                health.Revive();
            }
        }

        protected virtual void OnEnable()
        {
            this.MMEventStartListening<CorgiEngineEvent>();
        }

        protected virtual void OnDisable()
        {
            this.MMEventStopListening<CorgiEngineEvent>();
        }
    }
}
