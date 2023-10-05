using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDetection : MonoBehaviour
{
    public Light spotlight; // Reference to the spotlight
    private List<GameObject> targets; // List of potential target GameObjects

    void Start()
    {
        // Find all GameObjects with the "Illuminable" tag
        targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Illuminable"));
    }

    void Update()
    {
        // Check each target to see if it's illuminated
        foreach (var target in targets)
        {
            CheckIfIlluminated(target);
        }
    }

    void CheckIfIlluminated(GameObject target)
    {
        // Get direction from spotlight to target
        Vector3 directionToTarget = target.transform.position - spotlight.transform.position;

        // Check if target is within spotlight's range and angle
        if (Vector3.Distance(spotlight.transform.position, target.transform.position) < spotlight.range &&
            Vector3.Angle(spotlight.transform.forward, directionToTarget) < spotlight.spotAngle / 2)
        {
            // Cast a ray from spotlight to target
            RaycastHit hit;
            if (Physics.Raycast(spotlight.transform.position, directionToTarget, out hit, spotlight.range))
            {
                // Check if the ray hits the target directly without any obstacle
                if (hit.collider.gameObject == target)
                {
                    Debug.Log(target.name + " is illuminated!");
                    target.GetComponent<SendMsgWhenActivated>().SendMessage();
                }
                else
                {
                    Debug.Log(target.name + " is NOT illuminated (obstructed)!");
                }
            }
            else
            {
                Debug.Log(target.name + " is NOT illuminated (out of range or angle)!");
            }
        }
        else
        {
            Debug.Log(target.name + " is NOT illuminated (out of range or angle)!");
        }
    }
}
