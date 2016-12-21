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
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=false, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class rival_story : EventAction, DialogOption {
        
        private UnityEngine.GameObject other;
        
        UnityEngine.GameObject DialogOption.Other {
            get {
return other; 
            }
            set {
other = value; 
            }
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar99 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable84 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable84 != null)
			{
				Talkable StoredVariable85 = ((Talkable)StoredVariable84.GetComponent(typeof(Talkable))); //IsContext = False IsNew = False
				if(StoredVariable85 != null)
				{
					Markers StoredVariable86 = ((Markers)StoredVariable85.GetComponent(typeof(Markers))); //IsContext = False IsNew = False
					if(StoredVariable86 != null)
					{
						Relationships StoredVariable87 = ((Relationships)StoredVariable86.GetComponent(typeof(Relationships))); //IsContext = False IsNew = False
						if(StoredVariable87 != null)
						{
							ScriptedTypes.personality StoredVariable88 = ((ScriptedTypes.personality)StoredVariable87.GetComponent(typeof(ScriptedTypes.personality))); //IsContext = False IsNew = False
							if(StoredVariable88 != null)
							{
								System.Boolean ifResult89; //IsContext = False IsNew = False
								
								System.Boolean OperandVar91 = default(System.Boolean); //IsContext = False IsNew = False
								System.Boolean prop90 = StoredVariable84.HasRival(); //IsContext = False IsNew = False
								if(prop90 != false)
								{
									OperandVar91 = prop90;
								}
								
								System.Boolean OperandVar93 = default(System.Boolean); //IsContext = False IsNew = False
								if(StoredVariable85 != null)
								{
									System.Boolean prop92 = StoredVariable85.CanTalk; //IsContext = False IsNew = False
									OperandVar93 = prop92;
								}
								
								
								System.Single OperandVar96 = default(System.Single); //IsContext = False IsNew = False
								UnityEngine.GameObject OperandVar94 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar94 = other;
								System.Single prop95 = StoredVariable87.RelationsWith( (OperandVar94)); //IsContext = False IsNew = False
								OperandVar96 = prop95;
								
								System.Single OperandVar98 = default(System.Single); //IsContext = False IsNew = False
								System.Single prop97 = StoredVariable88.Trust; //IsContext = False IsNew = False
								OperandVar98 = prop97;
								if(ifResult89 = ( ( (OperandVar91))) && ( ( (OperandVar93))) && ( (( ( (OperandVar96))) > ( ( (OperandVar98))))))
								{
									applicable = true;
									OperandVar99 = applicable;
								}
							}
						}
					}
				}
			}
			return (System.Boolean) (OperandVar99);
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
			
			
			
			{
				Talkable subContext100 = (Talkable)root.GetComponent(typeof(Talkable)); //IsContext = True IsNew = False
				//ContextStatement Talkable subContext100 ContextSwitchInterpreter
				if(subContext100 != null)
				{
					
					
					{
						ScriptedTypes.facts subContext101 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext101 ContextSwitchInterpreter
						if(subContext101 != null)
						{
							
							ScriptedTypes.rival_queryDelegate Lambda102 = (ScriptedTypes.rival fact) => 
							{
								
								System.Boolean return_value = default(System.Boolean); //IsContext = False IsNew = False
								ScriptedTypes.facts OperandVar103 = default(ScriptedTypes.facts); //IsContext = False IsNew = False
								OperandVar103 = subContext101;
								ScriptedTypes.facts rival_of_root =  (OperandVar103); //IsContext = False IsNew = False
								
								{
									Dialog FuncCtx104 = subContext100.Dialog();; //IsContext = True IsNew = False
									//ContextStatement Dialog FuncCtx104 ContextPropertySwitchInterpreter
									if(FuncCtx104 != null)
									{
										
										System.String OperandVar105 = default(System.String); //IsContext = False IsNew = False
										OperandVar105 = "rival_story";
										
										System.Int32 OperandVar108 = default(System.Int32); //IsContext = False IsNew = False
										Entity StoredVariable106 = ((Entity)rival_of_root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
										if(StoredVariable106 != null)
										{
											System.Int32 prop107 = StoredVariable106.Id; //IsContext = False IsNew = False
											OperandVar108 = prop107;
										}
										FuncCtx104.Id = (System.String)(( ( (OperandVar105))) + ( ( (OperandVar108))));
										System.String OperandVar109 = default(System.String); //IsContext = False IsNew = False
										OperandVar109 = "looks_anxious";
										FuncCtx104.Hook = (System.String)( (OperandVar109));
										FuncCtx104.Utility = (Dialog.FloatDelegate)(()=>{;
return  (1f);});
										FuncCtx104.Allowed = (Dialog.BoolDelegate)(()=>{System.Boolean OperandVar114 = default(System.Boolean); //IsContext = False IsNew = False;
Markers StoredVariable110 = ((Markers)subContext101.GetComponent(typeof(Markers))); //IsContext = False IsNew = False;
if(StoredVariable110 != null)
											{
												System.String OperandVar112 = default(System.String); //IsContext = False IsNew = False
												if(FuncCtx104 != null)
												{
													System.String prop111 = FuncCtx104.Id; //IsContext = False IsNew = False
													if(prop111 != null)
													{
														OperandVar112 = prop111;
													}
												}
												System.Boolean prop113 = StoredVariable110.HasMarker( (OperandVar112)); //IsContext = False IsNew = False
												if(prop113 != false)
												{
													OperandVar114 = prop113;
												}
											};
return !(OperandVar114);});
										
										{
											DialogLine FuncCtx115 = FuncCtx104.Say();; //IsContext = True IsNew = False
											//ContextStatement DialogLine FuncCtx115 ContextPropertySwitchInterpreter
											if(FuncCtx115 != null)
											{
												
												FuncCtx115.String = (System.String)( ("say_about_rival"));
												
												{
													VoidDelegate subContext116 = FuncCtx115.Reaction; //IsContext = True IsNew = False
													//ContextStatement VoidDelegate subContext116 ContextPropertySwitchInterpreter
													if(subContext116 != null)
													{
														
														{
															Markers subContext117 = (Markers)root.GetComponent(typeof(Markers)); //IsContext = True IsNew = False
															//ContextStatement Markers subContext117 ContextSwitchInterpreter
															if(subContext117 != null)
															{
																
																System.String OperandVar119 = default(System.String); //IsContext = False IsNew = False
																if(FuncCtx104 != null)
																{
																	System.String prop118 = FuncCtx104.Id; //IsContext = False IsNew = False
																	if(prop118 != null)
																	{
																		OperandVar119 = prop118;
																	}
																}
																subContext117.SetMarker(( (OperandVar119)).ToString());
															}
														}
													}
												}
											}
										}
									}
								}
								return return_value;
							};
							subContext101.QueryRival(Lambda102);
						}
					}
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();
this.other = default(UnityEngine.GameObject);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class npc_has_facts_and_backstory : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			System.Boolean OperandVar122 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable120 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable120 != null)
			{
				Entity StoredVariable121 = ((Entity)StoredVariable120.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable121 != null)
				{
					applicable = true;
					OperandVar122 = applicable;
				}
			}
			return (System.Boolean) (OperandVar122);
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
			Entity EntVar123 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			root.AddComponent<ScriptedTypes.backstory>();
			
			root.AddComponent<ScriptedTypes.personality>();
			if(EntVar123 != null) EntVar123.ComponentAdded();
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
			
			System.Boolean OperandVar125 = default(System.Boolean); //IsContext = False IsNew = False
			PlayerMarker StoredVariable124 = ((PlayerMarker)root.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
			if(StoredVariable124 != null)
			{
				applicable = true;
				OperandVar125 = applicable;
			}
			return (System.Boolean) (OperandVar125);
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
			Entity EntVar126 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			root.AddComponent<TurnFollowMouseController>();
			
			root.AddComponent<InteractableController>();
			if(EntVar126 != null) EntVar126.ComponentAdded();
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
			
			System.Boolean OperandVar128 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable127 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable127 != null)
			{
				applicable = true;
				OperandVar128 = applicable;
			}
			return (System.Boolean) (OperandVar128);
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
			
			UnityEngine.GameObject OperandVar133 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop132 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar131 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable129 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable129 != null)
				{
					ScriptedTypes.king_role StoredVariable130 = ((ScriptedTypes.king_role)StoredVariable129.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable130 != null)
					{
						OperandVar131 = StoredVariable130;
					}
				};
return  (OperandVar131);}); //IsContext = False IsNew = False
			if(prop132 != null)
			{
				OperandVar133 = prop132;
			}
			UnityEngine.GameObject king =  (OperandVar133); //IsContext = False IsNew = False
			System.Boolean OperandVar136 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar134 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar134 = king;
			System.Boolean prop135 = External.Has( (OperandVar134)); //IsContext = False IsNew = False
			if(prop135 != false)
			{
				OperandVar136 = prop135;
			}
			if(!(OperandVar136))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx137 = External.SpawnPrefab(( ("npc")).ToString(),( ("king")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx137 ContextPropertySwitchInterpreter
					if(FuncCtx137 != null)
					{
						FuncCtx137.AddComponent<ScriptedTypes.king_role>();
						Entity EntVar138 = (Entity)FuncCtx137.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						if(EntVar138 != null) EntVar138.ComponentAdded();
						
						{
							Entity subContext139 = (Entity)FuncCtx137.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext139 ContextSwitchInterpreter
							if(subContext139 != null)
							{
								
								
								
								
								subContext139.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar140 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar140 = FuncCtx137;
						king =  (OperandVar140);
						
						{
							Actor subContext141 = (Actor)FuncCtx137.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext141 ContextSwitchInterpreter
							if(subContext141 != null)
							{
								
								
								System.Int32 OperandVar143 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop142 = subContext141.ScenariosCount; //IsContext = False IsNew = False
								OperandVar143 = prop142;
								
								
								subContext141.ScenariosCount = (System.Int32)(( ( (OperandVar143))) + ( ( (1f))));
							}
						}
					}
				}
			}
			UnityEngine.GameObject OperandVar145 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop144 = External.NoOne(); //IsContext = False IsNew = False
			if(prop144 != null)
			{
				OperandVar145 = prop144;
			}
			UnityEngine.GameObject rival =  (OperandVar145); //IsContext = False IsNew = False
			
			System.Int32 OperandVar148 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable146 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable146 != null)
			{
				System.Int32 prop147 = StoredVariable146.ActorsCount; //IsContext = False IsNew = False
				OperandVar148 = prop147;
			}
			
			System.Int32 OperandVar150 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable146 != null)
			{
				System.Int32 prop149 = StoredVariable146.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar150 = prop149;
			}
			if(( ( (OperandVar148))) > ( ( (OperandVar150))))
			{
				UnityEngine.GameObject OperandVar157 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop156 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar153 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable151 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable151 != null)
					{
						System.Int32 prop152 = StoredVariable151.ScenariosCount; //IsContext = False IsNew = False
						OperandVar153 = prop152;
					};
;
;
;
;
;
UnityEngine.GameObject OperandVar154 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar154 = go;;
;
UnityEngine.GameObject OperandVar155 = default(UnityEngine.GameObject); //IsContext = False IsNew = False;
OperandVar155 = king;;
return ( (( ( (OperandVar153))) < ( ( (2f))))) && ( (!(( ( (OperandVar154))) == ( ( (OperandVar155))))));}); //IsContext = False IsNew = False
				if(prop156 != null)
				{
					OperandVar157 = prop156;
				}
				rival =  (OperandVar157);
			}
			System.Boolean OperandVar160 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar158 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar158 = rival;
			System.Boolean prop159 = External.Has( (OperandVar158)); //IsContext = False IsNew = False
			if(prop159 != false)
			{
				OperandVar160 = prop159;
			}
			if(!(OperandVar160))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx161 = External.SpawnPrefab(( ("npc")).ToString(),( ("rival")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx161 ContextPropertySwitchInterpreter
					if(FuncCtx161 != null)
					{
						FuncCtx161.AddComponent<ScriptedTypes.feudal_landlord_role>();
						Entity EntVar162 = (Entity)FuncCtx161.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx161.AddComponent<ScriptedTypes.noble_role>();
						
						FuncCtx161.AddComponent<ScriptedTypes.criminal_role>();
						
						ScriptedTypes.rival_role ContextVar163 = FuncCtx161.AddComponent<ScriptedTypes.rival_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.rival_role ContextVar163 ContextSwitchInterpreter
							if(ContextVar163 != null)
							{
								
								UnityEngine.GameObject OperandVar165 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								UnityEngine.GameObject prop164 = External.Player(); //IsContext = False IsNew = False
								if(prop164 != null)
								{
									OperandVar165 = prop164;
								}
								ContextVar163.OfWhom = (UnityEngine.GameObject)( (OperandVar165));
							}
						}
						if(EntVar162 != null) EntVar162.ComponentAdded();
						
						{
							Entity subContext166 = (Entity)FuncCtx161.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext166 ContextSwitchInterpreter
							if(subContext166 != null)
							{
								
								
								
								
								subContext166.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						
						{
							Actor subContext167 = (Actor)FuncCtx161.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext167 ContextSwitchInterpreter
							if(subContext167 != null)
							{
								
								
								System.Int32 OperandVar169 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop168 = subContext167.ScenariosCount; //IsContext = False IsNew = False
								OperandVar169 = prop168;
								
								
								subContext167.ScenariosCount = (System.Int32)(( ( (OperandVar169))) + ( ( (1f))));
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
			
			System.Boolean OperandVar171 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable170 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable170 != null)
			{
				applicable = true;
				OperandVar171 = applicable;
			}
			return (System.Boolean) (OperandVar171);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar176 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop175 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar174 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable172 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable172 != null)
				{
					ScriptedTypes.king_role StoredVariable173 = ((ScriptedTypes.king_role)StoredVariable172.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable173 != null)
					{
						OperandVar174 = StoredVariable173;
					}
				};
return  (OperandVar174);}); //IsContext = False IsNew = False
			if(prop175 != null)
			{
				OperandVar176 = prop175;
			}
			king =  (OperandVar176);
			
			System.Boolean OperandVar179 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar177 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar177 = king;
			System.Boolean prop178 = External.Has( (OperandVar177)); //IsContext = False IsNew = False
			if(prop178 != false)
			{
				OperandVar179 = prop178;
			}
			if( (OperandVar179))
			{
				
				ut =  (1f);
				UnityEngine.GameObject OperandVar180 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar180 = king;
				External.Log((System.Object)( (OperandVar180)));
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
				UnityEngine.GameObject FuncCtx181 = External.SpawnPrefab(( ("npc")).ToString(),( ("personal cook")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx181 ContextPropertySwitchInterpreter
				if(FuncCtx181 != null)
				{
					FuncCtx181.AddComponent<ScriptedTypes.cook_role>();
					Entity EntVar182 = (Entity)FuncCtx181.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					ScriptedTypes.servant_role ContextVar183 = FuncCtx181.AddComponent<ScriptedTypes.servant_role>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.servant_role ContextVar183 ContextSwitchInterpreter
						if(ContextVar183 != null)
						{
							
							UnityEngine.GameObject OperandVar184 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar184 = king;
							ContextVar183.OfWhom = (UnityEngine.GameObject)( (OperandVar184));
						}
					}
					if(EntVar182 != null) EntVar182.ComponentAdded();
					
					{
						Entity subContext185 = (Entity)FuncCtx181.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext185 ContextSwitchInterpreter
						if(subContext185 != null)
						{
							
							
							
							
							subContext185.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
						}
					}
					
					{
						Actor subContext186 = (Actor)FuncCtx181.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
						//ContextStatement Actor subContext186 ContextSwitchInterpreter
						if(subContext186 != null)
						{
							
							
							System.Int32 OperandVar188 = default(System.Int32); //IsContext = False IsNew = False
							System.Int32 prop187 = subContext186.ScenariosCount; //IsContext = False IsNew = False
							OperandVar188 = prop187;
							
							
							subContext186.ScenariosCount = (System.Int32)(( ( (OperandVar188))) + ( ( (1f))));
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
			
			System.Boolean OperandVar190 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable189 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable189 != null)
			{
				applicable = true;
				OperandVar190 = applicable;
			}
			return (System.Boolean) (OperandVar190);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar195 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop194 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
ScriptedTypes.king_role OperandVar193 = default(ScriptedTypes.king_role); //IsContext = False IsNew = False;
Actor StoredVariable191 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable191 != null)
				{
					ScriptedTypes.king_role StoredVariable192 = ((ScriptedTypes.king_role)StoredVariable191.GetComponent(typeof(ScriptedTypes.king_role))); //IsContext = False IsNew = False
					if(StoredVariable192 != null)
					{
						OperandVar193 = StoredVariable192;
					}
				};
return  (OperandVar193);}); //IsContext = False IsNew = False
			if(prop194 != null)
			{
				OperandVar195 = prop194;
			}
			king =  (OperandVar195);
			
			UnityEngine.GameObject OperandVar203 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop202 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
ScriptedTypes.criminal_role OperandVar198 = default(ScriptedTypes.criminal_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable196 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable196 != null)
				{
					ScriptedTypes.criminal_role StoredVariable197 = ((ScriptedTypes.criminal_role)StoredVariable196.GetComponent(typeof(ScriptedTypes.criminal_role))); //IsContext = False IsNew = False
					if(StoredVariable197 != null)
					{
						OperandVar198 = StoredVariable197;
					}
				};
;
;
System.Int32 OperandVar201 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable199 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable199 != null)
				{
					System.Int32 prop200 = StoredVariable199.ScenariosCount; //IsContext = False IsNew = False
					OperandVar201 = prop200;
				};
;
;
return ( ( (OperandVar198))) && ( (( ( (OperandVar201))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop202 != null)
			{
				OperandVar203 = prop202;
			}
			noble =  (OperandVar203);
			
			
			UnityEngine.GameObject OperandVar204 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar204 = noble;
			
			UnityEngine.GameObject OperandVar205 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar205 = king;
			if(( ( (OperandVar204))) && ( ( (OperandVar205))))
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
			
			
			
			UnityEngine.GameObject OperandVar217 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			
			UnityEngine.GameObject prop216 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
System.Boolean OperandVar212 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.heir_role StoredVariable206 = ((ScriptedTypes.heir_role)go.GetComponent(typeof(ScriptedTypes.heir_role))); //IsContext = False IsNew = False;
if(StoredVariable206 != null)
				{
					ScriptedTypes.woman_role StoredVariable207 = ((ScriptedTypes.woman_role)StoredVariable206.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
					if(StoredVariable207 != null)
					{
						System.Boolean ifResult208; //IsContext = False IsNew = False
						
						UnityEngine.GameObject OperandVar210 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						if(StoredVariable206 != null)
						{
							UnityEngine.GameObject prop209 = StoredVariable206.OfWhom; //IsContext = False IsNew = False
							if(prop209 != null)
							{
								OperandVar210 = prop209;
							}
						}
						
						UnityEngine.GameObject OperandVar211 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar211 = king;
						if(ifResult208 = ( ( (OperandVar210))) == ( ( (OperandVar211))))
						{
							OperandVar212 = ifResult208;
						}
					}
				};
;
;
System.Int32 OperandVar215 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable213 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable213 != null)
				{
					System.Int32 prop214 = StoredVariable213.ScenariosCount; //IsContext = False IsNew = False
					OperandVar215 = prop214;
				};
;
;
return ( ( (OperandVar212))) && ( (( ( (OperandVar215))) < ( ( (2f)))));}); //IsContext = False IsNew = False
			if(prop216 != null)
			{
				OperandVar217 = prop216;
			}
			UnityEngine.GameObject kings_daughter =  (OperandVar217); //IsContext = False IsNew = False
			System.Boolean OperandVar220 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar218 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar218 = kings_daughter;
			System.Boolean prop219 = External.Has( (OperandVar218)); //IsContext = False IsNew = False
			if(prop219 != false)
			{
				OperandVar220 = prop219;
			}
			if(!(OperandVar220))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx221 = External.SpawnPrefab(( ("npc")).ToString(),( ("kings_daughter")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx221 ContextPropertySwitchInterpreter
					if(FuncCtx221 != null)
					{
						ScriptedTypes.heir_role ContextVar222 = FuncCtx221.AddComponent<ScriptedTypes.heir_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.heir_role ContextVar222 ContextSwitchInterpreter
							if(ContextVar222 != null)
							{
								
								UnityEngine.GameObject OperandVar223 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar223 = king;
								ContextVar222.OfWhom = (UnityEngine.GameObject)( (OperandVar223));
							}
						}
						Entity EntVar224 = (Entity)FuncCtx221.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx221.AddComponent<ScriptedTypes.woman_role>();
						
						ScriptedTypes.in_love ContextVar225 = FuncCtx221.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.in_love ContextVar225 ContextSwitchInterpreter
							if(ContextVar225 != null)
							{
								
								UnityEngine.GameObject OperandVar226 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar226 = noble;
								ContextVar225.WithWhom = (UnityEngine.GameObject)( (OperandVar226));
							}
						}
						if(EntVar224 != null) EntVar224.ComponentAdded();
						
						{
							Entity subContext227 = (Entity)FuncCtx221.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext227 ContextSwitchInterpreter
							if(subContext227 != null)
							{
								
								
								
								
								subContext227.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (3f)));
							}
						}
						UnityEngine.GameObject OperandVar228 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar228 = FuncCtx221;
						kings_daughter =  (OperandVar228);
						
						{
							Actor subContext229 = (Actor)FuncCtx221.GetComponent(typeof(Actor)); //IsContext = True IsNew = False
							//ContextStatement Actor subContext229 ContextSwitchInterpreter
							if(subContext229 != null)
							{
								
								
								System.Int32 OperandVar231 = default(System.Int32); //IsContext = False IsNew = False
								System.Int32 prop230 = subContext229.ScenariosCount; //IsContext = False IsNew = False
								OperandVar231 = prop230;
								
								
								subContext229.ScenariosCount = (System.Int32)(( ( (OperandVar231))) + ( ( (1f))));
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble ContextSwitchInterpreter
				if(noble != null)
				{
					
					ScriptedTypes.in_love ContextVar232 = noble.AddComponent<ScriptedTypes.in_love>();; //IsContext = False IsNew = True
					
					{
						//ContextStatement ScriptedTypes.in_love ContextVar232 ContextSwitchInterpreter
						if(ContextVar232 != null)
						{
							
							UnityEngine.GameObject OperandVar233 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar233 = kings_daughter;
							ContextVar232.WithWhom = (UnityEngine.GameObject)( (OperandVar233));
						}
					}
					Entity EntVar234 = (Entity)noble.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar234 != null) EntVar234.ComponentAdded();
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
			
			System.Boolean OperandVar236 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable235 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable235 != null)
			{
				applicable = true;
				OperandVar236 = applicable;
			}
			return (System.Boolean) (OperandVar236);
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
			
			UnityEngine.GameObject OperandVar238 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop237 = External.NoOne(); //IsContext = False IsNew = False
			if(prop237 != null)
			{
				OperandVar238 = prop237;
			}
			UnityEngine.GameObject noble =  (OperandVar238); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar240 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop239 = External.NoOne(); //IsContext = False IsNew = False
			if(prop239 != null)
			{
				OperandVar240 = prop239;
			}
			UnityEngine.GameObject whore =  (OperandVar240); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar242 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop241 = External.NoOne(); //IsContext = False IsNew = False
			if(prop241 != null)
			{
				OperandVar242 = prop241;
			}
			UnityEngine.GameObject noble_wife =  (OperandVar242); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar244 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop243 = External.NoOne(); //IsContext = False IsNew = False
			if(prop243 != null)
			{
				OperandVar244 = prop243;
			}
			UnityEngine.GameObject whore_lover =  (OperandVar244); //IsContext = False IsNew = False
			
			System.Int32 OperandVar247 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable245 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable245 != null)
			{
				System.Int32 prop246 = StoredVariable245.ActorsCount; //IsContext = False IsNew = False
				OperandVar247 = prop246;
			}
			
			System.Int32 OperandVar249 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable245 != null)
			{
				System.Int32 prop248 = StoredVariable245.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar249 = prop248;
			}
			if(( ( (OperandVar247))) > ( ( (OperandVar249))))
			{
				UnityEngine.GameObject OperandVar265 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop264 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar252 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable250 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable250 != null)
					{
						System.Int32 prop251 = StoredVariable250.ScenariosCount; //IsContext = False IsNew = False
						OperandVar252 = prop251;
					};
;
;
;
;
System.Int32 OperandVar255 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable253 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable253 != null)
					{
						System.Int32 prop254 = StoredVariable253.Influence; //IsContext = False IsNew = False
						OperandVar255 = prop254;
					};
;
;
;
;
System.Int32 OperandVar258 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable256 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable256 != null)
					{
						System.Int32 prop257 = StoredVariable256.Age; //IsContext = False IsNew = False
						OperandVar258 = prop257;
					};
;
;
;
ScriptedTypes.man_role OperandVar260 = default(ScriptedTypes.man_role); //IsContext = False IsNew = False;
ScriptedTypes.man_role StoredVariable259 = ((ScriptedTypes.man_role)go.GetComponent(typeof(ScriptedTypes.man_role))); //IsContext = False IsNew = False;
if(StoredVariable259 != null)
					{
						OperandVar260 = StoredVariable259;
					};
;
System.Boolean OperandVar263 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable261 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable261 != null)
					{
						System.Boolean prop262 = StoredVariable261.HasHusbandTo(); //IsContext = False IsNew = False
						if(prop262 != false)
						{
							OperandVar263 = prop262;
						}
					};
return ( (( ( (OperandVar252))) < ( ( (2f))))) && ( (( ( (OperandVar255))) > ( ( (80f))))) && ( (( ( (OperandVar258))) > ( ( (30f))))) && ( ( (OperandVar260))) && ( (!(OperandVar263)));}); //IsContext = False IsNew = False
				if(prop264 != null)
				{
					OperandVar265 = prop264;
				}
				noble =  (OperandVar265);
			}
			
			System.Int32 OperandVar267 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable245 != null)
			{
				System.Int32 prop266 = StoredVariable245.ActorsCount; //IsContext = False IsNew = False
				OperandVar267 = prop266;
			}
			
			System.Int32 OperandVar269 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable245 != null)
			{
				System.Int32 prop268 = StoredVariable245.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar269 = prop268;
			}
			if(( ( (OperandVar267))) > ( ( (OperandVar269))))
			{
				UnityEngine.GameObject OperandVar277 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop276 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar272 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable270 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable270 != null)
					{
						System.Int32 prop271 = StoredVariable270.ScenariosCount; //IsContext = False IsNew = False
						OperandVar272 = prop271;
					};
;
;
;
ScriptedTypes.woman_role OperandVar275 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.folk_role StoredVariable273 = ((ScriptedTypes.folk_role)go.GetComponent(typeof(ScriptedTypes.folk_role))); //IsContext = False IsNew = False;
if(StoredVariable273 != null)
					{
						ScriptedTypes.woman_role StoredVariable274 = ((ScriptedTypes.woman_role)StoredVariable273.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable274 != null)
						{
							OperandVar275 = StoredVariable274;
						}
					};
return ( (( ( (OperandVar272))) < ( ( (2f))))) && ( ( (OperandVar275)));}); //IsContext = False IsNew = False
				if(prop276 != null)
				{
					OperandVar277 = prop276;
				}
				whore =  (OperandVar277);
			}
			
			System.Int32 OperandVar279 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable245 != null)
			{
				System.Int32 prop278 = StoredVariable245.ActorsCount; //IsContext = False IsNew = False
				OperandVar279 = prop278;
			}
			
			System.Int32 OperandVar281 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable245 != null)
			{
				System.Int32 prop280 = StoredVariable245.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar281 = prop280;
			}
			if(( ( (OperandVar279))) > ( ( (OperandVar281))))
			{
				UnityEngine.GameObject OperandVar292 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop291 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar284 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable282 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable282 != null)
					{
						System.Int32 prop283 = StoredVariable282.ScenariosCount; //IsContext = False IsNew = False
						OperandVar284 = prop283;
					};
;
;
;
ScriptedTypes.woman_role OperandVar287 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable285 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable285 != null)
					{
						ScriptedTypes.woman_role StoredVariable286 = ((ScriptedTypes.woman_role)StoredVariable285.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable286 != null)
						{
							OperandVar287 = StoredVariable286;
						}
					};
;
System.Boolean OperandVar290 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable288 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable288 != null)
					{
						System.Boolean prop289 = StoredVariable288.HasWifeTo(); //IsContext = False IsNew = False
						if(prop289 != false)
						{
							OperandVar290 = prop289;
						}
					};
return ( (( ( (OperandVar284))) < ( ( (2f))))) && ( ( (OperandVar287))) && ( (!(OperandVar290)));}); //IsContext = False IsNew = False
				if(prop291 != null)
				{
					OperandVar292 = prop291;
				}
				noble_wife =  (OperandVar292);
			}
			
			System.Int32 OperandVar294 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable245 != null)
			{
				System.Int32 prop293 = StoredVariable245.ActorsCount; //IsContext = False IsNew = False
				OperandVar294 = prop293;
			}
			
			System.Int32 OperandVar296 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable245 != null)
			{
				System.Int32 prop295 = StoredVariable245.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar296 = prop295;
			}
			if(( ( (OperandVar294))) > ( ( (OperandVar296))))
			{
				UnityEngine.GameObject OperandVar306 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop305 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{;
;
;
System.Int32 OperandVar299 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable297 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable297 != null)
					{
						System.Int32 prop298 = StoredVariable297.ScenariosCount; //IsContext = False IsNew = False
						OperandVar299 = prop298;
					};
;
;
;
ScriptedTypes.noble_role OperandVar301 = default(ScriptedTypes.noble_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable300 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable300 != null)
					{
						OperandVar301 = StoredVariable300;
					};
;
;
System.Int32 OperandVar304 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable302 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable302 != null)
					{
						System.Int32 prop303 = StoredVariable302.Age; //IsContext = False IsNew = False
						OperandVar304 = prop303;
					};
;
;
return ( (( ( (OperandVar299))) < ( ( (2f))))) && ( ( (OperandVar301))) && ( (( ( (OperandVar304))) < ( ( (30f)))));}); //IsContext = False IsNew = False
				if(prop305 != null)
				{
					OperandVar306 = prop305;
				}
				whore_lover =  (OperandVar306);
			}
			System.Boolean OperandVar309 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar307 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar307 = noble;
			System.Boolean prop308 = External.Has( (OperandVar307)); //IsContext = False IsNew = False
			if(prop308 != false)
			{
				OperandVar309 = prop308;
			}
			if(!(OperandVar309))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx310 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx310 ContextPropertySwitchInterpreter
					if(FuncCtx310 != null)
					{
						ScriptedTypes.noble_role ContextVar311 = FuncCtx310.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar311 ContextSwitchInterpreter
							if(ContextVar311 != null)
							{
								
								
								ContextVar311.Influence = (System.Int32)( (90f));
							}
						}
						Entity EntVar312 = (Entity)FuncCtx310.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						ScriptedTypes.aged ContextVar313 = FuncCtx310.AddComponent<ScriptedTypes.aged>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.aged ContextVar313 ContextSwitchInterpreter
							if(ContextVar313 != null)
							{
								
								
								ContextVar313.Age = (System.Int32)( (50f));
							}
						}
						
						FuncCtx310.AddComponent<ScriptedTypes.man_role>();
						if(EntVar312 != null) EntVar312.ComponentAdded();
					}
				}
			}
			System.Boolean OperandVar316 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar314 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar314 = whore;
			System.Boolean prop315 = External.Has( (OperandVar314)); //IsContext = False IsNew = False
			if(prop315 != false)
			{
				OperandVar316 = prop315;
			}
			if(!(OperandVar316))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx317 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx317 ContextPropertySwitchInterpreter
					if(FuncCtx317 != null)
					{
						FuncCtx317.AddComponent<ScriptedTypes.folk_role>();
						Entity EntVar318 = (Entity)FuncCtx317.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx317.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar318 != null) EntVar318.ComponentAdded();
					}
				}
			}
			System.Boolean OperandVar321 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar319 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar319 = noble_wife;
			System.Boolean prop320 = External.Has( (OperandVar319)); //IsContext = False IsNew = False
			if(prop320 != false)
			{
				OperandVar321 = prop320;
			}
			if(!(OperandVar321))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx322 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble_wife")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx322 ContextPropertySwitchInterpreter
					if(FuncCtx322 != null)
					{
						FuncCtx322.AddComponent<ScriptedTypes.noble_role>();
						Entity EntVar323 = (Entity)FuncCtx322.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx322.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar323 != null) EntVar323.ComponentAdded();
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble_wife ContextSwitchInterpreter
				if(noble_wife != null)
				{
					
					
					{
						ScriptedTypes.facts subContext324 = (ScriptedTypes.facts)noble_wife.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext324 ContextSwitchInterpreter
						if(subContext324 != null)
						{
							
							
							{
								ScriptedTypes.wife_to FuncCtx325 = subContext324.AddWifeTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.wife_to FuncCtx325 ContextPropertySwitchInterpreter
								if(FuncCtx325 != null)
								{
									UnityEngine.GameObject OperandVar326 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar326 = noble;
									UnityEngine.GameObject whom =  (OperandVar326); //IsContext = False IsNew = False
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
						ScriptedTypes.facts subContext327 = (ScriptedTypes.facts)noble.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext327 ContextSwitchInterpreter
						if(subContext327 != null)
						{
							
							
							{
								ScriptedTypes.husband_to FuncCtx328 = subContext327.AddHusbandTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.husband_to FuncCtx328 ContextPropertySwitchInterpreter
								if(FuncCtx328 != null)
								{
									UnityEngine.GameObject OperandVar329 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar329 = noble_wife;
									UnityEngine.GameObject whom =  (OperandVar329); //IsContext = False IsNew = False
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
						ScriptedTypes.facts subContext330 = (ScriptedTypes.facts)noble.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext330 ContextSwitchInterpreter
						if(subContext330 != null)
						{
							
							
							{
								ScriptedTypes.lover FuncCtx331 = subContext330.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx331 ContextPropertySwitchInterpreter
								if(FuncCtx331 != null)
								{
									UnityEngine.GameObject OperandVar332 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar332 = whore;
									UnityEngine.GameObject of_whom =  (OperandVar332); //IsContext = False IsNew = False
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			System.Boolean OperandVar335 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar333 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar333 = whore_lover;
			System.Boolean prop334 = External.Has( (OperandVar333)); //IsContext = False IsNew = False
			if(prop334 != false)
			{
				OperandVar335 = prop334;
			}
			if(!(OperandVar335))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx336 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore_lover")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx336 ContextPropertySwitchInterpreter
					if(FuncCtx336 != null)
					{
						ScriptedTypes.noble_role ContextVar337 = FuncCtx336.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar337 ContextSwitchInterpreter
							if(ContextVar337 != null)
							{
								
								
								ContextVar337.Influence = (System.Int32)( (40f));
							}
						}
						Entity EntVar338 = (Entity)FuncCtx336.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx336.AddComponent<ScriptedTypes.man_role>();
						if(EntVar338 != null) EntVar338.ComponentAdded();
						
						{
							ScriptedTypes.aged subContext339 = (ScriptedTypes.aged)FuncCtx336.GetComponent(typeof(ScriptedTypes.aged)); //IsContext = True IsNew = False
							//ContextStatement ScriptedTypes.aged subContext339 ContextSwitchInterpreter
							if(subContext339 != null)
							{
								
								
								subContext339.Age = (System.Int32)( (25f));
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
						ScriptedTypes.facts subContext340 = (ScriptedTypes.facts)whore_lover.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext340 ContextSwitchInterpreter
						if(subContext340 != null)
						{
							
							
							{
								ScriptedTypes.lover FuncCtx341 = subContext340.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx341 ContextPropertySwitchInterpreter
								if(FuncCtx341 != null)
								{
									UnityEngine.GameObject OperandVar342 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar342 = whore;
									UnityEngine.GameObject of_whom =  (OperandVar342); //IsContext = False IsNew = False
									
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
						ScriptedTypes.facts subContext343 = (ScriptedTypes.facts)whore.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext343 ContextSwitchInterpreter
						if(subContext343 != null)
						{
							
							
							{
								ScriptedTypes.lover FuncCtx344 = subContext343.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx344 ContextPropertySwitchInterpreter
								if(FuncCtx344 != null)
								{
									UnityEngine.GameObject OperandVar345 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar345 = noble;
									UnityEngine.GameObject of_whom =  (OperandVar345); //IsContext = False IsNew = False
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
							
							{
								ScriptedTypes.lover FuncCtx346 = subContext343.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx346 ContextPropertySwitchInterpreter
								if(FuncCtx346 != null)
								{
									UnityEngine.GameObject OperandVar347 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar347 = noble;
									UnityEngine.GameObject of_whom =  (OperandVar347); //IsContext = False IsNew = False
									
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
			
			
			System.Single OperandVar350 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable348 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable348 != null)
			{
				System.Single prop349 = StoredVariable348.Brightness; //IsContext = False IsNew = False
				OperandVar350 = prop349;
			}
			System.Single OperandVar353 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable351 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable351 != null)
			{
				System.Single prop352 = StoredVariable351.Light; //IsContext = False IsNew = False
				OperandVar353 = prop352;
			}
			val = ( (OperandVar350)) * ( (OperandVar353));
			return val;
		}
        }
        
        public override bool RootFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar356 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable354 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable354 != null)
			{
				LightSensor StoredVariable355 = ((LightSensor)StoredVariable354.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable355 != null)
				{
					applicable = true;
					OperandVar356 = applicable;
				}
			}
			return (System.Boolean) (OperandVar356);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar359 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable357 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable357 != null)
			{
				LightSource StoredVariable358 = ((LightSource)StoredVariable357.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable358 != null)
				{
					applicable = true;
					OperandVar359 = applicable;
				}
			}
			return (System.Boolean) (OperandVar359);
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
			
			
			System.Boolean OperandVar361 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable360 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable360 != null)
			{
				applicable = true;
				OperandVar361 = applicable;
			}
			return (System.Boolean) (OperandVar361);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar363 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable362 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable362 != null)
			{
				applicable = true;
				OperandVar363 = applicable;
			}
			return (System.Boolean) (OperandVar363);
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
			
			System.Boolean OperandVar366 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop364 = root.Target; //IsContext = False IsNew = False
			if(prop364 != null)
			{
				Actor StoredVariable365 = ((Actor)prop364.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable365 != null)
				{
					applicable = true;
					OperandVar366 = applicable;
				}
			}
			return (System.Boolean) (OperandVar366);
		}
        }
        
        public override void Action() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			{
				VisualsFeed subContext367 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext367 ContextPropertySwitchInterpreter
				if(subContext367 != null)
				{
					TestEvent OperandVar368 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar368 = root;
					UnityEngine.Vector3 OperandVar372 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(root != null)
					{
						UnityEngine.GameObject prop369 = root.Target; //IsContext = False IsNew = False
						if(prop369 != null)
						{
							Entity StoredVariable370 = ((Entity)prop369.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
							if(StoredVariable370 != null)
							{
								UnityEngine.Vector3 prop371 = StoredVariable370.Position; //IsContext = False IsNew = False
								OperandVar372 = prop371;
							}
						}
					}
					subContext367.Push((Event)( (OperandVar368)),(UnityEngine.Vector3)( (OperandVar372)));
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
			
			System.Boolean OperandVar374 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable373 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable373 != null)
			{
				applicable = true;
				OperandVar374 = applicable;
			}
			return (System.Boolean) (OperandVar374);
		}
        }
        
        public override void Action() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			var e = this.e;
			
			
			{
				ScriptedTypes.facts subContext375 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext375 ContextSwitchInterpreter
				if(subContext375 != null)
				{
					
					System.Boolean OperandVar377 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop376 = subContext375.HasNoticedTestEvent(); //IsContext = False IsNew = False
					if(prop376 != false)
					{
						OperandVar377 = prop376;
					}
					if(!(OperandVar377))
					{
						ScriptedTypes.noticed_test_event OperandVar379 = default(ScriptedTypes.noticed_test_event); //IsContext = False IsNew = False
						ScriptedTypes.noticed_test_event prop378 = subContext375.AddNoticedTestEvent(); //IsContext = False IsNew = False
						if(prop378 != null)
						{
							OperandVar379 = prop378;
						}
						ScriptedTypes.noticed_test_event ev =  (OperandVar379); //IsContext = False IsNew = False
					}
				}
			}
		}
        }
    }
}
