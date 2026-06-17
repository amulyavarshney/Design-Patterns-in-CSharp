# Creational Patterns

Creational patterns are concerned with how objects are created, aiming to create them in a manner suitable to the situation.

| Pattern | Real-world Example | Key Idea |
|---|---|---|
| [Singleton](SingletonPattern) | Configuration manager | Only one instance ever exists; global access point |
| [Factory Method](FactoryMethodPattern) | Notification sender | Subclass decides which concrete product to create |
| [Abstract Factory](AbstractFactoryPattern) | UI theme system | Create families of related objects without specifying concrete classes |
| [Builder](BuilderPattern) | Computer assembler | Construct complex objects step by step |
| [Prototype](PrototypePattern) | Shape cloner | Create new objects by copying an existing one |

## Solution

Open `CreationalPatterns.sln` in Visual Studio or run any pattern individually:

```bash
cd <PatternName>
dotnet run
```
