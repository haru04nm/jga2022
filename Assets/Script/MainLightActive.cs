using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLightActive : MonoBehaviour
{
    Barrel[] barrele;

    List<int> moveBarreleIndex = new List<int>();

    Light mainLight;
    float lightStart;
    float lightGoal;
    float lightTime;
    const float OperationTime = 0.2f;

    int barreleNum;

    int barreleIndex =0;
    // Start is called before the first frame update
    void Start()
    {
        barreleNum = GameObject.Find("OtherIndex").GetComponent<OtherIndex>().IsBarreleIndex;

        barrele =new Barrel[barreleNum];

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

            //樽が動いているとき
            if (barrele[i].IsLightFlag)
            {
                //未登録だったら
                if (!moveBarreleIndex.Contains(i))
                {
                    //登録する
                    moveBarreleIndex.Add(i);

                    //明るい状態から動き出したら段々暗くする
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

            //登録している樽があれば
            else if(moveBarreleIndex.Contains(i))
            {
                //消す
                moveBarreleIndex.Remove(i);
            }
        }


        //動いている樽が無ければ段々明るくする
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

            //線形補完し明るくしたり暗くする
            mainLight.intensity = Mathf.Lerp(lightStart, lightGoal, (OperationTime - lightTime) / OperationTime);
        }
    }
}
