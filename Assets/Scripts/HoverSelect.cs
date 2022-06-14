using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 public class HoverSelect : MonoBehaviour, IPointerEnterHandler
 {
     [SerializeField]
     private Selectable selectable = null;
     
     public void OnPointerEnter(PointerEventData eventData)
     {
         selectable.Select();
     }
 }