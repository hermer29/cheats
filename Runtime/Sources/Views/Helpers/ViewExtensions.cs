using UnityEngine;

namespace Hermer29.Cheats.Helpers
{
    public static class ViewExtensions
    {
        public static void SetCanvasActive(this CanvasGroup group, bool state)
        {
            group.alpha = state ? 1 : 0;
            group.interactable = state;
            group.blocksRaycasts = state;
        }
    }
}