using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

[Serializable]
public class cooldown 
{
    public enum Progress
    {
        Ready,
        Started,
        InProgress,
        Finished
    }
    public Progress CurrentProgress = Progress.Ready;
    public float TimeLeft
    {
        get { return _currentduration; }
    }

    public float isoncooldown
    {
        get { return isoncooldown; }
    }

    public float Duration = 1.0f;
    public float _currentduration = 0f;

    private bool _inoncooldown = false;

    private Coroutine _coroutine;

    public void StartCooldown()
    {
        if (CurrentProgress is Progress.Started or Progress.InProgress)
        {
            return;
        }
        _coroutine = coroutinehost.Instance.StartCoroutine(DoCooldown());
    }
    public void StopCooldown()
    {
        if ( _coroutine != null)
        {
            coroutinehost.Instance.StopCoroutine(_coroutine);

            _currentduration = 0f;
            _inoncooldown = false;
            CurrentProgress = Progress.Ready;
        }
    }

    IEnumerator DoCooldown()
    {
        CurrentProgress = Progress.Started;
        _currentduration = Duration;
        _inoncooldown = true;

        while (_currentduration > 0f)
        {
            _currentduration -= Time.deltaTime;
            CurrentProgress = Progress.InProgress;

            yield return null;
        }

        _currentduration = 0f;
        _inoncooldown = false;

        CurrentProgress = Progress.Finished;
    }
}
