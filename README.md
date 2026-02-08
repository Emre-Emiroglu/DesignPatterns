# DesignPatterns
DesignPatterns is an independent pattern library that provides clean, readable, and ready-to-use implementations of commonly used design patterns for C# and Unity-based game development workflows.

## What Is a Design Pattern?
Design Patterns are proven and generally accepted solution approaches to recurring problems in software development.

A design pattern:
- Solves a specific problem
- Describes how to think, not how to implement
- Conveys design intent rather than concrete code

## Package Structure
Patterns are organized according to classical literature under the following categories:
- **Architectural Patterns**
- **Behavioral Patterns**
- **Creational Patterns**
- **Structural Patterns**

Each pattern is designed to be:
- Minimal
- Generic
- Unity-independent (except MonoBehaviour-based ones)
- Testable

## Getting Started
Install via UPM with git URL

`https://github.com/Emre-Emiroglu/DesignPatterns.git`

Clone the repository
```bash
git clone https://github.com/Emre-Emiroglu/DesignPatterns.git
```
This project is developed using Unity version 6000.2.6f2.

## Features
### Architectural Patterns
Except for the Service Locator pattern, this package does not provide runtime implementations for Architectural Patterns. These patterns define the overall structure of a system and are usually applied on a project-specific basis. Therefore, they are listed here for reference and guidance purposes only.

Included patterns:
- **Service Locator:** Centralizes the registration and resolution of dependencies. While it simplifies dependency management, uncontrolled usage may lead to hidden dependencies.
- **MVC (Model–View–Controller):** Separates data (Model), UI (View), and business logic (Controller) to improve readability and maintainability.
- **MVP (Model–View–Presenter):** A variant where the View is passive and all presentation logic is handled by the Presenter.
- **MVVM (Model–View–ViewModel):** Uses a ViewModel to bind the View and Model, commonly preferred in data-binding-heavy systems.
- **MVCS (Model–View–Controller–Service):** Extends MVC by introducing a service layer to separate business logic from controllers.
- **Clean Architecture:** Isolates business rules from frameworks and infrastructure by enforcing inward dependency flow.
- **Onion / Hexagonal Architecture:** Centers the core domain and connects external systems via adapters.
- **ECS (Entity Component System – Unity DOTS):** Separates data (Components) and behavior (Systems) to achieve high performance and cache-friendly design.
- **Component-Based Architecture:** Composes behavior from small, reusable components.

### Behavioral Patterns
Patterns that manage communication and behavior flow between objects.

Included patterns:
- **Chain of Responsibility:** Passes a request through a chain of handlers until one handles it.
- **Command:** Encapsulates a request as an object, decoupling the sender from the receiver.
- **Iterator:** Traverses a collection without exposing its internal structure.
- **Mediator:** Reduces direct communication between objects by centralizing interaction.
- **Memento:** Stores previous states of an object to enable undo operations.
- **Observer:** Automatically notifies dependent objects of state changes.
- **State:** Allows an object to change behavior based on its internal state.
- **Strategy:** Defines a family of algorithms and allows switching at runtime.
- **Template Method:** Defines the skeleton of an algorithm, deferring steps to subclasses.
- **Visitor:** Adds new behavior to object structures without modifying them.

### Creational Patterns
Patterns that control object creation processes.

Included patterns:
- **Abstract Factory:** Creates families of related objects without specifying concrete classes.
- **Builder:** Constructs complex objects step by step.
- **Factory Method:** Delegates object creation responsibility to subclasses.
- **Prototype:** Creates new objects by cloning existing ones.
- **Singleton:** Ensures a class has only one instance and provides global access.

### Structural Patterns
Patterns that organize relationships between classes and objects.

Included patterns:
- **Adapter:** Allows incompatible interfaces to work together.
- **Bridge:** Separates abstraction from implementation so both can vary independently.
- **Composite:** Treats individual objects and compositions uniformly.
- **Decorator:** Adds responsibilities to objects dynamically.
- **Facade:** Provides a simplified interface to a complex subsystem.
- **Flyweight:** Optimizes memory usage by sharing common object data.
- **Proxy:** Controls access to another object.

## Usage
### Architectural Patterns
- **Service Locator:**
```csharp
public interface IAudioService
{
    void PlaySound(string id);
}

public sealed class AudioService : IAudioService
{
    public void PlaySound(string id)
    {
        // Play sound logic
    }
}

// Registration
ServiceLocator.Register<IAudioService>(new AudioService());

// Resolve
var audioService = ServiceLocator.Resolve<IAudioService>();
audioService.PlaySound("click");
```

- **MVC / MVCS:** Ready-to-use runtime implementations for MVC and MVCS are provided in the [ModelViewMediatorController](https://github.com/Emre-Emiroglu/ModelViewMediatorController) package.

### Behavioral Patterns
- **Chain Of Responsibility:**
```csharp
public sealed class HealthCheckHandler : Handler<Player>
{
    protected override bool CanHandle(Player player) =>
        player.Health <= 0;

    protected override bool Process(Player player)
    {
        player.Die();
        return true;
    }
}

public sealed class AmmoCheckHandler : Handler<Player>
{
    protected override bool CanHandle(Player player) =>
        player.Ammo <= 0;

    protected override bool Process(Player player)
    {
        player.Reload();
        return true;
    }
}

// Usage
healthHandler.SetNext(ammoHandler);
healthHandler.Handle(player);
```

- **Command:**
```csharp
public sealed class MoveCommand : IUndoableCommand
{
    private readonly Player _player;
    private readonly Vector3 _direction;

    public MoveCommand(Player player, Vector3 direction)
    {
        _player = player;
        _direction = direction;
    }

    public void Execute() => _player.Position += _direction;
    public void Undo() => _player.Position -= _direction;
}

// Usage
invoker.Execute(new MoveCommand(player, Vector3.forward));
invoker.Undo();
```

- **Iterator:**
```csharp
public sealed class Inventory
{
    private readonly List<Item> _items = new();

    public IIterator<Item> CreateIterator()
    {
        return new ListIterator<Item>(_items);
    }
}

// Usage
var inventory = new Inventory();
var iterator = inventory.CreateIterator();

while (iterator.HasNext())
{
    Item item = iterator.Next();
}
```

- **Mediator:**
```csharp
public sealed class GameMediator : IMediator
{
    public void Notify(object sender, string eventId)
    {
        if (eventId == "PlayClicked")
        {
            // Start game
        }
    }
}

public sealed class PlayButton : Mediated
{
    public void Click()
    {
        Mediator.Notify(this, "PlayClicked");
    }
}
```

- **Memento:**
```csharp
public sealed class PlayerState
{
    public int Health;
    public Vector3 Position;
}

// Usage
var history = new MementoHistory<PlayerState>();

history.Save(new PlayerState { Health = 100 });
history.Save(new PlayerState { Health = 50 });

PlayerState previous = history.Undo(); // Health = 100
```

- **Observer:** For event-based and decoupled communication, the [SignalBus](https://github.com/Emre-Emiroglu/SignalBus) package is recommended.
```csharp
public sealed class Health : Subject<int>
{
    private int _value;

    public void Damage(int amount)
    {
        _value -= amount;
        Notify(_value);
    }
}

public sealed class HealthUI : IObserver<int>
{
    public void OnNotified(int data)
    {
        // Update UI
    }
}
```

- **State:**
```csharp
public sealed class IdleState : IState<Player>
{
    public void Enter(Player player) { }
    public void Update(Player player) { }
    public void Exit(Player player) { }
}

public sealed class AttackState : IState<Player>
{
    public void Enter(Player player) => player.PlayAttack();
    public void Update(Player player) { }
    public void Exit(Player player) { }
}

// Usage
stateMachine.ChangeState(new AttackState(), player);
```

- **Strategy:**
```csharp
public sealed class AggressiveStrategy : IStrategy<Player, void>
{
    public void Execute(Player player)
    {
        player.Attack();
    }
}

public sealed class DefensiveStrategy : IStrategy<Player, void>
{
    public void Execute(Player player)
    {
        player.Defend();
    }
}
```

- **Template Method:**
```csharp
public abstract class GameLoop : Template<object>
{
    protected override void Process(object context)
    {
        Initialize();
        Update();
        Shutdown();
    }

    protected abstract void Initialize();
    protected abstract void Update();
    protected abstract void Shutdown();
}
```

- **Visitor:**
```csharp
public interface IEnemy : IVisitable<IEnemy>
{
}

public sealed class Goblin : IEnemy
{
    public void Accept(IVisitor<IEnemy> visitor)
    {
        visitor.Visit(this);
    }
}

public sealed class DamageVisitor : IVisitor<IEnemy>
{
    public void Visit(IEnemy enemy)
    {
        // Apply damage
    }
}
```

### Creational Patterns
- **Abstract Factory:**
```csharp
public interface IUIFactory
{
    IButton CreateButton();
    IPanel CreatePanel();
}

public interface IButton { }
public interface IPanel { }

public sealed class MobileButton : IButton { }
public sealed class MobilePanel : IPanel { }

public sealed class DesktopButton : IButton { }
public sealed class DesktopPanel : IPanel { }

public sealed class MobileUIFactory : IUIFactory
{
    public IButton CreateButton() => new MobileButton();
    public IPanel CreatePanel() => new MobilePanel();
}

public sealed class DesktopUIFactory : IUIFactory
{
    public IButton CreateButton() => new DesktopButton();
    public IPanel CreatePanel() => new DesktopPanel();
}

// Usage
IUIFactory factory = new MobileUIFactory();

IButton button = factory.CreateButton();
IPanel panel = factory.CreatePanel();
```

- **Builder:**
```csharp
public sealed class Character
{
    public int Health;
    public int Damage;
    public float Speed;
}

public sealed class WarriorBuilder : Builder<Character>
{
    private Character _character = new();

    public WarriorBuilder WithHealth(int value)
    {
        _character.Health = value;
        return this;
    }

    public WarriorBuilder WithDamage(int value)
    {
        _character.Damage = value;
        return this;
    }

    public override Character Build() => _character;
    public override void Reset() => _character = new Character();
}

//Usage
Character _warrior = new WarriorBuilder().WithHealth(50).WithDamage(10).Build();
```

- **Factory Method:**
```csharp
public sealed class Enemy { }

public sealed class EnemyFactory : Factory<Enemy>
{
    protected override Enemy CreateInternal()
    {
        return new Enemy();
    }
}

// Usage
var factory = new EnemyFactory();
Enemy enemy = factory.Create();
```

- **Prototype:**
```csharp
public sealed class Bullet : Prototype<Bullet>
{
    public int Damage;
}

// Usage
var original = new Bullet { Damage = 10 };
var clone = original.Clone();
```

- **Singleton:**
```csharp
public sealed class GameSettings : Singleton<GameSettings>
{
    public int Volume = 10;
}

public sealed class GameManager : MonoSingleton<GameManager>
{
    public void StartGame() { }
}

public sealed class AudioManager : PersistentMonoSingleton<AudioManager>
{
    public void PlayMusic() { }
}

// Usage
GameSettings.Instance.Volume = 5;
GameManager.StartGame();
AudioManager.PlayMusic();
```

### Structural Patterns
- **Adapter:**
```csharp
public sealed class LegacyScoreSystem
{
    public int GetScoreValue() => 100;
}

public sealed class ScoreAdapter : IAdapter<int>
{
    private readonly LegacyScoreSystem _legacy = new();

    public int Adapt() => _legacy.GetScoreValue();
}
```

- **Bridge:**
```csharp
public interface IInputSystem : IBridgeImplementation
{
    void ReadInput();
}

public sealed class MobileInput : IInputSystem
{
    public void ReadInput() { }
}

public sealed class DesktopInput : IInputSystem
{
    public void ReadInput() { }
}

public sealed class PlayerController : Bridge<IInputSystem>
{
    public PlayerController(IInputSystem input) : base(input) { }
}
```

- **Composite:**
```csharp
public sealed class UIElement : Composite<UIElement>
{
    public void Render() { }
}

// Usage
var panel = new UIElement();
panel.Add(new UIElement()); // Button
panel.Add(new UIElement()); // Icon
```

- **Decorator:**
```csharp
public sealed class HealthDecorator : Decorator<int>
{
    public HealthDecorator(int value) : base(value) { }
}

// Usage
int health = new HealthDecorator(100).Value;
```

- **Facade:**
```csharp
public sealed class AudioSystem
{
    public void Load() { }
    public void Play() { }
}

public sealed class InputSystem
{
    public void Enable() { }
}

public sealed class SaveSystem
{
    public void LoadSave() { }
}

public sealed class GameFacade
{
    private readonly AudioSystem _audio = new();
    private readonly InputSystem _input = new();
    private readonly SaveSystem _save = new();

    public void StartGame()
    {
        _save.LoadSave();
        _audio.Load();
        _audio.Play();
        _input.Enable();
    }
}

// Usage
var game = new GameFacade();
game.StartGame();
```

- **Flyweight:**
```csharp
public sealed class Tile : IFlyweight<int>
{
    public int Key { get; }
    public Tile(int key) => Key = key;
}

public sealed class TileFactory : FlyweightFactory<int, Tile>
{
    protected override Tile Create(int key) => new Tile(key);
}

// Usage
var factory = new TileFactory();
Tile tileA = factory.Get(1);
Tile tileB = factory.Get(1); // Same instance
```

- **Proxy:**
```csharp
public sealed class TextureProxy : Proxy<Texture>
{
    protected override void EnsureSubject()
    {
        if (Subject == null)
            Subject = LoadTexture();
    }
    private Texture LoadTexture()
    {
        // Load texture from disk
    }
}

// Usage
Texture texture = new TextureProxy().Value;
```

## Notes
### When to Use Design Patterns
Design Patterns should be used to solve an existing problem, not to decorate code.

Use a pattern when:
- You observe duplication or rigid code
- A behavior or creation logic changes frequently
- You need to decouple systems or reduce dependencies
- You want to express design intent clearly to other developers

Patterns are most valuable when they reduce complexity over time, not when they are introduced prematurely.

### When Not to Use Design Patterns
Patterns should be used only when they solve a real problem.

Avoid using patterns when:
- The problem is simple and unlikely to change
- A pattern adds more abstraction than value
- Readability suffers due to over-engineering
- You are guessing future requirements instead of responding to real ones

Rule of thumb: If removing the pattern makes the code clearer, the pattern was probably unnecessary.

### Common Bad Usage / Anti-Patterns
#### Overusing Singleton
- Global access can hide dependencies
- Makes testing harder
- Encourages tight coupling

Prefer:
- Dependency Injection
- Explicit dependency passing
- Use Singleton only for truly global and stateless systems.

#### Service Locator Abuse
While Service Locator is included, it should be used with caution.

Common problems:
- Hidden dependencies
- Difficult-to-track object lifetimes
- Harder unit testing

Service Locator is acceptable for:
- Small projects
- Transitional architectures
- Tooling and infrastructure-level services

For larger projects, Dependency Injection is preferred.

#### Pattern Stacking
Avoid chaining multiple patterns without a clear reason.

Example:
- Singleton + Factory + Service Locator for the same responsibility

This often indicates:
- Unclear ownership
- Missing architectural decisions

#### Dependency Injection vs Patterns
Design Patterns and Dependency Injection are complementary, not competing concepts.

- Patterns describe structure and behavior
- Dependency Injection manages object lifetimes and dependencies

In modern Unity projects:
- Patterns define how systems interact
- DI frameworks (e.g. Zenject, VContainer) define how systems are wired

This package is DI-friendly by design:
- Constructors are explicit
- Interfaces are preferred
- Static usage is minimized where possible

#### Final Note
Design Patterns are tools, not goals. Understanding why a pattern exists is more important than memorizing its structure.

This package aims to serve as:
- A practical reference
- A learning resource
- A reminder of design intent

Use patterns consciously, refactor fearlessly, and keep systems simple.

## Tests
The package includes:
- **EditMode tests** to validate pattern intent
- **PlayMode tests** written only for `MonoSingleton` and `PersistentMonoSingleton`

## Acknowledgments
Special thanks to [Refactoring Guru](https://refactoring.guru/design-patterns) and the Unity community for their invaluable resources and tools.

For more information, visit the GitHub repository.
