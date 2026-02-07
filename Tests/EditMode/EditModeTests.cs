using System.Collections.Generic;
using NUnit.Framework;
using DesignPatterns.Runtime.Architectural;
using DesignPatterns.Runtime.Behavioral.ChainOfResponsibility;
using DesignPatterns.Runtime.Behavioral.Command;
using DesignPatterns.Runtime.Behavioral.Iterator;
using DesignPatterns.Runtime.Behavioral.Mediator;
using DesignPatterns.Runtime.Behavioral.Memento;
using DesignPatterns.Runtime.Behavioral.Observer;
using DesignPatterns.Runtime.Behavioral.State;
using DesignPatterns.Runtime.Behavioral.Strategy;
using DesignPatterns.Runtime.Behavioral.TemplateMethod;
using DesignPatterns.Runtime.Behavioral.Visitor;
using DesignPatterns.Runtime.Creational.Builder;
using DesignPatterns.Runtime.Creational.FactoryMethod;
using DesignPatterns.Runtime.Creational.Prototype;
using DesignPatterns.Runtime.Creational.Singleton;
using DesignPatterns.Runtime.Structural.Adapter;
using DesignPatterns.Runtime.Structural.Composite;
using DesignPatterns.Runtime.Structural.Decorator;
using DesignPatterns.Runtime.Structural.Flyweight;
using DesignPatterns.Runtime.Structural.Proxy;

namespace DesignPatterns.Tests.EditMode
{
    public sealed class EditModeTests
    {
        #region ArchitecturalTests
        [Test]
        public void ServiceLocator_ResolveRegisteredService_ReturnsInstance()
        {
            ServiceLocator.Clear();

            TestService service = new TestService();
            
            ServiceLocator.Register(service);

            TestService resolved = ServiceLocator.Resolve<TestService>();

            Assert.AreSame(service, resolved);
        }
        #endregion

        #region Behavioral
        [Test]
        public void ChainOfResponsibility_HandlesRequestInChain()
        {
            IntHandler handlerA = new IntHandler(1);
            
            IntHandler handlerB = new IntHandler(2);

            handlerA.SetNext(handlerB);

            bool handled = handlerA.Handle(2);

            Assert.IsTrue(handled);
        }
        [Test]
        public void Command_ExecuteAndUndo_ChangesState()
        {
            Counter receiver = new Counter();
            
            IncrementCommand command = new IncrementCommand(receiver);
            
            CommandInvoker invoker = new CommandInvoker();

            invoker.Execute(command);
            
            invoker.Undo();

            Assert.AreEqual(0, receiver.Value);
        }
        [Test]
        public void Iterator_IteratesAllElements()
        {
            List<int> list = new List<int> { 1, 2, 3 };
            
            ListIterator<int> iterator = new ListIterator<int>(list);

            int sum = 0;
            while (iterator.HasNext())
                sum += iterator.Next();

            Assert.AreEqual(6, sum);
        }
        [Test]
        public void Mediator_NotifiesThroughMediator()
        {
            TestMediator mediator = new TestMediator();
            
            TestMediated component = new TestMediated();

            component.SetMediator(mediator);
            
            component.Trigger();

            Assert.IsTrue(mediator.Notified);
        }
        [Test]
        public void Memento_SaveAndRestore_StateRestored()
        {
            TestOriginator originator = new TestOriginator(5);
            
            MementoHistory<TestMemento> history = new MementoHistory<TestMemento>();

            history.Save(originator.CreateMemento());

            originator.Value = 10;
            
            originator.Restore(history.Undo());

            Assert.AreEqual(5, originator.Value);
        }
        [Test]
        public void Observer_Notify_CallsObserver()
        {
            TestSubject subject = new TestSubject();
            
            TestObserver observer = new TestObserver();

            subject.Subscribe(observer);
            
            subject.Notify(3);

            Assert.AreEqual(3, observer.LastValue);
        }
        [Test]
        public void StateMachine_ChangeState_CallsEnter()
        {
            object context = new object();
            
            TestState state = new TestState();
            
            StateMachine<object> machine = new StateMachine<object>();

            machine.ChangeState(state, context);

            Assert.IsTrue(state.Entered);
        }
        [Test]
        public void Strategy_Execute_ReturnsExpectedResult()
        {
            IStrategy<int, int> strategy = new DoubleStrategy();

            int result = strategy.Execute(5);

            Assert.AreEqual(10, result);
        }
        [Test]
        public void TemplateMethod_Execute_CallsStepsInOrder()
        {
            TestTemplate template = new TestTemplate();

            template.Execute(null);

            CollectionAssert.AreEqual(new[] { "Start", "Process", "Finish" }, template.CallOrder);
        }
        [Test]
        public void Visitor_Visit_CalledOnElement()
        {
            TestVisitable element = new TestVisitable();
            
            TestVisitor visitor = new TestVisitor();

            element.Accept(visitor);

            Assert.IsTrue(visitor.Visited);
        }
        #endregion
        
        #region CreationalTests
        [Test]
        public void Builder_Build_ReturnsConstructedObject()
        {
            TestBuilder builder = new TestBuilder();
            
            Director<int> director = new Director<int>(builder);

            int result = director.Construct();

            Assert.AreEqual(42, result);
        }
        [Test]
        public void FactoryMethod_Create_ReturnsProduct()
        {
            TestFactory factory = new TestFactory();

            int product = factory.Create();

            Assert.AreEqual(10, product);
        }
        [Test]
        public void Prototype_Clone_ReturnsDifferentInstance()
        {
            TestPrototype original = new TestPrototype { Value = 5 };

            TestPrototype clone = original.Clone();

            Assert.AreNotSame(original, clone);
            
            Assert.AreEqual(original.Value, clone.Value);
        }
        [Test]
        public void Singleton_Instance_ReturnsSameReference()
        {
            TestSingleton a = TestSingleton.Instance;
            
            TestSingleton b = TestSingleton.Instance;

            Assert.AreSame(a, b);
        }
        #endregion

        #region Structural
        [Test]
        public void Adapter_Adapt_ReturnsAdaptedValue()
        {
            IAdapter<int> adapter = new TestAdapter();

            Assert.AreEqual(99, adapter.Adapt());
        }
        [Test]
        public void Composite_AddChild_IncreasesCount()
        {
            TestComposite composite = new TestComposite();
            
            composite.Add(1);

            Assert.AreEqual(1, ((List<int>)composite.Children).Count);
        }
        [Test]
        public void Decorator_WrapsValue()
        {
            TestDecorator decorator = new TestDecorator(5);

            Assert.AreEqual(5, decorator.Value);
        }
        [Test]
        public void FlyweightFactory_ReusesInstances()
        {
            TestFlyweightFactory factory = new TestFlyweightFactory();

            TestFlyweight a = factory.Get(1);
            
            TestFlyweight b = factory.Get(1);

            Assert.AreSame(a, b);
        }
        [Test]
        public void Proxy_Value_EnsuresSubject()
        {
            TestProxy proxy = new TestProxy();

            int value = proxy.Value;

            Assert.AreEqual(7, value);
        }
        #endregion

        #region TestElements
        private sealed class TestService { }
        private sealed class IntHandler : Handler<int>
        {
            private readonly int _value;
            
            public IntHandler(int value) => _value = value;
            
            protected override bool CanHandle(int request) => request == _value;
            protected override bool Process(int request) => true;
        }
        private sealed class Counter
        {
            public int Value; 
        }
        private sealed class IncrementCommand : IUndoableCommand
        {
            private readonly Counter _counter;
            
            public IncrementCommand(Counter counter) => _counter = counter;
            
            public void Execute() => _counter.Value++;
            public void Undo() => _counter.Value--;
        }
        private sealed class ListIterator<T> : IIterator<T>
        {
            private readonly IList<T> _list;
            
            private int _index;
            
            public ListIterator(IList<T> list) => _list = list;
            
            public bool HasNext() => _index < _list.Count;
            public T Next() => _list[_index++];
            public void Reset() => _index = 0;
        }
        private sealed class TestMediator : IMediator
        {
            public bool Notified;
            
            public void Notify(object sender, string eventId) => Notified = true;
        }
        private sealed class TestMediated : Mediated
        {
            public void Trigger() => Mediator.Notify(this, "test");
        }
        private sealed class TestMemento : IMemento
        {
            public int Value;
        }
        private sealed class TestOriginator : IOriginator<TestMemento>
        {
            public int Value;
            
            public TestOriginator(int value) => Value = value;
            
            public TestMemento CreateMemento() => new() { Value = Value };
            public void Restore(TestMemento memento) => Value = memento.Value;
        }
        private sealed class TestObserver : IObserver<int>
        {
            public int LastValue;
            
            public void OnNotified(int data) => LastValue = data;
        }
        private sealed class TestSubject : Subject<int> { }
        private sealed class TestState : IState<object>
        {
            public bool Entered;
            
            public void Enter(object context) => Entered = true;
            public void Exit(object context) { }
            public void Update(object context) { }
        }
        private sealed class DoubleStrategy : IStrategy<int, int>
        {
            public int Execute(int input) => input * 2;
        }
        private sealed class TestTemplate : Template<object>
        {
            public readonly List<string> CallOrder = new();
            
            protected override void OnStart(object context) => CallOrder.Add("Start");
            protected override void Process(object context) => CallOrder.Add("Process");
            protected override void OnFinish(object context) => CallOrder.Add("Finish");
        }
        private sealed class TestVisitor : IVisitor<TestVisitable>
        {
            public bool Visited;
            
            public void Visit(TestVisitable element) => Visited = true;
        }
        private sealed class TestVisitable : IVisitable<TestVisitable>
        {
            public void Accept(IVisitor<TestVisitable> visitor) => visitor.Visit(this);
        }
        private sealed class TestBuilder : Builder<int>
        {
            public override int Build() => 42;
            public override void Reset() { }
        }
        private sealed class TestFactory : Factory<int>
        {
            protected override int CreateInternal() => 10;
        }
        private sealed class TestPrototype : Prototype<TestPrototype>
        {
            public int Value;
        }
        private sealed class TestSingleton : Singleton<TestSingleton> { }
        private sealed class TestAdapter : IAdapter<int>
        {
            public int Adapt() => 99;
        }
        private sealed class TestComposite : Composite<int> { }
        private sealed class TestDecorator : Decorator<int>
        {
            public TestDecorator(int inner) : base(inner) { }
        }
        private sealed class TestFlyweight : IFlyweight<int>
        {
            public int Key { get; }
            
            public TestFlyweight(int key) => Key = key;
        }
        private sealed class TestFlyweightFactory : FlyweightFactory<int, TestFlyweight>
        {
            protected override TestFlyweight Create(int key) => new(key);
        }
        private sealed class TestProxy : Proxy<int>
        {
            protected override void EnsureSubject()
            {
                if (Subject == 0)
                    typeof(Proxy<int>).GetField("Subject",
                            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                        ?.SetValue(this, 7);
            }
        }
        #endregion
    }
}
