using System;
using UnityEngine;

using ARPGDemo.Character;
namespace ARPGDemo.Skill
{
    public class CircleAttackSelector : IAttackSelector
    {
        public GameObject[] SelectTagrget(SkillData skillData, Transform skilltransform)
        {
            Collider[] objs = Physics.OverlapSphere(skilltransform.position, skillData.attackDistance);

            if (objs == null || objs.Length == 0) return null;

            //Collider[] etemps = ArrayHelper.FindAll(objs,c=> (Array.IndexOf(skillData.acctackTargetTags, c.tag) >= 0&& c.GetComponent<MonsterStatus>().HP>0));
            //Collider[] etemps = ArrayHelper.FindAll(objs, c => ((Array.IndexOf(skillData.acctackTargetTags, c.tag)>=0) && (c.GetComponent<MonsterStatus>().HP > 0)));
            Collider[] etemps = ArrayHelper.FindAll(objs, delegate (Collider collider) {

               return ((Array.IndexOf(skillData.acctackTargetTags, collider.tag) >= 0) && (collider.GetComponent<CharacterStatus>().HP > 0));
 

             });

            if (etemps == null || etemps.Length == 0) return null; 

            

            switch (skillData.attackType)
            {
                case SkillAttackType.Group:
                    return ArrayHelper.Select(etemps, c => c.gameObject);
                case SkillAttackType.Single:
                    Collider collider = ArrayHelper.Min(etemps, c => Vector3.Distance(skilltransform.position, c.transform.position));
                    return new GameObject[] { collider.gameObject };
                default:
                    break;
            }

            return null;
        }
    }
}
