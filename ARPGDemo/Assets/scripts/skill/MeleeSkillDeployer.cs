using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ARPGDemo.Skill
{
    public class MeleeSkillDeployer : SkillDeployer
    {
        // Start is called before the first frame update


        public override void DeploySkill()
        {

            if (skilldata == null) return;
            skilldata.attackTargets = ResetTargets();
            listSelfImpact.ForEach(p => p.SelfImpact(this, skilldata, skilldata.Onwer));
            lisTargetImpact.ForEach(p => p.TargetImpact(this, skilldata, skilldata.Onwer));

            CollectSkill();

        }


    }
}
