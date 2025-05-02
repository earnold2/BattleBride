using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.CorgiEngine;

public class SpawnedEnemy : MonoBehaviour, MMEventListener<CorgiEngineEvent>
{
    public Spawner spawner;

    public bool bossSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeath()
    {
        if (!spawner.onTime)
        {
            spawner.Spawn();
        }

        if (bossSpawn)
        {
            MMEventManager.TriggerEvent<MMGameEvent>(new MMGameEvent { EventName = "BossSpawnedEnemyDeath" });
        }
        else
        {
            MMEventManager.TriggerEvent<MMGameEvent>(new MMGameEvent { EventName = "SpawnedEnemyDeath" });
        }
    }

    public virtual void OnMMEvent(CorgiEngineEvent corgiEvent)
    {
        CorgiEngineEventTypes eventType = corgiEvent.EventType;

        switch (eventType)
        {
            case CorgiEngineEventTypes.Respawn:
                if (bossSpawn)
                {
                    Destroy(this.gameObject);
                }

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
