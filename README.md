# Design Patterns in C#

A complete implementation of all 24 Gang of Four (GoF) design patterns in C# (.NET 6). Every pattern includes working code, two UML diagrams (generic pattern diagram + class diagram), and a README explaining the concept and each class.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later

## How to Run

Each pattern is a standalone console application. To run any pattern:

```bash
cd <Category>/<PatternName>
dotnet run
```

**Examples:**
```bash
cd BehaviouralPatterns/ObserverPattern
dotnet run

cd CreationalPatterns/SingletonPattern
dotnet run

cd StructuralPatterns/ProxyPattern
dotnet run
```

To build all patterns in a category at once:
```bash
cd BehaviouralPatterns
dotnet build BehaviouralPatterns.sln
```

---

## Creational Patterns
> Concerned with how objects are created.

| Pattern | Description |
|---|---|
| [Singleton](CreationalPatterns/SingletonPattern) | Ensures a class has only one instance and provides a global access point |
| [Factory Method](CreationalPatterns/FactoryMethodPattern) | Defines an interface for creating an object, but lets subclasses decide which class to instantiate |
| [Abstract Factory](CreationalPatterns/AbstractFactoryPattern) | Creates families of related objects without specifying their concrete classes |
| [Builder](CreationalPatterns/BuilderPattern) | Constructs complex objects step by step, separating construction from representation |
| [Prototype](CreationalPatterns/PrototypePattern) | Creates new objects by copying an existing object |

---

## Structural Patterns
> Concerned with how classes and objects are composed to form larger structures.

| Pattern | Description |
|---|---|
| [Adapter](StructuralPatterns/AdapterPattern) | Makes incompatible interfaces work together by wrapping one in the other |
| [Bridge](StructuralPatterns/BridgePattern) | Splits a class into two independent hierarchies — abstraction and implementation |
| [Composite](StructuralPatterns/CompositePattern) | Composes objects into tree structures so individual objects and composites are treated uniformly |
| [Decorator](StructuralPatterns/DecoratorPattern) | Attaches additional responsibilities to an object dynamically |
| [Facade](StructuralPatterns/FacadePattern) | Provides a simplified interface to a complex subsystem |
| [Flyweight](StructuralPatterns/FlyweightPattern) | Shares common state across many fine-grained objects to reduce memory usage |
| [Proxy](StructuralPatterns/ProxyPattern) | Provides a surrogate that controls access to another object |

---

## Behavioural Patterns
> Concerned with communication and responsibility between objects.

| Pattern | Description |
|---|---|
| [Chain of Responsibility](BehaviouralPatterns/ChainOfResponsibilityPattern) | Passes a request along a chain of handlers until one handles it |
| [Command](BehaviouralPatterns/CommandPattern) | Encapsulates a request as an object, enabling undo, queuing, and logging |
| [Interpreter](BehaviouralPatterns/InterpreterPattern) | Defines a grammar and an interpreter to evaluate sentences in that language |
| [Iterator](BehaviouralPatterns/IteratorPattern) | Provides a way to sequentially access elements of a collection without exposing its structure |
| [Mediator](BehaviouralPatterns/MediatorPattern) | Reduces dependencies between objects by routing communication through a central mediator |
| [Memento](BehaviouralPatterns/MementoPattern) | Captures and restores an object's internal state without violating encapsulation |
| [Observer](BehaviouralPatterns/ObserverPattern) | Notifies a list of dependents automatically when an object's state changes |
| [State](BehaviouralPatterns/StatePattern) | Allows an object to change its behaviour when its internal state changes |
| [Strategy](BehaviouralPatterns/StrategyPattern) | Defines a family of algorithms and makes them interchangeable at runtime |
| [Template Method](BehaviouralPatterns/TemplateMethodPattern) | Defines the skeleton of an algorithm in a base class, deferring some steps to subclasses |
| [Visitor](BehaviouralPatterns/VisitorPattern) | Lets you add new operations to a class hierarchy without modifying those classes |

---

## Contributing
Fork the repository and open a pull request with your changes.

## License
This repository is licensed under the MIT License. You can view the license [here](LICENSE).
