﻿using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _vfxSource;
    [SerializeField] private AudioSource _footStepSource;
    [SerializeField] private AudioClip[] _stepsClips;
    [SerializeField] private float _pitchMin,_pitchMax;
    [SerializeField] private float _delayBetweenSteps;
    [SerializeField] private AudioClip _onRedCharacterVFX;
    [SerializeField] private AudioClip _onMoneyVFX;
    [SerializeField] private AudioClip _onBeerVFX;
    [SerializeField] private AudioClip _onVictoryVFX;
    [SerializeField] private AudioClip _onLoseVFX;
    [SerializeField] private Player _player;
    private float _currentDelayBetweenSteps;
    private int _currentStepIndex;




    public void OnCollectItem(Collectible collectible)
    {
        print($"Collectable type {collectible}");
        if (collectible is Beer) _vfxSource.PlayOneShot(_onBeerVFX);
        else if (collectible is Money) _vfxSource.PlayOneShot(_onMoneyVFX);
        else if (collectible is RedCharacter) _vfxSource.PlayOneShot(_onRedCharacterVFX);
    }


    public void OnVictory()
    {
        _vfxSource.PlayOneShot(_onVictoryVFX);
    }

    public void OnLose()
    {
        _vfxSource.PlayOneShot(_onLoseVFX);
    }


    private void Update()
    {
        if (_player.CurrentState == PlayerState.Death) return;

        _currentDelayBetweenSteps += Time.deltaTime;

        if (_currentDelayBetweenSteps >= _delayBetweenSteps)
        {
            _footStepSource.pitch = Random.Range(_pitchMin,_pitchMax);
            _footStepSource.PlayOneShot(_stepsClips[_currentStepIndex]);
            _currentStepIndex = _currentStepIndex + 1 == _stepsClips.Length ? 0 : _currentStepIndex + 1;
            _currentDelayBetweenSteps = 0;
        }
    }
}
