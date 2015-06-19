package com.wangwang.sensor;

import android.app.Activity;
import android.content.Context;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;

import com.unity3d.player.UnityPlayer;

public class SensorPlugin {

	
	private SensorManager sensorManager;
	private Activity active ;
	private Sensor sensor;
	
	public void Init(){
		active = UnityPlayer.currentActivity;
		sensorManager = (SensorManager)active.getSystemService(Context.SENSOR_SERVICE);
		sensor = sensorManager.getDefaultSensor(Sensor.TYPE_PROXIMITY);

	}
	
	public void GetProximitySensorValue(){
		SensorEventListener lsn = new SensorEventListener() {
			
			@Override
			public void onSensorChanged(SensorEvent event) {
				float distance = event.values[0];
				UnityPlayer.UnitySendMessage("SensorManager","onSensorChanged",distance+"");
			}
			
			@Override
			public void onAccuracyChanged(Sensor sensor, int accuracy) {
//				UnityPlayer.UnitySendMessage("SensorManager", "onAccuracyChanged", "");
			}
		};
		sensorManager.registerListener(lsn, sensor, SensorManager.SENSOR_DELAY_GAME);
	}
	
}
