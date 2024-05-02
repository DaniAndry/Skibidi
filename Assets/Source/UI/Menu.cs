using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _recordDistanceText;

    private float _recordDistance;
    private MenuWindow _menuWindow;

    public event Action ClickingStart;

    private void Awake()
    {
        _menuWindow = GetComponent<MenuWindow>();       
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnClickStart);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnClickStart);
    }

    public void SetDistance(float distance)
    {
        if(distance > _recordDistance)
        {
            _recordDistance = distance;
            _recordDistanceText.text = $"{Convert.ToInt32(_recordDistance)}";
            TaskCounter.IncereaseProgress(Convert.ToInt32(_recordDistance), TaskType.RecordDistance.ToString());
        }
    }

    private void OnClickStart()
    {
        ClickingStart?.Invoke();
        _menuWindow.Close();
    }
}
