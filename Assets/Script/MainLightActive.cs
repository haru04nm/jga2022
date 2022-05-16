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

    GameObject breakWall;
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

        breakWall = GameObject.Find("Wall_break").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int count = moveBarreleIndex.Count;

        for (int i=0;i<barreleNum;i++)
        {
            //壁が壊れてない＋樽が動いているとき
            if (breakWall != null && barrele[i].IsLightFlag)
            {
                //一つでも動いていなかったら
                if (!moveBarreleIndex.Contains(i))
                {
                    //＋1する
                    moveBarreleIndex.Add(i);

                    //もし動いている奴一つでもあれば段々暗くする
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

            //リストの中身があれば
            else if(moveBarreleIndex.Contains(i))
            {
                //けしていく
                moveBarreleIndex.Remove(i);
            }
        }


        //動いているやつも無ければ段々明るくする
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

            //線形補完し明るくしたり暗くしたりする
            mainLight.intensity = Mathf.Lerp(lightStart, lightGoal, (OperationTime - lightTime) / OperationTime);
        }
    }
}
