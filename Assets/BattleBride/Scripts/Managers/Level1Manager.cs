using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class Level1Manager : MonoBehaviour, MMEventListener<CorgiEngineEvent>
{
    public static Level1Manager instance = null;

    [SerializeField] private GameObject _boss1;
    private Health _boss1Health;

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
        _boss1Health = _boss1.GetComponent<Health>();
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
        _boss1Health.ResetHealthToMaxHealth();
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
