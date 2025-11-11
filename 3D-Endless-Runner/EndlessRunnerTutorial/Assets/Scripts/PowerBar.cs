using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    [Header("UI Components")]
    public Slider powerSlider;
    public Image fillImage;
    public float fillSpeed = 0.5f;
    public bool autoFill = true;

    private float targetValue = 1f;

    void Start()
    {
        if (powerSlider == null)
            powerSlider = GetComponent<Slider>();

        powerSlider.minValue = 0;
        powerSlider.maxValue = 1;
        powerSlider.value = 0;
    }

    void Update()
    {
        if (autoFill)
        {
            // Smoothly fill power bar
            powerSlider.value = Mathf.MoveTowards(powerSlider.value, targetValue, fillSpeed * Time.deltaTime);

            // Simple glowing pulse effect
            float glow = 0.5f + Mathf.PingPong(Time.time * 2f, 0.5f);
            if (fillImage != null)
                fillImage.color = new Color(0, 1, 0, glow);
        }
    }

    public void SetPower(float value)
    {
        targetValue = Mathf.Clamp01(value);
    }

    public void ResetPower()
    {
        powerSlider.value = 0;
        targetValue = 1f;
    }
}
