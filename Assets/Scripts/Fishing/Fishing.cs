using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{

	[SerializeField] private Item[] fishes;
	[SerializeField] private float[] weights;
	[SerializeField] private bool verbose = true;

	private float totalWeight;
	private List<float> thresholds = new List<float>();

    void Awake()
    {
    	totalWeight = 0;
    	foreach (float weight in weights)
    		totalWeight += weight;

    	float threshold = 0;
    	for(int i = 0; i < fishes.Length; i++)
    	{
    		threshold += weights[i] / totalWeight;
    		thresholds.Add(threshold);
    	}
    }

    public void Fish()
    {
    	if (totalWeight >= 0)
    	{
    		float rand = Random.value;

    		if (verbose)
    		{
    			Debug.Log(rand);
    		}

    		for (int i = 0; i < thresholds.Count; i++)
    		{
    			if (rand <= thresholds[i])
    			{
    				Catch(fishes[i]);
    				break;
    			}
    		}
    	}
    }

    private void Catch(Item fish)
    {
    	Inventory.Add(fish);
    	if (verbose)
    		Debug.Log(System.String.Format("Caught a {0}", fish.itemName));
    }
}
