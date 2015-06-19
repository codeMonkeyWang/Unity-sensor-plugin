using UnityEngine;
using System;
using System.Collections;

public class SensorAndroidInterface : SensorInterface {

	AndroidJavaObject sensorClass = null;
	public void Init(){
		sensorClass = new AndroidJavaObject("com.wangwang.sensor.SensorPlugin");
		sensorClass.Call("Init");

	}

	public void GetProximitySensorValue(){
		sensorClass.Call("GetProximitySensorValue");
	}

}
