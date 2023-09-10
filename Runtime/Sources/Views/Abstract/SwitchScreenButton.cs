using UnityEngine;
using UnityEngine.UI;

namespace Hermer29.Cheats.Abstract
{
    [RequireComponent(typeof(Button))]
    public class SwitchScreenButton<TExit, TEnter> : MonoBehaviour 
        where TExit: Screen
        where TEnter: Screen
    {
        private TEnter _enter;
        private TExit _exit;
        
        public void Construct(TEnter enter, TExit exit)
        {
            _enter = enter;
            _exit = exit;
            
            GetComponent<Button>().onClick.AddListener(() =>
            {
                _exit.Hide();
                _enter.Show();
            });   
        }
    }
}