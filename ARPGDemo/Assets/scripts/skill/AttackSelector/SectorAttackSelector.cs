using System;
using UnityEngine;

using ARPGDemo.Character;
using System.Collections.Generic;

namespace ARPGDemo.Skill
{
    public class SectorAttackSelector : IAttackSelector
    {
        public GameObject[] SelectTagrget(SkillData skillData, Transform skilltransform)
        {


            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < skillData.acctackTargetTags.Length; i++) {
                GameObject[] objs =  GameObject.FindGameObjectsWithTag(skillData.acctackTargetTags[i]);
                if (objs!=null&&objs.Length > 0) list.AddRange(objs);
              
            }


            if (list.Count == 0) return null;

            var etemps = list.FindAll(delegate (GameObject gobj)
            {
                return (Vector3.Distance(gobj.transform.position, skilltransform.position)<skillData.attackDistance)
                &&(gobj.GetComponent<CharacterStatus>().HP>0)
                &&(Vector3.Angle(skilltransform.forward,gobj.transform.position- skilltransform.position)<skillData.attackAngle*0.5f);
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
    }
}
