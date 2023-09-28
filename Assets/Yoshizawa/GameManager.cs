using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
using CartoonFX;

public class GameManager : MonoBehaviour
{
    //====Public====
    public static GameManager Instance => _instance;
    public bool IsComplete { get => _isComplete; set => _isComplete = value; }
    public bool IsGameStart { get; private set; } = false;
    public bool IsVehicleDeparture { get; set; } = false;
    public bool IsVehicleArrival { get; set; } = false;

    //====SerializeField====
    [SerializeField] private float _timeLimit = 10f;
    [SerializeField] private Text _timeText = null;
    [SerializeField] private float _displayTime = 3f;
    [SerializeField] private CinemachineVirtualCamera _truckFollowCamera = null;
    [SerializeField] private string _resultSceneName = null;
    [SerializeField] private GameObject _levelImage = null;
    [SerializeField] private GameObject _playUI = null;
    [SerializeField] private GameObject _truckUI = null;
    [SerializeField] private SoundManager soundManagerScript;
 
    //====Private====
    private static GameManager _instance = null;
    private bool _isComplete = false;
    private bool _isGameStart = false;

    private void Awake()
    {
        if(!_instance) _instance = this;
        else Destroy(this);

        IsGameStart = true;
    }

    private void Start()
    {
        if (!_truckFollowCamera) Debug.LogWarning("トラックを追跡するカメラがassignされていません");
        if (_levelImage) _levelImage.SetActive(false);
        if (!_playUI) Debug.LogWarning("ゲームプレイ中のUIがassignされていません");
        if (!_truckUI) Debug.LogWarning("トラック走行中のUIがassignされていません");
        if (_timeText) _timeText.text = $"{_timeLimit}";

        StartCoroutine(GameFlow());
        soundManagerScript.Play(1);
    }

    private void Update()
    {
        TimeCount(Time.deltaTime);
    }

    private void TimeCount(float timeValue)
    {
        if (_isComplete || !_isGameStart) return;

        _timeLimit = Mathf.Clamp(_timeLimit - timeValue, 0f, _timeLimit);

        if (_timeText) _timeText.text = $"{_timeLimit.ToString("F2")}";
        if (_timeLimit == 0f) _isComplete = true;
    }

    private IEnumerator GameFlow()
    {
        Init();
        yield return new WaitForSeconds(_displayTime);
        if (_levelImage) _levelImage.SetActive(false);
        _isGameStart = true;
        yield return new WaitUntil(() => _isComplete == true);
        VehicleMovementPhase();
        yield return new WaitUntil(() => IsVehicleArrival == true);
        VehicleArrival();
    }

    private void Init()
    {
        if (_levelImage) _levelImage.SetActive(true);
        if (_playUI) _playUI.gameObject.SetActive(true);
        if (_truckUI) _truckUI.gameObject.SetActive(false);

    }

    private void VehicleMovementPhase()
    {
        Debug.Log("スクランブル発進！");
        soundManagerScript.Play(2);
        soundManagerScript.Play(5);
        IsVehicleDeparture = true;
        
        if (_truckFollowCamera) _truckFollowCamera.Priority = 100;
        if (_playUI) _playUI.gameObject.SetActive(false);
        if (_truckUI) _truckUI.gameObject.SetActive(true);
    }

    private void VehicleArrival()
    {
        Debug.Log("到着！");
        Score.ScoreCalculation();
        SceneManager.LoadScene(_resultSceneName);
    }
}
