using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CharacterSelectUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public GameObject leftPanel;
    public GameObject rightPanel;
   public void OnPointerEnter(PointerEventData eventData)
   {
        if (eventData.pointerEnter == leftPanel)
      {
        leftPanel.transform.localScale = new Vector2(1.2f, 1);
      }
       else if (eventData.pointerEnter == rightPanel)
      {
        rightPanel.transform.localScale = new Vector2(1.2f, 1);
      }
   }

   public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter == leftPanel)
      {
        leftPanel.transform.localScale = new Vector2(1, 1);
        Debug.Log("Exit Left");
      }
       else if (eventData.pointerEnter == rightPanel)
      {
        rightPanel.transform.localScale = new Vector2(1, 1);
         Debug.Log("Exit Right");
      }
    }

// Complete This Method 
// Add a way to activate a button to start game
   public void OnPointerClick(PointerEventData pointerEventData)
    {
      if (pointerEventData.pointerEnter == leftPanel)
      {
        RectTransform leftRectTransform = leftPanel.GetComponent<RectTransform>();
        leftRectTransform.sizeDelta = new Vector2(1920, leftRectTransform.sizeDelta.y);
        rightPanel.SetActive(false);
      }
      else if (pointerEventData.pointerEnter == rightPanel)
      {
        RectTransform rightRectTransform = rightPanel.GetComponent<RectTransform>();
        rightRectTransform.sizeDelta = new Vector2(1920, rightRectTransform.sizeDelta.y);
        leftPanel.SetActive(false);
      }
    }
}
