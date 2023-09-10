using System;

namespace Hermer29.Cheats.DebugValues
{
    public static class Cockpit
    {
        private static CockpitReadOnlyModel _sReadOnlyModel;
        private static bool _isConstructed;

        internal static void Construct(CockpitReadOnlyModel readOnlyModel)
        {
            _sReadOnlyModel = readOnlyModel;
            _isConstructed = true;
        }

        internal static void Destroy()
        {
            _isConstructed = false;
        }

        public static void SetReadOnly(string key, object value)
        {
            if (_isConstructed == false)
                throw new InvalidOperationException("Create cheat menu by calling Cheats.Create() at first");
            
            _sReadOnlyModel.SetValue(key, value);
        }

        public static void Set(string key, object value)
        {
            if (_isConstructed == false)
                throw new InvalidOperationException("Create cheat menu by calling Cheats.Create() at first");

            
        }
    }
}