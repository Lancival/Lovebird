using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : Interactable
{
    [System.Serializable]
    public struct FishWeight
    {
        public Item fish;
        public float weight;
    }

	[SerializeField] private FishWeight[] fishes;
    [SerializeField] private bool requirePerfume = true;

	private float totalWeight;
	private List<float> thresholds = new List<float>();

    new void Awake()
    {
        base.Awake();
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

    private void Catch(Item fish) => Inventory.Add(fish);

    public override void Interact()
    {
        if (!requirePerfume || Inventory.GetQuantity("Fish Perfume") > 0)
        {
            Fish();
        }
    }
}
