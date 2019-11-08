using System;
using UnityEngine;

using ARPGDemo.Character;
namespace ARPGDemo.Skill {
    public class CostPSSelfImpact:ISelfImpact
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deployer"></param>
        /// <param name="skillData"></param>
        /// <param name="gameobject">施放技能的物体</param>
        public void SelfImpact(SkillDeployer deployer, SkillData skillData, GameObject gameobject) {

            if (skillData.Onwer == null) return;
            var characterStatus = skillData.Onwer.GetComponent<CharacterStatus>();
            characterStatus.SP -= skillData.costSP;

        }
    }
}

