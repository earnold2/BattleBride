using MoreMountains.CorgiEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "PerfectRun", menuName = "Scriptable Objects/Reward Conditions/Perfect Run")]
public class TimeAndNoLivesLostCondition : RewardCondition
{
    public float maxTime;

    public override bool CheckRewardCondition()
    {
        return GameTimerManager.Instance.ElapsedTime <= maxTime
               && GameManager.Instance.CurrentLives >= GameManager.Instance.MaximumLives;
    }

    public override void GrantReward()
    {
        Debug.Log($"[Reward Granted] {rewardName}");
    }
}
