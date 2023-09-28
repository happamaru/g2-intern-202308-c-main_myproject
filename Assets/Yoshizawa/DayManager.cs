using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    //=====Public=====
    public bool IsGoNextDay { get; set; } = false;

    //=====SerializeField=====
    [SerializeField] private int _playDayCount = 1;
    [SerializeField] private string _inGameSceneName = null;
    [SerializeField] private string _resultSceneName = null;
    [SerializeField] private string _rankingSceneName = null;
    [SerializeField] private string _nextDayText = null;
    [SerializeField] private string _goToRankingText = null;

    //=====Private=====
    private static DayManager _instance = null;
    private int _dayCount = 0;
    private string _currentSceneName = null;
    private Text _resultButtonText = null;

    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        _dayCount = _playDayCount;
    }

    private void Update()
    {
        if (IsGoNextDay)
        {
            IsGoNextDay = false;
            string sceneName = null;

            switch (_dayCount)
            {
                case 0:
                    sceneName = _rankingSceneName;
                    _dayCount = _playDayCount;
                    break;
                default:
                    sceneName = _inGameSceneName;
                    break;
            }
            SceneManager.LoadScene(sceneName);
        }

        if (_currentSceneName == SceneManager.GetActiveScene().name) return;

        GameObject buttonObj = GameObject.FindGameObjectWithTag("Button");

        if (buttonObj)
        {
            if (buttonObj.TryGetComponent(out Button button))
            {
                button.onClick.AddListener(() => { IsGoNextDay = true; Debug.Log("check"); });
            }
            _resultButtonText = buttonObj.GetComponentInChildren<Text>();
        }
        _currentSceneName = SceneManager.GetActiveScene().name;

        if (_currentSceneName == _resultSceneName)
        {
            _dayCount--;
            Debug.Log($"DayCount = {_dayCount}");
        }

        if (_resultButtonText)
        {
            if (_dayCount <= 0) _resultButtonText.text = _goToRankingText;
            else _resultButtonText.text = _nextDayText;
        }
    }
}
