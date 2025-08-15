using MoreMountains.CorgiEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "NoLivesLostReward", menuName = "Scriptable Objects/Reward Conditions/No Lives Lost")]
public class NoLivesLostRewardCondition : RewardCondition
{
    public override bool CheckRewardCondition()
    {
        return GameManager.Instance.CurrentLives == GameManager.Instance.MaximumLives;
    }

    public override void GrantReward()
    {
        Debug.Log($"[Reward Granted] {rewardName}");
    }
}