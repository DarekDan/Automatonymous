﻿namespace Automatonymous.Tests
{
    using Impl;
    using NUnit.Framework;

    [TestFixture]
    public class When_an_event_is_declared
    {
        [Test]
        public void It_should_capture_a_simple_event_name()
        {
            Assert.AreEqual("Hello", _machine.Hello.Name);
        }

        [Test]
        public void It_should_capture_the_data_event_name()
        {
            Assert.AreEqual("EventA", _machine.EventA.Name);
        }

        [Test]
        public void It_should_create_the_proper_event_type_for_simple_events()
        {
            Assert.IsInstanceOf<EventImpl<Test>>(_machine.Hello);
        }

        [Test]
        public void It_should_create_the_proper_event_type_for_data_events()
        {
            Assert.IsInstanceOf<EventImpl<Test, A>>(_machine.EventA);
        }

        TestStateMachine _machine;

        [TestFixtureSetUp]
        public void A_state_is_declared()
        {
            _machine = new TestStateMachine();
        }

        class A
        {
        }

        class Test :
            StateMachineInstance
        {
            public State CurrentState { get; set; }
        }

        class TestStateMachine :
            StateMachineSpecification<Test>
        {
            public TestStateMachine()
            {
                Event(() => Hello);
                Event(() => EventA);
            }

            public Event Hello { get; private set; }
            public Event<A> EventA { get; private set; }

            public State Running { get; private set; }
        }
    }
}