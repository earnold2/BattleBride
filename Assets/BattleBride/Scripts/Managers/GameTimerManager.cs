using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimerManager : MonoBehaviour
{
    public static GameTimerManager Instance;

    [Tooltip("Name of the scene where the timer should start/reset.")]
    public string gameSceneName = "BBLevel";

    private float _elapsedTime = 0f;
    private bool _isRunning = true;
    private bool _victoryAchieved = false;

    public float ElapsedTime => _elapsedTime;
    public bool VictoryAchieved => _victoryAchieved;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Clean up
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void Update()
    {
        if (_isRunning)
        {
            _elapsedTime += Time.deltaTime;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == gameSceneName)
        {
            ResetTimer();
        }
        else
        {
            _isRunning = false;
        }
    }

    public void SetVictory()
    {
        if (!_victoryAchieved)
        {
            _isRunning = false;
            _victoryAchieved = true;
            Debug.Log($"Victory! Time elapsed: {_elapsedTime:F2} seconds.");
        }
    }

    public void ResetTimer()
    {
        _elapsedTime = 0f;
        _isRunning = true;
        _victoryAchieved = false;
        Debug.Log("Timer reset.");
    }
}
