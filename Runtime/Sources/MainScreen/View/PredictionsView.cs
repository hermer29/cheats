using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Hermer29.Cheats
{
    public class PredictionsView : MonoBehaviour
    {
        private CheatsView _cheatsView;
        
        [SerializeField] private Suggestion[] _suggestions;

        [Serializable]
        internal class Suggestion
        {
            public GameObject obj;
            public Text prediction;
            public Button execute;
            public Text paramsDescription;
        }

        public void Construct(CheatsView cheatsView)
        {
            _cheatsView = cheatsView;
        }

        private void Start()
        {
            DisableAll();
        }

        public void Show(IEnumerable<Match> predict)
        {
            if (predict.Any() == false)
                return;
            DisableAll();
            var predictions = predict.ToArray();
            var needToShowSubmit = false;
            for (var i = 0; i < predictions.Length && i < _suggestions.Length; i++)
            {
                var suggestionUi = _suggestions[i];
                var prediction = predictions[i];
                suggestionUi.obj.SetActive(true);
                suggestionUi.prediction.text =
                    $"<color=#9F9E9E>{prediction.Handler.GetCheatCode().Substring(0, prediction.EndPosition)}</color>" +
                    $"{prediction.Handler.GetCheatCode().Substring(prediction.EndPosition)}";
                suggestionUi.execute.onClick.AddListener(() =>
                {
                    if (prediction.Handler is IParametrizedCheatHandler parametrizedCheatHandler)
                    {
                        _cheatsView.SetField(parametrizedCheatHandler.GetCheatCode());
                        return;
                    }
                    prediction.Handler.Execute();
                });
                if (prediction.Handler is IParametrizedCheatHandler parametrized)
                {
                    needToShowSubmit = prediction.FullyDetected;
                    if (string.IsNullOrEmpty(parametrized.Description) || string.IsNullOrWhiteSpace(parametrized.Description))
                    {
                        suggestionUi.paramsDescription.text = "No desc";
                        continue;
                    }
                    suggestionUi.paramsDescription.text = parametrized.Description;
                    continue;
                }
                suggestionUi.paramsDescription.text = "No params";
            }
            _cheatsView.SetSubmitActive(needToShowSubmit);
        }

        private void DisableAll()
        {
            foreach (var element in _suggestions)
            {
                element.obj.SetActive(false);
                element.execute.onClick.RemoveAllListeners();
            }
        }
    }
}