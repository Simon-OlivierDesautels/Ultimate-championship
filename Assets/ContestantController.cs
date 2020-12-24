using System;
using System.Collections;
using System.Collections.Generic;
using _project.Scripts;
using UnityEngine;

public class ContestantController : MonoBehaviour
{
    private Contestant _player;
    private InputReader _inputReader;

    public void Constructor(Contestant contestant, InputReader inputReader)
    {
        _player = contestant;
        _inputReader = inputReader;
    }


    #region -Smash-

    IEnumerator ChargingSmash()
    {
        _player.CurrentPower = SmashPower.Weak;

        yield return new WaitForSeconds(1f);
        _player.CurrentPower = SmashPower.Medium;

        yield return new WaitForSeconds(2f);
        _player.CurrentPower = SmashPower.Strong;
    }

    private void ReleaseSmash(SmashDirection direction)
    {
        StopCoroutine("ChargingSmash");
        switch (direction)
        {
            case SmashDirection.North:
                _player.Smash(direction);
                break;
            case SmashDirection.South:
                _player.Smash(direction);
                break;
        }
    }

    #endregion

    #region -OnMethods-

    private void OnMove(float axis)
    {
        Debug.Log(axis);
    }

    private void OnFireHeld()
    {
        StartCoroutine("ChargingSmash");
    }

    private void OnFireCanceled(SmashDirection direction)
    {
        ReleaseSmash(direction);
    }

    #endregion

    #region -Enable/disable-

    private void Start()
    {
        _inputReader.MoveEvent += OnMove;
        _inputReader.FireNorthEventCanceled += OnFireCanceled;
        _inputReader.FireSouthEventCanceled += OnFireCanceled;
        _inputReader.FireEventHeld += OnFireHeld;
    }

    private void OnDisable()
    {
        _inputReader.MoveEvent -= OnMove;
        _inputReader.FireNorthEventCanceled -= OnFireCanceled;
        _inputReader.FireSouthEventCanceled -= OnFireCanceled;
        _inputReader.FireEventHeld -= OnFireHeld;
    }

    #endregion
}