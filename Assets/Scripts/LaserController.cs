using UnityEngine;

public class LaserController : MonoBehaviour
{
    private void Start() {
        GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target Area"))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Target Area"))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}