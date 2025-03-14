using Assets._Project.Scripts.Base.BaseStateMachine;

namespace Assets._Project.Scripts.Core.StateMachine.States
{
    //Пустышка что бы выйти из GamplayState
    public class ExitState : State
    {
        public ExitState(IStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
           
        }

        public override void Exit()
        {
            
        }
    }
}
