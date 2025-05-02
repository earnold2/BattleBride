using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
    public class Level5Manager : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {
        public List<GameObject> icicles;
        public List<bool> icicleBools;
        public List<Vector3> startPos;
        public List<Vector3> endPos;

        public float icicleSpeed;

        public List<ActivateTentacles> activateTentaclesScripts;
        public Bride brideScript;

        public Text youWinText;
        public Button MainMenuButton;
        public Button PlayAgainButton;

        void Start()
        {
            for (int i = 0; i < icicles.Count; i++)
            {
                startPos.Add(icicles[i].transform.localPosition);
                endPos.Add(icicles[i].transform.localPosition - new Vector3(0, 10, 0));
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (brideScript.youWin)
            {
                YouWin();

                brideScript.youWin = false;
            }

            if (icicleBools[0])
            {
                if (icicles[0].transform.localPosition.y > endPos[0].y)
                {
                    icicles[0].transform.position -= new Vector3(0, icicleSpeed * Time.deltaTime, 0);
                }
                else
                {
                    icicles[0].transform.localPosition = endPos[0];
                    icicleBools[0] = false;
                }
            }
            if (icicleBools[1])
            {
                if (icicles[1].transform.localPosition.y > endPos[1].y)
                {
                    icicles[1].transform.position -= new Vector3(0, icicleSpeed * Time.deltaTime, 0);
                }
                else
                {
                    icicles[1].transform.localPosition = endPos[1];
                    icicleBools[1] = false;
                }
            }
            if (icicleBools[2])
            {
                if (icicles[2].transform.localPosition.y > endPos[2].y)
                {
                    icicles[2].transform.position -= new Vector3(0, icicleSpeed * Time.deltaTime, 0);
                }
                else
                {
                    icicles[2].transform.localPosition = endPos[2];
                    icicleBools[2] = false;
                }
            }
            if (icicleBools[3])
            {
                if (icicles[3].transform.localPosition.y > endPos[3].y)
                {
                    icicles[3].transform.position -= new Vector3(0, icicleSpeed * Time.deltaTime, 0);
                }
                else
                {
                    icicles[3].transform.localPosition = endPos[3];
                    icicleBools[3] = false;
                }
            }
        }

        public void IcicleCrash(int ID)
        {
            icicleBools[ID] = true;
        }

        public void ResetIcicles()
        {
            for (int i = 0; i < icicles.Count; i++)
            {
                icicles[i].transform.localPosition = startPos[i];
            }
        }

        private void ResetTentaclesChallenge()
        {
            for (int i = 0; i < activateTentaclesScripts.Count; i++)
            {
                activateTentaclesScripts[i].activated = false;
            }

            activateTentaclesScripts[0].tentacles.ResetTentacles();

            ResetIcicles();
        }

        private void YouWin()
        {
            youWinText.gameObject.SetActive(true);

            //maybe play some victory music

            //display main menu button after 5 seconds
            StartCoroutine(DisplayEndGameButtons());
            
        }

        private IEnumerator DisplayEndGameButtons()
        {
            yield return new WaitForSeconds(3);

            MainMenuButton.gameObject.SetActive(true);
            PlayAgainButton.gameObject.SetActive(true);
        }

        public virtual void OnMMEvent(CorgiEngineEvent gameEvent)
        {
            CorgiEngineEventTypes eventName = gameEvent.EventType;

            switch (eventName)
            {
                case CorgiEngineEventTypes.Respawn:
                    ResetTentaclesChallenge();
                    break;
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
