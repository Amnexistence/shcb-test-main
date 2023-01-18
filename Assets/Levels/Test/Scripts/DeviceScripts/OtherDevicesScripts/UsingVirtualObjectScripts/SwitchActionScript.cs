using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActionScript : MonoBehaviour
{
	private float SwitchRotate;
	private int UIOrder;
	public Material OffIndicatorMat;
	public Material OnIndicatorMat;
	MeshRenderer _mr;
	DeviceActionScript _das;
	
	void Awake()
	{
	_mr = gameObject.transform.parent.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>();
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	UIOrder = _das.DeviceOrderIndex;
	}
	
    void OnEnable()
    {
	gameObject.transform.parent.transform.GetChild(1).transform.Rotate(0f, 0f, SwitchRotate * (-1), Space.Self);
	_mr.material = OnIndicatorMat;
	//gameObject.transform.parent.gameObject.GetComponent<SwitchScript>().SwitchOn();
	_das.UISignal(UIOrder);
	}
	
	 void OnDisable()
    {  
	SwitchRotate = Mathf.Abs(transform.parent.GetChild(1).transform.rotation.z * 315);
	gameObject.transform.parent.transform.GetChild(1).transform.Rotate(0f, 0f, SwitchRotate, Space.Self);
	//gameObject.GetComponent<MeshRenderer>().material = IndicatorMat;
	_mr.material = OffIndicatorMat;
	//gameObject.transform.parent.gameObject.GetComponent<SwitchScript>().SwitchOff();
	_das.UISignal(UIOrder);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
