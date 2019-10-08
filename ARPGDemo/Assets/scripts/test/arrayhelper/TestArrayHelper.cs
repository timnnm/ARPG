using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArrayHelper : MonoBehaviour
{

    void Start()
    {
        this.findDisMin();


    }

    void findMaxHp() {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");


        GameObject obj = ArrayHelper.Max(objs, delegate (GameObject enemy)
        {
            return enemy.GetComponent<EnemyHealth>().Hp;

        });

        obj.GetComponent<MeshRenderer>().material.color = Color.red;

    }


    void findAllHp() {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");


        GameObject[] obj = ArrayHelper.FindAll(objs, delegate (GameObject enemy)
        {
            return enemy.GetComponent<EnemyHealth>().Hp>5;

        });

        for (int i = 0; i < obj.Length; i++) {
            objs[i].GetComponent<MeshRenderer>().material.color = Color.red;
        }


    }

    void findDisMin() {

        Transform myTransform = transform;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject obj = ArrayHelper.Min(objs, delegate (GameObject enemy)
        {
            return Vector3.Distance(myTransform.position,enemy.transform.position);

        });


        obj.GetComponent<MeshRenderer>().material.color = Color.blue;


    }

}
