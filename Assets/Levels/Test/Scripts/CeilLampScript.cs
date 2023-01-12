using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilLampScript : MonoBehaviour
{
	
	public Material OffLampMat;
	public Material OnLampMat;
	public int UIOrder;
	MeshRenderer _mr;
	DeviceActionScript _das;
    
	void Awake()
	{
	_mr = transform.parent.gameObject.GetComponent<MeshRenderer>();
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	}
	
    void OnEnable()
    {
	_mr.material = OnLampMat;
	_das.UISignal(UIOrder);
	}
	
	void OnDisable()
    {
	_mr.material = OffLampMat;
	_das.UISignal(UIOrder);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
