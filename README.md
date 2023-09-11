# cheats
Library to simplify the creation of cheats for testing and debugging features


# Quick Start

To start using cheats, you need to implement the interface `ICheatHandler`

```csharp
﻿namespace Hermer29.Cheats
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

Next you need to pass instances of this interface to the first parameter of the method `Cheats.Create`.
You can redefine the key to which the cheat menu will open by passing the KeyCode of the key to the second parameter

## Cockpit

Cockpit is a feature that allows you to display key-value pairs in the cheat menu (replacing `Debug.Log`). This feature can be used only after calling the `Cheats.Create`.

```csharp
Cockpit.SetReadOnly(key, value);
```
