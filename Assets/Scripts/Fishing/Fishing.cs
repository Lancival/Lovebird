using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [System.Serializable]
    public struct FishWeight
    {
        public Item fish;
        public float weight;
    }

	[SerializeField] private FishWeight[] fishes;
	[SerializeField] private bool verbose = true;

	private float totalWeight;
	private List<float> thresholds = new List<float>();

    void Awake()
    {
    	totalWeight = 0;
    	foreach (FishWeight fish in fishes)
        {
    		totalWeight += fish.weight;
            thresholds.Add(totalWeight);
        }
    }

    public void Fish()
    {
    	if (totalWeight > 0)
    	{
    		float rand = Random.value * totalWeight;

    		if (verbose)
    		{
    			Debug.Log(rand);
    		}

    		for (int i = 0; i < thresholds.Count; i++)
    		{
    			if (rand <= thresholds[i])
    			{
    				Catch(fishes[i].fish);
    				break;
    			}
    		}
    	}
    }

    private void Catch(Item fish)
    {
    	Inventory.Add(fish);
    	if (verbose)
        {
    		Debug.Log(System.String.Format("Caught a {0}", fish.itemName));
        }
    }
}
