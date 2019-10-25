using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ARPGDemo.Skill
{
    public abstract class SkillDeployer : MonoBehaviour
    {
        // Start is called before the first frame update
        private SkillData m_SkillData;
        public SkillData skilldata
        {
            set
            {
                m_SkillData = value;
                attackSelector = DeployerConfig.CreateAttackSelector(m_SkillData);
                listSelfImpact = DeployerConfig.CreateSelfImpact(m_SkillData);
                lisTargetImpact = DeployerConfig.CreateTargetImpact(m_SkillData);
            }

            get
            {
                return m_SkillData;

            }

        }

        protected IAttackSelector attackSelector;

        protected List<ISelfImpact> listSelfImpact = new List<ISelfImpact>();
        protected List<ITargetImpact> lisTargetImpact = new List<ITargetImpact>();

        public GameObject[] ResetTargets()
        {
            var targets = attackSelector.SelectTagrget(m_SkillData, this.transform);
            if (targets != null && targets.Length > 0) return targets;
            return null;
        }

        public abstract void DeploySkill();

        public void CollectSkill()
        {
            if (m_SkillData.durationTime > 0)
            {
                GameObjectPool.instance.CollectObject(this.gameObject, m_SkillData.durationTime);
            }
            else
            {
                GameObjectPool.instance.CollectObject(this.gameObject, 0.2f);

            }

        }

    }
}

