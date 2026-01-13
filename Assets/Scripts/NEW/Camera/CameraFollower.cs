using UnityEngine;
using DG.Tweening;

public class CameraFollower : MonoBehaviour
{

    private GameObject follower;
    private float rangeCamera = 10f;
    public void SetFollower(GameObject g)
    {
        follower = g;
        UpdateFollower();
    }

    public void UpdateFollower()
    {
        Camera.main.transform.position = follower.transform.position + Vector3.up * rangeCamera;
        Camera.main.transform.LookAt(follower.transform.position);
    }

    public void ZoomDown()
    {
        rangeCamera = Mathf.Clamp(rangeCamera + 1, 2f, 20f);
        UpdateFollower();
    }
    public void ZoomUp()
    {
        rangeCamera = Mathf.Clamp(rangeCamera - 1, 2f, 20f);
        UpdateFollower();
    }
}
