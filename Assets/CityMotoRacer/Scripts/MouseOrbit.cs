using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Orbit")]
public class MouseOrbit : MonoBehaviour
{   
    public Transform target;
    public float distance = 10.0f;//相机距对象距离
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    public int yMinLimit = -20;
    public int yMaxLimit = 80;
    private float x = 0.0f;
    private float y = 0.0f;

    //public Camera cam;

    public bool isDrag = false;
    public Event mouseEvent;

    public Quaternion rotation;
    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
		
		// scale = distance / height ;
        //  = gameObject.GetComponent(Camera);

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
		
		Time.timeScale=1;

    }


    void OnGUI(){

        if(  Event.current.type == EventType.MouseDrag)
        {
            isDrag=true;
        }
        else isDrag=false;
    }


    // Update is called once per frame
    void Update()
    {

        if( isDrag){ 
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            
            y = ClampAngle(y, yMinLimit, yMaxLimit);
                
            rotation= Quaternion.Euler(y, x, 0);
            position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
            
            transform.rotation = rotation;
            transform.position = position;
        }
        else{
        
            x += 0.1f * xSpeed * 0.02f;
            y -= 0;//Input.GetAxis("Mouse Y") * ySpeed * 0.02;
            
            y = ClampAngle(y, yMinLimit, yMaxLimit);
                
            rotation = Quaternion.Euler(y, x, 0);
            position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
            
            transform.rotation = rotation;
            transform.position = position;
        
        
        }

    }

    static float ClampAngle (float angle, float min,float max) {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp (angle, min, max);
    }


}
