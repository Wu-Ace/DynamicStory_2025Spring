using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Debug.Log("Pacman进入了Home！");
            GameManager.Instance.PacmanEnteredHome();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Debug.Log("Pacman离开了Home！");
            GameManager.Instance.PacmanLeftHome();
        }
    }
}
