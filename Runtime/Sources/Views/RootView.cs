using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hermer29.Cheats
{
    internal class RootView : MonoBehaviour
    {
        [field: SerializeField] public CockpitSuperView CockpitSuperView { get; private set; }
        [field: SerializeField] public CheatsView CheatsView { get; private set; }
        [field: SerializeField] public PredictionsView PredictionsView { get; private set; }
        [SerializeField] private MainScreenView _mainScreenView;
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        public void Initialize(Cheats instance)
        {
            CheatsView.Initialize(instance);
            CockpitSuperView.Construct();
        }
    }
}