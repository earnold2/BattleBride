using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class VictoryResultsManager : MonoBehaviour
{
    public static VictoryResultsManager Instance;

    [Header("Reward Conditions to Evaluate")]
    [SerializeField] private List<RewardCondition> rewardConditions;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this after the player wins
    public void CalculateRewards()
    {
        if (GameTimerManager.Instance == null || GameManager.Instance == null)
        {
            Debug.LogWarning("Cannot calculate rewards — required managers are missing.");
            return;
        }

        RewardCondition bestResult = null;

        Debug.Log($"--- Evaluating Victory Conditions ---");
        foreach (var condition in rewardConditions)
        {
            if (condition.CheckRewardCondition())
            {
                Debug.Log($"✅ Reward Unlocked: {condition.rewardName}");
                condition.GrantReward();

                if (bestResult == null || bestResult.rewardRank < condition.rewardRank)
                {
                    bestResult = condition;
                }
            }
            else
            {
                Debug.Log($"❌ Missed: {condition.rewardName}");
            }
        }

        Debug.Log($"--- Finished Evaluating Rewards ---");
        Debug.Log($"--- Best Reward is {bestResult.rewardName} ---");
    }
}
