﻿using UnityEngine;

public class SplineWalker : MonoBehaviour
{

    public BezierSpline spline;

    public float duration;
    public float numberPassed = 1;

    private float progress;

    public SplineWalkerMode mode;

    private bool goingForward = true;

    public bool lookForward = true;

    public bool followAtStart = false;
    private bool _following = false;

    private void Start()
    {
       
    }

    public void StartGame()
    {
        duration = spline.CurveCount;

        if (followAtStart)
            _following = true;
    }

    public void UpdateSpline()
    {
        duration = spline.CurveCount - numberPassed * 1.5f;
        progress = 0.0f;
    }

    private void Update()
    {
        if (_following)
        {
            if (goingForward)
            {
                progress += Time.deltaTime / duration;
                if (progress > 1f)
                {
                    if (mode == SplineWalkerMode.Once)
                    {
                        progress = 1f;
                    }
                    else if (mode == SplineWalkerMode.Loop)
                    {
                        progress -= 1f;
                    }
                    else
                    {
                        progress = 2f - progress;
                        goingForward = false;
                    }
                }
            }
            else
            {
                progress -= Time.deltaTime / duration;
                if (progress < 0f)
                {
                    progress = -progress;
                    goingForward = true;
                }
            }

            Vector3 position = spline.GetPoint(progress);
            transform.localPosition = position;
            if (lookForward)
            {
                transform.LookAt(position + spline.GetDirection(progress));
            }
        }
    }

    public void StartFollowing()
    {
        _following = true;
    }
}