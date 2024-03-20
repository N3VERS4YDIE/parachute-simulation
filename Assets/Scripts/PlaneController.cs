using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject boxPrefab;
    private Transform planeTransform;
    private CameraController cameraController;

    [SerializeField]
    private Transform boxSpawnPoint;


    [Header("Settings")]
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float boxAdditionalForce = 4;
    [SerializeField]
    private float boxDispersion = 15;
    [SerializeField]
    private float boxInstantiateCooldown = 0.15f;


    private float lastBoxDropTime;
    private readonly Queue<GameObject> boxes = new Queue<GameObject>();
    private const int MAX_BOXES = 100;

    private void Start()
    {
        planeTransform = transform.GetChild(0);
        cameraController = FindObjectOfType<CameraController>();
    }

    private void Update()
    {
        if (!cameraController.IsPlaneVisible)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space) && Time.time - lastBoxDropTime > boxInstantiateCooldown)
        {
            DropBox();
            lastBoxDropTime = Time.time;
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
            Destroy(boxes.Dequeue());
        }

        var box = Instantiate(boxPrefab, boxSpawnPoint.position + planeTransform.right * Random.Range(-boxDispersion, boxDispersion), Quaternion.identity);
        boxes.Enqueue(box);
        return box;
    }
}
