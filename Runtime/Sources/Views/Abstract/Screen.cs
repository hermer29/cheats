using Hermer29.Cheats.Helpers;
using UnityEngine;

namespace Hermer29.Cheats.Abstract
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public void Hide()
        {
            _canvasGroup.SetCanvasActive(false);
        }

        public void Show()
        {
            _canvasGroup.SetCanvasActive(true);
        }
    }
}