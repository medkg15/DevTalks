using System;
using System.Linq;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare states & transitions
            // these are nothing but identifiers, but they can have logic too.
            var draft = new State("draft");
            var pendingApproval = new State("pendingApproval");
            var approved = new State("approved");
            var published = new State("published");

            var submitForApproval = new Transition("submitForApproval");
            var approve = new Transition("approve");
            var decline = new Transition("decline");
            var publish = new Transition("publish");

            // next, define the start state + transitions between states
            var stateMachine = new StateMachine(draft);

            stateMachine.AddTransition(submitForApproval, draft, pendingApproval);
            stateMachine.AddTransition(approve, pendingApproval, approved);
            stateMachine.AddTransition(decline, pendingApproval, draft);
            stateMachine.AddTransition(publish, approved, published);

            // finally, we can use the machine.

            while (true)
            {
                Console.WriteLine("Current: " + stateMachine.GetCurrentState().Name);
                Console.WriteLine("Available:");
                foreach (var transition in stateMachine.GetAvailableTransitions())
                {
                    Console.WriteLine(" - " + transition.Name);
                }

                Console.WriteLine();
                Console.WriteLine("Enter transition: ");
                var name = Console.ReadLine();
                var transitionToApply = stateMachine.GetAvailableTransitions().FirstOrDefault(t => t.Name == name);
                if (transitionToApply == null)
                {
                    Console.WriteLine("ERROR: Enter an available transition.");
                    continue;
                }

                stateMachine.Transition(transitionToApply);
            }
        }
    }
}
