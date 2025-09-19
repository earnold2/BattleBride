using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class Level2Manager : MonoBehaviour, MMEventListener<CorgiEngineEvent>
{
    public static Level2Manager instance = null;

    [SerializeField] private GameObject _boss2;
    private Health _boss2Health;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set Boss Health
        _boss2Health = _boss2.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {

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
        _boss2Health.ResetHealthToMaxHealth();
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
