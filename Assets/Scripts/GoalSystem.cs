using UnityEngine;
using TMPro;
using System;

public class GoalSystem : MonoBehaviour
{
    public static Action OnComplete;

    [SerializeField] private TMP_Text _completeText;

    private float _goalTarget = 20;
    private float _goalCount;

    public void IncreaseGoal()
    {
        _goalCount++;
        UpdateView();

        if (_goalCount >= _goalTarget)
        {
            OnComplete?.Invoke();
        }
    }

    private void ResetGoal()
    {
        _goalCount = _goalTarget;
        UpdateView();
    }

    private void UpdateView()
    {
        _completeText.text = _goalCount.ToString() + "/20";
    }
}
