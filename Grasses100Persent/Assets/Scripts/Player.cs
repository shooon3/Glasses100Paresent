using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //メッセージ
    private float ShotPow;//セリフ変更判定用変数
    private float AddPow;//判定用変数変化量
    private float SmolerPow;//判定：ちいさくなーれ
    private float BiggerPow;//判定：おおきくなーれ

    private string[] MassageText = { "ちいさくなーれ", "こわれろー", "おおきくなーれ" };
    private string ShotMassageText;//発射するメッセージ


    //発射角
    private float ShotDeg;//発射角
    private float AddDeg;//角度変化量
    private float MaxDeg;//角度最大値
    private float MinDeg;//角度最小値

    //ゲームオブジェクト
    public GameObject Massage;//セリフ
    public Sprite SmollerMassage;//ちいさくなーれ
    public Sprite BreakMassge;//こわれろー
    public Sprite BiggerMassage;//おおきくなーれ

    //発射角変更メソッド
    public void DegChanger(){
        //発射角が範囲を超えた場合加算量の符号を反転
        if(ShotDeg > MaxDeg){
            ShotDeg = MaxDeg;
            AddDeg = -AddDeg;
        }
        else if(ShotDeg < MinDeg){
            ShotDeg = MinDeg;
            AddDeg = -AddDeg;
        }

        //発射角に変化量を加算
        ShotDeg += AddDeg;

        Debug.Log("発射角を変更しています。");
        Debug.Log(string.Format("発射角：{0}",ShotDeg));
    }

    //セリフ配置メソッド
    public void MassageSet(){
        Debug.Log("セリフを配置しました。");
    }

    //セリフ変更メソッド
    public void MassageChange(){
        ShotPow += AddPow;//パワー加算

        //ShotPowの値でメッセージ変更
        int index = 2;
        if(ShotPow < SmolerPow){//基準値以下
            index = 1;
        }
        else if(ShotPow > BiggerPow){//基準値以上
            index = 3;
        }
        //ShotMassageText = MassageText[index];
        //現在のセリフの種類によって大きさを変更
        //現在のセリフの種類によってテキストを変更

        Debug.Log("セリフを変更しています。");
        Debug.Log(string.Format("発射するセリフ：{0}"), ShotMassageText);
    }

    //セリフ発射メソッド
    public void Shot(){
        //インスタンス化されたセリフにAddForceする。
        Debug.Log("セリフを発射します。");
    }
}
