using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





public class UIDeviceScript: MonoBehaviour, IPointerClickHandler
{


public static event Action ActionChange0;
public static event Action ActionChange1;
public static event Action ActionChange2;
public static event Action ActionChange3;
public static event Action ActionChange4;
public static event Action ActionChange5;
public static event Action ActionChange6;

public int UIDeviceOrderIndex;

void Start()
{

}

   public void OnPointerClick(PointerEventData eventData)
{

if (UIDeviceOrderIndex == 0)
{
ActionChange0?.Invoke();
}
else if (UIDeviceOrderIndex == 1)
{
ActionChange1?.Invoke();	
}
else if (UIDeviceOrderIndex == 2)
{
ActionChange2?.Invoke();	
}
else if (UIDeviceOrderIndex == 3)
{
ActionChange3?.Invoke();	
}
else if (UIDeviceOrderIndex == 4)
{
ActionChange4?.Invoke();	
}
else if (UIDeviceOrderIndex == 5)
{
ActionChange5?.Invoke();	
}
else if (UIDeviceOrderIndex == 6)
{
ActionChange6?.Invoke();	
}

			
}



}