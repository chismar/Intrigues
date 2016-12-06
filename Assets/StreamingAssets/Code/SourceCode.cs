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
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=true, IsInteraction=false)]
    public class rival_landlord : EventAction, base_scenario {
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar86 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable85 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
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
			
			
			return (System.Single) (1f);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			UnityEngine.GameObject OperandVar91 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop90 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar89 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable87 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable87 != null)
				{
					ScriptedTypes.king_role StoredVariable88 = ((ScriptedTypes.king_role)StoredVariable87.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable88 != null)
					{
						OperandVar89 = StoredVariable88;
					}
				};
return  (OperandVar89);}); //IsContext = False IsNew = False
			if(prop90 != null)
			{
				OperandVar91 = prop90;
			}
			UnityEngine.GameObject king =  (OperandVar91); //IsContext = False IsNew = False
			System.Boolean OperandVar94 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar92 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar92 = king;
			System.Boolean prop93 = External.Has( (OperandVar92)); //IsContext = False IsNew = False
			if(prop93 != false)
			{
				OperandVar94 = prop93;
			}
			if(!(OperandVar94))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx95 = External.SpawnPrefab(( ("npc")).ToString(),( ("king")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx95 ContextPropertySwitchInterpreter
					if(FuncCtx95 != null)
					{
						FuncCtx95.AddComponent<ScriptedTypes.king_role>();
						Entity EntVar96 = (Entity)FuncCtx95.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						if(EntVar96 != null) EntVar96.ComponentAdded();
						
						{
							Entity subContext97 = (Entity)FuncCtx95.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext97 ContextSwitchInterpreter
							if(subContext97 != null)
							{
								
								
								
								
								subContext97.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar98 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar98 = FuncCtx95;
						king =  (OperandVar98);
						
						{
							Actor subContext99 = (Actor)FuncCtx95.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext99 ContextSwitchInterpreter
							if(subContext99 != null)
							{
								
								
								System.Int32 OperandVar101 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop100 = subContext99.ScenariosCount; //IsContext = False IsNew = False
								OperandVar101 = prop100;
								
								
								subContext99.ScenariosCount = (System.Int32)(( ( (OperandVar101))) + ( ( (1f))));
							}
						}
					}
				}
			}
			UnityEngine.GameObject OperandVar103 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop102 = External.NoOne(); //IsContext = False IsNew = False
			if(prop102 != null)
			{
				OperandVar103 = prop102;
			}
			UnityEngine.GameObject rival =  (OperandVar103); //IsContext = False IsNew = False
			
			System.Int32 OperandVar106 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable104 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable104 != null)
			{
				System.Int32 prop105 = StoredVariable104.ActorsCount; //IsContext = False IsNew = False
				OperandVar106 = prop105;
			}
			
			System.Int32 OperandVar108 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable104 != null)
			{
				System.Int32 prop107 = StoredVariable104.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar108 = prop107;
			}
			if(( ( (OperandVar106))) > ( ( (OperandVar108))))
			{
				UnityEngine.GameObject OperandVar115 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop114 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar111 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable109 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable109 != null)
					{
						System.Int32 prop110 = StoredVariable109.ScenariosCount; //IsContext = False IsNew = False
						OperandVar111 = prop110;
					};
;
;
;
;
;
UnityEngine.GameObject OperandVar112 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar112 = go;;
;
UnityEngine.GameObject OperandVar113 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar113 = king;;
return ( (( ( (OperandVar111))) < ( ( (2f))))) && ( (!(( ( (OperandVar112))) == ( ( (OperandVar113))))));}); //IsContext = False IsNew = False
				if(prop114 != null)
				{
					OperandVar115 = prop114;
				}
				rival =  (OperandVar115);
			}
			System.Boolean OperandVar118 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar116 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar116 = rival;
			System.Boolean prop117 = External.Has( (OperandVar116)); //IsContext = False IsNew = False
			if(prop117 != false)
			{
				OperandVar118 = prop117;
			}
			if(!(OperandVar118))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx119 = External.SpawnPrefab(( ("npc")).ToString(),( ("rival")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx119 ContextPropertySwitchInterpreter
					if(FuncCtx119 != null)
					{
						FuncCtx119.AddComponent<ScriptedTypes.feudal_landlord_role>();
						Entity EntVar120 = (Entity)FuncCtx119.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx119.AddComponent<ScriptedTypes.noble_role>();
						
						FuncCtx119.AddComponent<ScriptedTypes.criminal_role>();
						
						ScriptedTypes.rival_role ContextVar121 = FuncCtx119.AddComponent<ScriptedTypes.rival_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.rival_role ContextVar121 ContextSwitchInterpreter
							if(ContextVar121 != null)
							{
								
								UnityEngine.GameObject OperandVar123 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								UnityEngine.GameObject prop122 = External.Player(); //IsContext = False IsNew = False
								if(prop122 != null)
								{
									OperandVar123 = prop122;
								}
								ContextVar121.OfWhom = (UnityEngine.GameObject)( (OperandVar123));
							}
						}
						if(EntVar120 != null) EntVar120.ComponentAdded();
						
						{
							Entity subContext124 = (Entity)FuncCtx119.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext124 ContextSwitchInterpreter
							if(subContext124 != null)
							{
								
								
								
								
								subContext124.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						
						{
							Actor subContext125 = (Actor)FuncCtx119.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext125 ContextSwitchInterpreter
							if(subContext125 != null)
							{
								
								
								System.Int32 OperandVar127 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop126 = subContext125.ScenariosCount; //IsContext = False IsNew = False
								OperandVar127 = prop126;
								
								
								subContext125.ScenariosCount = (System.Int32)(( ( (OperandVar127))) + ( ( (1f))));
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
			
			System.Boolean OperandVar129 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable128 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable128 != null)
			{
				applicable = true;
				OperandVar129 = applicable;
			}
			return (System.Boolean) (OperandVar129);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar134 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop133 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar132 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable130 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable130 != null)
				{
					ScriptedTypes.king_role StoredVariable131 = ((ScriptedTypes.king_role)StoredVariable130.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable131 != null)
					{
						OperandVar132 = StoredVariable131;
					}
				};
return  (OperandVar132);}); //IsContext = False IsNew = False
			if(prop133 != null)
			{
				OperandVar134 = prop133;
			}
			king =  (OperandVar134);
			
			System.Boolean OperandVar137 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar135 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar135 = king;
			System.Boolean prop136 = External.Has( (OperandVar135)); //IsContext = False IsNew = False
			if(prop136 != false)
			{
				OperandVar137 = prop136;
			}
			if( (OperandVar137))
			{
				
				ut =  (1f);
				UnityEngine.GameObject OperandVar138 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar138 = king;
				External.Log((System.Object)( (OperandVar138)));
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
				UnityEngine.GameObject FuncCtx139 = External.SpawnPrefab(( ("npc")).ToString(),( ("personal cook")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx139 ContextPropertySwitchInterpreter
				if(FuncCtx139 != null)
				{
					FuncCtx139.AddComponent<ScriptedTypes.cook_role>();
					Entity EntVar140 = (Entity)FuncCtx139.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					ScriptedTypes.servant_role ContextVar141 = FuncCtx139.AddComponent<ScriptedTypes.servant_role>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.servant_role ContextVar141 ContextSwitchInterpreter
						if(ContextVar141 != null)
						{
							
							UnityEngine.GameObject OperandVar142 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar142 = king;
							ContextVar141.OfWhom = (UnityEngine.GameObject)( (OperandVar142));
						}
					}
					if(EntVar140 != null) EntVar140.ComponentAdded();
					
					{
						Entity subContext143 = (Entity)FuncCtx139.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext143 ContextSwitchInterpreter
						if(subContext143 != null)
						{
							
							
							
							
							subContext143.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
						}
					}
					
					{
						Actor subContext144 = (Actor)FuncCtx139.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
						//ContextStatement Actor subContext144 ContextSwitchInterpreter
						if(subContext144 != null)
						{
							
							
							System.Int32 OperandVar146 = default(System.Int32); //IsContext = False IsNew = False
							System.Int32 prop145 = subContext144.ScenariosCount; //IsContext = False IsNew = False
							OperandVar146 = prop145;
							
							
							subContext144.ScenariosCount = (System.Int32)(( ( (OperandVar146))) + ( ( (1f))));
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
			
			System.Boolean OperandVar148 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable147 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable147 != null)
			{
				applicable = true;
				OperandVar148 = applicable;
			}
			return (System.Boolean) (OperandVar148);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar153 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop152 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar151 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable149 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable149 != null)
				{
					ScriptedTypes.king_role StoredVariable150 = ((ScriptedTypes.king_role)StoredVariable149.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable150 != null)
					{
						OperandVar151 = StoredVariable150;
					}
				};
return  (OperandVar151);}); //IsContext = False IsNew = False
			if(prop152 != null)
			{
				OperandVar153 = prop152;
			}
			king =  (OperandVar153);
			
			UnityEngine.GameObject OperandVar161 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop160 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
ScriptedTypes.criminal_role OperandVar156 = default(ScriptedTypes.criminal_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable154 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable154 != null)
				{
					ScriptedTypes.criminal_role StoredVariable155 = ((ScriptedTypes.criminal_role)StoredVariable154.GetComponent(typeof(ScriptedTypes.criminal_role))); //IsContext = False IsNew = False
					if(StoredVariable155 != null)
					{
						OperandVar156 = StoredVariable155;
					}
				};
;
;
System.Int32 OperandVar159 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable157 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable157 != null)
				{
					System.Int32 prop158 = StoredVariable157.ScenariosCount; //IsContext = False IsNew = False
					OperandVar159 = prop158;
				};
;
;
return ( ( (OperandVar156))) && ( (( ( (OperandVar159))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop160 != null)
			{
				OperandVar161 = prop160;
			}
			noble =  (OperandVar161);
			
			
			UnityEngine.GameObject OperandVar162 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar162 = noble;
			
			UnityEngine.GameObject OperandVar163 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar163 = king;
			if(( ( (OperandVar162))) && ( ( (OperandVar163))))
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
			
			
			
			UnityEngine.GameObject OperandVar175 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop174 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
System.Boolean OperandVar170 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.heir_role StoredVariable164 = ((ScriptedTypes.heir_role)go.GetComponent(typeof(ScriptedTypes.heir_role))); //IsContext = False IsNew = False;
if(StoredVariable164 != null)
				{
					ScriptedTypes.woman_role StoredVariable165 = ((ScriptedTypes.woman_role)StoredVariable164.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
					if(StoredVariable165 != null)
					{
						System.Boolean ifResult166; //IsContext = False IsNew = False
						
						UnityEngine.GameObject OperandVar168 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						if(StoredVariable164 != null)
						{
							UnityEngine.GameObject prop167 = StoredVariable164.OfWhom; //IsContext = False IsNew = False
							if(prop167 != null)
							{
								OperandVar168 = prop167;
							}
						}
						
						UnityEngine.GameObject OperandVar169 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar169 = king;
						if(ifResult166 = ( ( (OperandVar168))) == ( ( (OperandVar169))))
						{
							OperandVar170 = ifResult166;
						}
					}
				};
;
;
System.Int32 OperandVar173 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable171 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable171 != null)
				{
					System.Int32 prop172 = StoredVariable171.ScenariosCount; //IsContext = False IsNew = False
					OperandVar173 = prop172;
				};
;
;
return ( ( (OperandVar170))) && ( (( ( (OperandVar173))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop174 != null)
			{
				OperandVar175 = prop174;
			}
			UnityEngine.GameObject kings_daughter =  (OperandVar175); //IsContext = False IsNew = False
			System.Boolean OperandVar178 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar176 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar176 = kings_daughter;
			System.Boolean prop177 = External.Has( (OperandVar176)); //IsContext = False IsNew = False
			if(prop177 != false)
			{
				OperandVar178 = prop177;
			}
			if(!(OperandVar178))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx179 = External.SpawnPrefab(( ("npc")).ToString(),( ("kings_daughter")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx179 ContextPropertySwitchInterpreter
					if(FuncCtx179 != null)
					{
						ScriptedTypes.heir_role ContextVar180 = FuncCtx179.AddComponent<ScriptedTypes.heir_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.heir_role ContextVar180 ContextSwitchInterpreter
							if(ContextVar180 != null)
							{
								
								UnityEngine.GameObject OperandVar181 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar181 = king;
								ContextVar180.OfWhom = (UnityEngine.GameObject)( (OperandVar181));
							}
						}
						Entity EntVar182 = (Entity)FuncCtx179.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx179.AddComponent<ScriptedTypes.woman_role>();
						
						ScriptedTypes.in_love ContextVar183 = FuncCtx179.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.in_love ContextVar183 ContextSwitchInterpreter
							if(ContextVar183 != null)
							{
								
								UnityEngine.GameObject OperandVar184 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar184 = noble;
								ContextVar183.WithWhom = (UnityEngine.GameObject)( (OperandVar184));
							}
						}
						if(EntVar182 != null) EntVar182.ComponentAdded();
						
						{
							Entity subContext185 = (Entity)FuncCtx179.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext185 ContextSwitchInterpreter
							if(subContext185 != null)
							{
								
								
								
								
								subContext185.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar186 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar186 = FuncCtx179;
						kings_daughter =  (OperandVar186);
						
						{
							Actor subContext187 = (Actor)FuncCtx179.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext187 ContextSwitchInterpreter
							if(subContext187 != null)
							{
								
								
								System.Int32 OperandVar189 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop188 = subContext187.ScenariosCount; //IsContext = False IsNew = False
								OperandVar189 = prop188;
								
								
								subContext187.ScenariosCount = (System.Int32)(( ( (OperandVar189))) + ( ( (1f))));
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble ContextSwitchInterpreter
				if(noble != null)
				{
					
					ScriptedTypes.in_love ContextVar190 = noble.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.in_love ContextVar190 ContextSwitchInterpreter
						if(ContextVar190 != null)
						{
							
							UnityEngine.GameObject OperandVar191 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar191 = kings_daughter;
							ContextVar190.WithWhom = (UnityEngine.GameObject)( (OperandVar191));
						}
					}
					Entity EntVar192 = (Entity)noble.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar192 != null) EntVar192.ComponentAdded();
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
    
    
    [MetricAttribute(Weight=(50))]
    public class test_metric : Metric {
        
        public override float Value() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single val = 0; //IsContext = False IsNew = False
			
			
			System.Single OperandVar195 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable193 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable193 != null)
			{
				System.Single prop194 = StoredVariable193.Brightness; //IsContext = False IsNew = False
				OperandVar195 = prop194;
			}
			System.Single OperandVar198 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable196 = ((LightSensor)other.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable196 != null)
			{
				System.Single prop197 = StoredVariable196.Light; //IsContext = False IsNew = False
				OperandVar198 = prop197;
			}
			val = ( (OperandVar195)) * ( (OperandVar198));
			return val;
		}
        }
        
        public override bool RootFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar201 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable199 = ((Actor)other.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable199 != null)
			{
				LightSensor StoredVariable200 = ((LightSensor)StoredVariable199.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable200 != null)
				{
					applicable = true;
					OperandVar201 = applicable;
				}
			}
			return (System.Boolean) (OperandVar201);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar204 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable202 = ((Actor)other.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable202 != null)
			{
				LightSource StoredVariable203 = ((LightSource)StoredVariable202.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable203 != null)
				{
					applicable = true;
					OperandVar204 = applicable;
				}
			}
			return (System.Boolean) (OperandVar204);
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
}
