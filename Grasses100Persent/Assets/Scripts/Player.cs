using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //メッセージ変更用変数
    public float ShotPow;//セリフ変更判定用変数
    private float AddPow;//判定用変数変化量
    private float SmolerPow = 30;//判定：ちいさくなーれ
    private float BiggerPow = 60;//判定：おおきくなーれ

    //発射角
    private float ShotDeg;//発射角
    public float AddDeg;//角度変化量
    public float MaxDeg;//角度最大値
    public float MinDeg;//角度最小値

    //セリフ速度
    public float ShotSpeed;

    //ゲームオブジェクト
    public GameObject MassagePre;//セリフプレファブ
    private GameObject Massage;//セリフ

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

        //キャラクターの角度を変更
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, ShotDeg));

        Debug.Log("発射角を変更しています。");
        Debug.Log(string.Format("発射角：{0}",ShotDeg));
    }

    //セリフ配置メソッド
    public void MassageSet(){
        Massage = Instantiate(MassagePre,transform.position,Quaternion.identity) as GameObject;//セリフを生成
        Debug.Log("セリフを配置しました。");
    }

    //セリフ変更メソッド
    public void MassageChange(){
        //ShotPowの範囲は0～100
        if (ShotPow <= 0 || ShotPow >= 100){
            AddPow = -AddPow;
        }

        ShotPow += AddPow;//パワー加算

        //ShotPowの値でメッセージ変更
        Massage.GetComponent<MassageStatus>().Janle = MassageStatus.PMJanle.Berak;
        if (ShotPow < SmolerPow){//基準値以下
            Massage.GetComponent<MassageStatus>().Janle = MassageStatus.PMJanle.Smoler;
        }
        else if(ShotPow > BiggerPow){//基準値以上
            Massage.GetComponent<MassageStatus>().Janle = MassageStatus.PMJanle.Bigger;
        }
    }

    //セリフ発射メソッド
    public void Shot(){
        //インスタンス化されたセリフにAddForceする。
        float ShotRad = ShotDeg * Mathf.Deg2Rad;//ラジアン変換
        Vector2 ShotVec = new Vector2(Mathf.Cos(ShotRad), Mathf.Sin(ShotRad));//角度計算
        Massage.GetComponent<Rigidbody2D>().velocity = ShotVec * ShotSpeed;
        Debug.Log("セリフを発射します。");
        //発射後、弾がずれるところは止まることで解決
    }
}
