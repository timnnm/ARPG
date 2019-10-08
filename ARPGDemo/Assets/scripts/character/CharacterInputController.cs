using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARPGDemo.Character
{
    public class CharacterInputController : MonoBehaviour
    {
        public CharacterMotor chMotor;


        public void Start()
        {
            chMotor = this.GetComponent<CharacterMotor>();
        }

        public void JoystickMove(MovingJoystick move)
        {
            chMotor.Move(move.joystickAxis.x, move.joystickAxis.y);
        }

        public void JoystickMoveEnd(MovingJoystick move)
        {
        }

        private void OnEnable()
        {
            EasyJoystick.On_JoystickMove += JoystickMove;
            EasyJoystick.On_JoystickMoveEnd += JoystickMoveEnd;
        }

        private void OnDisable()
        {
            EasyJoystick.On_JoystickMove -= JoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= JoystickMoveEnd;
        }
    }
}
