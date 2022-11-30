using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public Transform Player;
    Vector3 Target;
    public float TrackingSpeed = 1.5f;
    
    void Update()
    {
        if(Player)
        {
            Target = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
            Vector3 currentPosition = Vector3.Lerp(transform.position, Target, TrackingSpeed * Time.deltaTime);
            currentPosition.z = transform.position.z;
            transform.position = currentPosition;
        }

    }
}
