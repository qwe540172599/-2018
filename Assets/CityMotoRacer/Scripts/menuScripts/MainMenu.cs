﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

		
//		Debug.Log( "MainMenu.cs is Attached to " + gameObject.name );

		#if UNITY_IPHONE
			// Apple won't allow quit button in their app submission guides 
			menuButtonRenders[4].transform.parent.gameObject.SetActive(false);
		#endif
	}

	public Camera uiCamera;
	public Renderer[] menuButtonRenders;
	public Texture[] buttonTexture;
	public RaycastHit hit;
	public GameObject storeObject;
	public GameObject ModeSelection;
	public string[] reviewUrls,MoreUrls;

	void Update () {
		if( Input.GetKeyDown(KeyCode.Mouse0) )
		{
			
			MouseDown(Input.mousePosition );
		}
		if( Input.GetKeyUp(KeyCode.Mouse0) )
		{
			
			MouseUp(Input.mousePosition );
		}
		if( Input.GetKeyUp(KeyCode.Escape) )
		{
			
			Application.Quit();
		}
	}

	bool isDrag=false;
	void OnGUI()
	{
		
		if(  Event.current.type == EventType.MouseDrag)
		{
			isDrag=true;
		}
		else isDrag=false;
		
		
		// GUI.Label(Rect(0,10,100,90),Input.mousePosition +"" );
	}

	void MouseUp(Vector3 a )
	{
		if(isDrag)return; //to avoid unwanted touches while swipine or mouse draging
		foreach(Renderer r in menuButtonRenders )
		{
			r.material.mainTexture = buttonTexture[0];
		}
		Ray ray = uiCamera.ScreenPointToRay(a);
		
		if (Physics.Raycast(ray, out hit, 500))
		{

			switch(hit.collider.name)
			{
			case "Play":
				ModeSelection.SetActive(true);
				gameObject.SetActive(false);
				break;

			case "Store":
				storeObject.SetActive(true);
				gameObject.SetActive(false);
			 
				break;
				
			case "Connect":
				ReceiverMode.connectBluetooth = 1;
				 Debug.Log("连接蓝牙");
				break;

			case "Quit":
				Application.Quit();
				break;
					
			}
		}
		
	}
	void MouseDown(Vector3 a )
	{
		
		Ray ray = uiCamera.ScreenPointToRay(a);
		
		if (Physics.Raycast(ray, out hit, 500))
		{
			SoundController.Static.PlayClickSound();
			//Debug.Log("mouse hit on "+ hit.collider.name);
			switch(hit.collider.name)
			{
			case "Play":
				menuButtonRenders[0].material.mainTexture  = buttonTexture[1];
				break;
			case "Store":
				menuButtonRenders[1].material.mainTexture  = buttonTexture[1];
				break;
			case "Connect":
				menuButtonRenders[2].material.mainTexture  = buttonTexture[1];
				break;
			case "Quit":
				menuButtonRenders[3].material.mainTexture  = buttonTexture[1];
				break;
			
				
			}

			 
		}
		
	}
}
