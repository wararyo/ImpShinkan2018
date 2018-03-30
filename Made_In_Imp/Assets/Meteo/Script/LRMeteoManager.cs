using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRMeteoManager : MonoBehaviour {

	public GameObject meteo;
	public int meteoMAX;
	public float FirstDelayTime;
	private GameObject[] L_unsa;
	private GameObject[] R_unsa;
	private bool[] flag;
	private float[] x;
	private float[] y;
	private float count = 0;

	// Use this for initialization
	void Start () {
		L_unsa = new GameObject[meteoMAX];
		R_unsa = new GameObject[meteoMAX];
		flag = new bool[meteoMAX];
		x = new float[meteoMAX];
		y = new float[meteoMAX];

		for (int i = 0; i < meteoMAX; i++) {
			L_unsa [i] = meteo;
			R_unsa [i] = meteo;
			do {
				x [i] = Random.Range (-6.5f, 6.5f);
				y [i] = Random.Range (-6.5f, 6.5f);
			} while(x [i] > -6 && x [i] < 6 && y [i] > -6 && y [i] < 6);
		}
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		for (int i = 0; i < meteoMAX; i++) {
			if (count > i*1.5+FirstDelayTime) {
				if (!flag[i]) {
					Instantiate (L_unsa [i], new Vector3 (x [i], y [i], 0), Quaternion.identity);
					L_unsa[i].layer = 8;
					Instantiate (R_unsa [i], new Vector3 (x [i], y [i], 0), Quaternion.identity);
					R_unsa[i].layer = 9;
					flag [i] = true;
				}
			}
		}
	}
}
