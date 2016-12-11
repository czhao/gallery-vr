using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPictureLoader : MonoBehaviour {

	public string url = "http://images.fineartamerica.com/images-medium-large/homage-to-picasso-john-nolan.jpg";

	IEnumerator Start () {
		Texture2D tex;
		tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
		WWW www = new WWW(url);
		Debug.Log ("loading images");
		yield return www;
		www.LoadImageIntoTexture(tex);
		GetComponent<Renderer>().material.mainTexture = tex;
		Debug.Log ("load image done");
	}
		
}
