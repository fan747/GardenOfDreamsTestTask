using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Base.BaseStateMachine
{
    public class StateMachine : IStateMachine
    {
        protected IState _currentState;
        protected Dictionary<string, IState> _states = new Dictionary<string, IState>();

        public bool IsCurrentState<T>() where T : IState
        {
            string key = typeof(T).Name;

            if (_currentState == _states[key])
            {
                return true;
               
            }
            return false;
        }

        public void AddState<T>(T state) where T : IState
        {
            string key = typeof(T).Name;

            if (_states.ContainsKey(key))
            {
                Debug.LogError("An attempt to add an already added state!");
                return;
            }

            _states.Add(key, state);
        }

        public void SetState<T>() where T : IState
        {
            string key = typeof(T).Name;

            if (!_states.ContainsKey(key))
            {
                Debug.LogError("An attempt to change to an un-added state!");
                return;
            }

            _currentState?.Exit();
            _currentState = _states[key];
            _currentState?.Enter();
        }

        public void Update()
        {
            _currentState.Update();
        }
    }

    public interface IStateMachine
    {
        public void AddState<T>(T state) where T : IState;
        public void SetState<T>() where T : IState;
        public void Update();
    }

}