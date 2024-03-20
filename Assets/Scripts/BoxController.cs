using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject parachute;


    [Header("Settings")]
    [SerializeField]
    private float OpenParachuteHeight = 10;

    [SerializeField]
    private float OpenParachuteHeightDeviation = 2;

    [SerializeField]
    private float minYVelocity = -2;

    [SerializeField]
    private float maxYVelocity = 1;

    [SerializeField]
    private float parachuteDrag = 3;


    private Rigidbody rb;
    private float parachuteOpenHeight;
    private Vector3 parachuteInitialScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        parachuteOpenHeight = transform.position.y - OpenParachuteHeight + Random.Range(-OpenParachuteHeightDeviation, OpenParachuteHeightDeviation);
        parachuteInitialScale = parachute.transform.localScale;

        parachute.SetActive(false);
        parachute.transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (rb.velocity.y >= minYVelocity && rb.velocity.y <= maxYVelocity)
        {
            rb.drag = 0;
            SetParachute(false);
        }
        else if (transform.position.y < parachuteOpenHeight)
        {
            rb.drag = parachuteDrag;
            SetParachute(true);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0), Time.deltaTime * 5);
        }
    }

    private void SetParachute(bool open)
    {
        parachute.transform.localScale = Vector3.Lerp(parachute.transform.localScale, open ? parachuteInitialScale : Vector3.zero, Time.deltaTime * 5);
        parachute.SetActive(transform.localScale != Vector3.zero);
        if (!parachute.activeSelf)
        {
            Destroy(parachute);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Target Area"))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (other.collider.CompareTag("Ground"))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
