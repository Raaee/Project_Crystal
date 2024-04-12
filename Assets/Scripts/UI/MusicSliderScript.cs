using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicSliderScript : MonoBehaviour
{
  public TMP_Text sliderValueText;
  public Slider slider;

  void Update()
  {
    if (sliderValueText && slider)
    {
        sliderValueText.text = (slider.value * 100).ToString("0") + "%";
    } 
    else 
    {
        Debug.Log("No instance of slider textbox nor slider set in the editor");
    }
    
  }
}
