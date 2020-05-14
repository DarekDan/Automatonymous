namespace Automatonymous.Binders
{
    using Behaviors;


    public class IgnoreEventActivityBinder<TInstance> :
        ActivityBinder<TInstance>
    {
        readonly Event _event;

        public IgnoreEventActivityBinder(Event @event)
        {
            _event = @event;
        }

        public bool IsStateTransitionEvent(State state)
        {
            return Equals(_event, state.Enter) || Equals(_event, state.BeforeEnter)
                   || Equals(_event, state.AfterLeave) || Equals(_event, state.Leave);
        }

        public void Bind(State<TInstance> state)
        {
            state.Ignore(_event);
        }

        public void Bind(BehaviorBuilder<TInstance> builder)
        {
        }
    }


    public class IgnoreEventActivityBinder<TInstance, TData> :
        ActivityBinder<TInstance>
    {
        readonly Event<TData> _event;
        readonly StateMachineEventFilter<TInstance, TData> _filter;

        public IgnoreEventActivityBinder(Event<TData> @event, StateMachineEventFilter<TInstance, TData> filter)
        {
            _event = @event;
            _filter = filter;
        }

        public bool IsStateTransitionEvent(State state)
        {
            return Equals(_event, state.Enter) || Equals(_event, state.BeforeEnter)
                   || Equals(_event, state.AfterLeave) || Equals(_event, state.Leave);
        }

        public void Bind(State<TInstance> state)
        {
            state.Ignore(_event, _filter);
        }

        public void Bind(BehaviorBuilder<TInstance> builder)
        {
        }
    }
}
