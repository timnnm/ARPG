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
            chMotor.Move(move.joystickAxis.x, move.joystickAxis.y);
        }

        private void ButtonDown(string buttonName) {


            var skillSystem = this.GetComponent<CharacterSkillSystem>();
            switch (buttonName) {
                case "skill1":
                    skillSystem.AttackUseSkill(11,false);
                    break;
                case "skill2":
                  
                    skillSystem.AttackUseSkill(12, false);
                    break;
            }

           
        }

        private void OnEnable()
        {
            EasyJoystick.On_JoystickMove += JoystickMove;
            EasyJoystick.On_JoystickMoveEnd += JoystickMoveEnd;
            EasyButton.On_ButtonDown += ButtonDown;


        }

        private void OnDisable()
        {
            EasyJoystick.On_JoystickMove -= JoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= JoystickMoveEnd;
            EasyButton.On_ButtonDown -= ButtonDown;
        }
    }
}
