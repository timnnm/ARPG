using UnityEngine;
using System.Collections;

using ARPGDemo.Skill;
using System.Collections.Generic;

namespace ARPGDemo.Character{
    public class CharacterSkillSystem : MonoBehaviour
    {
        // Use this for initialization
        


        private CharacterAnimation chAnim;
        private GameObject currentAttackTarget;
        private SkillData currentUseSkill;
        private CharacterSkillManager skillMgr;


        void Start()
        {
            chAnim = this.GetComponent<CharacterAnimation>();
            skillMgr = this.GetComponent<CharacterSkillManager>();

            GetComponent<AnimationEventBehaviour>().attackHandler += DeploySkill;
        }

        public void AttackUseSkill(int skillId,bool isBatter)
        {
            if (currentUseSkill != null) {
                skillId = currentUseSkill.nextBatterId;
            }
            currentUseSkill = skillMgr.PrepareSkill(skillId);

            chAnim.PlayAnimation(currentUseSkill.animationName);

            var selectedTarget = SelectTarget();
            if (selectedTarget == null) return;
            ShowSelectedFx(false);
            currentAttackTarget = selectedTarget;
            ShowSelectedFx(true);

            transform.LookAt(selectedTarget.transform);

        }

        public void DeploySkill()
        {

        }

        private GameObject SelectTarget()
        {
            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < skillData.acctackTargetTags.Length; i++)
            {
                GameObject[] objs = GameObject.FindGameObjectsWithTag(skillData.acctackTargetTags[i]);
                if (objs != null && objs.Length > 0) list.AddRange(objs);

            }


            if (list.Count == 0) return null;

            var etemps = list.FindAll(delegate (GameObject gobj)
            {
                return (Vector3.Distance(gobj.transform.position, skilltransform.position) < skillData.attackDistance)
                && (gobj.GetComponent<CharacterStatus>().HP > 0)
                && (Vector3.Angle(skilltransform.forward, gobj.transform.position - skilltransform.position) < skillData.attackAngle * 0.5f);
            });

            switch (skillData.attackType)
            {
                case SkillAttackType.Group:
                    return etemps.ToArray();
                case SkillAttackType.Single:
                    GameObject temp = ArrayHelper.Min(etemps.ToArray(), c => Vector3.Distance(skilltransform.position, c.transform.position));
                    return new GameObject[] { temp };
                default:
                    break;
            }

            return null;
        
        }

        private void ShowSelectedFx(bool show)
        {

        }

        public void UseRandomSkill()
        {
        }

    }
}

