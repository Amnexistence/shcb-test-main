using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotChargeActivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Activator()
	{
	StartCoroutine(Wait());
	}
	
	IEnumerator Wait()
	{
    yield return new WaitForSeconds(0.01f);
	gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject.SetActive(true);
	}
	
}
