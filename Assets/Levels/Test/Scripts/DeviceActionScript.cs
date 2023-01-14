using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class DeviceActionScript : MonoBehaviour
{
	public int DeviceOrderIndex;
	[HideInInspector]
	public int UIDeviceOrderIndex;
	
	public static event Action ActionUIStatusChange0;
	public static event Action ActionUIStatusChange1;
	public static event Action ActionUIStatusChange2;
	public static event Action ActionUIStatusChange3;
	public static event Action ActionUIStatusChange4;
	public static event Action ActionUIStatusChange5;
	public static event Action ActionUIStatusChange6;
	public static event Action ActionUIStatusChange7;
	public static event Action ActionUIStatusChange8;
	public static event Action ActionUIStatusChange9;
	public static event Action ActionUIStatusChange10;
	public static event Action ActionUIStatusChange11;
	public static event Action ActionUIStatusChange12;
	public static event Action ActionUIStatusChange13;
	public static event Action ActionUIStatusChange14;
	public static event Action ActionUIStatusChange15;
	public static event Action ActionUIStatusChange16;
	public static event Action ActionUIStatusChange17;
	
	private GameObject PowerSource;
	
	PowerSourceScript _pss;
	
	[HideInInspector]
	public int ConductVar;
	
	void Awake()
    {
	PowerSource = GetComponent<GridListScript>().PowerSource;
    _pss = PowerSource.GetComponent<PowerSourceScript>();
    }
	
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	 private void OnEnable()
    {
        UIDeviceScript.ActionChange0 += Change0;
		UIDeviceScript.ActionChange1 += Change1;
		UIDeviceScript.ActionChange2 += Change2;
		UIDeviceScript.ActionChange3 += Change3;
		UIDeviceScript.ActionChange4 += Change4;
		UIDeviceScript.ActionChange5 += Change5;
		UIDeviceScript.ActionChange6 += Change6;
		UIDeviceScript.ActionChange7 += Change7;
		UIDeviceScript.ActionChange8 += Change8;
		UIDeviceScript.ActionChange9 += Change9;
		UIDeviceScript.ActionChange10 += Change10;
		UIDeviceScript.ActionChange11 += Change11;
		UIDeviceScript.ActionChange12 += Change12;
		UIDeviceScript.ActionChange13 += Change13;
		UIDeviceScript.ActionChange14 += Change14;
		UIDeviceScript.ActionChange15 += Change15;
		UIDeviceScript.ActionChange16 += Change16;
		UIDeviceScript.ActionChange17 += Change17;
    }

    private void OnDisable()
    {
        UIDeviceScript.ActionChange0 -= Change0;
		UIDeviceScript.ActionChange1 -= Change1;
		UIDeviceScript.ActionChange2 -= Change2;
		UIDeviceScript.ActionChange3 -= Change3;
		UIDeviceScript.ActionChange4 -= Change4;
		UIDeviceScript.ActionChange5 -= Change5;
		UIDeviceScript.ActionChange6 -= Change6;
		UIDeviceScript.ActionChange7 -= Change7;
		UIDeviceScript.ActionChange8 -= Change8;
		UIDeviceScript.ActionChange9 -= Change9;
		UIDeviceScript.ActionChange10 -= Change10;
		UIDeviceScript.ActionChange11 -= Change11;
		UIDeviceScript.ActionChange12 -= Change12;
		UIDeviceScript.ActionChange13 -= Change13;
		UIDeviceScript.ActionChange14 -= Change14;
		UIDeviceScript.ActionChange15 -= Change15;
		UIDeviceScript.ActionChange16 -= Change16;
		UIDeviceScript.ActionChange17 -= Change17;
    }
	
	 private void Change0()
    {
	UIDeviceOrderIndex = 0;
	CheckChange();
    }
	
	private void Change1()
    {
	UIDeviceOrderIndex = 1;
	CheckChange();
    }
	
	private void Change2()
    {
	UIDeviceOrderIndex = 2;
	CheckChange();
    }
	
	private void Change3()
    {
	UIDeviceOrderIndex = 3;
	CheckChange();
    }
	
	private void Change4()
    {
	UIDeviceOrderIndex = 4;
	CheckChange();
    }
	
	private void Change5()
    {
	UIDeviceOrderIndex = 5;
	CheckChange();
    }
	
	private void Change6()
    {
	UIDeviceOrderIndex = 6;
	CheckChange();
    }
	
	private void Change7()
    {
	UIDeviceOrderIndex = 7;
	CheckChange();
    }
	
	private void Change8()
    {
	UIDeviceOrderIndex = 8;
	CheckChange();
    }
	
	 private void Change9()
    {
	UIDeviceOrderIndex = 9;
	CheckChange();
    }
	
	private void Change10()
    {
	UIDeviceOrderIndex = 10;
	CheckChange();
    }
	
	private void Change11()
    {
	UIDeviceOrderIndex = 11;
	CheckChange();
    }
	
	private void Change12()
    {
	UIDeviceOrderIndex = 12;
	CheckChange();
    }
	
	private void Change13()
    {
	UIDeviceOrderIndex = 13;
	CheckChange();
    }
	
	private void Change14()
    {
	UIDeviceOrderIndex = 14;
	CheckChange();
    }
	
	private void Change15()
    {
	UIDeviceOrderIndex = 15;
	CheckChange();
    }
	
	private void Change16()
    {
	UIDeviceOrderIndex = 16;
	CheckChange();
    }
	
	private void Change17()
    {
	UIDeviceOrderIndex = 17;
	CheckChange();
    }
	
	private void CheckChange()
	{
	if (DeviceOrderIndex == UIDeviceOrderIndex) //не работает с лампочками (не объект включаемый напрямую через UI)
	{
	transform.GetChild(transform.childCount - 2).gameObject.SetActive(!transform.GetChild(transform.childCount - 2).gameObject.activeInHierarchy);
	_pss.ResetGrid();
	}
	
	}

public void UISignal(int Index)
{	
	if (Index == 0)
{
ActionUIStatusChange0?.Invoke();
}
else if (Index == 1)
{
ActionUIStatusChange1?.Invoke();	
}
else if (Index == 2)
{
ActionUIStatusChange2?.Invoke();	
}
else if (Index == 3)
{
ActionUIStatusChange3?.Invoke();	
}
else if (Index == 4)
{
ActionUIStatusChange4?.Invoke();	
}
else if (Index == 5)
{
ActionUIStatusChange5?.Invoke();	
}
else if (Index == 6)
{
ActionUIStatusChange6?.Invoke();	
}
else if (Index == 7)
{
ActionUIStatusChange7?.Invoke();	
}
else if (Index == 8)
{
ActionUIStatusChange8?.Invoke();	
}
else if (Index == 9)
{
ActionUIStatusChange9?.Invoke();	
}
else if (Index == 10)
{
ActionUIStatusChange10?.Invoke();	
}
else if (Index == 11)
{
ActionUIStatusChange11?.Invoke();	
}
else if (Index == 12)
{
ActionUIStatusChange12?.Invoke();	
}
else if (Index == 13)
{
ActionUIStatusChange13?.Invoke();	
}
else if (Index == 14)
{
ActionUIStatusChange14?.Invoke();	
}
else if (Index == 15)
{
ActionUIStatusChange15?.Invoke();	
}
else if (Index == 16)
{
ActionUIStatusChange16?.Invoke();	
}
else if (Index == 17)
{
ActionUIStatusChange17?.Invoke();	
}
}
}
