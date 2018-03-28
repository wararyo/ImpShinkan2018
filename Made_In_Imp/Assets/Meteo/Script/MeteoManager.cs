using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoManager : MonoBehaviour {

	public GameObject meteo;
	public int meteoMAX;
	public float FirstDelayTime;
	public float interval;
	private GameObject[] unsa;
	private bool[] flag;
	private float[] x;
	private float[] y;
	private float count = 0;

	// Use this for initialization
	void Start () {
		unsa = new GameObject[meteoMAX];
		flag = new bool[meteoMAX];
		x = new float[meteoMAX];
		y = new float[meteoMAX];

		for (int i = 0; i < meteoMAX; i++) {
			unsa[i] = meteo;
			do {
				x [i] = Random.Range (-7, 7);
				y [i] = Random.Range (-7, 7);
			} while(x[i] > -6 && x[i] < 6 && y[i] > -6 && y[i] < 6);
			//flag [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		for (int i = 0; i < meteoMAX; i++) {
			if (count > i*interval + FirstDelayTime && !flag [i]) {
				Instantiate (unsa [i], new Vector3 (x [i], y [i], 0), Quaternion.identity);
				flag [i] = true;
			}
		}
	}
}
