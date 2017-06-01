using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    private bool ShotF;//角度変更中か否か判定フラグ

	void Update () {

        //ロングタップ開始時角度変更を止める
        if (Input.GetButtonDown("Fire1")){
            ShotF = !ShotF;
        }

        if (ShotF){
            Debug.Log("発射するセリフの種類を決めています。");
        }
        else{
            Debug.Log("セリフを発射する角度を変えています。");
        }
	}
}
