using System;
using UnityEngine;

namespace ARPGDemo.Skill
{
    public interface ITargetImpact
    {
        void TargetImpact(SkillDeployer deployer, SkillData skillData, GameObject gameobject);
    }
}

