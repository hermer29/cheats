using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Hermer29.Cheats.UiComponent
{
    [ExecuteAlways, RequireComponent(typeof(RectTransform), typeof(LayoutElement))]
    public class CockpitLayout : MonoBehaviour
    {
        [SerializeField] private Vector2 _spacing;
        [SerializeField] private float _marginBottom = 10;
        [SerializeField] private float _marginTop = 10;
        [SerializeField] private float _marginRight = 10;
        [SerializeField] private float _marginLeft = 10;
        [SerializeField, HideInInspector] private RectTransform _rect;
        [SerializeField, HideInInspector] private LayoutElement _layoutElement;
        [SerializeField] private float _childHeight;
        
        private void OnValidate()
        {
            _rect = GetComponent<RectTransform>();
            _layoutElement = GetComponent<LayoutElement>();
        }

        private void Update()
        {
            float width = _rect.rect.width;
            _layoutElement.minWidth = width;
            float sumWidth = _marginLeft;
            float height = _marginBottom;

            var castChildren = transform.Cast<Transform>().ToArray();
            for (int i = 0; i < castChildren.Length; i++)
            {
                var rect = castChildren[i].GetComponent<RectTransform>();
                Vector2 size = rect.sizeDelta;
                size.y = _childHeight;
                rect.sizeDelta = size;
                float childWidth = rect.rect.width; 
                rect.pivot = new Vector2(0, 0);
                if (sumWidth + childWidth + _spacing.x > width)
                {
                    height += rect.rect.height + _spacing.y;
                    sumWidth = _marginLeft;
                    var prev = castChildren[i - 1];
                    var prevRect = prev.GetComponent<RectTransform>();
                    var prevAnchoredPosition = prevRect.anchoredPosition;
                    prevAnchoredPosition.x = width - prevRect.rect.width - _marginRight;
                    prevRect.anchoredPosition = prevAnchoredPosition;
                }
                rect.anchorMin = Vector2.zero;
                rect.anchorMax = Vector2.zero;
                rect.anchoredPosition = new Vector2(sumWidth, height);
                sumWidth += childWidth + _spacing.x;
            }
            
            _layoutElement.minHeight = height + _childHeight + _marginTop;
        }
    }
}