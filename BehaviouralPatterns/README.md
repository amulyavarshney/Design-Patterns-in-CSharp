# Behavioural Patterns

Behavioural patterns are concerned with communication and the assignment of responsibilities between objects.

| Pattern | Real-world Example | Key Idea |
|---|---|---|
| [Chain of Responsibility](ChainOfResponsibilityPattern) | Support ticket escalation | Pass a request along a chain until a handler accepts it |
| [Command](CommandPattern) | Smart home remote control | Encapsulate a request as an object with undo support |
| [Interpreter](InterpreterPattern) | Boolean expression evaluator | Define a grammar and evaluate sentences recursively |
| [Iterator](IteratorPattern) | Music playlist | Traverse a collection without exposing its structure |
| [Mediator](MediatorPattern) | Chat room | Route all communication through a central object |
| [Memento](MementoPattern) | Text editor undo | Capture and restore object state without breaking encapsulation |
| [Observer](ObserverPattern) | Stock price alerts | Notify many dependents automatically when state changes |
| [State](StatePattern) | Drawing tool selector | Change object behaviour by swapping its state object |
| [Strategy](StrategyPattern) | Sorting algorithms | Swap interchangeable algorithms at runtime |
| [Template Method](TemplateMethodPattern) | Report generator | Fix the algorithm skeleton; let subclasses fill in steps |
| [Visitor](VisitorPattern) | Document exporter | Add new operations to a class hierarchy without modifying it |

## Solution

Open `BehaviouralPatterns.sln` in Visual Studio or run any pattern individually:

```bash
cd <PatternName>
dotnet run
```
