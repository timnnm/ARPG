using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ARPGDemo.Character;

namespace ARPGDemo.Skill {

    public class CharacterSkillManager : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        public List<SkillData> skills = new List<SkillData>();


        private void Start()
        {
            foreach (SkillData skill in skills) {

                if (!string.IsNullOrEmpty(skill.perfabName))
                {
                    skill.skillPerfab = this.LoadPrefab(skill.perfabName);
                }

                if (!string.IsNullOrEmpty(skill.hitFxName))
                {
                    skill.hitFxPerfab = this.LoadPrefab(skill.hitFxName);
                }

                skill.Onwer = this.gameObject;
                
            }

        }

        public GameObject LoadPrefab(string resName) {

            GameObject prefabgo = Resources.Load<GameObject>(resName);


            GameObject temp = GameObjectPool.instance.CreateObject(resName, prefabgo, this.transform.position, this.transform.rotation);

            GameObjectPool.instance.CollectObject(temp);

            return prefabgo;
        }

        //准备技能
        public SkillData PrepareSkill(int id) {

            SkillData skill = skills.Find(delegate (SkillData obj)
            {
                return obj.skillID == id;
            });
            if (skill != null) {
                if (skill.coolRemain == 0 && skill.costSP <= skill.Onwer.GetComponent<CharacterStatus>().SP) {
                    return skill;
                }
            }

            return null;
        }

        //释放技能
        public void DeploySkill(SkillData skillData) {
           GameObject skill =  GameObjectPool.instance.CreateObject(skillData.perfabName, skillData.skillPerfab,
                skillData.Onwer.transform.position, skillData.Onwer.transform.rotation);

            SkillDeployer deployer = skill.GetComponent<SkillDeployer>();
            deployer.skilldata = skillData;
            deployer.DeploySkill();
            StartCoroutine(CoolTimeDown(skillData));
        }

        //技能冷却
        public IEnumerator CoolTimeDown(SkillData skillData) {

            skillData.coolRemain = skillData.coolTime;

            while (skillData.coolRemain > 0) {
                yield return new WaitForSeconds(1);
                skillData.coolRemain--;

            }

            skillData.coolRemain = 0;
        }


        //剩余冷却
        public int GetSkillCoolRemain(int id) {

            return skills.Find(s => s.skillID == id).coolRemain;
        }
    }
}

