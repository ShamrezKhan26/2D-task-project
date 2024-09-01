using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float timetodestroy=2;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(timetodestroy);
        Destroy(gameObject);
    }

   
}
