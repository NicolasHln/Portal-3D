using UnityEngine;

public class PortalcameraB : MonoBehaviour
{
	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;

	// Update is called once per frame
	void Update()
	{
		// a Vector3 represetin the difference of the player position and the portal position
		Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;

		Vector3 swp = playerOffsetFromPortal;
		
		// change the position of the camera of the portal compared to the rotation of the other portal
		if(otherPortal.rotation.y > 0.99 && otherPortal.rotation.y < 1.01)
		{
			if(transform.rotation.y > 0.707 && transform.rotation.y < 0.708)
			{
				playerOffsetFromPortal = new Vector3(-swp.z, swp.y, swp.x);
			}
			if(transform.rotation.y > -0.708 && transform.rotation.y < -0.707)
			{
				playerOffsetFromPortal = new Vector3(swp.z, swp.y, swp.x);
			}
			if(transform.rotation.y > -0.01 && transform.rotation.y < 0.01)
			{
				playerOffsetFromPortal = new Vector3(swp.x, swp.y, -swp.z);
			}
		}

		if (otherPortal.rotation.y > 0.707 && otherPortal.rotation.y < 0.708)
		{
			if (transform.rotation.y > 0.99 && transform.rotation.y < 1.01)
			{
				playerOffsetFromPortal = new Vector3(swp.z, swp.y, -swp.x);
			}
			if (transform.rotation.y > -0.01 && transform.rotation.y < 0.01)
			{
				playerOffsetFromPortal = new Vector3(swp.z, swp.y, swp.x);
			}
			if (transform.rotation.y > -0.708 && transform.rotation.y < -0.707)
			{
				playerOffsetFromPortal = new Vector3(-swp.x, swp.y, swp.z);
			}
		}

		if (otherPortal.rotation.y > -0.708 && otherPortal.rotation.y < -0.707)
		{
			if (transform.rotation.y > 0.99 && transform.rotation.y < 1.01)
			{
				playerOffsetFromPortal = new Vector3(swp.z, swp.y, swp.x);
			}
			if (transform.rotation.y > -0.01 && transform.rotation.y < 0.01)
			{
				playerOffsetFromPortal = new Vector3(swp.z, swp.y, -swp.x);
			}
			if (transform.rotation.y > 0.707 && transform.rotation.y < 0.708)
			{
				playerOffsetFromPortal = new Vector3(-swp.x, swp.y, swp.z);
			}
		}

		if (otherPortal.rotation.y > -0.01 && otherPortal.rotation.y < 0.01)
		{
			if (transform.rotation.y > 0.707 && transform.rotation.y < 0.708)
			{
				playerOffsetFromPortal = new Vector3(swp.z, swp.y, swp.x);
			}
			if (transform.rotation.y > -0.708 && transform.rotation.y < -0.707)
			{
				playerOffsetFromPortal = new Vector3(-swp.z, swp.y, swp.x);
			}
			if (transform.rotation.y > 0.99 && transform.rotation.y < 1.01)
			{
				playerOffsetFromPortal = new Vector3(swp.x, swp.y, -swp.z);
			}
		}

		// the camera of the portal follow the movements of the player
		Vector3 pos = portal.position + playerOffsetFromPortal / 2;
		transform.position = pos;
	}
}
