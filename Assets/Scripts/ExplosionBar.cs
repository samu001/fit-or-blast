using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;




    public void SetInitialValues(int startingWeight, int maxWeight) {
        slider.maxValue = maxWeight;
        slider.value = startingWeight;
        fill.color = gradient.Evaluate(0.3f);
    }

    public void SetWeight(int currentWeight) {
        slider.value = currentWeight;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }



}
