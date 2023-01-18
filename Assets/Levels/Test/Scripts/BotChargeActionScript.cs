using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotChargeActionScript : MonoBehaviour
{
	private GameObject Bot;
	DeviceActionScript _das;
	BotScript _bs;
	BotChargeActivate _bca;
	
    // Start is called before the first frame update
    void Awake()
    {
    Bot = gameObject.transform.parent.transform.parent.transform.GetChild(0).gameObject;
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	_bs = Bot.GetComponent<BotScript>();
	_bca = transform.parent.gameObject.GetComponent<BotChargeActivate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnEnable()
    {
	
	if (_das.ConductVar == 1)
	{
	_bs.MyState = 1;
	}
	
	}
	
	void OnDisable()
    {
	
	_bca.Activator();
	
	}
}
