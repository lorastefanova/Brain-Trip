using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider; // Slider

    // Function to Set the maximum health
    public void SetMaxHP(int hp) 
    {
        slider.maxValue = hp; 
        slider.value = hp; 
    }

    // Function to set current health
    public void SetHP(int hp)
    {
        slider.value = hp;

    }
}
