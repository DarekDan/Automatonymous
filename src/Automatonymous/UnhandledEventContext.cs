namespace Automatonymous
{
    using System.Threading.Tasks;


    /// <summary>
    /// The context of an unhandled event in the state machine
    /// </summary>
    /// <typeparam name="TInstance"></typeparam>
    public interface UnhandledEventContext<out TInstance> :
        EventContext<TInstance>
    {
        /// <summary>
        /// The current state of the state machine
        /// </summary>
        State CurrentState { get; }

        /// <summary>
        /// Returns a Task that ignores the unhandled event
        /// </summary>
        Task Ignore();

        /// <summary>
        /// Returns a thrown exception task for the unhandled event
        /// </summary>
        /// <returns></returns>
        Task Throw();
    }
}
