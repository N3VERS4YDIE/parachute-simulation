using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneUIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text dispersionText;
    [SerializeField] private TMP_Text frontPushText;
    private PlaneController planeController;

    private Vector3 initialDispersionTextPosition;

    void Start()
    {
        planeController = FindObjectOfType<PlaneController>();
        initialDispersionTextPosition = dispersionText.transform.position;

        var inverseVector = new Vector3(-1, 1, 1);
        dispersionText.rectTransform.localScale = inverseVector;
        // deviationText.rectTransform.localScale = inverseVector;
        frontPushText.rectTransform.localScale = inverseVector;
    }

    void Update()
    {
        dispersionText.text = planeController.Dispersion;
        frontPushText.text = planeController.FrontPush;

        dispersionText.rectTransform.LookAt(Camera.main.transform.position);
        // deviationText.rectTransform.LookAt(Camera.main.transform.position);
        frontPushText.rectTransform.LookAt(Camera.main.transform.position);

        dispersionText.rectTransform.position = planeController.DispersionPosition;
    }
}
