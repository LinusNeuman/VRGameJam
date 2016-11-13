using UnityEngine;
using System.Collections;

public class waveSimulation : MonoBehaviour {
    [SerializeField]
    private float myMaxWaveAmount;

    private bool paused;
    private Vector3 goals;
    private Vector3 newGoals;
    private Vector3 current;

    public void Pause()
    {
        paused = true;
    }
    public void Unpause()
    {
        paused = false;
    }

	// Use this for initialization
	void Start ()
    {
        paused = false;
        current.x = 0.0f;
        current.y = 0.0f;
        current.z = 0.0f;
        goals.x = myMaxWaveAmount;
        goals.y = myMaxWaveAmount;
        goals.z = myMaxWaveAmount;
        newGoals.x = myMaxWaveAmount;
        newGoals.y = myMaxWaveAmount;
        newGoals.z = myMaxWaveAmount;

        gameObject.transform.Rotate(current);
	}

	// Update is called once per frame
	void Update ()
    {
        if (paused == false)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (goals[i] != newGoals[i])
                {
                    goals[i] += (newGoals[i] - goals[i]) * Time.deltaTime;
                }

                current[i] += goals[i] * Time.deltaTime;

                if ((goals[i] > 0.0f && current[i] >= goals[i]) || ((goals[i] < 0.0f && current[i] <= goals[i])))
                {
                    newGoals[i] = 0.0f;

                    while (newGoals[i] == 0.0f)
                    {
                        newGoals[i] = Random.Range(-myMaxWaveAmount, myMaxWaveAmount);
                    }
                }
            }

            gameObject.transform.rotation = Quaternion.Euler(current);
        }
	}
}
