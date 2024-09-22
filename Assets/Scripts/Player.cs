using Dreamteck.Splines;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private int _initialWealth = 40;               
    [SerializeField] private GameObject _poorModel;                 
    [SerializeField] private GameObject _casualModel;             
    [SerializeField] private GameObject _middleModel;             
    [SerializeField] private GameObject _buisinessModel;          
    [SerializeField] private GameObject _blingModel;             
    [SerializeField] private SplineFollower _splineFollow;             
    [SerializeField] private SwipeMovement _swipeMovement;             

    [SerializeField] private int _wealth;                          
    private PlayerState _currentState;            


    private void Start()
    {
        _wealth = _initialWealth;                 
        _currentState = PlayerState.Casual;      
        SetState(_currentState);                  
    }


    public void ModifyWealth(int amount)
    {
        _wealth += amount;
        UpdateState();
    }


    private void UpdateState()
    {
        if(_wealth <= 0 && _currentState != PlayerState.Death) 
        {
            SetState(PlayerState.Death);
        }
        if (_wealth <= 15 && _currentState != PlayerState.Poor)
        {
            SetState(PlayerState.Poor);
        }
        else if (_wealth > 15 && _wealth <= 59 && _currentState != PlayerState.Casual)
        {
            SetState(PlayerState.Casual);
        }
        else if (_wealth >= 60 && _wealth <= 99 && _currentState != PlayerState.Middle)
        {
            SetState(PlayerState.Middle);
        }
        else if (_wealth >= 100 && _wealth <= 139 && _currentState != PlayerState.Buisiness)
        {
            SetState(PlayerState.Buisiness);
        }
        else if (_wealth >= 140 && _currentState != PlayerState.Bling)
        {
            SetState(PlayerState.Bling);
        }
    }


    private void SetState(PlayerState newState)
    {
        _currentState = newState;

        _poorModel.SetActive(false);
        _casualModel.SetActive(false);
        _middleModel.SetActive(false);
        _buisinessModel.SetActive(false);
        _blingModel.SetActive(false);

        switch (_currentState)
        {
            case PlayerState.Death:
                Debug.Log("УМЕР!");
                _splineFollow.enabled = false;
                _swipeMovement.enabled = false;
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
        }
    }
}
