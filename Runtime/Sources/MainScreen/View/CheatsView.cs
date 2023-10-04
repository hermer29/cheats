using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Hermer29.Cheats
{
    public class CheatsView : MonoBehaviour
    {
        private Cheats _cheats;

        [SerializeField] private InputField _field;
        [SerializeField] private Transform _root;
        [SerializeField] private Button _submit;
        
        private bool _enabled;

        public void Initialize(Cheats cheats)
        {
            _cheats = cheats;
            Hide();
        }

        private void Start()
        {
            _submit.gameObject.SetActive(false);
            _field.onValueChanged.AddListener(OnValueChanged);
            _submit.onClick.AddListener(() => _cheats.NotifySubmitClicked(_field.text));
        }

        private void OnValueChanged(string value)
        {
            _cheats.NotifyValueChanged(value);
        }

        public void Toggle()
        {
            if (_enabled)
            {
                Hide();
                return;
            }
            Show();
        }

        private void Hide()
        {
            _enabled = false;
            _field.DeactivateInputField();
            _root.gameObject.SetActive(false);
        }

        private void Show()
        {
            IEnumerator WaitForObjectActivation()
            {
                yield return new WaitForEndOfFrame();
                _field.Select();
            }
            _enabled = true;
            _root.gameObject.SetActive(true);
            StartCoroutine(WaitForObjectActivation());
        }

        public void SetSubmitActive(bool active)
        {
            _submit.gameObject.SetActive(active);
        }

        public void ClearField() => _field.text = "";

        public void SetField(string cheat) => _field.text = cheat + " ";
    }
}