using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightScript : MonoBehaviour
{
	private int LightOrderIndex;
	private int LampOrderIndex;
	private bool BoolIntensity;
	Light _l;
	
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
        CeilLampScript.ActionCeilLamp += CheckChange;

    }

    private void OnDisable()
    {
        CeilLampScript.ActionCeilLamp -= CheckChange;
    }
	
	
	private void CheckChange()
	{
	if (StaticValues._LampOrderIndex == LightOrderIndex)
	{
	BoolIntensity = !BoolIntensity;
	_l.intensity = Convert.ToInt32(BoolIntensity);
	}
	
	}
}
