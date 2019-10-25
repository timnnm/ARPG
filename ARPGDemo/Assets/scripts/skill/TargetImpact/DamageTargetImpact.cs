using UnityEngine;
using System.Collections;


using ARPGDemo.Character;
namespace ARPGDemo.Skill
{


    public class DamageTargetImpact:ITargetImpact
    {
        // Use this for initialization


        private int baseDamage = 0;

        public void TargetImpact(SkillDeployer deployer, SkillData skillData, GameObject gameobject)
        {
            if (skillData.Onwer != null) {

                baseDamage = skillData.Onwer.GetComponent<CharacterStatus>().Damage;
            }


            deployer.StartCoroutine(RepeatDamage(deployer,skillData));
        }


        private void OnceDamage(SkillData skillData, GameObject damageobj)
        {
            CharacterStatus chStatus = damageobj.GetComponent<CharacterStatus>();
            float realDamage = baseDamage * skillData.damage;
            chStatus.OnDamage((int)realDamage);
            if (skillData.hitFxName != null && skillData.hitFxPerfab != null) {
                GameObject hitEffect = GameObjectPool.instance.CreateObject(skillData.hitFxName, skillData.hitFxPerfab, chStatus.HitFxPos.position, chStatus.HitFxPos.rotation);
                hitEffect.transform.parent = chStatus.HitFxPos;

                GameObjectPool.instance.CollectObject(hitEffect, 0.2f);
            }

        }

        private IEnumerator RepeatDamage(SkillDeployer deploy, SkillData skillData) {

            float damageTime = 0;
            do
            {
                if (skillData.attackTargets == null) break;

                for (int i = 0; i < skillData.attackTargets.Length; i++) {

                    GameObject obj = skillData.attackTargets[i];

                    OnceDamage(skillData, obj);

                }

                yield return new WaitForSeconds(skillData.damageInterval);
                damageTime += skillData.damageInterval;

                skillData.attackTargets = deploy.ResetTargets();

            } while (damageTime < skillData.durationTime);

        }


    }
}
