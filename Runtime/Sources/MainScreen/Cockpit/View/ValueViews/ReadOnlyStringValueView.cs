using UnityEngine;
using UnityEngine.UI;

namespace Hermer29.Cheats
{
    public class ReadOnlyStringValueView : MonoBehaviour
    {
        [SerializeField] private Text _key;
        [SerializeField] private Text _value;
        
        public void DefineKey(string key)
        {
            _key.text = key;
        }
        
        public void ShowValue(object value)
        {
            _value.text = value.ToString();
        }
    }
}