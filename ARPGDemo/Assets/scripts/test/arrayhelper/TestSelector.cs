using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPGDemo.Skill;
using ARPGDemo.Character;

public class TestSelector : MonoBehaviour
{
    // Start is called before the first frame update

    public SkillData skillData = new SkillData();
    GameObject[] result = null;

    void Start()
    {
        

    }

    private void OnGUI()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SectorAttackSelector selector = new SectorAttackSelector();
        result = selector.SelectTagrget(skillData, this.transform);

        if (result != null && result.Length > 0)
        {

            for (var i = 0; i < result.Length; i++)
            {
                Debug.DrawLine(transform.position, result[i].transform.position, Color.red);
            }


        }
    }
}
