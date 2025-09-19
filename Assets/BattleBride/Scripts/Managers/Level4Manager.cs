using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
    public class Level4Manager : MonoBehaviour, MMEventListener<MMGameEvent>, MMEventListener<CorgiEngineEvent>
    {

        //First gate
        public ActivateGate gate1;
        private bool isGate1Open;

        //Second gate
        public ActivateGate gate2;
        private bool isGate2Open;
        public int enemiesRequired;
        private int enemiesKilled;
        public Text enemiesKilledText;

        //VARIOUS PLATFORMS
        public AlternatingPlatforms platforms1;
        public AlternatingPlatforms platforms2;

        public AlternatingPlatforms bossPlatforms1;
        public AlternatingPlatforms bossPlatforms2;
        public AlternatingPlatforms bossPlatforms3;

        public List<GameObject> otherPlatforms;

        public GameObject platformToDestroy;
        public GameObject platformToBreak;

        //Level 4 spawners
        public List<Spawner> level4Spawners;

        //Boss4 spawner
        public Spawner boss4Spawner;

        //Make the boss enemies boss specific

        // Start is called before the first frame update
        void Start()
        {
            isGate1Open = false;
            isGate2Open = false;

            enemiesKilledText.text = enemiesKilled + " / " + enemiesRequired;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CallBackAll()
        {
            for(int i = 0; i < level4Spawners.Count; i++)
            {
                level4Spawners[i].CallBack();
            }
        }

        public void KilledEnemy()
        {
            if (!isGate1Open)
            {
                gate1.OpenGate();
                isGate1Open = true;
            }

            if (!isGate2Open)
            {
                enemiesKilled++;
                enemiesKilledText.text = enemiesKilled + " / " + enemiesRequired;

                if (enemiesKilled >= enemiesRequired)
                {
                    gate2.OpenGate();
                    isGate2Open = true;

                    enemiesKilledText.gameObject.SetActive(false);
                }
            }

            platforms1.Alternate1();
            platforms2.Alternate2();

        }

        public void KilledBossEnemy()
        {
            bossPlatforms1.Alternate1();
            bossPlatforms2.Alternate1();
            bossPlatforms3.Alternate1();
        }

        public IEnumerator Boss4Hit()
        {
            //turn platforms off for 2 seconds
            bossPlatforms1.SetAllInactive();
            bossPlatforms2.SetAllInactive();
            bossPlatforms3.SetAllInactive();

            for(int i = 0; i < otherPlatforms.Count; i++)
            {
                otherPlatforms[i].SetActive(false);
            }

            CharacterHandleWeapon player = GameObject.Find("BBPlayer").GetComponent<CharacterHandleWeapon>();
            player.AbilityPermitted = false;

            yield return new WaitForSeconds(2);

            //turn them back on
            bossPlatforms1.Start();
            bossPlatforms2.Start();
            bossPlatforms3.Start();

            for (int i = 0; i < otherPlatforms.Count; i++)
            {
                otherPlatforms[i].SetActive(true);
            }

            player.AbilityPermitted = true;
        }

        public void Boss4Death()
        {
            //Activate all alternating platforms permanently
            bossPlatforms1.SetAllActive();
            bossPlatforms2.SetAllActive();
            bossPlatforms3.SetAllActive();

            //destroy on part of ceiling and move the other so the character can continue moving up
            platformToDestroy.SetActive(false);
            platformToBreak.transform.Rotate(new Vector3(0, 0, 30));
            platformToBreak.transform.position += new Vector3(0, -1.76f, 0);
        }

        public virtual void OnMMEvent(MMGameEvent gameEvent)
        {
            string eventName = gameEvent.EventName;

            switch (eventName)
            {
                case "SpawnedEnemyDeath":
                    KilledEnemy();
                    break;
                case "BossSpawnedEnemyDeath":
                    KilledBossEnemy();
                    break;
                case "Boss4Death":
                    Boss4Death();
                    break;
                case "Boss4Hit":
                    StartCoroutine(Boss4Hit());
                    break;
                case "Boss4SpawnStart":
                    boss4Spawner.StartSpawnerCoroutine();
                    break;
                case "Boss4SpawnStop":
                    boss4Spawner.StopSpawnerCoroutine();
                    break;
            }
        }

        public virtual void OnMMEvent(CorgiEngineEvent corgiEvent)
        {
            CorgiEngineEventTypes eventType = corgiEvent.EventType;

            switch (eventType)
            {
                case CorgiEngineEventTypes.Respawn:
                    Debug.Log("Respawning 4");
                    CallBackAll();
                    boss4Spawner.StopSpawnerCoroutine();
                    break;
            }
        }

        protected virtual void OnEnable()
        {
            this.MMEventStartListening<MMGameEvent>();
            this.MMEventStartListening<CorgiEngineEvent>();
        }

        protected virtual void OnDisable()
        {
            this.MMEventStopListening<MMGameEvent>();
            this.MMEventStopListening<CorgiEngineEvent>();
        }
    }
}

