using Assets.Modifiers;
using UnityEngine;

public class ModifierViewTester : MonoBehaviour
{
    [SerializeField] private ModifierView modifierViewPrefab;
    [SerializeField] private Transform parent;   // UI parent under your Canvas

    private void Start()
    {
        StartCoroutine(SpawnAfterDelay());
    }

    private System.Collections.IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(5f);

        // Create a test modifier (backend)
        ModifierBase testModifier = new EnemyHealthModifier();

        // Spawn the UI prefab (frontend)
        ModifierView view = Instantiate(modifierViewPrefab, parent);
        if(view.enabled == false)
        {
            Debug.LogError("ModifierView prefab is disabled. Please enable it to see the test.");
            yield break;
        }
        view.enabled = true;

        Debug.Log("About to bind");
        // Bind backend → frontend
        view.Bind(testModifier);
    }
}