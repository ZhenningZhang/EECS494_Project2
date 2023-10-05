using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public Transform weapon;
    public float defaultDistance = 10f; // Set this to your desired default distance

    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPosition;
        if (Physics.Raycast(ray, out hit))
        {
            // If the ray hits something, use that point as the target
            targetPosition = hit.point;
        }
        else
        {
            // If the ray doesn't hit anything, use a point at defaultDistance from the camera
            targetPosition = ray.GetPoint(defaultDistance);
        }

        // Calculate and apply the rotation as before
        Vector3 directionToTarget = targetPosition - weapon.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        weapon.rotation = Quaternion.Slerp(weapon.rotation, targetRotation, Time.deltaTime * 5.0f);
    }
}
