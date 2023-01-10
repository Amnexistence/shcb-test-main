using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActionScript : MonoBehaviour
{
	private float SwitchRotate;
	public Material OffIndicatorMat;
	public Material OnIndicatorMat;
	
    // Start is called before the first frame update
    void OnEnable()
    {
	SwitchRotate = Mathf.Abs(transform.parent.GetChild(1).transform.rotation.z * 315);
	gameObject.transform.parent.transform.GetChild(1).transform.Rotate(0f, 0f, SwitchRotate, Space.Self);
	//gameObject.GetComponent<MeshRenderer>().material = IndicatorMat;
	gameObject.transform.parent.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().material = OffIndicatorMat;
	}
	
	 void OnDisable()
    {  
    gameObject.transform.parent.transform.GetChild(1).transform.Rotate(0f, 0f, SwitchRotate * (-1), Space.Self);
	gameObject.transform.parent.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().material = OnIndicatorMat;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
