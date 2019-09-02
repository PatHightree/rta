using UnityEngine;
using SpaceNavigatorDriver;

public class FlyAround : MonoBehaviour {
    public Transform TargetCamera;
	public bool HorizonLock = true;

	public void Update () {
        if (TargetCamera != null)
        {
            transform.Translate(TargetCamera.TransformVector(SpaceNavigator.Translation), Space.World);
            transform.RotateAround(TargetCamera.position, TargetCamera.up, SpaceNavigator.Rotation.Yaw() * Mathf.Rad2Deg);
            transform.RotateAround(TargetCamera.position, TargetCamera.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg);
            if (!HorizonLock)
                transform.RotateAround(TargetCamera.position, TargetCamera.forward, SpaceNavigator.Rotation.Roll() * Mathf.Rad2Deg);
        }
        else
        {
            transform.Translate(SpaceNavigator.Translation, Space.Self);

            if (HorizonLock)
            {
                // This method keeps the horizon horizontal at all times.
                // Perform azimuth in world coordinates.
                transform.Rotate(Vector3.up, SpaceNavigator.Rotation.Yaw() * Mathf.Rad2Deg, Space.World);
                // Perform pitch in local coordinates.
                transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg, Space.Self);
            }
            else
            {
                transform.Rotate(SpaceNavigator.Rotation.eulerAngles, Space.Self);
            }
        }
	}
}
