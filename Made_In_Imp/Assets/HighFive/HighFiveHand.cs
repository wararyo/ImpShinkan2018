using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFiveHand : MonoBehaviour {

    public Vector3 startPoint, endPoint;
    public float target = 0.5f;
    public float speed = 2;
    [Tooltip("ハイタッチ判定の誤差範囲")]
    public float errorRange = 0.1f;
    float currentPosition = 0;
    bool isReversing = false;

    public AudioClip succeedSound, failedSound;

    /// <summary>
    /// ハイタッチをします。成功したらtrueを返します。
    /// </summary>
    /// <returns>ハイタッチに成功したかどうか</returns>
    public bool HighFive()
    {
        float error = Mathf.Abs(currentPosition - target);
        if(error <= errorRange)
        {
            GetComponent<AudioSource>().PlayOneShot(succeedSound);
            return true;
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(failedSound);
            return false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPoint, endPoint);
        Gizmos.DrawSphere(startPoint, 0.4f);
        Gizmos.DrawSphere(endPoint, 0.4f);
        Gizmos.DrawSphere(Vector3.Lerp(startPoint,endPoint,target), 0.8f);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentPosition += (isReversing ? -speed : speed) * Time.deltaTime;
        if(0 >= currentPosition || currentPosition >= 1)
        {
            currentPosition = Mathf.Clamp01(currentPosition);
            isReversing = !isReversing;
        }
        transform.position = Vector3.Lerp(startPoint, endPoint, currentPosition);

    }
}
