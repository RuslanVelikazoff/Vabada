using System.Collections;
using UnityEngine;

public class GetDataLevel : MonoBehaviour
{
    [SerializeField]
    private AbilityBar abilityBar;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.2f);
        
        abilityBar.SetAbilityBar();
    }
}
