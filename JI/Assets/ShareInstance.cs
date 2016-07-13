using UnityEngine;
using System.Collections;
using cn.sharesdk.unity3d;
public class ShareInstance : MonoBehaviour 
{
	private ShareSDK ssdk;
	public static ShareInstance Instance;
	// Use this for initialization
	void Start () 
	{Instance = this;
		ssdk = GetComponent<ShareSDK> ();
		if (ssdk == null) 
		{
			ssdk = gameObject.AddComponent<ShareSDK> ();
		}
	}

	public void OnkeyShare(string Title,string Content,string url,int contenttype)
	{
		PlatformType[] platforms = new PlatformType[] {
			PlatformType.WeChat,
			PlatformType.QQ,
			PlatformType.SinaWeibo
		};
		ShareContent content = new ShareContent();
		content.SetText(Content);
		content.SetImagePath(url);
		content.SetTitle(Title);
		content.SetComment(Content);
		content.SetShareType(ContentType.Image);
//		content.SetText("this is a test string.");
//		content.SetImageUrl("https://f1.webshare.mob.com/code/demo/img/1.jpg");
//		content.SetTitle("test title");
//		content.SetTitleUrl("http://www.mob.com");
//		content.SetSite("Mob-ShareSDK");
//		content.SetSiteUrl("http://www.mob.com");
//		content.SetUrl("http://www.mob.com");
//		content.SetComment("test description");
//		content.SetMusicUrl("http://mp3.mwap8.com/destdir/Music/2009/20090601/ZuiXuanMinZuFeng20090601119.mp3");
//		content.SetShareType(ContentType.Image);
		ssdk.ShowPlatformList (platforms,content,100,100);
	}



}
