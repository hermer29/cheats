using Hermer29.Cheats.DebugValues;
using Hermer29.Cheats.UiComponent;
using UnityEngine;

namespace Hermer29.Cheats
{
    public class CockpitSuperView : Abstract.Screen
    {
        private CockpitReadOnlyModel _cockpitReadOnlyModel;
        private CockpitValuesDrawer _valuesDrawer;
        
        [SerializeField] private CockpitLayout _parent;

        public void Construct()
        {
            _cockpitReadOnlyModel = new CockpitReadOnlyModel();
            Cockpit.Construct(_cockpitReadOnlyModel);
            _valuesDrawer = new CockpitValuesDrawer(_parent, _cockpitReadOnlyModel);
            _valuesDrawer.Setup();
        }
    }
}