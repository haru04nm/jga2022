using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRay : MonoBehaviour
{

    Rigidbody rbody;

    public static bool adhesionFlag;
    bool rayFlag;

    Move player;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Move>();
    }

    private void FixedUpdate()
    {
        // ínñ Ç…ê⁄ínÇµÇƒÇ¢Ç»Ç¢èÍçáisKinematicÇfalseÇ…Ç∑ÇÈ
        rayFlag = Physics.Raycast(this.gameObject.transform.position, Vector3.down, 0.7f);
        
        if (rayFlag == false && adhesionFlag == false)
        {
            rbody.GetComponent<Rigidbody>().isKinematic = false;
        }

        if (player.IsHakoHit)
        {
            rbody.GetComponent<Rigidbody>().mass = 1000;
            rbody.GetComponent<Rigidbody>().isKinematic = true;
            player.IsHakoHit = false;
        }
       
        Debug.DrawRay(this.gameObject.transform.position, Vector3.down, Color.yellow);
    }
}
