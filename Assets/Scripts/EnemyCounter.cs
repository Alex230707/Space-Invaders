using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

    public int enemyCounter = 55;
    public GameObject EnemyStagecontrol;
    public Transform Enemy;
    Coroutine StageRefresh;
    private void Update()
    {
        Debug.Log(enemyCounter);
    }
    public void EnemyCounterRefresh()
    {
        enemyCounter--;

        if(enemyCounter<=0)
        {
            NewStage();
        }
    }

    void NewStage()
    {   
        Destroy(EnemyStagecontrol);
        StageRefresh = StartCoroutine(stagerefresh());
        Instantiate(EnemyStagecontrol, Enemy.position, transform.rotation, Enemy);
    }


    IEnumerator stagerefresh ()
    {
        Debug.Log("coroutine iniziata");
        yield return new WaitForSecondsRealtime(2);
        enemyCounter = 55;
        Debug.Log("coroutine finita");
    }

}