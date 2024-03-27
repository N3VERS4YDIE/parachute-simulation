using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider speedSlider;
    public int Speed => (int)speedSlider.value;
    [SerializeField] private TMP_Text speedText;

    [SerializeField] private Slider heightSlider;
    public int Height => (int)heightSlider.value / 20;
    [SerializeField] private TMP_Text heightText;

    [Header("Settings")]
    [SerializeField] private int minSpeed = 60;
    public int MinSpeed => minSpeed;
    [SerializeField] private int maxSpeed = 150;
    public int MaxSpeed => maxSpeed;

    [SerializeField] private int minHeight = 1000;
    public int MinHeight => minHeight;
    [SerializeField] private int maxHeight = 1500;
    public int MaxHeight => maxHeight;


    private void Start()
    {
        speedSlider.onValueChanged.AddListener(value => speedText.text = $"{value}kn");
        speedSlider.wholeNumbers = true;
        speedSlider.minValue = minSpeed;
        speedSlider.maxValue = maxSpeed;
        speedSlider.value = minSpeed;

        heightSlider.onValueChanged.AddListener(value =>
        {
            value = Mathf.Round(value / 100) * 100;
            heightText.text = $"{value}ft";
        });
        heightSlider.wholeNumbers = true;
        heightSlider.minValue = minHeight;
        heightSlider.maxValue = maxHeight;
        heightSlider.value = minHeight;
    }
}
