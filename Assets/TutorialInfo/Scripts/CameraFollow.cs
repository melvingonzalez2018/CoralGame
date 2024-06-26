using UnityEngine; 

public class Follow_player: MonoBehaviour { 
    public Transform player; 

    void Update () { 
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}