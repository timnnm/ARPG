using System;
using UnityEngine;

using ARPGDemo.Character;
namespace ARPGDemo.Skill {
    public class CostPSSelfImpact
    {
        public void SelfImpact(SkillDeployer deployer, SkillData skillData, GameObject gameobject) {

            if (skillData.Onwer == null) return;
            var characterStatus = skillData.Onwer.GetComponent<CharacterStatus>();
            characterStatus.SP -= skillData.costSP;

        }
    }
}

