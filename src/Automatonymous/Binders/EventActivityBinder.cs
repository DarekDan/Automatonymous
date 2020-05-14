namespace Automatonymous.Binders
{
    using System;


    public interface EventActivityBinder<TInstance> :
        EventActivities<TInstance>
        where TInstance : class
    {
        StateMachine<TInstance> StateMachine { get; }

        Event Event { get; }

        EventActivityBinder<TInstance> Add(Activity<TInstance> activity);

        /// <summary>
        /// Catch the exception of type T, and execute the compensation chain
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="activityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance> Catch<T>(
            Func<ExceptionActivityBinder<TInstance, T>, ExceptionActivityBinder<TInstance, T>> activityCallback)
            where T : Exception;

        /// <summary>
        /// Create a conditional branch of activities for processing
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="activityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance> If(StateMachineCondition<TInstance> condition,
            Func<EventActivityBinder<TInstance>, EventActivityBinder<TInstance>> activityCallback);

        /// <summary>
        /// Create a conditional branch of activities for processing
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="activityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance> IfAsync(StateMachineAsyncCondition<TInstance> condition,
            Func<EventActivityBinder<TInstance>, EventActivityBinder<TInstance>> activityCallback);

        /// <summary>
        /// Create a conditional branch of activities for processing
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="thenActivityCallback"></param>
        /// <param name="elseActivityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance> IfElse(StateMachineCondition<TInstance> condition,
            Func<EventActivityBinder<TInstance>, EventActivityBinder<TInstance>> thenActivityCallback,
            Func<EventActivityBinder<TInstance>, EventActivityBinder<TInstance>> elseActivityCallback);

        /// <summary>
        /// Create a conditional branch of activities for processing
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="thenActivityCallback"></param>
        /// <param name="elseActivityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance> IfElseAsync(StateMachineAsyncCondition<TInstance> condition,
            Func<EventActivityBinder<TInstance>, EventActivityBinder<TInstance>> thenActivityCallback,
            Func<EventActivityBinder<TInstance>, EventActivityBinder<TInstance>> elseActivityCallback);
    }


    public interface EventActivityBinder<TInstance, TData> :
        EventActivities<TInstance>
        where TInstance : class
    {
        StateMachine<TInstance> StateMachine { get; }

        Event<TData> Event { get; }

        EventActivityBinder<TInstance, TData> Add(Activity<TInstance> activity);

        EventActivityBinder<TInstance, TData> Add(Activity<TInstance, TData> activity);

        /// <summary>
        /// Catch the exception of type T, and execute the compensation chain
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="activityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance, TData> Catch<T>(
            Func<ExceptionActivityBinder<TInstance, TData, T>, ExceptionActivityBinder<TInstance, TData, T>> activityCallback)
            where T : Exception;

        /// <summary>
        /// Create a conditional branch of activities for processing
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="activityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance, TData> If(StateMachineCondition<TInstance, TData> condition,
            Func<EventActivityBinder<TInstance, TData>, EventActivityBinder<TInstance, TData>> activityCallback);

        /// <summary>
        /// Create a conditional branch of activities for processing
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="activityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance, TData> IfAsync(StateMachineAsyncCondition<TInstance, TData> condition,
            Func<EventActivityBinder<TInstance, TData>, EventActivityBinder<TInstance, TData>> activityCallback);

        /// <summary>
        /// Create a conditional branch of activities for processing
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="thenActivityCallback"></param>
        /// <param name="elseActivityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance, TData> IfElse(StateMachineCondition<TInstance, TData> condition,
            Func<EventActivityBinder<TInstance, TData>, EventActivityBinder<TInstance, TData>> thenActivityCallback,
            Func<EventActivityBinder<TInstance, TData>, EventActivityBinder<TInstance, TData>> elseActivityCallback);

        /// <summary>
        /// Create a conditional branch of activities for processing
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="thenActivityCallback"></param>
        /// <param name="elseActivityCallback"></param>
        /// <returns></returns>
        EventActivityBinder<TInstance, TData> IfElseAsync(StateMachineAsyncCondition<TInstance, TData> condition,
            Func<EventActivityBinder<TInstance, TData>, EventActivityBinder<TInstance, TData>> thenActivityCallback,
            Func<EventActivityBinder<TInstance, TData>, EventActivityBinder<TInstance, TData>> elseActivityCallback);
    }
}
