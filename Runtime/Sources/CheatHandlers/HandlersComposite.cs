using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Hermer29.Cheats
{
    internal class HandlersComposite
    {
        private readonly ICheatHandler[] _handlers;

        public HandlersComposite(IEnumerable<ICheatHandler> handlers)
        {
            _handlers = handlers as ICheatHandler[] ?? handlers.ToArray();
            foreach (ICheatHandler handler in _handlers)
            {
                Debug.Log(handler.GetCheatCode());
            }
        }

        public static HandlersComposite CreateAndValidate(IEnumerable<ICheatHandler> handlers)
        {
            if (Application.isEditor == false)
                return new HandlersComposite(handlers);
            foreach (ICheatHandler cheatHandler in handlers)
            {
                var cheatCode = cheatHandler.GetCheatCode().ToLower();
                foreach (ICheatHandler handler in handlers.Except(new ICheatHandler[] {cheatHandler}))
                {
                    if (handler.GetCheatCode().ToLower() == cheatCode)
                        throw new InvalidOperationException(
                            $"The cheat code handler with code {cheatCode} has a duplicate");
                }
            }

            return new HandlersComposite(handlers: handlers);
        }

        public IEnumerable<Match> Predict(string codePart)
        {
            var regex = new Regex($"^{codePart}");
            foreach (ICheatHandler cheatHandler in _handlers)
            {
                System.Text.RegularExpressions.Match match = regex.Match(cheatHandler.GetCheatCode());
                if(match.Success == false)
                    continue;
                yield return new Match
                {
                    EndPosition = match.Groups[0].Length,
                    Handler = cheatHandler
                };
            }
        }

        public ICheatHandler Detect(string code)
        {
            foreach (ICheatHandler cheatHandler in _handlers)
            {
                if (string.Equals(cheatHandler.GetCheatCode(), code, StringComparison.CurrentCultureIgnoreCase))
                {
                    return cheatHandler;
                }
            }
            return null;
        }
    }
}