using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour {

	public Camera uiCamera;
	public Renderer[] buttonRenders;
	public Texture[] buttonTexture;
	public RaycastHit hit;
	public GameObject BIKESelection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Mouse0) )
		{
			
			MouseDown(Input.mousePosition );
		}
		if( Input.GetKeyUp(KeyCode.Mouse0) )
		{
			
			MouseUp(Input.mousePosition );
		}
	}


	void MouseUp(Vector3 a )
	{
		
		Ray ray = uiCamera.ScreenPointToRay(a);
		
		if (Physics.Raycast(ray, out hit, 500))
		{

			switch(hit.collider.name)
			{
				case "singleMode":
					BIKESelection.SetActive(true);
					gameObject.SetActive(false);
					break;

				case "multiplayermode":
					BIKESelection.SetActive(true);
					gameObject.SetActive(false);
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
			case "singleMode":
				buttonRenders[0].material.mainTexture  = buttonTexture[1];
				break;
			case "multiplayermode":
				buttonRenders[1].material.mainTexture  = buttonTexture[1];
				break;
			
			}
		}
	}



}
