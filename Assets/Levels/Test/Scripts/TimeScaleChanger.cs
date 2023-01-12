using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class TimeScaleChanger : MonoBehaviour, IPointerClickHandler
{
	public GameObject TimeObject;
	public float Scale;
	TimeScript _ts;
	
	
    // Start is called before the first frame update
    void Start()
    {
     _ts = TimeObject.GetComponent<TimeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnPointerClick(PointerEventData eventData)
	{
	_ts.MyTimeScale += Scale;
	_ts.ScaleChange();	
	}
}
