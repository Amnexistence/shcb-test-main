using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	
    
public class SwitchActionScript : MonoBehaviour
{
	private float SwitchRotate;
	public Material OffIndicatorMat;
	public Material OnIndicatorMat;
	MeshRenderer _mr;
	[HideInInspector]
	public bool StateFlag;
	
	DeviceActionScript _das;
	
	public int UIOrder;
	
	void Awake()
	{
	_mr = gameObject.transform.parent.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>();
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	}
	
    void OnEnable()
    {
	gameObject.transform.parent.transform.GetChild(1).transform.Rotate(0f, 0f, SwitchRotate * (-1), Space.Self);
	_mr.material = OnIndicatorMat;
	gameObject.transform.parent.gameObject.GetComponent<SwitchScript>().SwitchOn();
	_das.UISignal(UIOrder);
	}
	
	 void OnDisable()
    {  
	SwitchRotate = Mathf.Abs(transform.parent.GetChild(1).transform.rotation.z * 315);
	gameObject.transform.parent.transform.GetChild(1).transform.Rotate(0f, 0f, SwitchRotate, Space.Self);
	//gameObject.GetComponent<MeshRenderer>().material = IndicatorMat;
	_mr.material = OffIndicatorMat;
	gameObject.transform.parent.gameObject.GetComponent<SwitchScript>().SwitchOff();
	_das.UISignal(UIOrder);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
