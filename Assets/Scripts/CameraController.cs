using System;
using System.ComponentModel;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform planeController;
    private Quaternion initialRotation;


    [Header("Settings")]
    [SerializeField]
    private float minXRotation = 0;

    [SerializeField]
    [ReadOnly(true)]
    private bool isPlaneVisible = false;
    public bool IsPlaneVisible => isPlaneVisible;

    void Start()
    {
        planeController = FindObjectOfType<PlaneController>().transform.GetChild(0);
        initialRotation = transform.rotation;
    }

    void Update()
    {
        Vector3 planePosition = planeController.transform.position;
        isPlaneVisible = planePosition.x - 40 < transform.position.x;

        Quaternion rotationToPlane = Quaternion.LookRotation(planePosition - transform.position);
        rotationToPlane.x = Mathf.Clamp(rotationToPlane.x, minXRotation, float.MaxValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, isPlaneVisible ? rotationToPlane : initialRotation, Time.deltaTime * 0.8f);
    }
}
