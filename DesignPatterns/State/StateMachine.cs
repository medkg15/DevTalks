using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    public class StateMachine
    {
        private Dictionary<Tuple<IState, IState>, HashSet<ITransition>> _transitions = new Dictionary<Tuple<IState, IState>, HashSet<ITransition>>();

        private IState _state;

        public StateMachine(IState startState)
        {
            _state = startState;
        }

        public void AddTransition(ITransition transition, IState start, IState end)
        {
            var key = new Tuple<IState, IState>(start, end);
            if (!_transitions.ContainsKey(key))
            {
                _transitions.Add(key, new HashSet<ITransition>());
            }

            var transitions = _transitions[key];
            if (!transitions.Contains(transition))
            {
                transitions.Add(transition);
            }
        }

        public IEnumerable<ITransition> GetAvailableTransitions()
        {
            return _transitions.Where(kvp => kvp.Key.Item1 == _state).SelectMany(kvp => kvp.Value);
        }

        public IState GetCurrentState()
        {
            return _state;
        }

        public void Transition(ITransition transitionToApply)
        {
            var match = _transitions.FirstOrDefault(kvp => kvp.Key.Item1 == _state && kvp.Value.Contains(transitionToApply));

            var next = match.Key.Item2;

            if (next == null)
            {
                throw new InvalidOperationException(transitionToApply.Name + " is not a valid transition.");
            }

            _state = next;
        }
    }
}
