using UnityEngine;

public abstract class RewardCondition : ScriptableObject
{
    [Tooltip("The name or ID of the reward.")]
    public string rewardName;

    [Tooltip("Higher values mean this reward takes precedence when multiple are earned.")]
    public int rewardRank;

    public abstract bool CheckRewardCondition();

    public abstract void GrantReward();
}