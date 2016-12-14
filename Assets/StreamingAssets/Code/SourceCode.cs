namespace ScriptedTypes {
    
    
    public interface lit_up_room {
    }
    
    public interface testing {
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
					Manual StoredVariable4 = ((Manual)StoredVariable3.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
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
				Manual StoredVariable14 = ((Manual)StoredVariable13.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
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
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=false, OncePerTurn=false, IsAIAction=true, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class facts_notice : EventAction, testing {
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar85 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable84 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable84 != null)
			{
				applicable = true;
				OperandVar85 = applicable;
			}
			return (System.Boolean) (OperandVar85);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			System.Boolean OperandVar88 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable86 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable86 != null)
			{
				System.Boolean prop87 = StoredVariable86.HasNoticedTestEvent(); //IsContext = False IsNew = False
				if(prop87 != false)
				{
					OperandVar88 = prop87;
				}
			}
			if( (OperandVar88))
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
			
			
			External.Log((System.Object)( ("I've noticed an event!")));
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class npc_has_facts_and_backstory : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar91 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable89 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable89 != null)
			{
				Entity StoredVariable90 = ((Entity)StoredVariable89.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable90 != null)
				{
					applicable = true;
					OperandVar91 = applicable;
				}
			}
			return (System.Boolean) (OperandVar91);
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
			Entity EntVar92 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			root.AddComponent<ScriptedTypes.backstory>();
			if(EntVar92 != null) EntVar92.ComponentAdded();
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
			
			System.Boolean OperandVar94 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable93 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable93 != null)
			{
				applicable = true;
				OperandVar94 = applicable;
			}
			return (System.Boolean) (OperandVar94);
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
			
			UnityEngine.GameObject OperandVar99 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop98 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar97 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable95 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable95 != null)
				{
					ScriptedTypes.king_role StoredVariable96 = ((ScriptedTypes.king_role)StoredVariable95.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable96 != null)
					{
						OperandVar97 = StoredVariable96;
					}
				};
return  (OperandVar97);}); //IsContext = False IsNew = False
			if(prop98 != null)
			{
				OperandVar99 = prop98;
			}
			UnityEngine.GameObject king =  (OperandVar99); //IsContext = False IsNew = False
			System.Boolean OperandVar102 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar100 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar100 = king;
			System.Boolean prop101 = External.Has( (OperandVar100)); //IsContext = False IsNew = False
			if(prop101 != false)
			{
				OperandVar102 = prop101;
			}
			if(!(OperandVar102))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx103 = External.SpawnPrefab(( ("npc")).ToString(),( ("king")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx103 ContextPropertySwitchInterpreter
					if(FuncCtx103 != null)
					{
						FuncCtx103.AddComponent<ScriptedTypes.king_role>();
						Entity EntVar104 = (Entity)FuncCtx103.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						if(EntVar104 != null) EntVar104.ComponentAdded();
						
						{
							Entity subContext105 = (Entity)FuncCtx103.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext105 ContextSwitchInterpreter
							if(subContext105 != null)
							{
								
								
								
								
								subContext105.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar106 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar106 = FuncCtx103;
						king =  (OperandVar106);
						
						{
							Actor subContext107 = (Actor)FuncCtx103.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext107 ContextSwitchInterpreter
							if(subContext107 != null)
							{
								
								
								System.Int32 OperandVar109 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop108 = subContext107.ScenariosCount; //IsContext = False IsNew = False
								OperandVar109 = prop108;
								
								
								subContext107.ScenariosCount = (System.Int32)(( ( (OperandVar109))) + ( ( (1f))));
							}
						}
					}
				}
			}
			UnityEngine.GameObject OperandVar111 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop110 = External.NoOne(); //IsContext = False IsNew = False
			if(prop110 != null)
			{
				OperandVar111 = prop110;
			}
			UnityEngine.GameObject rival =  (OperandVar111); //IsContext = False IsNew = False
			
			System.Int32 OperandVar114 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable112 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable112 != null)
			{
				System.Int32 prop113 = StoredVariable112.ActorsCount; //IsContext = False IsNew = False
				OperandVar114 = prop113;
			}
			
			System.Int32 OperandVar116 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable112 != null)
			{
				System.Int32 prop115 = StoredVariable112.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar116 = prop115;
			}
			if(( ( (OperandVar114))) > ( ( (OperandVar116))))
			{
				UnityEngine.GameObject OperandVar123 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop122 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar119 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable117 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable117 != null)
					{
						System.Int32 prop118 = StoredVariable117.ScenariosCount; //IsContext = False IsNew = False
						OperandVar119 = prop118;
					};
;
;
;
;
;
UnityEngine.GameObject OperandVar120 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar120 = go;;
;
UnityEngine.GameObject OperandVar121 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar121 = king;;
return ( (( ( (OperandVar119))) < ( ( (2f))))) && ( (!(( ( (OperandVar120))) == ( ( (OperandVar121))))));}); //IsContext = False IsNew = False
				if(prop122 != null)
				{
					OperandVar123 = prop122;
				}
				rival =  (OperandVar123);
			}
			System.Boolean OperandVar126 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar124 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar124 = rival;
			System.Boolean prop125 = External.Has( (OperandVar124)); //IsContext = False IsNew = False
			if(prop125 != false)
			{
				OperandVar126 = prop125;
			}
			if(!(OperandVar126))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx127 = External.SpawnPrefab(( ("npc")).ToString(),( ("rival")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx127 ContextPropertySwitchInterpreter
					if(FuncCtx127 != null)
					{
						FuncCtx127.AddComponent<ScriptedTypes.feudal_landlord_role>();
						Entity EntVar128 = (Entity)FuncCtx127.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx127.AddComponent<ScriptedTypes.noble_role>();
						
						FuncCtx127.AddComponent<ScriptedTypes.criminal_role>();
						
						ScriptedTypes.rival_role ContextVar129 = FuncCtx127.AddComponent<ScriptedTypes.rival_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.rival_role ContextVar129 ContextSwitchInterpreter
							if(ContextVar129 != null)
							{
								
								UnityEngine.GameObject OperandVar131 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								UnityEngine.GameObject prop130 = External.Player(); //IsContext = False IsNew = False
								if(prop130 != null)
								{
									OperandVar131 = prop130;
								}
								ContextVar129.OfWhom = (UnityEngine.GameObject)( (OperandVar131));
							}
						}
						if(EntVar128 != null) EntVar128.ComponentAdded();
						
						{
							Entity subContext132 = (Entity)FuncCtx127.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext132 ContextSwitchInterpreter
							if(subContext132 != null)
							{
								
								
								
								
								subContext132.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						
						{
							Actor subContext133 = (Actor)FuncCtx127.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext133 ContextSwitchInterpreter
							if(subContext133 != null)
							{
								
								
								System.Int32 OperandVar135 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop134 = subContext133.ScenariosCount; //IsContext = False IsNew = False
								OperandVar135 = prop134;
								
								
								subContext133.ScenariosCount = (System.Int32)(( ( (OperandVar135))) + ( ( (1f))));
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
			
			System.Boolean OperandVar137 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable136 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable136 != null)
			{
				applicable = true;
				OperandVar137 = applicable;
			}
			return (System.Boolean) (OperandVar137);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar142 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop141 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar140 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable138 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable138 != null)
				{
					ScriptedTypes.king_role StoredVariable139 = ((ScriptedTypes.king_role)StoredVariable138.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable139 != null)
					{
						OperandVar140 = StoredVariable139;
					}
				};
return  (OperandVar140);}); //IsContext = False IsNew = False
			if(prop141 != null)
			{
				OperandVar142 = prop141;
			}
			king =  (OperandVar142);
			
			System.Boolean OperandVar145 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar143 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar143 = king;
			System.Boolean prop144 = External.Has( (OperandVar143)); //IsContext = False IsNew = False
			if(prop144 != false)
			{
				OperandVar145 = prop144;
			}
			if( (OperandVar145))
			{
				
				ut =  (1f);
				UnityEngine.GameObject OperandVar146 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar146 = king;
				External.Log((System.Object)( (OperandVar146)));
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
				UnityEngine.GameObject FuncCtx147 = External.SpawnPrefab(( ("npc")).ToString(),( ("personal cook")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx147 ContextPropertySwitchInterpreter
				if(FuncCtx147 != null)
				{
					FuncCtx147.AddComponent<ScriptedTypes.cook_role>();
					Entity EntVar148 = (Entity)FuncCtx147.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					ScriptedTypes.servant_role ContextVar149 = FuncCtx147.AddComponent<ScriptedTypes.servant_role>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.servant_role ContextVar149 ContextSwitchInterpreter
						if(ContextVar149 != null)
						{
							
							UnityEngine.GameObject OperandVar150 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar150 = king;
							ContextVar149.OfWhom = (UnityEngine.GameObject)( (OperandVar150));
						}
					}
					if(EntVar148 != null) EntVar148.ComponentAdded();
					
					{
						Entity subContext151 = (Entity)FuncCtx147.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext151 ContextSwitchInterpreter
						if(subContext151 != null)
						{
							
							
							
							
							subContext151.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
						}
					}
					
					{
						Actor subContext152 = (Actor)FuncCtx147.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
						//ContextStatement Actor subContext152 ContextSwitchInterpreter
						if(subContext152 != null)
						{
							
							
							System.Int32 OperandVar154 = default(System.Int32); //IsContext = False IsNew = False
							System.Int32 prop153 = subContext152.ScenariosCount; //IsContext = False IsNew = False
							OperandVar154 = prop153;
							
							
							subContext152.ScenariosCount = (System.Int32)(( ( (OperandVar154))) + ( ( (1f))));
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
			
			System.Boolean OperandVar156 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable155 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable155 != null)
			{
				applicable = true;
				OperandVar156 = applicable;
			}
			return (System.Boolean) (OperandVar156);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar161 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop160 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar159 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable157 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable157 != null)
				{
					ScriptedTypes.king_role StoredVariable158 = ((ScriptedTypes.king_role)StoredVariable157.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable158 != null)
					{
						OperandVar159 = StoredVariable158;
					}
				};
return  (OperandVar159);}); //IsContext = False IsNew = False
			if(prop160 != null)
			{
				OperandVar161 = prop160;
			}
			king =  (OperandVar161);
			
			UnityEngine.GameObject OperandVar169 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop168 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
ScriptedTypes.criminal_role OperandVar164 = default(ScriptedTypes.criminal_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable162 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable162 != null)
				{
					ScriptedTypes.criminal_role StoredVariable163 = ((ScriptedTypes.criminal_role)StoredVariable162.GetComponent(typeof(ScriptedTypes.criminal_role))); //IsContext = False IsNew = False
					if(StoredVariable163 != null)
					{
						OperandVar164 = StoredVariable163;
					}
				};
;
;
System.Int32 OperandVar167 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable165 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable165 != null)
				{
					System.Int32 prop166 = StoredVariable165.ScenariosCount; //IsContext = False IsNew = False
					OperandVar167 = prop166;
				};
;
;
return ( ( (OperandVar164))) && ( (( ( (OperandVar167))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop168 != null)
			{
				OperandVar169 = prop168;
			}
			noble =  (OperandVar169);
			
			
			UnityEngine.GameObject OperandVar170 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar170 = noble;
			
			UnityEngine.GameObject OperandVar171 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar171 = king;
			if(( ( (OperandVar170))) && ( ( (OperandVar171))))
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
			
			
			
			UnityEngine.GameObject OperandVar183 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop182 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
System.Boolean OperandVar178 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.heir_role StoredVariable172 = ((ScriptedTypes.heir_role)go.GetComponent(typeof(ScriptedTypes.heir_role))); //IsContext = False IsNew = False;
if(StoredVariable172 != null)
				{
					ScriptedTypes.woman_role StoredVariable173 = ((ScriptedTypes.woman_role)StoredVariable172.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
					if(StoredVariable173 != null)
					{
						System.Boolean ifResult174; //IsContext = False IsNew = False
						
						UnityEngine.GameObject OperandVar176 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						if(StoredVariable172 != null)
						{
							UnityEngine.GameObject prop175 = StoredVariable172.OfWhom; //IsContext = False IsNew = False
							if(prop175 != null)
							{
								OperandVar176 = prop175;
							}
						}
						
						UnityEngine.GameObject OperandVar177 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar177 = king;
						if(ifResult174 = ( ( (OperandVar176))) == ( ( (OperandVar177))))
						{
							OperandVar178 = ifResult174;
						}
					}
				};
;
;
System.Int32 OperandVar181 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable179 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable179 != null)
				{
					System.Int32 prop180 = StoredVariable179.ScenariosCount; //IsContext = False IsNew = False
					OperandVar181 = prop180;
				};
;
;
return ( ( (OperandVar178))) && ( (( ( (OperandVar181))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop182 != null)
			{
				OperandVar183 = prop182;
			}
			UnityEngine.GameObject kings_daughter =  (OperandVar183); //IsContext = False IsNew = False
			System.Boolean OperandVar186 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar184 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar184 = kings_daughter;
			System.Boolean prop185 = External.Has( (OperandVar184)); //IsContext = False IsNew = False
			if(prop185 != false)
			{
				OperandVar186 = prop185;
			}
			if(!(OperandVar186))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx187 = External.SpawnPrefab(( ("npc")).ToString(),( ("kings_daughter")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx187 ContextPropertySwitchInterpreter
					if(FuncCtx187 != null)
					{
						ScriptedTypes.heir_role ContextVar188 = FuncCtx187.AddComponent<ScriptedTypes.heir_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.heir_role ContextVar188 ContextSwitchInterpreter
							if(ContextVar188 != null)
							{
								
								UnityEngine.GameObject OperandVar189 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar189 = king;
								ContextVar188.OfWhom = (UnityEngine.GameObject)( (OperandVar189));
							}
						}
						Entity EntVar190 = (Entity)FuncCtx187.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx187.AddComponent<ScriptedTypes.woman_role>();
						
						ScriptedTypes.in_love ContextVar191 = FuncCtx187.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.in_love ContextVar191 ContextSwitchInterpreter
							if(ContextVar191 != null)
							{
								
								UnityEngine.GameObject OperandVar192 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar192 = noble;
								ContextVar191.WithWhom = (UnityEngine.GameObject)( (OperandVar192));
							}
						}
						if(EntVar190 != null) EntVar190.ComponentAdded();
						
						{
							Entity subContext193 = (Entity)FuncCtx187.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext193 ContextSwitchInterpreter
							if(subContext193 != null)
							{
								
								
								
								
								subContext193.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar194 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar194 = FuncCtx187;
						kings_daughter =  (OperandVar194);
						
						{
							Actor subContext195 = (Actor)FuncCtx187.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext195 ContextSwitchInterpreter
							if(subContext195 != null)
							{
								
								
								System.Int32 OperandVar197 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop196 = subContext195.ScenariosCount; //IsContext = False IsNew = False
								OperandVar197 = prop196;
								
								
								subContext195.ScenariosCount = (System.Int32)(( ( (OperandVar197))) + ( ( (1f))));
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble ContextSwitchInterpreter
				if(noble != null)
				{
					
					ScriptedTypes.in_love ContextVar198 = noble.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.in_love ContextVar198 ContextSwitchInterpreter
						if(ContextVar198 != null)
						{
							
							UnityEngine.GameObject OperandVar199 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar199 = kings_daughter;
							ContextVar198.WithWhom = (UnityEngine.GameObject)( (OperandVar199));
						}
					}
					Entity EntVar200 = (Entity)noble.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar200 != null) EntVar200.ComponentAdded();
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
			
			
			System.Single OperandVar203 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable201 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable201 != null)
			{
				System.Single prop202 = StoredVariable201.Brightness; //IsContext = False IsNew = False
				OperandVar203 = prop202;
			}
			System.Single OperandVar206 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable204 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable204 != null)
			{
				System.Single prop205 = StoredVariable204.Light; //IsContext = False IsNew = False
				OperandVar206 = prop205;
			}
			val = ( (OperandVar203)) * ( (OperandVar206));
			return val;
		}
        }
        
        public override bool RootFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar209 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable207 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable207 != null)
			{
				LightSensor StoredVariable208 = ((LightSensor)StoredVariable207.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable208 != null)
				{
					applicable = true;
					OperandVar209 = applicable;
				}
			}
			return (System.Boolean) (OperandVar209);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar212 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable210 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable210 != null)
			{
				LightSource StoredVariable211 = ((LightSource)StoredVariable210.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable211 != null)
				{
					applicable = true;
					OperandVar212 = applicable;
				}
			}
			return (System.Boolean) (OperandVar212);
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
			
			
			System.Boolean OperandVar214 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable213 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable213 != null)
			{
				applicable = true;
				OperandVar214 = applicable;
			}
			return (System.Boolean) (OperandVar214);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar216 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable215 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable215 != null)
			{
				applicable = true;
				OperandVar216 = applicable;
			}
			return (System.Boolean) (OperandVar216);
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
			
			System.Boolean OperandVar219 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop217 = root.Target; //IsContext = False IsNew = False
			if(prop217 != null)
			{
				Actor StoredVariable218 = ((Actor)prop217.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable218 != null)
				{
					applicable = true;
					OperandVar219 = applicable;
				}
			}
			return (System.Boolean) (OperandVar219);
		}
        }
        
        public override void Action() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			External.Log((System.Object)( ("reacted to an event")));
			
			{
				VisualsFeed subContext220 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext220 ContextPropertySwitchInterpreter
				if(subContext220 != null)
				{
					TestEvent OperandVar221 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar221 = root;
					UnityEngine.Vector3 OperandVar225 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(root != null)
					{
						UnityEngine.GameObject prop222 = root.Target; //IsContext = False IsNew = False
						if(prop222 != null)
						{
							Entity StoredVariable223 = ((Entity)prop222.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
							if(StoredVariable223 != null)
							{
								UnityEngine.Vector3 prop224 = StoredVariable223.Position; //IsContext = False IsNew = False
								OperandVar225 = prop224;
							}
						}
					}
					subContext220.Push((Event)( (OperandVar221)),(UnityEngine.Vector3)( (OperandVar225)));
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
			
			System.Boolean OperandVar227 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable226 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable226 != null)
			{
				applicable = true;
				OperandVar227 = applicable;
			}
			return (System.Boolean) (OperandVar227);
		}
        }
        
        public override void Action() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			var e = this.e;
			
			
			{
				ScriptedTypes.facts subContext228 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext228 ContextSwitchInterpreter
				if(subContext228 != null)
				{
					
					System.Boolean OperandVar230 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop229 = subContext228.HasNoticedTestEvent(); //IsContext = False IsNew = False
					if(prop229 != false)
					{
						OperandVar230 = prop229;
					}
					if(!(OperandVar230))
					{
						ScriptedTypes.noticed_test_event OperandVar232 = default(ScriptedTypes.noticed_test_event); //IsContext = False IsNew = False
						ScriptedTypes.noticed_test_event prop231 = subContext228.AddNoticedTestEvent(); //IsContext = False IsNew = False
						if(prop231 != null)
						{
							OperandVar232 = prop231;
						}
						ScriptedTypes.noticed_test_event ev =  (OperandVar232); //IsContext = False IsNew = False
					}
				}
			}
		}
        }
    }
}
