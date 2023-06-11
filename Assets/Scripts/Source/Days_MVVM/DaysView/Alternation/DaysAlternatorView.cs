using Days.ViewModel.Alternation;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Days.View.Alternation
{
    public class DaysAlternatorView : MonoBehaviour
    {
        [SerializeField] private Button _startDayButton;

        private IDaysAlternatorViewModel _viewModel;

        [Inject]
        private void Construct(IDaysAlternatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private void OnEnable()
        {
            _startDayButton.onClick.AddListener(OnStartDayButtonClicked);
        }

        private void OnDisable()
        {
            _startDayButton.onClick.RemoveListener(OnStartDayButtonClicked);
        }

        private void OnStartDayButtonClicked()
        {
            _viewModel.StartNextDay();
        }
    }
}