using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightScript : MonoBehaviour
{
	private int LightOrderIndex;
	private int LampOrderIndex;
	Light _l;
	private bool BoolIntensity;
	
    // Start is called before the first frame update
    void Awake()
    {
    LightOrderIndex = transform.GetSiblingIndex();
	_l = GetComponent<Light>();
	if (_l.intensity > 0)
	{
	BoolIntensity = true;
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnEnable()
    {
        CeilLampScript.ActionCeilLamp0 += Change0;
		CeilLampScript.ActionCeilLamp1 += Change1;

    }

    private void OnDisable()
    {
        CeilLampScript.ActionCeilLamp0 -= Change0;
		CeilLampScript.ActionCeilLamp1 -= Change1;
    }
	
	 private void Change0()
    {
	LampOrderIndex = 0;
	CheckChange();
    }
	
	private void Change1()
    {
	LampOrderIndex = 1;
	CheckChange();
    }
	
	private void CheckChange()
	{
	if (LampOrderIndex == LightOrderIndex)
	{
	BoolIntensity = !BoolIntensity;
	_l.intensity = Convert.ToInt32(BoolIntensity);
	}
	
	}
}
