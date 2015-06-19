using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SensorManager : MonoBehaviour {


	SensorInterface sensor;
	#region static Singleton
	static SensorManager _instance;

	public static SensorManager Instance {
		get {
			if (_instance == null) {
				_instance = new GameObject ("SensorManager").AddComponent<SensorManager> ();
				DontDestroyOnLoad (_instance.gameObject);
			}
			return _instance;
		}
	}

	#endregion

	#region members
	Dictionary<int, System.Action<bool>> _delegates;	
	#endregion


	#region Lyfecycles
	void Awake (){
	#if UNITY_ANDROID
		sensor = new SensorAndroidInterface();
	#elif UNITy_IOS

	#elif UNITY_EDITOR

	#endif
		sensor.Init();
	}

	void OnDestroy ()
	{
		if (_delegates != null) {
			_delegates.Clear ();
			_delegates = null;
		}
	}

//	void Start () {
//	
//	}
//	

//	void Update () {
//	
//	}
	#endregion

	public Action<float>  proximityEvent = null;
	public void getProximityValue(Action<float> del){
		proximityEvent = del;
		sensor.GetProximitySensorValue();
	}


	#region Invoked from Native Plugin
	public void onSensorChanged (string idStr)
	{
		float value =  float.Parse(idStr);
		proximityEvent.Invoke(value);
	}

	public void onAccuracyChanged (string idStr)
	{
//		int id = int.Parse (idStr);
//		if (_delegates.ContainsKey (id)) {
//			_delegates [id] (false);
//			_delegates.Remove (id);
//		} else {
//			Debug.LogWarning ("undefined id:" + idStr);
//		}
	}
	#endregion

}
