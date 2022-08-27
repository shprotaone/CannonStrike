using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _failWindow;

    private void Awake()
    {
        AmmoSystem.OnAmmoIsOut += Fail;
        GoalSystem.OnComplete += Win;
    }

    public void Fail()
    {
        if (!_failWindow.activeInHierarchy)
        {
            _failWindow.SetActive(true);
        }
    }

    private void Win()
    {
        if (!_winWindow.activeInHierarchy)
        {
            _winWindow.SetActive(true);
        }      
    }

    private void OnDisable()
    {
        AmmoSystem.OnAmmoIsOut -= Fail;
        GoalSystem.OnComplete -= Win;
    }
}
