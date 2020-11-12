using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAttention : MonoBehaviour {

	private AndroidJavaClass jc;
    private AndroidJavaObject jo;

	public TextMesh attentionTxt;
	public static int static_attentionNum=0;
	 public int i=0;
	// Use this for initialization
	void Start () {
		 jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
	}
	
	// Update is called once per frame
	void Update () {
 		i++;

		if(i>25 ) { 

            onBtnClickHander();

            i=0;
        }
	}

	 private void onBtnClickHander()
    {
        //调用android中的方法UnityCallAndroid_data2
        jo.Call("UnityCallAndroid_data2");
    }

	 public void UnityMethod_data2(string str)
    {
		static_attentionNum = (int)(float.Parse(str));
        attentionTxt.text = ""+static_attentionNum;
        
    }

}
