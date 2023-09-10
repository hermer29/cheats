using System.Collections.Generic;
using UnityEngine;

namespace Hermer29.Cheats.Helpy
{
    internal class TickService : MonoBehaviour, ITickService
    {
        private List<ITickable> _tickables = new List<ITickable>();
        
        public void Integrate(ITickable tickable) => _tickables.Add(tickable);
        
        private void Update()
        {
            foreach (ITickable tickable in _tickables) 
                tickable.Tick(Time.deltaTime);
        }
    }
}