using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
	Light _l;
	DeviceActionScript _das;
	
    void Awake()
	{
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	}
	
    void OnEnable()
    {
	_l = gameObject.transform.parent.transform.GetChild(0).GetComponent<Light>();
	_l.enabled = true;
	_l = gameObject.transform.parent.transform.GetChild(1).GetComponent<Light>();
	_l.enabled = true;
	_das.UISignal(_das.DeviceOrderIndex);
	}
	
	void OnDisable()
    {
	_l = gameObject.transform.parent.transform.GetChild(0).GetComponent<Light>();
	_l.enabled = false;
	_l = gameObject.transform.parent.transform.GetChild(1).GetComponent<Light>();
	_l.enabled = false;
	_das.UISignal(_das.DeviceOrderIndex);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
