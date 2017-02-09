using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class TasksStore : Root<TasksStore>
{
	public Dictionary<Type, List<ObjectPool>> PoolListsByCategory = new Dictionary<Type, List<ObjectPool>>();
	public Dictionary<Type, ObjectPool> TaskPoolsByType = new Dictionary<Type, ObjectPool>();

	void Awake()
	{
		base.Awake ();
		FindObjectOfType<BasicLoader> ().Loaded += OnLoad;
	}

	void OnLoad()
	{
		var engine = FindObjectOfType<BasicLoader> ().Engine;
		var tasks = engine.FindTypesCastableTo<Task> ();
		foreach (var taskType in tasks) {
			var taskPoolType = typeof(ObjectPool<>).MakeGenericType (taskType);
			var taskPool = Activator.CreateInstance (taskPoolType) as ObjectPool;
			var task = taskPool.Get () as Task;
			var cat = task.Category;
			taskPool.Return (task);
			var catType = engine.GetType (cat);
			if (catType == null)
				catType = typeof(object);
			PoolListsByCategory.Get (catType).Add (taskPool);
			TaskPoolsByType.Add (taskType, taskPool);

		}

	}
	public void InitAI(GameObject go)
	{
		var agent = go.GetComponent<Agent> ();
		if (agent == null)
			return;
		var allTasks = new Dictionary<Type, ObjectPool> ();
		var poolsByCat = new Dictionary<Type, List<ObjectPool>> ();
		foreach (var listPair in PoolListsByCategory) {
			List<ObjectPool> pools = new List<ObjectPool> ();
			foreach (var pool in listPair.Value) {
				var task = pool.Get () as Task;
				task.Root = go;
				if (task.Filter ()) {
					pools.Add (pool);
					allTasks.Add (task.GetType (), pool);
				} else
					pool.Return (task);
			}
			if (pools.Count > 0)
				poolsByCat.Add (listPair.Key, pools);
		}

		agent.tasksByType = allTasks;
		agent.tasksSet = poolsByCat;
		foreach (var taskPool in allTasks.Values) {
			
			var task = taskPool.Get () as Task;
			if (!task.IsBehaviour) {
				taskPool.Return (task);
				continue;
			}

			var beh = AgentBehaviour.FromTask (agent, task);
			agent.Behaviours.Add (beh);
		}
	}


}

