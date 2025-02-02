﻿using UnityEngine;
using System.Collections;
using System ;
// using UnityEngine.SceneManagement;
// using UnityEditor.SceneManagement;

public class UIControl : MonoBehaviour {
	public Camera UICamera;

	public enum UiState
	{
		pause,
		resume,
		gameOver,
		empty 
	}
	public static float     ShieldTime = 10;
	public static float     MagnetTime = 15;
	public GameObject pauseMenu,gameOverMenu,coinIngameCointainer,distanceInGameContainer,pauseButton,NitrousUiParent,CameraChangeAngle;
	public RaycastHit hit;
	public Texture[] buttonTex,pauseButtonTex,brakeButtonTex,nitrousButton,CameraChangeAngleText,LeftButtonTex,RightButtonTex;
	public Renderer pauseButtonRenderer,brakeRenderer,nitrousButtonRenderer,CameraChangeAngleRenderer,LeftRenderer,RightRenderer;
	public static bool isBrakesOn = false ;
	public static bool isLeftOn = false ;
	public static bool isRightOn = false ;
	public Renderer[] buttonRenders;
	public Transform nitrousTransform,brakeTransform,LeftTransform,RightTransform ;
	public TextMesh coinMessageText ;
	public GameObject messageParent,Loading,GameEndMenu ;
	public static UIControl Static;
	public GameObject NitrousParticle,TutorialParent;
	public Transform speedoMeterNeedle ;
	public Rigidbody playerRigidBody ;
	public float[] needleRotations ;
	public int neddleIndex ;
	
	void OnEnable()
	{
		Static = this;
		playerBIKEControl.gameEnded += onGameEnd;
	//	TutorialParent.SetActive (true);
	//	NitrousParticle = GameObject.FindGameObjectWithTag ("SpeedParticle");
	}
	void OnDisable()
	{
		playerBIKEControl.gameEnded -= onGameEnd;
	}

	public void showCoinAwardMessage()
	{
		if (messageParent.activeSelf)
						return;
		coinMessageText.text = "+ 10";
		GamePlayController.collectedCoinsCounts+=10;
		messageParent.SetActive (true);
	}
	void onGameEnd(System.Object obj, System.EventArgs args)
	{
		pauseMenu.SetActive(false);
		coinIngameCointainer.SetActive(false);
		distanceInGameContainer.SetActive(false);
		NitrousUiParent.SetActive(false);
		pauseButton.SetActive (false);
	}
	void downState(Vector3 a )
	{
		
		Ray ray = UICamera.ScreenPointToRay(a);
		
		if (Physics.Raycast(ray, out hit, 500))
		{
			string objName  = hit.collider.name;
			SoundController.Static.PlayClickSound();
			switch(objName)
			{
			case "PlayAgain":
				SoundController.Static.PlayClickSound();
				buttonRenders[0].material.mainTexture=buttonTex[1];
				break;
			case "mainmenu":
				buttonRenders[1].material.mainTexture=buttonTex[1]; //we have two mainmenu button in pausemenu and gameover menu,
				buttonRenders[4].material.mainTexture=buttonTex[1];
				break;
			
			case "resume":
				buttonRenders[2].material.mainTexture=buttonTex[1];
				break;
			case "pauseIngame":
				pauseButtonRenderer.material.mainTexture = pauseButtonTex[1];
				break;

			case "NitrousButton":
				if(NitrousIndicator.NitrousCount > 1)
				{
					NitrousIndicator.Static.isNitrousOn = true;
					nitrousButtonRenderer .material.mainTexture =  nitrousButton[1];
					//neddleIndex=2;
				}
				
				break;
			case "BrakeButton" :
				isBrakesOn = true ;
				brakeRenderer.material.mainTexture = brakeButtonTex [1];

				//neddleIndex=1;
				break;
			case "LeftButton" :
				isLeftOn = true ;
				LeftRenderer.material.mainTexture = LeftButtonTex [1];

				//neddleIndex=1;
				break;
			case "RightButton" :
				isRightOn = true ;
				RightRenderer.material.mainTexture = RightButtonTex [1];

				//neddleIndex=1;
				break;

			case "CameraChangeAngleBtn":
			
				CameraChangeAngleRenderer.material.mainTexture=CameraChangeAngleText[1];
				break;

			}
			
		}
		
	}
	void upState(Vector3 a )
	{
		
		
		pauseButtonRenderer.material.mainTexture = pauseButtonTex[0];
		nitrousButtonRenderer .material.mainTexture = nitrousButton[0];
		brakeRenderer.material.mainTexture = brakeButtonTex [0];
		LeftRenderer.material.mainTexture = LeftButtonTex[0];
		RightRenderer.material.mainTexture = RightButtonTex[0];

		CameraChangeAngleRenderer.material.mainTexture=CameraChangeAngleText[0];

		isBrakesOn = false;
		isLeftOn = false;
		isRightOn = false;

		Ray ray = UICamera.ScreenPointToRay(a);
		
		if (Physics.Raycast(ray, out hit, 500))
		{
			
			string objName  = hit.collider.name;
			
			switch(objName)
			{
			case "PlayAgain":
				GamePlayController.isGameEnded = false;
				GameEndMenu.SetActive(false);
				Loading.SetActive(true);
				//Application.LoadLevel(Application.loadedLevelName);
				Invoke("LoadingBg",0.5f);
				break;
			case "mainmenu":
				 //UnityEngine.SceneManagement.SceneManager.LoadScene((int)0);
				Application.LoadLevel("mainMenu");
				break;
			
			case "resume":
				Time.timeScale=1;
				pauseButton.SetActive(true);
				pauseMenu.SetActive(false);
				coinIngameCointainer.SetActive(true);
				distanceInGameContainer.SetActive(true);
				NitrousUiParent.SetActive(true);
				 
				break;
			case "pauseIngame":
			 
				Time.timeScale=0;
				pauseMenu.SetActive(true);
				coinIngameCointainer.SetActive(false);
				distanceInGameContainer.SetActive(false);
				NitrousUiParent.SetActive(false);
				pauseButton.SetActive(false);
				 
				break;

			case "NitrousButton":
				 
				NitrousIndicator.Static.isNitrousOn = false;
				playerBIKEControl.isDoubleSpeed=1.0f;
					 
				break;
			case "CameraChangeAngleBtn":
				
				BIKECamera.Static.ChangeCamera();
				break;
			}
		}
		foreach(Renderer r in buttonRenders)
		{
			r.material.mainTexture=buttonTex[0];
		}
		
	}
	// Use this for initialization
	void Start () {
	
	}
	void LoadingBg(){
		Application.LoadLevel(Application.loadedLevelName);
		Loading.SetActive(false);
		}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Mouse0) )
		{
			
			downState(Input.mousePosition );
		}
		if( Input.GetKeyUp(KeyCode.Mouse0) )
		{
			
			upState(Input.mousePosition );
		}
		
		//**********************************************
		if( Input.GetKeyUp(KeyCode.UpArrow))
		{
			
			NitrousIndicator.Static.isNitrousOn = false;
			nitrousButtonRenderer .material.mainTexture =  nitrousButton[0];
			playerBIKEControl.isDoubleSpeed=1.0f;
			//playerBIKEControl.currentState=playerBIKEControl.PlayerStates.backrotate;
		}

		if( Input.GetKeyDown(KeyCode.UpArrow) )
		{
			if(NitrousIndicator.NitrousCount > 1)
			{
				NitrousIndicator.Static.isNitrousOn = true;
				nitrousButtonRenderer .material.mainTexture =  nitrousButton[1];
			}
		}

		//
		if( Input.GetKeyDown(KeyCode.DownArrow))
		{
			 isBrakesOn = true ;
			brakeRenderer.material.mainTexture = brakeButtonTex [1];
		}
		if( Input.GetKeyUp(KeyCode.DownArrow) )
		{
			isBrakesOn = false ;
			brakeRenderer.material.mainTexture = brakeButtonTex [0];
		}

		
		if( Input.GetKeyDown(KeyCode.LeftArrow) )
		{
			isLeftOn = true ;
			LeftRenderer.material.mainTexture = LeftButtonTex [1];
		}
		if( Input.GetKeyUp(KeyCode.LeftArrow) )
		{
			isLeftOn = false ;
			LeftRenderer.material.mainTexture = LeftButtonTex [0];
		}

		//
		if( Input.GetKeyDown(KeyCode.RightArrow) )
		{
			isRightOn = true ;
			RightRenderer.material.mainTexture = RightButtonTex [1];
		}
		if( Input.GetKeyUp(KeyCode.RightArrow) )
		{
			isRightOn = false ;
			RightRenderer.material.mainTexture = RightButtonTex [0];
		}
		
		//码表指针动画
		speedoMeterNeedle.rotation =	Quaternion.Slerp (speedoMeterNeedle.rotation, Quaternion.Euler(0,0,needleRotations[ neddleIndex] + BIKESelection.BIKEIndex + ( UnityEngine.Random.Range(-3,3))), 0.01f);

		#if ( UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8 ) && !UNITY_EDITOR
//		//orientation change
//		if ((Screen.orientation == ScreenOrientation.Portrait) || (Screen.orientation == ScreenOrientation.PortraitUpsideDown) ) 
//		{
//			nitrousTransform.localPosition = new Vector3(-7,-16.17969f,0);
//			brakeTransform.localPosition = new Vector3(7,-16.17969f,0);
//		}
//		else if ((Screen.orientation == ScreenOrientation.LandscapeLeft) || (Screen.orientation == ScreenOrientation.LandscapeRight) ) 
//		{
//			nitrousTransform.localPosition =  new Vector3(0,-16.17969f,0);
//			brakeTransform.localPosition = new Vector3(0,-16.17969f,0);
//		}
		#endif
	}
}
