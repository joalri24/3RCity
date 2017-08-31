using UnityEngine;

/// <summary>
/// Handles logic related to camera panning. Moves camera along its local X and Z axes.
/// </summary>
public class MoveCamera : MonoBehaviour
{
    [Header("Movement Settings")]

    [Tooltip("Camera will move if mouse is closer than this percent of the screen width to the left/right")]
    [Range(0.0f, 1.0f)]
    public float WidthPercentageSideThreshold = 0.1f;

    [Tooltip("Camera will move if mouse is closer than this percent of screen height to the top/bottom")]
    [Range(0.0f, 1.0f)]
    public float HeightPercentageTopThreshold = 0.1f;

    [Tooltip("When screen is too small, camera will move if mouse is closer than this to the left/right")]
    public float MinSideThreshold = 15f;

    [Tooltip("When screen is too small, camera will move if mouse is closer than this to the top/bottom")]
    public float MinTopThreshold = 15f;

    public float MovementSpeed = 20f;


    [Header("Limit Settings")]

    [Range(0.0f, 1000000f)]
    [Tooltip("Camera won't move in its local +X more than this")]
    public float MaxRightTranslation;

    [Range(-1000000f, 0.0f)]
    [Tooltip("Camera won't move in its local -X more than this")]
    public float MaxLeftTranslation;

    [Range(0.0f, 1000000f)]
    [Tooltip("Camera won't move in its local +Z more than this")]
    public float MaxForwardTranslation;

    [Range(-1000000f, 0.0f)]
    [Tooltip("Camera won't move in its local -Z more than this")]
    public float MaxBackwardTranslation;

    float XTranslationFromStartingPosition = 0f;
    float ZTranslationFromStartingPosition = 0f;

    Vector3 translateAmount;
    float currentSideThreshold;
    float currentTopThreshold;
    int directionX = 0;
    int directionZ = 0;

    void Start()
    {
        translateAmount = Vector3.zero;
        float sideThresholdPercent = WidthPercentageSideThreshold * Screen.width;
        currentSideThreshold = Mathf.Max(MinSideThreshold, sideThresholdPercent);

        float topThresholdPercent = HeightPercentageTopThreshold * Screen.height;
        currentTopThreshold = Mathf.Max(MinTopThreshold, topThresholdPercent);
    }

    void Update()
    {
        directionX = 0;
        directionZ = 0;
        if (IsMouseInsideViewport())
        {
            ManageCameraPanning();
        }
    }

    void ManageCameraPanning()
    {
        CheckPanningDirection();
        translateAmount.x = MovementSpeed * Time.deltaTime * directionX;
        translateAmount.z = MovementSpeed * Time.deltaTime * directionZ;
        KeepTranslationInLimits();
        transform.Translate(translateAmount);
        XTranslationFromStartingPosition += translateAmount.x;
        ZTranslationFromStartingPosition += translateAmount.z;
    }

    bool IsMouseInsideViewport()
    {
        //Input.mousePosition is (0,0) in viewport's bottom left corner and 
        //(Screen.width, Screen.height) in its top right corner
        return
            Input.mousePosition.x >= 0f && Input.mousePosition.y >= 0f
            && Input.mousePosition.x <= Screen.width && Input.mousePosition.y <= Screen.height;
    }

    void CheckPanningDirection()
    {
        if (Input.mousePosition.x < currentSideThreshold)
        {
            directionX = -1;
        }
        else if (Input.mousePosition.x > Screen.width - currentSideThreshold)
        {
            directionX = 1;
        }
        if (Input.mousePosition.y < currentTopThreshold)
        {
            directionZ = -1;
        }
        else if (Input.mousePosition.y > Screen.height - currentTopThreshold)
        {
            directionZ = 1;
        }
    }

    void KeepTranslationInLimits()
    {
        //if moving more to the left than MaxLeftTranslation
        if (XTranslationFromStartingPosition + translateAmount.x < MaxLeftTranslation)
        {
            //move up to MaxLeftTranslation
            translateAmount.x = MaxLeftTranslation - XTranslationFromStartingPosition;
        }
        //if moving more to the right than MaxRightTranslation
        else if (XTranslationFromStartingPosition + translateAmount.x > MaxRightTranslation)
        {
            //move up to MaxRightTranslation
            translateAmount.x = MaxRightTranslation - XTranslationFromStartingPosition;
        }
        if (ZTranslationFromStartingPosition + translateAmount.z < MaxBackwardTranslation)
        {
            translateAmount.z = MaxBackwardTranslation - ZTranslationFromStartingPosition;
        }
        else if (ZTranslationFromStartingPosition + translateAmount.z > MaxForwardTranslation)
        {
            translateAmount.z = MaxForwardTranslation - ZTranslationFromStartingPosition;
        }
    }
}