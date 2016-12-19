namespace ScriptedTypes {
    
    
    public interface lit_up_room {
    }
    
    public interface base_scenario {
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=false, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=true)]
    public class interaction_lit_up_manual : EventAction, EventInteraction {
        
        private UnityEngine.GameObject initiator;
        
        UnityEngine.GameObject EventInteraction.Initiator {
            get {
return initiator; 
            }
            set {
initiator = value; 
            }
        }
        
        public override bool Interaction() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar1 = default(System.Boolean); //IsContext = False IsNew = False
			Manual StoredVariable0 = ((Manual)root.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
			if(StoredVariable0 != null)
			{
				applicable = true;
				OperandVar1 = applicable;
			}
			return (System.Boolean) (OperandVar1);
		}
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar8 = default(System.Boolean); //IsContext = False IsNew = False
			Interactable StoredVariable2 = ((Interactable)root.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
			if(StoredVariable2 != null)
			{
				LightSource StoredVariable3 = ((LightSource)StoredVariable2.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable3 != null)
				{
					ManualController StoredVariable4 = ((ManualController)StoredVariable3.GetComponent(typeof(ManualController))); //IsContext = False IsNew = False
					if(StoredVariable4 != null)
					{
						System.Boolean ifResult5; //IsContext = False IsNew = False
						System.Boolean OperandVar7 = default(System.Boolean); //IsContext = False IsNew = False
						if(StoredVariable3 != null)
						{
							System.Boolean prop6 = StoredVariable3.LitUp; //IsContext = False IsNew = False
							OperandVar7 = prop6;
						}
						if(ifResult5 = !(OperandVar7))
						{
							applicable = true;
							OperandVar8 = applicable;
						}
					}
				}
			}
			return (System.Boolean) (OperandVar8);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			
			{
				LightSource subContext9 = (LightSource)root.GetComponent(typeof(LightSource)); //IsContext = True IsNew = False
				//ContextStatement LightSource subContext9 ContextSwitchInterpreter
				if(subContext9 != null)
				{
					
					
					subContext9.LitUp = (System.Boolean)( (true));
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override System.Collections.Generic.List<Dependency> GetDependencies() {

		{
			
			var list10 = new System.Collections.Generic.List<Dependency>(1);
			
			{
				list10.Add(new CloserThan().Init(this.root,this.initiator, (1f)));
			}
			return list10;
		}
        }
        
        public override void Init() {
base.Init();
this.initiator = default(UnityEngine.GameObject);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=false, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=true)]
    public class interaction_lit_up_remote : EventAction, EventInteraction {
        
        private UnityEngine.GameObject initiator;
        
        UnityEngine.GameObject EventInteraction.Initiator {
            get {
return initiator; 
            }
            set {
initiator = value; 
            }
        }
        
        public override bool Interaction() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar12 = default(System.Boolean); //IsContext = False IsNew = False
			Manual StoredVariable11 = ((Manual)root.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
			if(StoredVariable11 != null)
			{
				applicable = true;
				OperandVar12 = applicable;
			}
			return (System.Boolean) (OperandVar12);
		}
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar21 = default(System.Boolean); //IsContext = False IsNew = False
			Interactable StoredVariable13 = ((Interactable)root.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
			if(StoredVariable13 != null)
			{
				ManualController StoredVariable14 = ((ManualController)StoredVariable13.GetComponent(typeof(ManualController))); //IsContext = False IsNew = False
				if(StoredVariable14 != null)
				{
					RemoteController StoredVariable15 = ((RemoteController)StoredVariable14.GetComponent(typeof(RemoteController))); //IsContext = False IsNew = False
					if(StoredVariable15 != null)
					{
						UnityEngine.GameObject prop16 = StoredVariable15.Controlled; //IsContext = False IsNew = False
						if(prop16 != null)
						{
							LightSource StoredVariable17 = ((LightSource)prop16.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
							if(StoredVariable17 != null)
							{
								System.Boolean ifResult18; //IsContext = False IsNew = False
								System.Boolean OperandVar20 = default(System.Boolean); //IsContext = False IsNew = False
								System.Boolean prop19 = StoredVariable17.LitUp; //IsContext = False IsNew = False
								OperandVar20 = prop19;
								if(ifResult18 = !(OperandVar20))
								{
									applicable = true;
									OperandVar21 = applicable;
								}
							}
						}
					}
				}
			}
			return (System.Boolean) (OperandVar21);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			LightSource OperandVar25 = default(LightSource); //IsContext = False IsNew = False
			RemoteController StoredVariable22 = ((RemoteController)root.GetComponent(typeof(RemoteController))); //IsContext = False IsNew = False
			if(StoredVariable22 != null)
			{
				UnityEngine.GameObject prop23 = StoredVariable22.Controlled; //IsContext = False IsNew = False
				if(prop23 != null)
				{
					LightSource StoredVariable24 = ((LightSource)prop23.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
					if(StoredVariable24 != null)
					{
						OperandVar25 = StoredVariable24;
					}
				}
			}
			External.Log((System.Object)( (OperandVar25)));
			
			{
				RemoteController subContext26 = (RemoteController)root.GetComponent(typeof(RemoteController)); //IsContext = True IsNew = False
				//ContextStatement RemoteController subContext26 ContextSwitchInterpreter
				if(subContext26 != null)
				{
					
					
					{
						UnityEngine.GameObject subContext27 = subContext26.Controlled; //IsContext = True IsNew = False
						//ContextStatement UnityEngine.GameObject subContext27 ContextPropertySwitchInterpreter
						if(subContext27 != null)
						{
							
							{
								LightSource subContext28 = (LightSource)subContext27.GetComponent(typeof(LightSource)); //IsContext = True IsNew = False
								//ContextStatement LightSource subContext28 ContextSwitchInterpreter
								if(subContext28 != null)
								{
									
									
									subContext28.LitUp = (System.Boolean)( (true));
								}
							}
						}
					}
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override System.Collections.Generic.List<Dependency> GetDependencies() {

		{
			
			var list29 = new System.Collections.Generic.List<Dependency>(1);
			
			{
				list29.Add(new CloserThan().Init(this.root,this.initiator, (1f)));
			}
			return list29;
		}
        }
        
        public override void Init() {
base.Init();
this.initiator = default(UnityEngine.GameObject);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=false, OncePerTurn=false, IsAIAction=true, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class lit_up_room_manual : EventAction, lit_up_room {
        
        private UnityEngine.GameObject light;
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar33 = default(System.Boolean); //IsContext = False IsNew = False
			LightSensor StoredVariable30 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable30 != null)
			{
				Actor StoredVariable31 = ((Actor)StoredVariable30.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable31 != null)
				{
					System.Boolean prop32 = StoredVariable31.CanDo(typeof(ScriptedTypes.interaction_lit_up_manual )); //IsContext = False IsNew = False
					if(prop32 != false)
					{
						applicable = true;
						OperandVar33 = applicable;
					}
				}
			}
			return (System.Boolean) (OperandVar33);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar40 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar35 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop34 = External.AllObjects; //IsContext = False IsNew = False
			if(prop34 != null)
			{
				OperandVar35 = prop34;
			}
			UnityEngine.GameObject prop39 = External.Any( (OperandVar35),(UnityEngine.GameObject go)=>{;
System.Boolean OperandVar38 = default(System.Boolean); //IsContext = False IsNew = False;
Interactable StoredVariable36 = ((Interactable)go.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False;
if(StoredVariable36 != null)
				{
					System.Boolean prop37 = StoredVariable36.Can(typeof(ScriptedTypes.interaction_lit_up_manual )); //IsContext = False IsNew = False
					if(prop37 != false)
					{
						OperandVar38 = prop37;
					}
				};
return  (OperandVar38);}); //IsContext = False IsNew = False
			if(prop39 != null)
			{
				OperandVar40 = prop39;
			}
			light =  (OperandVar40);
			
			UnityEngine.GameObject OperandVar41 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar41 = light;
			if( (OperandVar41))
			{
				
				
				
				System.Single OperandVar44 = default(System.Single); //IsContext = False IsNew = False
				LightSensor StoredVariable42 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable42 != null)
				{
					System.Single prop43 = StoredVariable42.Light; //IsContext = False IsNew = False
					OperandVar44 = prop43;
				}
				ut = ( ( (10f))) - ( ( (OperandVar44)));
			}
			return ut;
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			UnityEngine.GameObject OperandVar45 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar45 = light;
			var a46 = Actions.Instance.GetAction(typeof(ScriptedTypes.interaction_lit_up_manual ));
			a46.Init();
			(a46 as EventInteraction).Initiator = root;
			a46.Root =  (OperandVar45);
			UnityEngine.Debug.Log(a46.Root);
			UnityEngine.Debug.Log((a46 as EventInteraction).Initiator);
			(root.GetComponent(typeof(Actor)) as Actor).Act(a46);
			while(a46.State != EventAction.ActionState.Finished){ if(a46.State == EventAction.ActionState.Failed) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Action() {
Coroutine = ActionCoroutine(); state = ActionState.Started;
        }
        
        public override void Init() {
base.Init();
this.light = default(UnityEngine.GameObject);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=false, OncePerTurn=false, IsAIAction=true, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class lit_up_room_remote : EventAction, lit_up_room {
        
        private UnityEngine.GameObject remote_c;
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar50 = default(System.Boolean); //IsContext = False IsNew = False
			LightSensor StoredVariable47 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable47 != null)
			{
				Actor StoredVariable48 = ((Actor)StoredVariable47.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable48 != null)
				{
					System.Boolean prop49 = StoredVariable48.CanDo(typeof(ScriptedTypes.interaction_lit_up_remote )); //IsContext = False IsNew = False
					if(prop49 != false)
					{
						applicable = true;
						OperandVar50 = applicable;
					}
				}
			}
			return (System.Boolean) (OperandVar50);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar61 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar52 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop51 = External.AllObjects; //IsContext = False IsNew = False
			if(prop51 != null)
			{
				OperandVar52 = prop51;
			}
			UnityEngine.GameObject prop58 = External.Any( (OperandVar52),(UnityEngine.GameObject go)=>{;
System.Boolean OperandVar57 = default(System.Boolean); //IsContext = False IsNew = False;
Remote StoredVariable53 = ((Remote)go.GetComponent(typeof(Remote))); //IsContext = False IsNew = False;
if(StoredVariable53 != null)
				{
					UnityEngine.GameObject prop54 = StoredVariable53.Controller; //IsContext = False IsNew = False
					if(prop54 != null)
					{
						Interactable StoredVariable55 = ((Interactable)prop54.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
						if(StoredVariable55 != null)
						{
							System.Boolean prop56 = StoredVariable55.Can(typeof(ScriptedTypes.interaction_lit_up_remote )); //IsContext = False IsNew = False
							if(prop56 != false)
							{
								OperandVar57 = prop56;
							}
						}
					}
				};
return  (OperandVar57);}); //IsContext = False IsNew = False
			if(prop58 != null)
			{
				Remote StoredVariable59 = ((Remote)prop58.GetComponent(typeof(Remote))); //IsContext = False IsNew = False
				if(StoredVariable59 != null)
				{
					UnityEngine.GameObject prop60 = StoredVariable59.Controller; //IsContext = False IsNew = False
					if(prop60 != null)
					{
						OperandVar61 = prop60;
					}
				}
			}
			remote_c =  (OperandVar61);
			
			UnityEngine.GameObject OperandVar62 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar62 = remote_c;
			if( (OperandVar62))
			{
				
				
				
				System.Single OperandVar65 = default(System.Single); //IsContext = False IsNew = False
				LightSensor StoredVariable63 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable63 != null)
				{
					System.Single prop64 = StoredVariable63.Light; //IsContext = False IsNew = False
					OperandVar65 = prop64;
				}
				ut = ( ( (10f))) - ( ( (OperandVar65)));
			}
			return ut;
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			UnityEngine.GameObject OperandVar66 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar66 = remote_c;
			var a67 = Actions.Instance.GetAction(typeof(ScriptedTypes.interaction_lit_up_remote ));
			a67.Init();
			(a67 as EventInteraction).Initiator = root;
			a67.Root =  (OperandVar66);
			UnityEngine.Debug.Log(a67.Root);
			UnityEngine.Debug.Log((a67 as EventInteraction).Initiator);
			(root.GetComponent(typeof(Actor)) as Actor).Act(a67);
			while(a67.State != EventAction.ActionState.Finished){ if(a67.State == EventAction.ActionState.Failed) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Action() {
Coroutine = ActionCoroutine(); state = ActionState.Started;
        }
        
        public override void Init() {
base.Init();
this.remote_c = default(UnityEngine.GameObject);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=false, OncePerTurn=false, IsAIAction=true, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class basic_move : EventAction, ScriptedTypes.move_to {
        
        private UnityEngine.GameObject target;
        
        private float distance;
        
        UnityEngine.GameObject ScriptedTypes.move_to.Target {
            get {
return target; 
            }
            set {
target = value; 
            }
        }
        
        float ScriptedTypes.move_to.Distance {
            get {
return distance; 
            }
            set {
distance = value; 
            }
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			
			System.Boolean OperandVar69 = default(System.Boolean); //IsContext = False IsNew = False
			Movable StoredVariable68 = ((Movable)root.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
			if(StoredVariable68 != null)
			{
				applicable = true;
				OperandVar69 = applicable;
			}
			return (System.Boolean) (OperandVar69);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			
			
			System.Boolean OperandVar72 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar70 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar70 = target;
			System.Boolean prop71 = External.Has( (OperandVar70)); //IsContext = False IsNew = False
			if(prop71 != false)
			{
				OperandVar72 = prop71;
			}
			if( (OperandVar72))
			{
				
				ut =  (1f);
			}
			return ut;
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			
			
			{
				Movable subContext73 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext73 ContextSwitchInterpreter
				if(subContext73 != null)
				{
					
					System.Single OperandVar74 = default(System.Single); //IsContext = False IsNew = False
					OperandVar74 = distance;
					UnityEngine.GameObject OperandVar75 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar75 = target;
					subContext73.Goto((System.Single)( (OperandVar74)),(UnityEngine.GameObject)( (OperandVar75)));
					
					System.Boolean OperandVar77 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop76 = subContext73.IsMoving; //IsContext = False IsNew = False
					OperandVar77 = prop76;
					
					System.Boolean OperandVar79 = default(System.Boolean); //IsContext = False IsNew = False
					
					System.Boolean prop78 = External.Log( ("updated basic_move")); //IsContext = False IsNew = False
					if(prop78 != false)
					{
						OperandVar79 = prop78;
					}
					
					System.Boolean OperandVar81 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop80 = subContext73.IsMoving; //IsContext = False IsNew = False
					OperandVar81 = prop80;
					
					System.Boolean OperandVar83 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop82 = subContext73.NearTarget; //IsContext = False IsNew = False
					OperandVar83 = prop82;
					
					while(( ( (OperandVar77))) && ( ( (OperandVar79)))){ if(( (!(OperandVar81))) && ( (!(OperandVar83)))) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Action() {
Coroutine = ActionCoroutine(); state = ActionState.Started;
        }
        
        public override void Init() {
base.Init();
this.target = default(UnityEngine.GameObject);
this.distance = default(System.Single);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class npc_has_facts_and_backstory : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar86 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable84 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable84 != null)
			{
				Entity StoredVariable85 = ((Entity)StoredVariable84.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable85 != null)
				{
					applicable = true;
					OperandVar86 = applicable;
				}
			}
			return (System.Boolean) (OperandVar86);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			
			return (System.Single) (1f);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			root.AddComponent<ScriptedTypes.facts>();
			Entity EntVar87 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			root.AddComponent<ScriptedTypes.backstory>();
			if(EntVar87 != null) EntVar87.ComponentAdded();
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class player_has_controls : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar89 = default(System.Boolean); //IsContext = False IsNew = False
			PlayerMarker StoredVariable88 = ((PlayerMarker)root.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
			if(StoredVariable88 != null)
			{
				applicable = true;
				OperandVar89 = applicable;
			}
			return (System.Boolean) (OperandVar89);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			
			return (System.Single) (1f);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			root.AddComponent<MovableController>();
			Entity EntVar90 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			root.AddComponent<TurnFollowMouseController>();
			
			root.AddComponent<InteractableController>();
			if(EntVar90 != null) EntVar90.ComponentAdded();
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=true, IsInteraction=false)]
    public class rival_landlord : EventAction, base_scenario {
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar92 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable91 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable91 != null)
			{
				applicable = true;
				OperandVar92 = applicable;
			}
			return (System.Boolean) (OperandVar92);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			
			return (System.Single) (1f);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			UnityEngine.GameObject OperandVar97 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop96 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar95 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable93 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable93 != null)
				{
					ScriptedTypes.king_role StoredVariable94 = ((ScriptedTypes.king_role)StoredVariable93.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable94 != null)
					{
						OperandVar95 = StoredVariable94;
					}
				};
return  (OperandVar95);}); //IsContext = False IsNew = False
			if(prop96 != null)
			{
				OperandVar97 = prop96;
			}
			UnityEngine.GameObject king =  (OperandVar97); //IsContext = False IsNew = False
			System.Boolean OperandVar100 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar98 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar98 = king;
			System.Boolean prop99 = External.Has( (OperandVar98)); //IsContext = False IsNew = False
			if(prop99 != false)
			{
				OperandVar100 = prop99;
			}
			if(!(OperandVar100))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx101 = External.SpawnPrefab(( ("npc")).ToString(),( ("king")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx101 ContextPropertySwitchInterpreter
					if(FuncCtx101 != null)
					{
						FuncCtx101.AddComponent<ScriptedTypes.king_role>();
						Entity EntVar102 = (Entity)FuncCtx101.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						if(EntVar102 != null) EntVar102.ComponentAdded();
						
						{
							Entity subContext103 = (Entity)FuncCtx101.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext103 ContextSwitchInterpreter
							if(subContext103 != null)
							{
								
								
								
								
								subContext103.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar104 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar104 = FuncCtx101;
						king =  (OperandVar104);
						
						{
							Actor subContext105 = (Actor)FuncCtx101.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext105 ContextSwitchInterpreter
							if(subContext105 != null)
							{
								
								
								System.Int32 OperandVar107 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop106 = subContext105.ScenariosCount; //IsContext = False IsNew = False
								OperandVar107 = prop106;
								
								
								subContext105.ScenariosCount = (System.Int32)(( ( (OperandVar107))) + ( ( (1f))));
							}
						}
					}
				}
			}
			UnityEngine.GameObject OperandVar109 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop108 = External.NoOne(); //IsContext = False IsNew = False
			if(prop108 != null)
			{
				OperandVar109 = prop108;
			}
			UnityEngine.GameObject rival =  (OperandVar109); //IsContext = False IsNew = False
			
			System.Int32 OperandVar112 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable110 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable110 != null)
			{
				System.Int32 prop111 = StoredVariable110.ActorsCount; //IsContext = False IsNew = False
				OperandVar112 = prop111;
			}
			
			System.Int32 OperandVar114 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable110 != null)
			{
				System.Int32 prop113 = StoredVariable110.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar114 = prop113;
			}
			if(( ( (OperandVar112))) > ( ( (OperandVar114))))
			{
				UnityEngine.GameObject OperandVar121 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop120 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar117 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable115 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable115 != null)
					{
						System.Int32 prop116 = StoredVariable115.ScenariosCount; //IsContext = False IsNew = False
						OperandVar117 = prop116;
					};
;
;
;
;
;
UnityEngine.GameObject OperandVar118 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar118 = go;;
;
UnityEngine.GameObject OperandVar119 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar119 = king;;
return ( (( ( (OperandVar117))) < ( ( (2f))))) && ( (!(( ( (OperandVar118))) == ( ( (OperandVar119))))));}); //IsContext = False IsNew = False
				if(prop120 != null)
				{
					OperandVar121 = prop120;
				}
				rival =  (OperandVar121);
			}
			System.Boolean OperandVar124 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar122 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar122 = rival;
			System.Boolean prop123 = External.Has( (OperandVar122)); //IsContext = False IsNew = False
			if(prop123 != false)
			{
				OperandVar124 = prop123;
			}
			if(!(OperandVar124))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx125 = External.SpawnPrefab(( ("npc")).ToString(),( ("rival")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx125 ContextPropertySwitchInterpreter
					if(FuncCtx125 != null)
					{
						FuncCtx125.AddComponent<ScriptedTypes.feudal_landlord_role>();
						Entity EntVar126 = (Entity)FuncCtx125.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx125.AddComponent<ScriptedTypes.noble_role>();
						
						FuncCtx125.AddComponent<ScriptedTypes.criminal_role>();
						
						ScriptedTypes.rival_role ContextVar127 = FuncCtx125.AddComponent<ScriptedTypes.rival_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.rival_role ContextVar127 ContextSwitchInterpreter
							if(ContextVar127 != null)
							{
								
								UnityEngine.GameObject OperandVar129 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								UnityEngine.GameObject prop128 = External.Player(); //IsContext = False IsNew = False
								if(prop128 != null)
								{
									OperandVar129 = prop128;
								}
								ContextVar127.OfWhom = (UnityEngine.GameObject)( (OperandVar129));
							}
						}
						if(EntVar126 != null) EntVar126.ComponentAdded();
						
						{
							Entity subContext130 = (Entity)FuncCtx125.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext130 ContextSwitchInterpreter
							if(subContext130 != null)
							{
								
								
								
								
								subContext130.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						
						{
							Actor subContext131 = (Actor)FuncCtx125.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext131 ContextSwitchInterpreter
							if(subContext131 != null)
							{
								
								
								System.Int32 OperandVar133 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop132 = subContext131.ScenariosCount; //IsContext = False IsNew = False
								OperandVar133 = prop132;
								
								
								subContext131.ScenariosCount = (System.Int32)(( ( (OperandVar133))) + ( ( (1f))));
							}
						}
					}
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class kings_cook : EventAction {
        
        private UnityEngine.GameObject king;
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar135 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable134 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable134 != null)
			{
				applicable = true;
				OperandVar135 = applicable;
			}
			return (System.Boolean) (OperandVar135);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar140 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop139 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar138 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable136 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable136 != null)
				{
					ScriptedTypes.king_role StoredVariable137 = ((ScriptedTypes.king_role)StoredVariable136.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable137 != null)
					{
						OperandVar138 = StoredVariable137;
					}
				};
return  (OperandVar138);}); //IsContext = False IsNew = False
			if(prop139 != null)
			{
				OperandVar140 = prop139;
			}
			king =  (OperandVar140);
			
			System.Boolean OperandVar143 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar141 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar141 = king;
			System.Boolean prop142 = External.Has( (OperandVar141)); //IsContext = False IsNew = False
			if(prop142 != false)
			{
				OperandVar143 = prop142;
			}
			if( (OperandVar143))
			{
				
				ut =  (1f);
				UnityEngine.GameObject OperandVar144 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar144 = king;
				External.Log((System.Object)( (OperandVar144)));
			}
			return ut;
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			
			
			
			{
				UnityEngine.GameObject FuncCtx145 = External.SpawnPrefab(( ("npc")).ToString(),( ("personal cook")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx145 ContextPropertySwitchInterpreter
				if(FuncCtx145 != null)
				{
					FuncCtx145.AddComponent<ScriptedTypes.cook_role>();
					Entity EntVar146 = (Entity)FuncCtx145.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					ScriptedTypes.servant_role ContextVar147 = FuncCtx145.AddComponent<ScriptedTypes.servant_role>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.servant_role ContextVar147 ContextSwitchInterpreter
						if(ContextVar147 != null)
						{
							
							UnityEngine.GameObject OperandVar148 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar148 = king;
							ContextVar147.OfWhom = (UnityEngine.GameObject)( (OperandVar148));
						}
					}
					if(EntVar146 != null) EntVar146.ComponentAdded();
					
					{
						Entity subContext149 = (Entity)FuncCtx145.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext149 ContextSwitchInterpreter
						if(subContext149 != null)
						{
							
							
							
							
							subContext149.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
						}
					}
					
					{
						Actor subContext150 = (Actor)FuncCtx145.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
						//ContextStatement Actor subContext150 ContextSwitchInterpreter
						if(subContext150 != null)
						{
							
							
							System.Int32 OperandVar152 = default(System.Int32); //IsContext = False IsNew = False
							System.Int32 prop151 = subContext150.ScenariosCount; //IsContext = False IsNew = False
							OperandVar152 = prop151;
							
							
							subContext150.ScenariosCount = (System.Int32)(( ( (OperandVar152))) + ( ( (1f))));
						}
					}
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();
this.king = default(UnityEngine.GameObject);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class fucks_kings_daughter : EventAction {
        
        private UnityEngine.GameObject king;
        
        private UnityEngine.GameObject noble;
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar154 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable153 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable153 != null)
			{
				applicable = true;
				OperandVar154 = applicable;
			}
			return (System.Boolean) (OperandVar154);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar159 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop158 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar157 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable155 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable155 != null)
				{
					ScriptedTypes.king_role StoredVariable156 = ((ScriptedTypes.king_role)StoredVariable155.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable156 != null)
					{
						OperandVar157 = StoredVariable156;
					}
				};
return  (OperandVar157);}); //IsContext = False IsNew = False
			if(prop158 != null)
			{
				OperandVar159 = prop158;
			}
			king =  (OperandVar159);
			
			UnityEngine.GameObject OperandVar167 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop166 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
ScriptedTypes.criminal_role OperandVar162 = default(ScriptedTypes.criminal_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable160 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable160 != null)
				{
					ScriptedTypes.criminal_role StoredVariable161 = ((ScriptedTypes.criminal_role)StoredVariable160.GetComponent(typeof(ScriptedTypes.criminal_role))); //IsContext = False IsNew = False
					if(StoredVariable161 != null)
					{
						OperandVar162 = StoredVariable161;
					}
				};
;
;
System.Int32 OperandVar165 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable163 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable163 != null)
				{
					System.Int32 prop164 = StoredVariable163.ScenariosCount; //IsContext = False IsNew = False
					OperandVar165 = prop164;
				};
;
;
return ( ( (OperandVar162))) && ( (( ( (OperandVar165))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop166 != null)
			{
				OperandVar167 = prop166;
			}
			noble =  (OperandVar167);
			
			
			UnityEngine.GameObject OperandVar168 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar168 = noble;
			
			UnityEngine.GameObject OperandVar169 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar169 = king;
			if(( ( (OperandVar168))) && ( ( (OperandVar169))))
			{
				
				ut =  (1f);
			}
			return ut;
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			
			UnityEngine.GameObject OperandVar181 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop180 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
System.Boolean OperandVar176 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.heir_role StoredVariable170 = ((ScriptedTypes.heir_role)go.GetComponent(typeof(ScriptedTypes.heir_role))); //IsContext = False IsNew = False;
if(StoredVariable170 != null)
				{
					ScriptedTypes.woman_role StoredVariable171 = ((ScriptedTypes.woman_role)StoredVariable170.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
					if(StoredVariable171 != null)
					{
						System.Boolean ifResult172; //IsContext = False IsNew = False
						
						UnityEngine.GameObject OperandVar174 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						if(StoredVariable170 != null)
						{
							UnityEngine.GameObject prop173 = StoredVariable170.OfWhom; //IsContext = False IsNew = False
							if(prop173 != null)
							{
								OperandVar174 = prop173;
							}
						}
						
						UnityEngine.GameObject OperandVar175 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar175 = king;
						if(ifResult172 = ( ( (OperandVar174))) == ( ( (OperandVar175))))
						{
							OperandVar176 = ifResult172;
						}
					}
				};
;
;
System.Int32 OperandVar179 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable177 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable177 != null)
				{
					System.Int32 prop178 = StoredVariable177.ScenariosCount; //IsContext = False IsNew = False
					OperandVar179 = prop178;
				};
;
;
return ( ( (OperandVar176))) && ( (( ( (OperandVar179))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop180 != null)
			{
				OperandVar181 = prop180;
			}
			UnityEngine.GameObject kings_daughter =  (OperandVar181); //IsContext = False IsNew = False
			System.Boolean OperandVar184 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar182 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar182 = kings_daughter;
			System.Boolean prop183 = External.Has( (OperandVar182)); //IsContext = False IsNew = False
			if(prop183 != false)
			{
				OperandVar184 = prop183;
			}
			if(!(OperandVar184))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx185 = External.SpawnPrefab(( ("npc")).ToString(),( ("kings_daughter")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx185 ContextPropertySwitchInterpreter
					if(FuncCtx185 != null)
					{
						ScriptedTypes.heir_role ContextVar186 = FuncCtx185.AddComponent<ScriptedTypes.heir_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.heir_role ContextVar186 ContextSwitchInterpreter
							if(ContextVar186 != null)
							{
								
								UnityEngine.GameObject OperandVar187 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar187 = king;
								ContextVar186.OfWhom = (UnityEngine.GameObject)( (OperandVar187));
							}
						}
						Entity EntVar188 = (Entity)FuncCtx185.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx185.AddComponent<ScriptedTypes.woman_role>();
						
						ScriptedTypes.in_love ContextVar189 = FuncCtx185.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.in_love ContextVar189 ContextSwitchInterpreter
							if(ContextVar189 != null)
							{
								
								UnityEngine.GameObject OperandVar190 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar190 = noble;
								ContextVar189.WithWhom = (UnityEngine.GameObject)( (OperandVar190));
							}
						}
						if(EntVar188 != null) EntVar188.ComponentAdded();
						
						{
							Entity subContext191 = (Entity)FuncCtx185.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext191 ContextSwitchInterpreter
							if(subContext191 != null)
							{
								
								
								
								
								subContext191.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar192 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar192 = FuncCtx185;
						kings_daughter =  (OperandVar192);
						
						{
							Actor subContext193 = (Actor)FuncCtx185.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext193 ContextSwitchInterpreter
							if(subContext193 != null)
							{
								
								
								System.Int32 OperandVar195 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop194 = subContext193.ScenariosCount; //IsContext = False IsNew = False
								OperandVar195 = prop194;
								
								
								subContext193.ScenariosCount = (System.Int32)(( ( (OperandVar195))) + ( ( (1f))));
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble ContextSwitchInterpreter
				if(noble != null)
				{
					
					ScriptedTypes.in_love ContextVar196 = noble.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.in_love ContextVar196 ContextSwitchInterpreter
						if(ContextVar196 != null)
						{
							
							UnityEngine.GameObject OperandVar197 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar197 = kings_daughter;
							ContextVar196.WithWhom = (UnityEngine.GameObject)( (OperandVar197));
						}
					}
					Entity EntVar198 = (Entity)noble.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar198 != null) EntVar198.ComponentAdded();
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();
this.king = default(UnityEngine.GameObject);
this.noble = default(UnityEngine.GameObject);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class noble_whore_scenario : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar200 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable199 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable199 != null)
			{
				applicable = true;
				OperandVar200 = applicable;
			}
			return (System.Boolean) (OperandVar200);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			
			return (System.Single) (1f);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			UnityEngine.GameObject OperandVar202 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop201 = External.NoOne(); //IsContext = False IsNew = False
			if(prop201 != null)
			{
				OperandVar202 = prop201;
			}
			UnityEngine.GameObject noble =  (OperandVar202); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar204 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop203 = External.NoOne(); //IsContext = False IsNew = False
			if(prop203 != null)
			{
				OperandVar204 = prop203;
			}
			UnityEngine.GameObject whore =  (OperandVar204); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar206 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop205 = External.NoOne(); //IsContext = False IsNew = False
			if(prop205 != null)
			{
				OperandVar206 = prop205;
			}
			UnityEngine.GameObject noble_wife =  (OperandVar206); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar208 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop207 = External.NoOne(); //IsContext = False IsNew = False
			if(prop207 != null)
			{
				OperandVar208 = prop207;
			}
			UnityEngine.GameObject whore_lover =  (OperandVar208); //IsContext = False IsNew = False
			
			System.Int32 OperandVar211 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable209 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable209 != null)
			{
				System.Int32 prop210 = StoredVariable209.ActorsCount; //IsContext = False IsNew = False
				OperandVar211 = prop210;
			}
			
			System.Int32 OperandVar213 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable209 != null)
			{
				System.Int32 prop212 = StoredVariable209.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar213 = prop212;
			}
			if(( ( (OperandVar211))) > ( ( (OperandVar213))))
			{
				UnityEngine.GameObject OperandVar229 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop228 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar216 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable214 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable214 != null)
					{
						System.Int32 prop215 = StoredVariable214.ScenariosCount; //IsContext = False IsNew = False
						OperandVar216 = prop215;
					};
;
;
;
;
System.Int32 OperandVar219 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable217 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable217 != null)
					{
						System.Int32 prop218 = StoredVariable217.Influence; //IsContext = False IsNew = False
						OperandVar219 = prop218;
					};
;
;
;
;
System.Int32 OperandVar222 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable220 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable220 != null)
					{
						System.Int32 prop221 = StoredVariable220.Age; //IsContext = False IsNew = False
						OperandVar222 = prop221;
					};
;
;
;
ScriptedTypes.man_role OperandVar224 = default(ScriptedTypes.man_role); //IsContext = False IsNew = False;
ScriptedTypes.man_role StoredVariable223 = ((ScriptedTypes.man_role)go.GetComponent(typeof(ScriptedTypes.man_role))); //IsContext = False IsNew = False;
if(StoredVariable223 != null)
					{
						OperandVar224 = StoredVariable223;
					};
;
System.Boolean OperandVar227 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable225 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable225 != null)
					{
						System.Boolean prop226 = StoredVariable225.HasHusbandTo(); //IsContext = False IsNew = False
						if(prop226 != false)
						{
							OperandVar227 = prop226;
						}
					};
return ( (( ( (OperandVar216))) < ( ( (2f))))) && ( (( ( (OperandVar219))) > ( ( (80f))))) && ( (( ( (OperandVar222))) > ( ( (30f))))) && ( ( (OperandVar224))) && ( (!(OperandVar227)));}); //IsContext = False IsNew = False
				if(prop228 != null)
				{
					OperandVar229 = prop228;
				}
				noble =  (OperandVar229);
			}
			
			System.Int32 OperandVar231 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable209 != null)
			{
				System.Int32 prop230 = StoredVariable209.ActorsCount; //IsContext = False IsNew = False
				OperandVar231 = prop230;
			}
			
			System.Int32 OperandVar233 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable209 != null)
			{
				System.Int32 prop232 = StoredVariable209.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar233 = prop232;
			}
			if(( ( (OperandVar231))) > ( ( (OperandVar233))))
			{
				UnityEngine.GameObject OperandVar241 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop240 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar236 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable234 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable234 != null)
					{
						System.Int32 prop235 = StoredVariable234.ScenariosCount; //IsContext = False IsNew = False
						OperandVar236 = prop235;
					};
;
;
;
ScriptedTypes.woman_role OperandVar239 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.folk_role StoredVariable237 = ((ScriptedTypes.folk_role)go.GetComponent(typeof(ScriptedTypes.folk_role))); //IsContext = False IsNew = False;
if(StoredVariable237 != null)
					{
						ScriptedTypes.woman_role StoredVariable238 = ((ScriptedTypes.woman_role)StoredVariable237.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable238 != null)
						{
							OperandVar239 = StoredVariable238;
						}
					};
return ( (( ( (OperandVar236))) < ( ( (2f))))) && ( ( (OperandVar239)));}); //IsContext = False IsNew = False
				if(prop240 != null)
				{
					OperandVar241 = prop240;
				}
				whore =  (OperandVar241);
			}
			
			System.Int32 OperandVar243 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable209 != null)
			{
				System.Int32 prop242 = StoredVariable209.ActorsCount; //IsContext = False IsNew = False
				OperandVar243 = prop242;
			}
			
			System.Int32 OperandVar245 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable209 != null)
			{
				System.Int32 prop244 = StoredVariable209.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar245 = prop244;
			}
			if(( ( (OperandVar243))) > ( ( (OperandVar245))))
			{
				UnityEngine.GameObject OperandVar256 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop255 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar248 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable246 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable246 != null)
					{
						System.Int32 prop247 = StoredVariable246.ScenariosCount; //IsContext = False IsNew = False
						OperandVar248 = prop247;
					};
;
;
;
ScriptedTypes.woman_role OperandVar251 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable249 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable249 != null)
					{
						ScriptedTypes.woman_role StoredVariable250 = ((ScriptedTypes.woman_role)StoredVariable249.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable250 != null)
						{
							OperandVar251 = StoredVariable250;
						}
					};
;
System.Boolean OperandVar254 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable252 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable252 != null)
					{
						System.Boolean prop253 = StoredVariable252.HasWifeTo(); //IsContext = False IsNew = False
						if(prop253 != false)
						{
							OperandVar254 = prop253;
						}
					};
return ( (( ( (OperandVar248))) < ( ( (2f))))) && ( ( (OperandVar251))) && ( (!(OperandVar254)));}); //IsContext = False IsNew = False
				if(prop255 != null)
				{
					OperandVar256 = prop255;
				}
				noble_wife =  (OperandVar256);
			}
			
			System.Int32 OperandVar258 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable209 != null)
			{
				System.Int32 prop257 = StoredVariable209.ActorsCount; //IsContext = False IsNew = False
				OperandVar258 = prop257;
			}
			
			System.Int32 OperandVar260 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable209 != null)
			{
				System.Int32 prop259 = StoredVariable209.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar260 = prop259;
			}
			if(( ( (OperandVar258))) > ( ( (OperandVar260))))
			{
				UnityEngine.GameObject OperandVar270 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop269 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar263 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable261 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable261 != null)
					{
						System.Int32 prop262 = StoredVariable261.ScenariosCount; //IsContext = False IsNew = False
						OperandVar263 = prop262;
					};
;
;
;
ScriptedTypes.noble_role OperandVar265 = default(ScriptedTypes.noble_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable264 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable264 != null)
					{
						OperandVar265 = StoredVariable264;
					};
;
;
System.Int32 OperandVar268 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable266 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable266 != null)
					{
						System.Int32 prop267 = StoredVariable266.Age; //IsContext = False IsNew = False
						OperandVar268 = prop267;
					};
;
;
return ( (( ( (OperandVar263))) < ( ( (2f))))) && ( ( (OperandVar265))) && ( (( ( (OperandVar268))) < ( ( (30f)))));}); //IsContext = False IsNew = False
				if(prop269 != null)
				{
					OperandVar270 = prop269;
				}
				whore_lover =  (OperandVar270);
			}
			System.Boolean OperandVar273 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar271 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar271 = noble;
			System.Boolean prop272 = External.Has( (OperandVar271)); //IsContext = False IsNew = False
			if(prop272 != false)
			{
				OperandVar273 = prop272;
			}
			if(!(OperandVar273))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx274 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx274 ContextPropertySwitchInterpreter
					if(FuncCtx274 != null)
					{
						ScriptedTypes.noble_role ContextVar275 = FuncCtx274.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar275 ContextSwitchInterpreter
							if(ContextVar275 != null)
							{
								
								
								ContextVar275.Influence = (System.Int32)( (90f));
							}
						}
						Entity EntVar276 = (Entity)FuncCtx274.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						ScriptedTypes.aged ContextVar277 = FuncCtx274.AddComponent<ScriptedTypes.aged>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.aged ContextVar277 ContextSwitchInterpreter
							if(ContextVar277 != null)
							{
								
								
								ContextVar277.Age = (System.Int32)( (50f));
							}
						}
						
						FuncCtx274.AddComponent<ScriptedTypes.man_role>();
						if(EntVar276 != null) EntVar276.ComponentAdded();
					}
				}
			}
			System.Boolean OperandVar280 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar278 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar278 = whore;
			System.Boolean prop279 = External.Has( (OperandVar278)); //IsContext = False IsNew = False
			if(prop279 != false)
			{
				OperandVar280 = prop279;
			}
			if(!(OperandVar280))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx281 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx281 ContextPropertySwitchInterpreter
					if(FuncCtx281 != null)
					{
						FuncCtx281.AddComponent<ScriptedTypes.folk_role>();
						Entity EntVar282 = (Entity)FuncCtx281.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx281.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar282 != null) EntVar282.ComponentAdded();
					}
				}
			}
			System.Boolean OperandVar285 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar283 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar283 = noble_wife;
			System.Boolean prop284 = External.Has( (OperandVar283)); //IsContext = False IsNew = False
			if(prop284 != false)
			{
				OperandVar285 = prop284;
			}
			if(!(OperandVar285))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx286 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble_wife")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx286 ContextPropertySwitchInterpreter
					if(FuncCtx286 != null)
					{
						FuncCtx286.AddComponent<ScriptedTypes.noble_role>();
						Entity EntVar287 = (Entity)FuncCtx286.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx286.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar287 != null) EntVar287.ComponentAdded();
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble_wife ContextSwitchInterpreter
				if(noble_wife != null)
				{
					
					
					{
						ScriptedTypes.facts subContext288 = (ScriptedTypes.facts)noble_wife.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext288 ContextSwitchInterpreter
						if(subContext288 != null)
						{
							
							
							{
								ScriptedTypes.wife_to FuncCtx289 = subContext288.AddWifeTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.wife_to FuncCtx289 ContextPropertySwitchInterpreter
								if(FuncCtx289 != null)
								{
									UnityEngine.GameObject OperandVar290 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar290 = noble;
									UnityEngine.GameObject whom =  (OperandVar290); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble ContextSwitchInterpreter
				if(noble != null)
				{
					
					
					{
						ScriptedTypes.facts subContext291 = (ScriptedTypes.facts)noble.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext291 ContextSwitchInterpreter
						if(subContext291 != null)
						{
							
							
							{
								ScriptedTypes.husband_to FuncCtx292 = subContext291.AddHusbandTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.husband_to FuncCtx292 ContextPropertySwitchInterpreter
								if(FuncCtx292 != null)
								{
									UnityEngine.GameObject OperandVar293 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar293 = noble_wife;
									UnityEngine.GameObject whom =  (OperandVar293); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble ContextSwitchInterpreter
				if(noble != null)
				{
					
					
					{
						ScriptedTypes.facts subContext294 = (ScriptedTypes.facts)noble.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext294 ContextSwitchInterpreter
						if(subContext294 != null)
						{
							
							
							{
								ScriptedTypes.lover FuncCtx295 = subContext294.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx295 ContextPropertySwitchInterpreter
								if(FuncCtx295 != null)
								{
									UnityEngine.GameObject OperandVar296 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar296 = whore;
									UnityEngine.GameObject of_whom =  (OperandVar296); //IsContext = False IsNew = False
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			System.Boolean OperandVar299 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar297 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar297 = whore_lover;
			System.Boolean prop298 = External.Has( (OperandVar297)); //IsContext = False IsNew = False
			if(prop298 != false)
			{
				OperandVar299 = prop298;
			}
			if(!(OperandVar299))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx300 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore_lover")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx300 ContextPropertySwitchInterpreter
					if(FuncCtx300 != null)
					{
						ScriptedTypes.noble_role ContextVar301 = FuncCtx300.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar301 ContextSwitchInterpreter
							if(ContextVar301 != null)
							{
								
								
								ContextVar301.Influence = (System.Int32)( (40f));
							}
						}
						Entity EntVar302 = (Entity)FuncCtx300.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx300.AddComponent<ScriptedTypes.man_role>();
						if(EntVar302 != null) EntVar302.ComponentAdded();
						
						{
							ScriptedTypes.aged subContext303 = (ScriptedTypes.aged)FuncCtx300.GetComponent(typeof(ScriptedTypes.aged)); //IsContext = True IsNew = False
							//ContextStatement ScriptedTypes.aged subContext303 ContextSwitchInterpreter
							if(subContext303 != null)
							{
								
								
								subContext303.Age = (System.Int32)( (25f));
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject whore_lover ContextSwitchInterpreter
				if(whore_lover != null)
				{
					
					
					{
						ScriptedTypes.facts subContext304 = (ScriptedTypes.facts)whore_lover.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext304 ContextSwitchInterpreter
						if(subContext304 != null)
						{
							
							
							{
								ScriptedTypes.lover FuncCtx305 = subContext304.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx305 ContextPropertySwitchInterpreter
								if(FuncCtx305 != null)
								{
									UnityEngine.GameObject OperandVar306 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar306 = whore;
									UnityEngine.GameObject of_whom =  (OperandVar306); //IsContext = False IsNew = False
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject whore ContextSwitchInterpreter
				if(whore != null)
				{
					
					
					{
						ScriptedTypes.facts subContext307 = (ScriptedTypes.facts)whore.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext307 ContextSwitchInterpreter
						if(subContext307 != null)
						{
							
							
							{
								ScriptedTypes.lover FuncCtx308 = subContext307.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx308 ContextPropertySwitchInterpreter
								if(FuncCtx308 != null)
								{
									UnityEngine.GameObject OperandVar309 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar309 = noble;
									UnityEngine.GameObject of_whom =  (OperandVar309); //IsContext = False IsNew = False
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
							
							{
								ScriptedTypes.lover FuncCtx310 = subContext307.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx310 ContextPropertySwitchInterpreter
								if(FuncCtx310 != null)
								{
									UnityEngine.GameObject OperandVar311 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar311 = noble;
									UnityEngine.GameObject of_whom =  (OperandVar311); //IsContext = False IsNew = False
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
}
namespace ScriptedTypes {
    
    
    public interface test_metrics {
    }
    
    [MetricAttribute(Weight=(50))]
    public class test_metric : Metric, test_metrics {
        
        public override float Value() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single val = 0; //IsContext = False IsNew = False
			
			
			System.Single OperandVar314 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable312 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable312 != null)
			{
				System.Single prop313 = StoredVariable312.Brightness; //IsContext = False IsNew = False
				OperandVar314 = prop313;
			}
			System.Single OperandVar317 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable315 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable315 != null)
			{
				System.Single prop316 = StoredVariable315.Light; //IsContext = False IsNew = False
				OperandVar317 = prop316;
			}
			val = ( (OperandVar314)) * ( (OperandVar317));
			return val;
		}
        }
        
        public override bool RootFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar320 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable318 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable318 != null)
			{
				LightSensor StoredVariable319 = ((LightSensor)StoredVariable318.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable319 != null)
				{
					applicable = true;
					OperandVar320 = applicable;
				}
			}
			return (System.Boolean) (OperandVar320);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar323 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable321 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable321 != null)
			{
				LightSource StoredVariable322 = ((LightSource)StoredVariable321.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable322 != null)
				{
					applicable = true;
					OperandVar323 = applicable;
				}
			}
			return (System.Boolean) (OperandVar323);
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [MetricAttribute(Weight=(30))]
    public class test_metric_actors : Metric, test_metrics {
        
        public override float Value() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single val = 0; //IsContext = False IsNew = False
			
			
			
			val =  (0.4f);
			return val;
		}
        }
        
        public override bool RootFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar325 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable324 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable324 != null)
			{
				applicable = true;
				OperandVar325 = applicable;
			}
			return (System.Boolean) (OperandVar325);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar327 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable326 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable326 != null)
			{
				applicable = true;
				OperandVar327 = applicable;
			}
			return (System.Boolean) (OperandVar327);
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
}
namespace reactions {
    
    
    [ReactionAttribute(IsRepeatable=false, EventType=typeof(TestEvent))]
    public class test_common_reaction : Reaction {
        
        private TestEvent root;
        
        public override Event Root {
            get {
return root;
            }
            set {
root = value as TestEvent;
            }
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar330 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop328 = root.Target; //IsContext = False IsNew = False
			if(prop328 != null)
			{
				Actor StoredVariable329 = ((Actor)prop328.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable329 != null)
				{
					applicable = true;
					OperandVar330 = applicable;
				}
			}
			return (System.Boolean) (OperandVar330);
		}
        }
        
        public override void Action() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			{
				VisualsFeed subContext331 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext331 ContextPropertySwitchInterpreter
				if(subContext331 != null)
				{
					TestEvent OperandVar332 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar332 = root;
					UnityEngine.Vector3 OperandVar336 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(root != null)
					{
						UnityEngine.GameObject prop333 = root.Target; //IsContext = False IsNew = False
						if(prop333 != null)
						{
							Entity StoredVariable334 = ((Entity)prop333.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
							if(StoredVariable334 != null)
							{
								UnityEngine.Vector3 prop335 = StoredVariable334.Position; //IsContext = False IsNew = False
								OperandVar336 = prop335;
							}
						}
					}
					subContext331.Push((Event)( (OperandVar332)),(UnityEngine.Vector3)( (OperandVar336)));
				}
			}
		}
        }
    }
    
    [ReactionAttribute(IsRepeatable=false, EventType=typeof(TestEvent), EventFeed=typeof(VisualSensor))]
    public class test_common_personal_reaction : PersonalReaction {
        
        private TestEvent e;
        
        public override Event Event {
            get {
return e;
            }
            set {
e = value as TestEvent;
            }
        }
        
        public override bool RootFilter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			var e = this.e;
			
			System.Boolean OperandVar338 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable337 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable337 != null)
			{
				applicable = true;
				OperandVar338 = applicable;
			}
			return (System.Boolean) (OperandVar338);
		}
        }
        
        public override void Action() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			var e = this.e;
			
			
			{
				ScriptedTypes.facts subContext339 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext339 ContextSwitchInterpreter
				if(subContext339 != null)
				{
					
					System.Boolean OperandVar341 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop340 = subContext339.HasNoticedTestEvent(); //IsContext = False IsNew = False
					if(prop340 != false)
					{
						OperandVar341 = prop340;
					}
					if(!(OperandVar341))
					{
						ScriptedTypes.noticed_test_event OperandVar343 = default(ScriptedTypes.noticed_test_event); //IsContext = False IsNew = False
						ScriptedTypes.noticed_test_event prop342 = subContext339.AddNoticedTestEvent(); //IsContext = False IsNew = False
						if(prop342 != null)
						{
							OperandVar343 = prop342;
						}
						ScriptedTypes.noticed_test_event ev =  (OperandVar343); //IsContext = False IsNew = False
					}
				}
			}
		}
        }
    }
}
