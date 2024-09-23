using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    private readonly int WEALTH_ANIMATION_ID = Animator.StringToHash("Wealth");
    private readonly int DANCE_ANIMATION_ID = Animator.StringToHash("Dance");

    [SerializeField] private int _initialWealth = 40;
    [SerializeField] private GameObject _poorModel;
    [SerializeField] private GameObject _casualModel;
    [SerializeField] private GameObject _middleModel;
    [SerializeField] private GameObject _buisinessModel;
    [SerializeField] private GameObject _blingModel;
    [SerializeField] private SplineFollower _splineFollow;
    [SerializeField] private SwipeMovement _swipeMovement;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private UnityEvent _OnLose;


    [SerializeField] private int _wealth;


    public UnityAction<int> OnWealthChanged;

    public PlayerState CurrentState { get; private set; }


    private void Start()
    {
        _wealth = _initialWealth;
        CurrentState = PlayerState.Casual;
        SetState(CurrentState);

        _playerAnimator.SetFloat(WEALTH_ANIMATION_ID, _wealth);

        OnWealthChanged?.Invoke(_wealth);
    }


    public void ModifyWealth(int amount)
    {
        _wealth += amount; 
        UpdateState();
        OnWealthChanged?.Invoke(_wealth);
    }


    private void UpdateState()
    {
        if (_wealth <= 0 && CurrentState != PlayerState.Death)
        {
            SetState(PlayerState.Death);
        }
        if (_wealth <= 15 && CurrentState != PlayerState.Poor)
        {
            SetState(PlayerState.Poor);
        }
        else if (_wealth > 15 && _wealth <= 59 && CurrentState != PlayerState.Casual)
        {
            SetState(PlayerState.Casual);
        }
        else if (_wealth >= 60 && _wealth <= 99 && CurrentState != PlayerState.Middle)
        {
            SetState(PlayerState.Middle);
        }
        else if (_wealth >= 100 && _wealth <= 139 && CurrentState != PlayerState.Buisiness)
        {
            SetState(PlayerState.Buisiness);
        }
        else if (_wealth >= 140 && CurrentState != PlayerState.Bling)
        {
            SetState(PlayerState.Bling);
        }

        _playerAnimator.SetFloat(WEALTH_ANIMATION_ID, _wealth);
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
                Debug.Log("УМЕР!");
                _splineFollow.enabled = false;
                _swipeMovement.enabled = false;
                _OnLose?.Invoke();
                break;

            case PlayerState.Poor:
                _poorModel.SetActive(true);
                break;

            case PlayerState.Casual:
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
