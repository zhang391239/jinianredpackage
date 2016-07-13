using UnityEngine;
using System;
using System.Collections;
using System.Threading;
using System.IO;
using System.Reflection;
public class ShootPicture : MonoBehaviour {
	private int texWidth,texHeight;
	Texture2D tex;
	private byte[] byts;
	private string path;
	// Use this for initialization
	void Start () {
		texWidth = Screen.width;
		texHeight = Screen.height;
		#if UNITY_ANDROID
		AndroidBrige.Init ();
		path = AndroidBrige.externalStorageDirectory+"/Icon.jpg";
		#elif UNITY_IPHONE
		#else
		path = Application.persistentDataPath + "/Icon.jpg";
		#endif
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SaveImage()
	{
		File.WriteAllBytes (path, byts);

	}

	IEnumerator ShootPic()
	{
		yield return new WaitForEndOfFrame();
		texWidth = Screen.width;
		texHeight = Screen.height;

		tex = new Texture2D (texWidth,texHeight,TextureFormat.RGB24,false);
		tex.ReadPixels (new Rect (0, 0, texWidth, texHeight), 0, 0, true);
		byts = tex.EncodeToJPG (100);
		Thread thread = new Thread (SaveImage);
		thread.Start ();
		yield return new WaitForSeconds (1);
		ShareInstance.Instance.OnkeyShare ("分享图片", "我在鸡年红包app中拍了一张图片", path, 0);
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(50,50,200,40),"拍照"))
		{
			StartCoroutine(ShootPic ());
		}
	}
}
