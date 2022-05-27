using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(SpriteRenderer))]

public class GeorgePoint : MonoBehaviour
{
    new private SpriteRenderer renderer;

    [SerializeField] private DialogueRunner runner;
    [SerializeField] private FadeSpriteRenderer turtle;

    void Awake() => renderer = GetComponent<SpriteRenderer>();

    void Start()
    {
        bool disabled = false;
        VariableStorage.instance?.TryGetValue<bool>("$weedPulled", out disabled);
        renderer.enabled = !disabled;

        runner.AddCommandHandler("PullWeed", () => renderer.enabled = false);
        runner.AddCommandHandler("CheckFish", CheckFish);
        runner.AddCommandHandler("ShowTurtle", () => turtle.FadeIn());
        runner.AddCommandHandler("UnlockAtlantaCove", UnlockAtlantaCove);
    }

    private void CheckFish()
    {
        VariableStorage.instance?.SetValue("$numCheddarfin", Inventory.GetQuantity("Cheddarfin"));
        VariableStorage.instance?.SetValue("$numFlutterfly", Inventory.GetQuantity("Flutterfly"));
        VariableStorage.instance?.SetValue("$numPopsnapper", Inventory.GetQuantity("Popsnapper"));
        VariableStorage.instance?.SetValue("$hasFishPerfume", Inventory.GetQuantity("Fish Perfume") > 0);
    }

    private void UnlockAtlantaCove()
    {
        AtlantaCoveManager.unlocked = true;
        SceneLoader.instance?.LoadScene("Atlanta Cove");
    }
}
