using UnityEngine;

[CreateAssetMenu(fileName = "TimedRewardCondition", menuName = "Scriptable Objects/Reward Conditions/Timed Reward")]
public class TimedRewardCondition : RewardCondition
{
    public float maxTimeAllowed = 60f;

    public override bool CheckRewardCondition()
    {
        return GameTimerManager.Instance.ElapsedTime <= maxTimeAllowed;
    }

    public override void GrantReward()
    {
        Debug.Log($"[Reward Granted] {rewardName}");
    }
}