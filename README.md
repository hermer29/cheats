# cheats

Library to simplify the creation of cheats for testing and debugging features

# Installation

To install the package, you can add it in package manager using the git url: 

`https://github.com/hermer29/cheats.git#v1.1.0`

# Quick Start

To start using cheats without parameters, you need to implement the interface `ICheatHandler`

```csharp
namespace Hermer29.Cheats
{
    public interface ICheatHandler
    {
        string GetCheatCode();
        void Execute();
    }
}
```

- `GetCheatCode()` method returns case insensitive cheat code, which can later be used in the cheat menu
- `Execute()` implements the operation that will be performed when typing this cheat code

To start using cheats with parameters, you need to implement the interface `IParametrizedCheatHandler`

```csharp
namespace Hermer29.Cheats
{
    public interface IParametrizedCheatHandler : ICheatHandler
    {
        string Description { get; }
        void Execute(string[] args);
    }
}
```

- `Description` property returns description of the cheat and its parameters
- `Execute(string[] args)` implements the operation that will be performed when typing this cheat code and pressing submit button, the passed parameters will be passed to the method

Next you need to pass instances of this interfaces to the first parameter of the method `Cheats.Create`.
You can redefine the key to which the cheat menu will open by passing the KeyCode of the key to the second parameter

## Cockpit

Cockpit is a feature that allows you to display key-value pairs in the cheat menu (replacing `Debug.Log` sometimes). This feature can be used only after calling the `Cheats.Create`.

```csharp
Cockpit.SetReadOnly(key, value);
```
