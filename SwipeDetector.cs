using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{

    //---------------------------------------------------
    [SerializeField]
    Transform Camera;
    [SerializeField]
    GameObject SliderGOz;
    [SerializeField]
    float rotateDivisorCoeficient = 4f;
    //---------------------------------------------------

    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private bool detectSwipeOnlyAfterRelease = false;

    [SerializeField]
    private float minDistanceForSwipe = 20f;

    public static event Action<SwipeData> OnSwipe = delegate { };


    bool incrementingSpeed = false;
    bool rotatinP = false;
    int timesProcessingRotation = 0;
    int equationTime = 0;
    bool negativeSignal = false;

    bool canSlide = false;
    float speed = 10;

    void resetRotation()
    {
        incrementingSpeed = false; rotatinP = false;
        timesProcessingRotation = 0;
        equationTime = 0;
    }


    /*
    private void OnMouseDown()
    {
        if (slider)
        {
            SliderGOz.gameObject.SetActive(false);
            slider = false;

            zerarRotation();
        }
        else if(!slider || canOpenSlider)
        {
            SliderGOz.gameObject.SetActive(true);
            slider = true;
        }
    }
    */

    private void OnMouseDrag()
    {
        canSlide = true;
    }
    private void OnMouseUp()
    {
        canSlide = false;
        //resetRotation();
    }


    private void FixedUpdate()
    {

        this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed * SliderGOz.GetComponent<Slider>().value);



        if (timesProcessingRotation >= equationTime)
        {
            resetRotation();
        }
        if (rotatinP)
        {
            if(timesProcessingRotation < equationTime && canSlide)
            {
                if (negativeSignal)
                {
                    this.gameObject.transform.Rotate(0, -1f, 0);
                    timesProcessingRotation++; canSlide = false;
                }
                else
                {
                    this.gameObject.transform.Rotate(0, 1f, 0);
                    timesProcessingRotation++; canSlide = false;
                }
            }
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
                
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                var direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }
            fingerUpPosition = fingerDownPosition;
        }
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = fingerDownPosition,
            EndPosition = fingerUpPosition
        };
        if(direction== SwipeDirection.Up || direction == SwipeDirection.Down)//vertical
        {
            if (direction == SwipeDirection.Up)
            {
                //RotateC(VerticalMovementDistance()*-1);
                sliderSpdInc(true);
                GameObject.Find("Text").GetComponent<Text>().text = VerticalMovementDistance().ToString();
            }
            else if (direction == SwipeDirection.Down)
            {
                //RotateC(VerticalMovementDistance());
                sliderSpdInc(false);
                GameObject.Find("Text").GetComponent<Text>().text = VerticalMovementDistance().ToString();
            }
            
            
        }
        else//horizontal
        {
            if (direction == SwipeDirection.Left)
            {
                RotateP(HorizontalMovementDistance() * -1);
            }
            else if (direction == SwipeDirection.Right)
            {
                RotateP(HorizontalMovementDistance());
            }
        }
        OnSwipe(swipeData);
    }
    void sliderSpdInc(bool isSignalNegative2)
    {
        negativeSignal = isSignalNegative2;
        if (isSignalNegative2)
        {
            if (canSlide)
            { SliderGOz.GetComponent<Slider>().value += (VerticalMovementDistance() / 4.7f); }
        }
        else
        {
            if (canSlide)
            { SliderGOz.GetComponent<Slider>().value -= (VerticalMovementDistance() / 4.7f); }

        }
    }
    private void RotateP(float value)
    {
        if (value > 0)
        {
            negativeSignal = false;
        }
        else
        {
            negativeSignal = true;
        }
        float value2 = Math.Abs(value);
        equationTime = (int)(value2 / rotateDivisorCoeficient);
        
        rotatinP = true;
    }
    private void RotateC(float value)
    {
        if (value > 0)
        {
            negativeSignal = false;
        }
        else
        {
            negativeSignal = true;
        }
        float value2 = Math.Abs(value);
        equationTime = (int)(value2 / rotateDivisorCoeficient);

        incrementingSpeed = true;
    }
}

public struct SwipeData
{
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public SwipeDirection Direction;
}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}