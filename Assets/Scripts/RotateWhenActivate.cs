using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWhenActivate : MonoBehaviour
{
    [SerializeField]
    int activationNr = -1;
    [SerializeField]
    float maxAngle = 90.0f;
    [SerializeField]
    bool neverStayOpen = false;

    [SerializeField]
    bool rotateX = false;
    [SerializeField]
    bool rotateY = true;
    [SerializeField]
    bool rotateZ = false;

    bool isRotating = false;
    bool completeRotation = false;
    Vector3 initAngle;
    Quaternion targetRotation;
    Subscription<ActivateEvent> activate_event_subscription;

    [SerializeField]
    float activationTimeout = 0.1f;
    float lastActivationTime;

    void Start()
    {
        activate_event_subscription = EventBus.Subscribe<ActivateEvent>(OnActivate);
        targetRotation = this.transform.rotation;
        initAngle = this.transform.eulerAngles;

        lastActivationTime = -activationTimeout;
    }

    void Update()
    {
        if (completeRotation) { return; }

        if (Time.time - lastActivationTime > activationTimeout)
        {
            // Stop rotating if the timeout period has elapsed since the last activation
            isRotating = false;
        }

        bool reachMax = false;

        if (rotateY)
            reachMax = Mathf.Abs(transform.eulerAngles.y - initAngle.y) >= maxAngle;
        if (rotateZ)
            reachMax = Mathf.Abs(transform.eulerAngles.z - initAngle.z) >= maxAngle;
        if (rotateX)
            reachMax = Mathf.Abs(transform.eulerAngles.x - initAngle.x) >= maxAngle;

        if (reachMax && !neverStayOpen)
        {
            completeRotation = true;
            EventBus.Publish<CompleteRotationEvent>(new CompleteRotationEvent());
        }

        if (!reachMax && isRotating)
        {
            if (rotateY)
                transform.Rotate(new Vector3(0, 80 * Time.deltaTime, 0));
            if (rotateZ)
                transform.Rotate(new Vector3(0, 0, 80 * Time.deltaTime));
            if (rotateX)
                transform.Rotate(new Vector3(80 * Time.deltaTime, 0, 0));
        }

        if (!isRotating)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f);
        }
    }

    void OnActivate(ActivateEvent ae)
    {
        if (completeRotation) { return; }

        if (ae.cubeNr == activationNr)
            if (ae.activate == true)
            {
                isRotating = true;
                lastActivationTime = Time.time;
            }
            else
                isRotating = false;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(activate_event_subscription);
    }
}

public class CompleteRotationEvent
{
    public CompleteRotationEvent() { }
}
