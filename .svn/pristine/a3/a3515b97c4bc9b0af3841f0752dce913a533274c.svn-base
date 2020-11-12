using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionNum : MonoBehaviour {

// Use this for initialization
	void Start () {
		staticAttention = this ;
		UpdateAttentionNum();
	}

	void Update () {

		UpdateAttentionNum();
		
	}
	
	// Update is called once per frame
	public int attentionNum=0;
	public TextMesh attentionTxt;
	public static AttentionNum staticAttention ;
	void UpdateAttentionNum () {
		
		attentionNum = PlayerPrefs.GetInt("AttentionNum",0 );
		attentionTxt.text = ""+ attentionNum;
	}

	public void AddAttentionNum (int num) {

		PlayerPrefs.SetInt("AttentionNum",num) ;
		//UpdateAttentionNum();
	}


	public int getAttentionNum()
	{
		return PlayerPrefs.GetInt ("AttentionNum", 0);
	}
	


	public void ClearAttentionNum()
	{
		PlayerPrefs.DeleteKey("AttentionNum");
		UpdateAttentionNum();
	}


}
