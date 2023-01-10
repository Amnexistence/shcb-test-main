using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class DeviceActionScript : MonoBehaviour
{
	public int DeviceOrderIndex;
	[HideInInspector]
	public int UIDeviceOrderIndex;
	
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
	
	private void CheckChange()
	{
	if (DeviceOrderIndex == UIDeviceOrderIndex)
	{
	transform.GetChild(transform.childCount - 1).gameObject.SetActive(!transform.GetChild(transform.childCount - 1).gameObject.activeInHierarchy);
	}
	}

}
