namespace Assets._Project.Scripts.Base.BaseStateMachine
{
    public abstract class State : IState
    {
        protected IStateMachine StateMachine;

        protected State(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public abstract void Enter();

        public virtual void Update()
        {

        }

        public abstract void Exit();
    }
    public interface IState
    {
        public void Enter();
        public void Update();
        public void Exit();

    }

}