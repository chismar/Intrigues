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
					
					
					
					UnityEngine.GameObject OperandVar76 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar76 = target;
					External.Log((System.Object)(( ( ("Target: "))) + ( ( (OperandVar76)))));
					
					System.Boolean OperandVar78 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop77 = subContext73.IsMoving; //IsContext = False IsNew = False
					OperandVar78 = prop77;
					
					System.Boolean OperandVar80 = default(System.Boolean); //IsContext = False IsNew = False
					
					System.Boolean prop79 = External.Log( ("updated basic_move")); //IsContext = False IsNew = False
					if(prop79 != false)
					{
						OperandVar80 = prop79;
					}
					
					System.Boolean OperandVar82 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop81 = subContext73.IsMoving; //IsContext = False IsNew = False
					OperandVar82 = prop81;
					
					System.Boolean OperandVar84 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop83 = subContext73.NearTarget; //IsContext = False IsNew = False
					OperandVar84 = prop83;
					
					while(( ( (OperandVar78))) && ( ( (OperandVar80)))){ if(( (!(OperandVar82))) && ( (!(OperandVar84)))) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
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
			
			System.Boolean OperandVar86 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable85 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable85 != null)
			{
				applicable = true;
				OperandVar86 = applicable;
			}
			return (System.Boolean) (OperandVar86);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			System.Boolean OperandVar89 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable87 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable87 != null)
			{
				System.Boolean prop88 = StoredVariable87.HasNoticedTestEvent(); //IsContext = False IsNew = False
				if(prop88 != false)
				{
					OperandVar89 = prop88;
				}
			}
			if( (OperandVar89))
			{
				
				
				
				UnityEngine.GameObject OperandVar90 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar90 = root;
				External.Log((System.Object)(( ( ("Utility: noticed test event"))) + ( ( (OperandVar90)))));
				
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
			
			System.Boolean OperandVar93 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable91 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable91 != null)
			{
				Entity StoredVariable92 = ((Entity)StoredVariable91.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable92 != null)
				{
					applicable = true;
					OperandVar93 = applicable;
				}
			}
			return (System.Boolean) (OperandVar93);
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
			Entity EntVar94 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			root.AddComponent<ScriptedTypes.backstory>();
			if(EntVar94 != null) EntVar94.ComponentAdded();
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
			
			System.Boolean OperandVar96 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable95 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable95 != null)
			{
				applicable = true;
				OperandVar96 = applicable;
			}
			return (System.Boolean) (OperandVar96);
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
			
			UnityEngine.GameObject OperandVar101 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop100 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar99 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable97 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable97 != null)
				{
					ScriptedTypes.king_role StoredVariable98 = ((ScriptedTypes.king_role)StoredVariable97.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable98 != null)
					{
						OperandVar99 = StoredVariable98;
					}
				};
return  (OperandVar99);}); //IsContext = False IsNew = False
			if(prop100 != null)
			{
				OperandVar101 = prop100;
			}
			UnityEngine.GameObject king =  (OperandVar101); //IsContext = False IsNew = False
			System.Boolean OperandVar104 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar102 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar102 = king;
			System.Boolean prop103 = External.Has( (OperandVar102)); //IsContext = False IsNew = False
			if(prop103 != false)
			{
				OperandVar104 = prop103;
			}
			if(!(OperandVar104))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx105 = External.SpawnPrefab(( ("npc")).ToString(),( ("king")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx105 ContextPropertySwitchInterpreter
					if(FuncCtx105 != null)
					{
						FuncCtx105.AddComponent<ScriptedTypes.king_role>();
						Entity EntVar106 = (Entity)FuncCtx105.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						if(EntVar106 != null) EntVar106.ComponentAdded();
						
						{
							Entity subContext107 = (Entity)FuncCtx105.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext107 ContextSwitchInterpreter
							if(subContext107 != null)
							{
								
								
								
								
								subContext107.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar108 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar108 = FuncCtx105;
						king =  (OperandVar108);
						
						{
							Actor subContext109 = (Actor)FuncCtx105.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext109 ContextSwitchInterpreter
							if(subContext109 != null)
							{
								
								
								System.Int32 OperandVar111 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop110 = subContext109.ScenariosCount; //IsContext = False IsNew = False
								OperandVar111 = prop110;
								
								
								subContext109.ScenariosCount = (System.Int32)(( ( (OperandVar111))) + ( ( (1f))));
							}
						}
					}
				}
			}
			UnityEngine.GameObject OperandVar113 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop112 = External.NoOne(); //IsContext = False IsNew = False
			if(prop112 != null)
			{
				OperandVar113 = prop112;
			}
			UnityEngine.GameObject rival =  (OperandVar113); //IsContext = False IsNew = False
			
			System.Int32 OperandVar116 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable114 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable114 != null)
			{
				System.Int32 prop115 = StoredVariable114.ActorsCount; //IsContext = False IsNew = False
				OperandVar116 = prop115;
			}
			
			System.Int32 OperandVar118 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable114 != null)
			{
				System.Int32 prop117 = StoredVariable114.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar118 = prop117;
			}
			if(( ( (OperandVar116))) > ( ( (OperandVar118))))
			{
				UnityEngine.GameObject OperandVar125 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop124 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar121 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable119 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable119 != null)
					{
						System.Int32 prop120 = StoredVariable119.ScenariosCount; //IsContext = False IsNew = False
						OperandVar121 = prop120;
					};
;
;
;
;
;
UnityEngine.GameObject OperandVar122 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar122 = go;;
;
UnityEngine.GameObject OperandVar123 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar123 = king;;
return ( (( ( (OperandVar121))) < ( ( (2f))))) && ( (!(( ( (OperandVar122))) == ( ( (OperandVar123))))));}); //IsContext = False IsNew = False
				if(prop124 != null)
				{
					OperandVar125 = prop124;
				}
				rival =  (OperandVar125);
			}
			System.Boolean OperandVar128 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar126 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar126 = rival;
			System.Boolean prop127 = External.Has( (OperandVar126)); //IsContext = False IsNew = False
			if(prop127 != false)
			{
				OperandVar128 = prop127;
			}
			if(!(OperandVar128))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx129 = External.SpawnPrefab(( ("npc")).ToString(),( ("rival")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx129 ContextPropertySwitchInterpreter
					if(FuncCtx129 != null)
					{
						FuncCtx129.AddComponent<ScriptedTypes.feudal_landlord_role>();
						Entity EntVar130 = (Entity)FuncCtx129.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx129.AddComponent<ScriptedTypes.noble_role>();
						
						FuncCtx129.AddComponent<ScriptedTypes.criminal_role>();
						
						ScriptedTypes.rival_role ContextVar131 = FuncCtx129.AddComponent<ScriptedTypes.rival_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.rival_role ContextVar131 ContextSwitchInterpreter
							if(ContextVar131 != null)
							{
								
								UnityEngine.GameObject OperandVar133 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								UnityEngine.GameObject prop132 = External.Player(); //IsContext = False IsNew = False
								if(prop132 != null)
								{
									OperandVar133 = prop132;
								}
								ContextVar131.OfWhom = (UnityEngine.GameObject)( (OperandVar133));
							}
						}
						if(EntVar130 != null) EntVar130.ComponentAdded();
						
						{
							Entity subContext134 = (Entity)FuncCtx129.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext134 ContextSwitchInterpreter
							if(subContext134 != null)
							{
								
								
								
								
								subContext134.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						
						{
							Actor subContext135 = (Actor)FuncCtx129.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext135 ContextSwitchInterpreter
							if(subContext135 != null)
							{
								
								
								System.Int32 OperandVar137 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop136 = subContext135.ScenariosCount; //IsContext = False IsNew = False
								OperandVar137 = prop136;
								
								
								subContext135.ScenariosCount = (System.Int32)(( ( (OperandVar137))) + ( ( (1f))));
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
			
			System.Boolean OperandVar139 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable138 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable138 != null)
			{
				applicable = true;
				OperandVar139 = applicable;
			}
			return (System.Boolean) (OperandVar139);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar144 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop143 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar142 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable140 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable140 != null)
				{
					ScriptedTypes.king_role StoredVariable141 = ((ScriptedTypes.king_role)StoredVariable140.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable141 != null)
					{
						OperandVar142 = StoredVariable141;
					}
				};
return  (OperandVar142);}); //IsContext = False IsNew = False
			if(prop143 != null)
			{
				OperandVar144 = prop143;
			}
			king =  (OperandVar144);
			
			System.Boolean OperandVar147 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar145 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar145 = king;
			System.Boolean prop146 = External.Has( (OperandVar145)); //IsContext = False IsNew = False
			if(prop146 != false)
			{
				OperandVar147 = prop146;
			}
			if( (OperandVar147))
			{
				
				ut =  (1f);
				UnityEngine.GameObject OperandVar148 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar148 = king;
				External.Log((System.Object)( (OperandVar148)));
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
				UnityEngine.GameObject FuncCtx149 = External.SpawnPrefab(( ("npc")).ToString(),( ("personal cook")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx149 ContextPropertySwitchInterpreter
				if(FuncCtx149 != null)
				{
					FuncCtx149.AddComponent<ScriptedTypes.cook_role>();
					Entity EntVar150 = (Entity)FuncCtx149.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					ScriptedTypes.servant_role ContextVar151 = FuncCtx149.AddComponent<ScriptedTypes.servant_role>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.servant_role ContextVar151 ContextSwitchInterpreter
						if(ContextVar151 != null)
						{
							
							UnityEngine.GameObject OperandVar152 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar152 = king;
							ContextVar151.OfWhom = (UnityEngine.GameObject)( (OperandVar152));
						}
					}
					if(EntVar150 != null) EntVar150.ComponentAdded();
					
					{
						Entity subContext153 = (Entity)FuncCtx149.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext153 ContextSwitchInterpreter
						if(subContext153 != null)
						{
							
							
							
							
							subContext153.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
						}
					}
					
					{
						Actor subContext154 = (Actor)FuncCtx149.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
						//ContextStatement Actor subContext154 ContextSwitchInterpreter
						if(subContext154 != null)
						{
							
							
							System.Int32 OperandVar156 = default(System.Int32); //IsContext = False IsNew = False
							System.Int32 prop155 = subContext154.ScenariosCount; //IsContext = False IsNew = False
							OperandVar156 = prop155;
							
							
							subContext154.ScenariosCount = (System.Int32)(( ( (OperandVar156))) + ( ( (1f))));
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
			
			System.Boolean OperandVar158 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable157 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable157 != null)
			{
				applicable = true;
				OperandVar158 = applicable;
			}
			return (System.Boolean) (OperandVar158);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar163 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop162 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar161 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable159 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable159 != null)
				{
					ScriptedTypes.king_role StoredVariable160 = ((ScriptedTypes.king_role)StoredVariable159.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable160 != null)
					{
						OperandVar161 = StoredVariable160;
					}
				};
return  (OperandVar161);}); //IsContext = False IsNew = False
			if(prop162 != null)
			{
				OperandVar163 = prop162;
			}
			king =  (OperandVar163);
			
			UnityEngine.GameObject OperandVar171 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop170 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
ScriptedTypes.criminal_role OperandVar166 = default(ScriptedTypes.criminal_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable164 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable164 != null)
				{
					ScriptedTypes.criminal_role StoredVariable165 = ((ScriptedTypes.criminal_role)StoredVariable164.GetComponent(typeof(ScriptedTypes.criminal_role))); //IsContext = False IsNew = False
					if(StoredVariable165 != null)
					{
						OperandVar166 = StoredVariable165;
					}
				};
;
;
System.Int32 OperandVar169 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable167 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable167 != null)
				{
					System.Int32 prop168 = StoredVariable167.ScenariosCount; //IsContext = False IsNew = False
					OperandVar169 = prop168;
				};
;
;
return ( ( (OperandVar166))) && ( (( ( (OperandVar169))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop170 != null)
			{
				OperandVar171 = prop170;
			}
			noble =  (OperandVar171);
			
			
			UnityEngine.GameObject OperandVar172 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar172 = noble;
			
			UnityEngine.GameObject OperandVar173 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar173 = king;
			if(( ( (OperandVar172))) && ( ( (OperandVar173))))
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
			
			
			
			UnityEngine.GameObject OperandVar185 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop184 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
System.Boolean OperandVar180 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.heir_role StoredVariable174 = ((ScriptedTypes.heir_role)go.GetComponent(typeof(ScriptedTypes.heir_role))); //IsContext = False IsNew = False;
if(StoredVariable174 != null)
				{
					ScriptedTypes.woman_role StoredVariable175 = ((ScriptedTypes.woman_role)StoredVariable174.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
					if(StoredVariable175 != null)
					{
						System.Boolean ifResult176; //IsContext = False IsNew = False
						
						UnityEngine.GameObject OperandVar178 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						if(StoredVariable174 != null)
						{
							UnityEngine.GameObject prop177 = StoredVariable174.OfWhom; //IsContext = False IsNew = False
							if(prop177 != null)
							{
								OperandVar178 = prop177;
							}
						}
						
						UnityEngine.GameObject OperandVar179 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar179 = king;
						if(ifResult176 = ( ( (OperandVar178))) == ( ( (OperandVar179))))
						{
							OperandVar180 = ifResult176;
						}
					}
				};
;
;
System.Int32 OperandVar183 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable181 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable181 != null)
				{
					System.Int32 prop182 = StoredVariable181.ScenariosCount; //IsContext = False IsNew = False
					OperandVar183 = prop182;
				};
;
;
return ( ( (OperandVar180))) && ( (( ( (OperandVar183))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop184 != null)
			{
				OperandVar185 = prop184;
			}
			UnityEngine.GameObject kings_daughter =  (OperandVar185); //IsContext = False IsNew = False
			System.Boolean OperandVar188 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar186 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar186 = kings_daughter;
			System.Boolean prop187 = External.Has( (OperandVar186)); //IsContext = False IsNew = False
			if(prop187 != false)
			{
				OperandVar188 = prop187;
			}
			if(!(OperandVar188))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx189 = External.SpawnPrefab(( ("npc")).ToString(),( ("kings_daughter")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx189 ContextPropertySwitchInterpreter
					if(FuncCtx189 != null)
					{
						ScriptedTypes.heir_role ContextVar190 = FuncCtx189.AddComponent<ScriptedTypes.heir_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.heir_role ContextVar190 ContextSwitchInterpreter
							if(ContextVar190 != null)
							{
								
								UnityEngine.GameObject OperandVar191 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar191 = king;
								ContextVar190.OfWhom = (UnityEngine.GameObject)( (OperandVar191));
							}
						}
						Entity EntVar192 = (Entity)FuncCtx189.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx189.AddComponent<ScriptedTypes.woman_role>();
						
						ScriptedTypes.in_love ContextVar193 = FuncCtx189.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.in_love ContextVar193 ContextSwitchInterpreter
							if(ContextVar193 != null)
							{
								
								UnityEngine.GameObject OperandVar194 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar194 = noble;
								ContextVar193.WithWhom = (UnityEngine.GameObject)( (OperandVar194));
							}
						}
						if(EntVar192 != null) EntVar192.ComponentAdded();
						
						{
							Entity subContext195 = (Entity)FuncCtx189.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext195 ContextSwitchInterpreter
							if(subContext195 != null)
							{
								
								
								
								
								subContext195.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar196 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar196 = FuncCtx189;
						kings_daughter =  (OperandVar196);
						
						{
							Actor subContext197 = (Actor)FuncCtx189.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext197 ContextSwitchInterpreter
							if(subContext197 != null)
							{
								
								
								System.Int32 OperandVar199 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop198 = subContext197.ScenariosCount; //IsContext = False IsNew = False
								OperandVar199 = prop198;
								
								
								subContext197.ScenariosCount = (System.Int32)(( ( (OperandVar199))) + ( ( (1f))));
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble ContextSwitchInterpreter
				if(noble != null)
				{
					
					ScriptedTypes.in_love ContextVar200 = noble.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.in_love ContextVar200 ContextSwitchInterpreter
						if(ContextVar200 != null)
						{
							
							UnityEngine.GameObject OperandVar201 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar201 = kings_daughter;
							ContextVar200.WithWhom = (UnityEngine.GameObject)( (OperandVar201));
						}
					}
					Entity EntVar202 = (Entity)noble.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar202 != null) EntVar202.ComponentAdded();
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
			
			
			System.Single OperandVar205 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable203 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable203 != null)
			{
				System.Single prop204 = StoredVariable203.Brightness; //IsContext = False IsNew = False
				OperandVar205 = prop204;
			}
			System.Single OperandVar208 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable206 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable206 != null)
			{
				System.Single prop207 = StoredVariable206.Light; //IsContext = False IsNew = False
				OperandVar208 = prop207;
			}
			val = ( (OperandVar205)) * ( (OperandVar208));
			return val;
		}
        }
        
        public override bool RootFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar211 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable209 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable209 != null)
			{
				LightSensor StoredVariable210 = ((LightSensor)StoredVariable209.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable210 != null)
				{
					applicable = true;
					OperandVar211 = applicable;
				}
			}
			return (System.Boolean) (OperandVar211);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar214 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable212 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable212 != null)
			{
				LightSource StoredVariable213 = ((LightSource)StoredVariable212.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable213 != null)
				{
					applicable = true;
					OperandVar214 = applicable;
				}
			}
			return (System.Boolean) (OperandVar214);
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
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar218 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable217 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable217 != null)
			{
				applicable = true;
				OperandVar218 = applicable;
			}
			return (System.Boolean) (OperandVar218);
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
			
			System.Boolean OperandVar221 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop219 = root.Target; //IsContext = False IsNew = False
			if(prop219 != null)
			{
				Actor StoredVariable220 = ((Actor)prop219.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable220 != null)
				{
					applicable = true;
					OperandVar221 = applicable;
				}
			}
			return (System.Boolean) (OperandVar221);
		}
        }
        
        public override void Action() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			External.Log((System.Object)( ("reacted to an event")));
			
			{
				VisualsFeed subContext222 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext222 ContextPropertySwitchInterpreter
				if(subContext222 != null)
				{
					TestEvent OperandVar223 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar223 = root;
					UnityEngine.Vector3 OperandVar227 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(root != null)
					{
						UnityEngine.GameObject prop224 = root.Target; //IsContext = False IsNew = False
						if(prop224 != null)
						{
							Entity StoredVariable225 = ((Entity)prop224.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
							if(StoredVariable225 != null)
							{
								UnityEngine.Vector3 prop226 = StoredVariable225.Position; //IsContext = False IsNew = False
								OperandVar227 = prop226;
							}
						}
					}
					subContext222.Push((Event)( (OperandVar223)),(UnityEngine.Vector3)( (OperandVar227)));
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
			
			System.Boolean OperandVar229 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable228 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable228 != null)
			{
				applicable = true;
				OperandVar229 = applicable;
			}
			return (System.Boolean) (OperandVar229);
		}
        }
        
        public override void Action() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			var e = this.e;
			
			
			{
				ScriptedTypes.facts subContext230 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext230 ContextSwitchInterpreter
				if(subContext230 != null)
				{
					
					System.Boolean OperandVar232 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop231 = subContext230.HasNoticedTestEvent(); //IsContext = False IsNew = False
					if(prop231 != false)
					{
						OperandVar232 = prop231;
					}
					if(!(OperandVar232))
					{
						ScriptedTypes.noticed_test_event OperandVar234 = default(ScriptedTypes.noticed_test_event); //IsContext = False IsNew = False
						ScriptedTypes.noticed_test_event prop233 = subContext230.AddNoticedTestEvent(); //IsContext = False IsNew = False
						if(prop233 != null)
						{
							OperandVar234 = prop233;
						}
						ScriptedTypes.noticed_test_event ev =  (OperandVar234); //IsContext = False IsNew = False
					}
				}
			}
			
			UnityEngine.GameObject OperandVar235 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar235 = root;
			
			
			
			System.Boolean OperandVar238 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable236 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable236 != null)
			{
				System.Boolean prop237 = StoredVariable236.HasNoticedTestEvent(); //IsContext = False IsNew = False
				if(prop237 != false)
				{
					OperandVar238 = prop237;
				}
			}
			External.Log((System.Object)(( ( (OperandVar235))) + ( ( ("has_noticed_test_event = "))) + ( ( (OperandVar238)))));
			System.Single OperandVar242 = default(System.Single); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar240 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			if(e != null)
			{
				UnityEngine.GameObject prop239 = e.Target; //IsContext = False IsNew = False
				if(prop239 != null)
				{
					OperandVar240 = prop239;
				}
			}
			var metrics241 = root != null?root.GetComponent<Metrics>():null;
			OperandVar242 = (metrics241 != null? metrics241.Value("test_metrics",  (OperandVar240)) : 0f);
			External.Log((System.Object)( (OperandVar242)));
			System.Single OperandVar246 = default(System.Single); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar244 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			if(e != null)
			{
				UnityEngine.GameObject prop243 = e.Target; //IsContext = False IsNew = False
				if(prop243 != null)
				{
					OperandVar244 = prop243;
				}
			}
			var metrics245 = root != null?root.GetComponent<Metrics>():null;
			OperandVar246 = (metrics245 != null? metrics245.Weight("test_metrics",  (OperandVar244)) : 0f);
			External.Log((System.Object)( (OperandVar246)));
		}
        }
    }
}
