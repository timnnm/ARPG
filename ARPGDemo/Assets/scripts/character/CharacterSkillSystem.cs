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
            if (currentUseSkill != null&&isBatter) {
                skillId = currentUseSkill.nextBatterId;
            }
            currentUseSkill = skillMgr.PrepareSkill(skillId);

            if (currentUseSkill == null) return;
            Debug.Log("==PPP"+ currentUseSkill.animationName);
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
            for (int i = 0; i < currentUseSkill.acctackTargetTags.Length; i++)
            {
                GameObject[] objs = GameObject.FindGameObjectsWithTag(currentUseSkill.acctackTargetTags[i]);
                if (objs != null && objs.Length > 0) list.AddRange(objs);

            }


            if (list.Count == 0) return null;

            var etemps = list.FindAll(delegate (GameObject gobj)
            {
                return (Vector3.Distance(gobj.transform.position, this.transform.position) < currentUseSkill.attackDistance)
                && (gobj.GetComponent<CharacterStatus>().HP > 0);
            });

            if (etemps.Count == 0) return null;
            GameObject temp = ArrayHelper.Min(etemps.ToArray(), c => Vector3.Distance(this.transform.position, c.transform.position));
            return temp;
          
        }

        private void ShowSelectedFx(bool isShow)
        {
            Transform selectedFx = null;
            if (currentAttackTarget != null) {
                selectedFx = TransformHelper.FindChild(currentAttackTarget.transform, "selected");

            }

            if (selectedFx != null) {
                selectedFx.GetComponent<Renderer>().enabled = isShow;
            }
        }

        public void UseRandomSkill()
        {
            var useableSkill = skillMgr.skills.FindAll(skill => skill.coolRemain == 0 && skill.costSP <= skill.Onwer.GetComponent<CharacterStatus>().SP);

            if (useableSkill != null && useableSkill.Count > 0) {
                var index = Random.Range(0,useableSkill.Count);
                var skillid = skillMgr.skills[index].skillID;
                AttackUseSkill(skillid, false);
            }
        }

    }
}

