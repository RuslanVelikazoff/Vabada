using System.Collections;
using UnityEngine;

public class StartGamePanel : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        
        this.gameObject.SetActive(false);
    }
}
