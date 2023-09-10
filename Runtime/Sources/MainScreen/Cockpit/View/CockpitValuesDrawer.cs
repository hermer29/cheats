using System.Collections.Generic;
using Hermer29.Cheats.DebugValues;
using Hermer29.Cheats.UiComponent;
using UnityEngine;

namespace Hermer29.Cheats
{
    internal class CockpitValuesDrawer
    {
        private readonly ReadOnlyStringValueView _readOnlyStringValueView;
        private readonly CockpitLayout _layout;
        private readonly CockpitReadOnlyModel _readOnlyModel;

        private Dictionary<string, ReadOnlyStringValueView> _stringValueViews = new Dictionary<string, ReadOnlyStringValueView>();

        internal CockpitValuesDrawer(CockpitLayout layout, CockpitReadOnlyModel readOnlyModel)
        {
            _layout = layout;
            _readOnlyModel = readOnlyModel;
            _readOnlyStringValueView = Resources.Load<ReadOnlyStringValueView>("Prefabs/adb31-cockpit-entry-readonly");
        }

        internal void Setup()
        {
            _readOnlyModel.ValueChanged += OnValueChanged;
            _readOnlyModel.ValueDefined += OnValueDefined;
        }

        private void OnValueDefined(string key, string value)
        {
            var newEntry = Object.Instantiate(_readOnlyStringValueView, _layout.transform);
            _stringValueViews.Add(key, newEntry);
            newEntry.DefineKey(key);
            newEntry.ShowValue(value);
        }

        private void OnValueChanged(string key, string value)
        {
            _stringValueViews[key].ShowValue(value);
        }
    }
}