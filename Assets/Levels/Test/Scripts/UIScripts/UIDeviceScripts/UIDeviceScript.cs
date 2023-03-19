using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIDeviceScript: MonoBehaviour, IPointerClickHandler
{

private int UIDeviceOrderIndex;
[HideInInspector]
//public int DeviceOrderIndex;
//private GameObject Test;
//DeviceActionScript _das;

public static event Action ActionChange;


void Start()
{
//StaticValues._UIDeviceOrderIndex = transform.parent.transform.parent.transform.GetSiblingIndex();
// StaticValues._UILinkString = (transform.parent.transform.parent.gameObject.name).Substring(13);
 //Test = GameObject.Find((transform.parent.transform.parent.gameObject.name).Substring(7)); 
}

   public void OnPointerClick(PointerEventData eventData) //по клику отправляем действие-запрос с соответствующим индексом для устройств
   //(индекс пишется в статик)
{

//StaticValues._UIDeviceOrderIndex = transform.parent.transform.parent.transform.GetSiblingIndex();
StaticValues._UILinkString = (transform.parent.transform.parent.gameObject.name).Substring(13); // 13 chars because our uis start with "Device Block "
ActionChange?.Invoke();

}




}