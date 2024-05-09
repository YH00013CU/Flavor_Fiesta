using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // Reference to the slider component

    // Method to set the slider's value
    public void SetHealth(int health)
    {
        slider.value = health; // Set the slider's value to the specified health value
    }

    // Method to reset the health to its maximum value
    public void ResetHealth()
    {
        slider.value = slider.maxValue; // Set the slider's value to its maximum
    }
}
