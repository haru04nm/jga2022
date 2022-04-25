using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour
{
    float oldPosX;

    float count;

    [SerializeField]
    GameObject spotLight;

    [SerializeField]
    Transform mainLight;
    
    float speed=3.5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        rb= this.gameObject.GetComponent<Rigidbody>();
        count += Time.deltaTime;

        //spotLight　OFF
        //spotLight.SetActive(false);

        mainLight.transform.rotation = new Quaternion(30, -30,0,0);

        if(oldPosX != transform.position.x)
        {

            if (count >= 1.0f)
            {
                //コントローラー振動
                StartVibration(0.1f, 0.7f, 1f);
                count=0.0f; 
            }
            
            rb.velocity = new Vector3(Mathf.Clamp((rb.velocity.x * speed),-speed,speed),rb.velocity.y, rb.velocity.z);

            //spotLight　ON
            spotLight.SetActive(true);
            spotLight.transform.position = new Vector3(transform.position.x, /*this.transform.position.y+*/spotLight.transform.position.y, spotLight.transform.position.z);

            mainLight.transform.rotation = new Quaternion(180, 30, 0, 0);
        }

        oldPosX = transform.position.x;
    }

    //コントローラー振動
    public void Vibration(float l, float r)
    {
        Gamepad.current.SetMotorSpeeds(l, r);
    }

    public void StopVibration()
    {
        Gamepad.current.SetMotorSpeeds(0, 0);
    }
    private IEnumerator LoopVibration(float t, float l, float r)
    {
        Gamepad.current.SetMotorSpeeds(l, r);
        yield return new WaitForSeconds(t);
        //StopVibration();
    }

    public void StartVibration(float t, float l, float r)
    {
        StartCoroutine(LoopVibration(t, l, r));
        StopVibration();
    }

}
