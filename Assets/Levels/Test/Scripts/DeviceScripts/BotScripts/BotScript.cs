using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{
	public int MaximumPower;
	public int MyPower;
	[HideInInspector]
	public int MyState;
	private bool BreakVar = false;
	private float Timer;
	private bool ChooseMove = true;
	

	
	public List<float> TargetPositionList;

	private List<float> VisitedList;

	private List<float> PriorList;
	private int BotStep;
	private bool PowerRotateFlag = false;
	private bool PowerMoveFlag = false;

	
	List<List<float>> VisitedListOfLists = new List<List<float>>();
	List<List<float>> PriorListOfLists = new List<List<float>>();
	List<List<List<float>>> PriorListOfListsOfLists = new List<List<List<float>>>();
	
	
    // Start is called before the first frame update
    void Start()
    {
	TargetPositionList = new List<float>() {-999,-999};
	VisitedList = new List<float>() {-999,-999};
	
	PriorList = new List<float>() {-999,-999};
	

	for(int i = 0; i < 3; i++)	
	{
    PriorListOfLists.Add(PriorList);
	}    
	
	for(int i = 0; i < 4; i++)	
	{
    PriorListOfListsOfLists.Add(PriorListOfLists);
	}
	
	for(int i = 0; i < 200; i++)	
	{
    VisitedListOfLists.Add(VisitedList);
	}    
	
		
     VisitedListOfLists[0][0] = transform.position.x;
	 VisitedListOfLists[0][1] = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
    
	if ((MyState == 1) && (MyPower >= 15)) //если запущен и энергия больше критически низкого заряда
	{
	if (ChooseMove == true)
	{
	BotStep += 1;
    RaycastHit hit;

    //if (hit.collider != null)
	if (!Physics.Raycast(transform.position, (transform.forward * (-1)), out hit, 1))
	{
	for(int i = 0; i < VisitedListOfLists.Count; i++)	
	{
	
	if ( (((transform.position + (transform.forward * (-1))).x) == VisitedListOfLists[i][0]) && (((transform.position + (transform.forward * (-1))).z) == VisitedListOfLists[i][1]) )
	{
	PriorListOfListsOfLists[1][0][0] = (transform.position + (transform.forward * (-1))).x;
	PriorListOfListsOfLists[1][0][1] = (transform.position + (transform.forward * (-1))).z;
	break;
	}
	
	if ( i == (VisitedListOfLists.Count - 1) )
	{
	PriorListOfListsOfLists[3][0][0] = (transform.position + (transform.forward * (-1))).x;
	PriorListOfListsOfLists[3][0][1] = (transform.position + (transform.forward * (-1))).z;
	Debug.Log("!");
	}
	

	}
	
    }
	

    if (!Physics.Raycast(transform.position, (transform.right * (-1)), out hit, 1))
	{
		
    for(int i = 0; i < VisitedListOfLists.Count; i++)	
	{
	
	if ( (((transform.position + (transform.right * (-1))).x) == VisitedListOfLists[i][0]) && (((transform.position + (transform.right * (-1))).z) == VisitedListOfLists[i][1]) )
	{
	PriorListOfListsOfLists[0][0][0] = (transform.position + (transform.right * (-1))).x;
	PriorListOfListsOfLists[0][0][1] = (transform.position + (transform.right * (-1))).z;
	break;
	}
	
	if ( i == (VisitedListOfLists.Count - 1) )
	{
	PriorListOfListsOfLists[2][0][0] = (transform.position + (transform.right * (-1))).x;
	PriorListOfListsOfLists[2][0][1] = (transform.position + (transform.right * (-1))).z;
	
	}
	

	}
            
    }
	

    if (!Physics.Raycast(transform.position, transform.right, out hit, 1))
	{
		
    for(int i = 0; i < VisitedListOfLists.Count; i++)	
	{
	
	if ( (((transform.position + transform.right).x) == VisitedListOfLists[i][0]) && (((transform.position + transform.right).z) == VisitedListOfLists[i][1]) )
	{
	PriorListOfListsOfLists[0][1][0] = (transform.position + transform.right).x;
	PriorListOfListsOfLists[0][1][1] = (transform.position + transform.right).z;
	break;
	}
	
	if ( i == (VisitedListOfLists.Count - 1) )
	{
	PriorListOfListsOfLists[2][1][0] = (transform.position + transform.right).x;
	PriorListOfListsOfLists[2][1][1] = (transform.position + transform.right).z;
	
	}
	

	}
            
    }
	
	
	for(int i = 0; i < PriorListOfListsOfLists.Count; i++) //приоритет обратно
	{
	//if (BreakVar == true) 
	//{
	//break;
	//}
	for(int j = 0; j < PriorListOfListsOfLists[i].Count; j++)	
	{
	if (PriorListOfListsOfLists[i][j][0] != -999 )
	{
	//TargetPositionList = PriorListOfListsOfLists[i][j];
	TargetPositionList[0] = PriorListOfListsOfLists[i][j][0];
	TargetPositionList[1] = PriorListOfListsOfLists[i][j][1];
	//BreakVar = true;
	//break;
	}
	}
	}
	
	BreakVar = false;
	
	ChooseMove = false;
	
	Timer = 1;
	PowerMoveFlag = true;
	PowerRotateFlag = true;
	}
	
	//if (TargetPositionList[1] != null)
	//{
	if ((TargetPositionList[0] == ((transform.position + (transform.forward * (-1))).x)) && (TargetPositionList[1] == ((transform.position + (transform.forward * (-1))).z)) )
	{
	//Timer = 0;
	//var step =  1 * Time.deltaTime; // calculate distance to move
	}
	else
	{
	if (Timer > 0)
	{
	transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, new Vector3(TargetPositionList[0] - transform.position.x, 0f, TargetPositionList[1] - transform.position.z)*(-1), 2f*Time.deltaTime, 0.0f));
	if (PowerRotateFlag == true)
	{
	MyPower = MyPower - 5;
	PowerRotateFlag = false;
	}
	}
	} 
	
	
	
	if (Timer <= 0)
	{
	transform.position = Vector3.MoveTowards(transform.position, new Vector3(TargetPositionList[0], transform.position.y, TargetPositionList[1]), Time.deltaTime);	
	if (PowerMoveFlag == true)
	{
	MyPower = MyPower - 10;
	PowerMoveFlag = false;
	}
	}
	
	if ((transform.position.x == TargetPositionList[0]) && (transform.position.z == TargetPositionList[1]))
	{
		
	VisitedListOfLists[BotStep][0] = transform.position.x;	
	VisitedListOfLists[BotStep][1] = transform.position.z;	
		
	ChooseMove = true;
	
	for(int i = 0; i < PriorListOfListsOfLists.Count; i++)
	{
	for(int j = 0; j < PriorListOfListsOfLists[i].Count - 1; j++)	//приоритет обратно
	{
	PriorListOfListsOfLists[i][j][0] = -999;
	PriorListOfListsOfLists[i][j][1] = -999;
	}
	}
	
	
	}
	//}
	
	if (Timer > 0)
	{
	
	Timer = Timer - Time.deltaTime;
	}
	
    }
	
	
    }
	
	
    }
