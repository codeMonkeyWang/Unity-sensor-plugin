using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SensorTest : MonoBehaviour {


	Text mText ;
	void Start () {
		mText  = GetComponent<Text>();
		SensorManager.Instance.getProximityValue((value)=>{
				mText.text = value +"";

		});
	}
	
	// Update is called once per frame
//	void Update () {
//
//		float X=Input.acceleration.x;  
//		float Y=Input.acceleration.y;  
//		float Z=Input.acceleration.z;
//		if(Z >0.95f){
//			Handheld.Vibrate();
//			mText.text = "down";	
//		}
//
//		if(Z < -0.5f){
//			mText.text = "up";
//		}
//
//	}
}
