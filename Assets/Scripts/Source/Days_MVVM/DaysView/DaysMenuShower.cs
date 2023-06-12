using Clients.Adapter.DailyCounting;
using UnityEngine;
using Zenject;

public class DaysMenuShower : MonoBehaviour
{
    [SerializeField] private GameObject _daysMenu;

    private IReadonlyClientsDailyCounter _counter;

    [Inject]
    private void Construct(IReadonlyClientsDailyCounter counter)
    {
        _counter = counter;
    }

    private void OnEnable()
    {
        _counter.AllClientsServed += OnAllClientsServed;
    }

    private void OnDisable()
    {
        _counter.AllClientsServed -= OnAllClientsServed;
    }

    private void OnAllClientsServed()
    {
        _daysMenu.SetActive(true);
    }
}
