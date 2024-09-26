using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    public int MaxWealth { get; } = 140; //TODO:rename
    private readonly int WEALTH_ANIMATION_ID = Animator.StringToHash("Wealth");
    private readonly int DANCE_ANIMATION_ID = Animator.StringToHash("Dance");
    private readonly int StartWalk_ANIMATION_ID = Animator.StringToHash("StartWalk");

    [SerializeField] private GameObject _poorModel;
    [SerializeField] private GameObject _casualModel;
    [SerializeField] private GameObject _middleModel;
    [SerializeField] private GameObject _buisinessModel;
    [SerializeField] private GameObject _blingModel;
    [SerializeField] private GameObject _DeathUI;
    [SerializeField] private SplineFollower _splineFollow;
    [SerializeField] private SwipeMovement _swipeMovement;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private UnityEvent _OnLose;
    [SerializeField] private WealthChecker _wealthChecker;

    public PlayerState CurrentState { get; private set; }


    private void Start()
    {
        SetState(PlayerState.Idle);
    }

    public void OnFirstTouch() 
    {
        SetState(PlayerState.Casual);
        this._playerAnimator.SetTrigger(StartWalk_ANIMATION_ID);
        UpdateState();
    }

    public void ModifyWealth(int amount)
    {
        _wealthChecker.AddMoney(amount, MaxWealth, CurrentState);
        UpdateState();
    }


    private void UpdateState()
    {
        if (_wealthChecker.Wealth <= 0 && CurrentState != PlayerState.Death)
        {
            SetState(PlayerState.Death);
        }
        if (_wealthChecker.Wealth <= 15 && CurrentState != PlayerState.Poor)
        {
            SetState(PlayerState.Poor);
        }
        else if (_wealthChecker.Wealth > 15 && _wealthChecker.Wealth <= 59 && CurrentState != PlayerState.Casual)
        {
            SetState(PlayerState.Casual);
        }
        else if (_wealthChecker.Wealth >= 60 && _wealthChecker.Wealth <= 99 && CurrentState != PlayerState.Middle)
        {
            SetState(PlayerState.Middle);
        }
        else if (_wealthChecker.Wealth >= 100 && _wealthChecker.Wealth <= 139 && CurrentState != PlayerState.Buisiness)
        {
            SetState(PlayerState.Buisiness);
        }
        else if (_wealthChecker.Wealth >= MaxWealth && CurrentState != PlayerState.Bling)
        {
            SetState(PlayerState.Bling);
        }

        _playerAnimator.SetFloat(WEALTH_ANIMATION_ID, _wealthChecker.Wealth);
    }


    public void SetState(PlayerState newState)
    {
        CurrentState = newState;

        _poorModel.SetActive(false);
        _casualModel.SetActive(false);
        _middleModel.SetActive(false);
        _buisinessModel.SetActive(false);
        _blingModel.SetActive(false);

        switch (CurrentState)
        {
            case PlayerState.Death:
                _splineFollow.enabled = false;
                _swipeMovement.enabled = false;
                _DeathUI.SetActive(true);
                _OnLose?.Invoke();
                break;

            case PlayerState.Idle:
                _splineFollow.enabled = false;
                _swipeMovement.enabled = false;
                _casualModel.SetActive(true);
                break;

            case PlayerState.Poor:
                _poorModel.SetActive(true);
                break;

            case PlayerState.Casual:
                _splineFollow.enabled = true;
                _swipeMovement.enabled = true;
                _casualModel.SetActive(true);
                break;

            case PlayerState.Middle:
                _middleModel.SetActive(true);
                break;

            case PlayerState.Buisiness:
                _buisinessModel.SetActive(true);
                break;

            case PlayerState.Bling:
                _blingModel.SetActive(true);
                break;

            case PlayerState.EndLevel:
                _splineFollow.enabled = false;
                _swipeMovement.enabled = false;
                _blingModel.SetActive(true);
                _playerAnimator.SetTrigger(DANCE_ANIMATION_ID);
                break;
        }
    }
}

