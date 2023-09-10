using System;
using System.Collections.Generic;
using System.Linq;
using Hermer29.Cheats.Helpy;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Hermer29.Cheats
{
    public class Cheats : ITickable
    {
        private readonly KeyCode _keyCode;
        
        private static RootView s_view;
        private static Cheats s_instance;
        private static ITickService s_tickService;

        private HandlersComposite _cheatHandlers;

        private Cheats(IEnumerable<ICheatHandler> cheatHandlers, KeyCode keyCode)
        {
            _keyCode = keyCode;
            _cheatHandlers = HandlersComposite.CreateAndValidate(cheatHandlers);
        }

        public static void Create(IEnumerable<ICheatHandler> cheatHandlers, KeyCode enable = KeyCode.F3)
        {
            if (s_view != null)
                throw new InvalidOperationException("Already initialized");
            
            s_instance = new Cheats(cheatHandlers, enable);
            GameObject cheatsObject = CreateCheatsObject();
            InitializeRootView(cheatsObject);
            InitializeCheatsProcessing();
        }

        private static void InitializeCheatsProcessing()
        {
            s_tickService = s_view.GetComponent<TickService>();
            s_tickService.Integrate(s_instance);
        }

        private static void InitializeRootView(GameObject cheatsObject)
        {
            s_view = cheatsObject.GetComponent<RootView>();
            s_view.Initialize(s_instance);
        }

        private static GameObject CreateCheatsObject()
        {
            return Object.Instantiate(
                Resources.Load<GameObject>("Prefabs/adb31c33-25c8-456d-af77-fb717037f0a8_cheats_view"));
        }

        public static void Dispose()
        {
            if (s_view == null)
                throw new InvalidOperationException("Nothing to dispose! Create not called previously");

            GameObject.Destroy(s_view.gameObject);
            s_view = null;
            s_instance = null;
        }

        public static void Create(KeyCode enable = KeyCode.F3, params ICheatHandler[] cheatHandlers)
        {
            Create(cheatHandlers.AsEnumerable(), enable);
        }

        public void Tick(float deltaTime)
        {
            if (Input.GetKeyDown(_keyCode))
            {
                s_view.CheatsView.Toggle();
            }
        }

        public void NotifyValueChanged(string value)
        {
            s_view.PredictionsView.Show(_cheatHandlers.Predict(value));
            ICheatHandler handler = _cheatHandlers.Detect(value);
            if (handler != null)
            {
                handler?.Execute();
                s_view.CheatsView.ClearField();
            }
        }
    }
}