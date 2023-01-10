using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilLampScript : MonoBehaviour
{
	public GameObject MySwitch;
	SwitchScript _ss;
	
    
    void OnEnable()
    {
	_ss = MySwitch.GetComponent<SwitchScript>();
    //_ss.ConductedPower = _ss.ConductedPower + 100;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
