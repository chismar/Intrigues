using UnityEngine;
using System.Collections;
using System.Text;

public class GenerationMarker : MonoBehaviour
{

    private void Awake()
    {
        StartCoroutine(WaitCoroutine());
    }
    StringBuilder builder = new StringBuilder();
    IEnumerator WaitCoroutine()
    {
        yield return null;
        while (!Actions.Instance.Loaded)
            yield return null;
        yield return Actions.Instance.GenerateCoroutine(gameObject, 0.1f);
        MetricsManager.Instance.InitMetrics(gameObject);
        EventsManager.Instance.InitReactions(gameObject);
		TasksStore.Instance.InitAI (gameObject);

        Actor actor = gameObject.GetComponent<Actor>();

        builder.Length = 0;
        if (actor != null)
        {
            builder.Append("Actor: ").AppendLine(gameObject.name);
            while (!Actions.Instance.Loaded)
                yield return null;
            builder.Append("actions:").AppendLine();
            actor.actionsSet = Actions.Instance.FormActionsSet(gameObject);
            foreach (var cat in actor.actionsSet)
                foreach (var action in cat.Value)
                {
                    builder.Append(action.GetType().Name).AppendLine();
                    actor.allActions.Add(action);
                    
                }
            builder.Append("interactions:").AppendLine();
            actor.interactionsSet = Actions.Instance.FormInteractionsSet(gameObject);
            foreach (var cat in actor.interactionsSet)
                foreach (var action in cat.Value)
                {
                    builder.Append(action.GetType().Name).AppendLine();
                    actor.allInteractions.Add(action);

                }

            Debug.Log(builder.ToString());
        }

        Destroy(this);
    }
}
