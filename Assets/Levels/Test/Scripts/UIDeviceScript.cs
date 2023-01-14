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
public static event Action ActionChange7;
public static event Action ActionChange8;
public static event Action ActionChange9;
public static event Action ActionChange10;
public static event Action ActionChange11;
public static event Action ActionChange12;
public static event Action ActionChange13;
public static event Action ActionChange14;
public static event Action ActionChange15;
public static event Action ActionChange16;
public static event Action ActionChange17;

private int UIDeviceOrderIndex;
[HideInInspector]
public int DeviceOrderIndex;

void Start()
{

UIDeviceOrderIndex = transform.parent.transform.parent.transform.GetSiblingIndex();
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
else if (UIDeviceOrderIndex == 7)
{
ActionChange7?.Invoke();	
}
else if (UIDeviceOrderIndex == 8)
{
ActionChange8?.Invoke();	
}
else if (UIDeviceOrderIndex == 9)
{
ActionChange9?.Invoke();	
}
else if (UIDeviceOrderIndex == 10)
{
ActionChange10?.Invoke();	
}
else if (UIDeviceOrderIndex == 11)
{
ActionChange11?.Invoke();	
}
else if (UIDeviceOrderIndex == 12)
{
ActionChange12?.Invoke();	
}
else if (UIDeviceOrderIndex == 13)
{
ActionChange13?.Invoke();	
}
else if (UIDeviceOrderIndex == 14)
{
ActionChange14?.Invoke();	
}
else if (UIDeviceOrderIndex == 15)
{
ActionChange15?.Invoke();	
}
else if (UIDeviceOrderIndex == 16)
{
ActionChange16?.Invoke();	
}
else if (UIDeviceOrderIndex == 17)
{
ActionChange17?.Invoke();	
}

			
}



}