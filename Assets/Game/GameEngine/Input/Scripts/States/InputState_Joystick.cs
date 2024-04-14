using Elementary;
using InputModule;

namespace Game.GameEngine
{
    public sealed class InputState_Joystick : IState
    {
        private readonly JoystickInput input;

        public InputState_Joystick(JoystickInput input)
        {
            this.input = input;
        }

        public void Enter()
        {
            this.input.enabled = true;
        }

        public void Exit()
        {
            this.input.CancelInput();
            this.input.enabled = false;
        }
    }
}