
using UnityEngine;


public class LevelEndZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallController>() != null)
        {
            //build indexte şuankinden sonra gelen ekranı alacak .
            FindObjectOfType<LevelManager>().NextLevel();
            
        }
    }
}
