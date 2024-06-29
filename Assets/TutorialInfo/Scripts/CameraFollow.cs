using UnityEngine; 

public class Follow_player: MonoBehaviour { 
    public Transform player; 

    void Update () { 

        float xCamMove = Input.GetAxisRaw("Mouse X"); 
        float yCamMove = Input.GetAxisRaw("Mouse Y"); 
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}

