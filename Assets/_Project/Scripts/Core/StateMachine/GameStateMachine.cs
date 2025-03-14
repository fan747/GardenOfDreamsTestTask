using Assets._Project.Scripts.Core.StateMachine.States;

namespace Assets._Project.Scripts.Core.StateMachine
{
    public class GameStateMachine : Base.BaseStateMachine.StateMachine
    {
        public GameStateMachine()
        {
            AddState<BootstrapState>(new BootstrapState(this));
            AddState<GameplayState>(new GameplayState(this));
            AddState<ExitState>(new ExitState(this));

            SetState<BootstrapState>();
        }
    }
}
