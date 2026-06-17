# Structural Patterns

Structural patterns are concerned with how classes and objects are composed to form larger, more flexible structures.

| Pattern | Real-world Example | Key Idea |
|---|---|---|
| [Adapter](AdapterPattern) | Legacy payment processor | Wrap an incompatible interface so it matches what the client expects |
| [Bridge](BridgePattern) | Shape renderer | Split abstraction and implementation into independent hierarchies |
| [Composite](CompositePattern) | File system | Treat individual objects and collections uniformly via a shared interface |
| [Decorator](DecoratorPattern) | Coffee order | Wrap an object to add behaviour dynamically without subclassing |
| [Facade](FacadePattern) | Home theatre | Provide a simple interface over a complex subsystem |
| [Flyweight](FlyweightPattern) | Forest renderer | Share intrinsic state across many objects to reduce memory |
| [Proxy](ProxyPattern) | Secure document service | Control access to an object via a same-interface substitute |

## Solution

Open `StructuralPatterns.sln` in Visual Studio or run any pattern individually:

```bash
cd <PatternName>
dotnet run
```
