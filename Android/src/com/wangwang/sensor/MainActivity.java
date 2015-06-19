package com.wangwang.sensor;

import android.app.Activity;
import android.content.Context;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.os.Bundle;
import android.widget.TextView;

public class MainActivity extends Activity {

	private SensorManager sensorManager;
	private TextView sensorText;
		
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		sensorText = (TextView) findViewById(R.id.sensorText);	
		
		sensorManager = (SensorManager)getSystemService(Context.SENSOR_SERVICE);
		Sensor sensor = sensorManager.getDefaultSensor(Sensor.TYPE_PROXIMITY);
		
		
		SensorEventListener lsn = new SensorEventListener() {
			
			@Override
			public void onSensorChanged(SensorEvent event) {
				
				sensorText.setText(event.values[0]+"");
			}
			
			@Override
			public void onAccuracyChanged(Sensor sensor, int accuracy) {

			}
		};
		sensorManager.registerListener(lsn, sensor, SensorManager.SENSOR_DELAY_GAME);
	
	
	}
}
