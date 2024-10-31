using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "rewardfinder", story: "check if [detector] has a target", category: "Action", id: "abdd2ecc9876fd8fcf6268ce000bf2d2")]
public partial class RewardfinderAction : Action
{
    [SerializeReference] public BlackboardVariable<Detector> Detector;

    protected override Status OnStart()
    {
        return Detector.Value.Reward==null? Status.Failure : Status.Success;
    }

}

