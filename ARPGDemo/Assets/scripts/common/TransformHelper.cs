using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHelper : MonoBehaviour
{
    public static Transform FindChild(Transform trans,string goName) {
        Transform child = trans.Find(goName);
        if (child != null) return child;

        Transform go = null;
        for (int i = 0; i < trans.childCount; i++) {
            child = trans.GetChild(i);
            go = FindChild(child, goName);
            if (go != null) return go;
        }


        return null;
    }


    public static void LookAtTarget(Transform transform, Vector3 tager, float rotationSpeed) {
        if (tager != Vector3.zero) {
            Quaternion quaternion = Quaternion.LookRotation(tager);
            transform.rotation = Quaternion.Lerp(transform.rotation,quaternion,rotationSpeed*Time.deltaTime);

        }
    }
   
}
