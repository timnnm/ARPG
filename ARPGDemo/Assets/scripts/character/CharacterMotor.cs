using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARPGDemo.Character
{
    public class CharacterMotor : MonoBehaviour
    {
        public float moveSpeed = 5.0f;
        public float rotationSpeed = 5.0f;
        public CharacterAnimation chAnim;
        public CharacterController chController;

        public void Start()
        {
            this.chAnim = this.GetComponent<CharacterAnimation>();
            this.chController = this.GetComponent<CharacterController>();
        }

        public void Move(float x, float z)
        {
            if ((x <= -0.00001 || x >= 0.00001) || (z >= 0.00001 || z <= -0.00001))
            {

                TransformHelper.LookAtTarget(this.transform, new Vector3(x, 0, z), this.rotationSpeed);

                Vector3 motion = new Vector3(this.transform.forward.x * Time.deltaTime, -1, this.transform.forward.z * Time.deltaTime);
                chController.Move(motion);
                chAnim.PlayAnimation("run", true);
            }
            else
            {
                chAnim.PlayAnimation("run", false);
            }

        }

        
    }
}
