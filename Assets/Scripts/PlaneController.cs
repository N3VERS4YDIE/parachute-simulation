using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private Transform boxSpawnPoint;
    private Transform planeTransform;
    private CameraController cameraController;
    private UIController ui;

    [Header("Settings")]
    [SerializeField] private float boxAdditionalForce = 4;
    [SerializeField] private float boxDispersion = 15;
    [SerializeField] private float boxInstantiateCooldown = 0.15f;
    private float height => ui.Height;
    private float speed => ui.Speed * 0.5f / ui.MinSpeed;
    private float lastBoxDropTime;
    private const int MAX_BOXES = 100;

    private int droppedBoxes = 0;
    private readonly List<GameObject> boxes = new List<GameObject>();
    private float dispersion = 0;
    public string Dispersion => dispersion > 0 ? $"DI = {dispersion:0.00}m" : "";
    private Vector3 dispersionPosition = Vector3.zero;
    public Vector3 DispersionPosition => dispersionPosition;
    public string FrontPush => $"E = V * T\nE = {ui.Speed}kn * {5.97f}s\nE = {ui.Speed * 5.97f}m/s";

    private void Start()
    {
        planeTransform = transform.GetChild(0);
        cameraController = FindObjectOfType<CameraController>();
        ui = FindObjectOfType<UIController>();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, height, transform.position.z);   

        if (!cameraController.IsPlaneVisible)
        {
            droppedBoxes = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space) && Time.time - lastBoxDropTime > boxInstantiateCooldown)
        {
            DropBox();
            lastBoxDropTime = Time.time;
            droppedBoxes++;

            if (droppedBoxes >= 2)
            {
                var lastBox = boxes[boxes.Count - 1];
                var firstBox = boxes[boxes.Count - droppedBoxes];
                dispersion = Vector3.Distance(firstBox.transform.position, lastBox.transform.position) / 10;
                dispersionPosition = (firstBox.transform.position + lastBox.transform.position) / 2;
            } else {
                dispersion = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - speed, transform.rotation.eulerAngles.z);
    }

    private void DropBox()
    {
        var box = AddBox();
        var boxRb = box.GetComponent<Rigidbody>();
        boxRb.AddForce(planeTransform.forward * speed * boxAdditionalForce, ForceMode.Impulse);
    }

    private GameObject AddBox()
    {
        if (boxes.Count >= MAX_BOXES)
        {
            Destroy(boxes[0]);
            boxes.RemoveAt(0);
        }

        var box = Instantiate(boxPrefab, boxSpawnPoint.position + planeTransform.right * Random.Range(-boxDispersion, boxDispersion), Quaternion.identity);
        boxes.Add(box);
        return box;
    }
}
