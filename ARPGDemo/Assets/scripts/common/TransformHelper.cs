using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHelper : MonoBehaviour
{
    public static void LookAtTarget(Transform transform, Vector3 tager, float rotationSpeed) {
        if (tager != Vector3.zero) {
            Quaternion quaternion = Quaternion.LookRotation(tager);
            transform.rotation = Quaternion.Lerp(transform.rotation,quaternion,rotationSpeed*Time.deltaTime);

        }


    }
   
}
