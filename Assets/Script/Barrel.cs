using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour
{
    float oldPosX;

    float count;

    
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

        if(oldPosX != transform.position.x && count >= 1.0f)
        {
            //コントローラー振動
            StartVibration(0.1f, 0.7f, 1f);
            count=0.0f; 
            rb.velocity = new Vector3(Mathf.Clamp((rb.velocity.x * speed),-speed,speed),rb.velocity.y, rb.velocity.z);
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
