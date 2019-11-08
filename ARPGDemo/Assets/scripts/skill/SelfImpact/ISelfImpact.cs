using System;
using UnityEngine;

namespace ARPGDemo.Skill {
    public interface ISelfImpact
    {
        void SelfImpact(SkillDeployer deployer, SkillData skillData, GameObject gameobject);
    }
}

