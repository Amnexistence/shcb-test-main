using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class UIActionStatus : MonoBehaviour
{
	private int UIDeviceOrderIndex;
	[HideInInspector]
	public int DeviceOrderIndex;
	Component[] _HeaderStatuses;
	
    // Start is called before the first frame update
    void Start()
    {
	_HeaderStatuses = gameObject.GetComponents(typeof(HeaderStatus)); 
	UIDeviceOrderIndex = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnEnable()
    {
        DeviceActionScript.ActionUIStatusChange0 += Change0;
		DeviceActionScript.ActionUIStatusChange1 += Change1;
		DeviceActionScript.ActionUIStatusChange2 += Change2;
		DeviceActionScript.ActionUIStatusChange3 += Change3;
		DeviceActionScript.ActionUIStatusChange4 += Change4;
		DeviceActionScript.ActionUIStatusChange5 += Change5;
		DeviceActionScript.ActionUIStatusChange6 += Change6;
		DeviceActionScript.ActionUIStatusChange7 += Change7;
		DeviceActionScript.ActionUIStatusChange8 += Change8;
		DeviceActionScript.ActionUIStatusChange9 += Change9;
		DeviceActionScript.ActionUIStatusChange10 += Change10;
		DeviceActionScript.ActionUIStatusChange11 += Change11;
		DeviceActionScript.ActionUIStatusChange12 += Change12;
		DeviceActionScript.ActionUIStatusChange13 += Change13;
		DeviceActionScript.ActionUIStatusChange14 += Change14;
		DeviceActionScript.ActionUIStatusChange15 += Change15;
		DeviceActionScript.ActionUIStatusChange16 += Change16;
		DeviceActionScript.ActionUIStatusChange17 += Change17;
    }

    private void OnDisable()
    {
        DeviceActionScript.ActionUIStatusChange0 -= Change0;
		DeviceActionScript.ActionUIStatusChange1 -= Change1;
		DeviceActionScript.ActionUIStatusChange2 -= Change2;
		DeviceActionScript.ActionUIStatusChange3 -= Change3;
		DeviceActionScript.ActionUIStatusChange4 -= Change4;
		DeviceActionScript.ActionUIStatusChange5 -= Change5;
		DeviceActionScript.ActionUIStatusChange6 -= Change6;
		DeviceActionScript.ActionUIStatusChange7 -= Change7;
		DeviceActionScript.ActionUIStatusChange8 -= Change8;
		DeviceActionScript.ActionUIStatusChange9 -= Change9;
		DeviceActionScript.ActionUIStatusChange10 -= Change10;
		DeviceActionScript.ActionUIStatusChange11 -= Change11;
		DeviceActionScript.ActionUIStatusChange12 -= Change12;
		DeviceActionScript.ActionUIStatusChange13 -= Change13;
		DeviceActionScript.ActionUIStatusChange14 -= Change14;
		DeviceActionScript.ActionUIStatusChange15 -= Change15;
		DeviceActionScript.ActionUIStatusChange16 -= Change16;
		DeviceActionScript.ActionUIStatusChange17 -= Change17;
    }
	
	 private void Change0()
    {
	DeviceOrderIndex = 0;
	CheckChange();
    }
	
	private void Change1()
    {
	DeviceOrderIndex = 1;
	CheckChange();
    }
	
	private void Change2()
    {
	DeviceOrderIndex = 2;
	CheckChange();
    }
	
	private void Change3()
    {
	DeviceOrderIndex = 3;
	CheckChange();
    }
	
	private void Change4()
    {
	DeviceOrderIndex = 4;
	CheckChange();
    }
	
	private void Change5()
    {
	DeviceOrderIndex = 5;
	CheckChange();
    }
	
	private void Change6()
    {
	DeviceOrderIndex = 6;
	CheckChange();
    }
	
	private void Change7()
    {
	DeviceOrderIndex = 7;
	CheckChange();
    }
	
	private void Change8()
    {
	DeviceOrderIndex = 8;
	CheckChange();
    }
	
	 private void Change9()
    {
	DeviceOrderIndex = 9;
	CheckChange();
    }
	
	private void Change10()
    {
	DeviceOrderIndex = 10;
	CheckChange();
    }
	
	private void Change11()
    {
	DeviceOrderIndex = 11;
	CheckChange();
    }
	
	private void Change12()
    {
	DeviceOrderIndex = 12;
	CheckChange();
    }
	
	private void Change13()
    {
	DeviceOrderIndex = 13;
	CheckChange();
    }
	
	private void Change14()
    {
	DeviceOrderIndex = 14;
	CheckChange();
    }
	
	private void Change15()
    {
	DeviceOrderIndex = 15;
	CheckChange();
    }
	
	private void Change16()
    {
	DeviceOrderIndex = 16;
	CheckChange();
    }
	
	private void Change17()
    {
	DeviceOrderIndex = 17;
	CheckChange();
    }

	private void CheckChange() //проверяем соответствие статуса устройства и меняем статус во всех объектах хедер-статуса
	{
	if (DeviceOrderIndex == UIDeviceOrderIndex)
	{
	foreach (HeaderStatus _hs in _HeaderStatuses)
	_hs.ChangeStatus();
	}
	}
}
