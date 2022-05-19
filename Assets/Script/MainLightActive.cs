using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLightActive : MonoBehaviour
{
    [SerializeField]
    int barreleNum;

    Barrel[] barrele;

    List<int> moveBarreleIndex = new List<int>();

    Light mainLight;
    float lightStart;
    float lightGoal;
    float lightTime;
    const float OperationTime = 0.2f;

    int barreleIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        barrele=new Barrel[barreleNum];

        barrele[0] = GameObject.Find("Barrele").GetComponent<Barrel>();

        if (barreleNum != 1)
        {
            for (int i=1;i<barreleNum;i++)
            {
                barrele[i] = GameObject.Find("Barrele ("+i+")").GetComponent<Barrel>();
            }
        }

        moveBarreleIndex.Clear();

        mainLight = GameObject.Find("Directional Light").GetComponent<Light>();
        lightStart = 0;
        lightGoal = 0;
        lightTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int count = moveBarreleIndex.Count;
        barreleIndex = barreleNum;

        for (int i=0;i<barreleNum;i++)
        {
            if (barrele[i] == null)
            {
                barreleIndex =- 1;
            }

            //’M‚ª“®‚¢‚Ä‚¢‚é‚Æ‚«
            if (barrele[i].IsLightFlag)
            {
                //–¢“o˜^‚¾‚Á‚½‚ç
                if (!moveBarreleIndex.Contains(i))
                {
                    //“o˜^‚·‚é
                    moveBarreleIndex.Add(i);

                    //–¾‚é‚¢ó‘Ô‚©‚ç“®‚«o‚µ‚½‚ç’iXˆÃ‚­‚·‚é
                    if (moveBarreleIndex.Count == 1)
                    {
                        if (lightTime == 0.0f)
                        {
                            lightTime = OperationTime;
                        }
                        else
                        {
                            lightTime = OperationTime - lightTime;
                        }

                        lightStart = 1.0f;
                        lightGoal = 0.0f;
                    }
                }
            }

            //“o˜^‚µ‚Ä‚¢‚é’M‚ª‚ ‚ê‚Î
            else if(moveBarreleIndex.Contains(i))
            {
                //Á‚·
                moveBarreleIndex.Remove(i);
            }
        }


        //“®‚¢‚Ä‚¢‚é’M‚ª–³‚¯‚ê‚Î’iX–¾‚é‚­‚·‚é
        if(count > 0 && moveBarreleIndex.Count == 0)
        {
            if (lightTime == 0.0f)
            {
                lightTime = OperationTime;
            }
            else
            {
                lightTime = OperationTime - lightTime;
            }

            lightStart = 0.0f;
            lightGoal = 1.0f;
        }


        if (lightTime > 0)
        {
            lightTime -= Time.deltaTime;
            if(lightTime < 0.0f)
            {
                lightTime = 0.0f;
            }

            //üŒ`•âŠ®‚µ–¾‚é‚­‚µ‚½‚èˆÃ‚­‚·‚é
            mainLight.intensity = Mathf.Lerp(lightStart, lightGoal, (OperationTime - lightTime) / OperationTime);
        }
    }
}
