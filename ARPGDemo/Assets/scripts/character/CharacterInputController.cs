using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using  ARPGDemo.Skill;

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
            Debug.Log("ButtonDown===");
            CharacterSkillManager skillManager = this.GetComponent<CharacterSkillManager>();

            SkillData skillData = null;


            switch (buttonName) {
                case "skill1":
                    skillData = skillManager.PrepareSkill(11);
                    break;
                case "skill2":
                    skillData = skillManager.PrepareSkill(12);
                    break;
            }

            if (skillData != null) skillManager.DeploySkill(skillData);
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
