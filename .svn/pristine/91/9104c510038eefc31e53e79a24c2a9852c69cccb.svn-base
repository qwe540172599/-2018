using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverMode : MonoBehaviour {

    private AndroidJavaClass jc;
    private AndroidJavaObject jo;


    public int start_flag=0;//测试用
    public int i=0;
	public int num=0;



    public static int  connectBluetooth = 0;

	void Start () {
      
        jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

	}
	
	// Update is called once per frame
	void Update () {
		  i++;

        if((connectBluetooth == 1)){

            //此处可以做connect button的监听事件
            onBtnClickHander();
            connectBluetooth=0;
        }
        if(i>25 && start_flag==1) { 
        	//AttentionNum.staticAttention.AddAttentionNum(30);
            onBtnClickHander1();
            i=0;
        }
	}

    //
    private void onBtnClickHander()
    {
        //调用android中的方法unitycallandroid
        jo.Call("UnityCallAndroid_connect");
    }

    private void onBtnClickHander1()
    {
        //调用android中的方法unitycallandroid
        jo.Call("UnityCallAndroid_data1");
    }


    public void UnityMethod_flag(string str)
    {
        if(str == "true"){
            start_flag = 1;
        }
        // elseif(str == "false"){
        //     ;
        // }
        
    }

    //被android中UnityCallAndroid
    public void UnityMethod_data1(string str)
    {
        Debug.Log("unityMethod被调用，参数：" + str);
        
        AttentionNum.staticAttention.AddAttentionNum((int)(float.Parse(str)));
        
    }

//*************************************************
//     public static ReceiverMode receiverMode ;
// 	//public TextMesh ZZ_TEXT;
//     private AndroidJavaClass jc;
//     private AndroidJavaObject jo;

//  //   private Button btn;


//     public int zz=0,start_flag=0;//测试用
//     public int i=0;
// 	public int num=0;

//     // enum BluetoothFlag
//     // {
//     //     CONNECT=1,
//     //     DISCONNECT
//     // }

//     public static int  connectBluetooth = 0;
// 	// Use this for initialization
// 	void Start () {

//         receiverMode = this;
//       // zz = 100;
//      //   jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//      //   jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

// 	}
	
// 	// Update is called once per frame
// 	void Update () {
// 		  i++;

//         if((connectBluetooth == 1)){
//             zz=0;
//             //此处可以做connect button的监听事件



//             start_flag=1;//启动标志
//             connectBluetooth=0;
//         }
//         if(i>20 && start_flag==1) {  //
//         	zz++;
        	
//            // onBtnClickHander();
//             AttentionNum.staticAttention.AddAttentionNum(zz);//测试用
//             i=0;
//         }
	

// 	//	ZZ_TEXT.text = "" + zz.ToString ().PadLeft (3, '0');
// 	}

//     //
//     private void onBtnClickHander()
//     {
//         //调用android中的方法unitycallandroid
//         jo.Call("UnityCallAndroid");
//     }

//     //被android中UnityCallAndroid
//     public void UnityMethod(string str)
//     {
//         Debug.Log("unityMethod被调用，参数：" + str);
//         if(str == "false"){


//         }
//         else{

//         //    ZZ_TEXT.text = str;
//             AttentionNum.staticAttention.AddAttentionNum(num);
//         }
        
//     }

}
