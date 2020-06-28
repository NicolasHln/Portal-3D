using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
	public Camera cameraB;
	public Camera cameraO;

	public Material cameraMatB;
	public Material cameraMatO;

	// Use this for initialization
	void Start()
	{
		if (cameraB.targetTexture != null)
		{
			cameraB.targetTexture.Release();
		}
		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatB.mainTexture = cameraB.targetTexture;

		if (cameraO.targetTexture != null)
		{
			cameraO.targetTexture.Release();
		}
		cameraO.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatO.mainTexture = cameraO.targetTexture;
	}
}
