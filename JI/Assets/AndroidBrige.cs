using UnityEngine;
using System.Collections;
using System.IO;
public class AndroidBrige  {
	public static string externalStorageDirectory {
		get;
		private set;
	}
	private AndroidJavaClass jclassEnvironment;
	private AndroidJavaObject jobjFile;
	public static string GetExternalStorageDirectory()
	{
		return "";
	}
	public static void Init()
	{
		AndroidJavaClass jclassEnvironment = new AndroidJavaClass("android.os.Environment");
		AndroidJavaObject jobjFile = jclassEnvironment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory");
		externalStorageDirectory = jobjFile.Call<string>("getAbsolutePath")+"/RedPackage";
		if (Directory.Exists (externalStorageDirectory)) {
		}
		else 
		{
			Directory.CreateDirectory (externalStorageDirectory);
		}
	}
}
