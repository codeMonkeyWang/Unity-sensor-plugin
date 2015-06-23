# Unity sensor Plugin 

* 这是一个用来获取手机传感器数据的Unity插件。暂时只支持安卓

## 目前已经支持的传感器
1. 距离传感器


## How to use
1. import `UnitySensorPlugin.unitypackage `

2. Create Script

Example:

``` csharp

Text mText ;
void Start () {
	mText  = GetComponent<Text>();
	SensorManager.Instance.getProximityValue((value)=>{
			if(value ==0){
				Debug.Log("proximity");
				mText.text = "proximity";
			}else{
				Debug.Log("normal");
				mText.text = "normal";
			}
	});
}

```