namespace ScriptedTypes {
    
    
    public interface lit_up_room {
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject initiator; //IsContext = False IsNew = False
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject initiator; //IsContext = False IsNew = False
			
			{
				LightSource subContext9 = (LightSource)root.GetComponent(typeof(LightSource)); //IsContext = True IsNew = False
				//ContextStatement LightSource subContext9 ContextSwitchInterpreter
				if(subContext9 != null)
				{
					//LightSource subContext9; //IsContext = True IsNew = False
					
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject initiator; //IsContext = False IsNew = False
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject initiator; //IsContext = False IsNew = False
			
			{
				RemoteController subContext22 = (RemoteController)root.GetComponent(typeof(RemoteController)); //IsContext = True IsNew = False
				//ContextStatement RemoteController subContext22 ContextSwitchInterpreter
				if(subContext22 != null)
				{
					//RemoteController subContext22; //IsContext = True IsNew = False
					
					{
						UnityEngine.GameObject subContext23 = subContext22.Controlled; //IsContext = True IsNew = False
						//ContextStatement UnityEngine.GameObject subContext23 ContextPropertySwitchInterpreter
						if(subContext23 != null)
						{
							
							{
								LightSource subContext24 = (LightSource)subContext23.GetComponent(typeof(LightSource)); //IsContext = True IsNew = False
								//ContextStatement LightSource subContext24 ContextSwitchInterpreter
								if(subContext24 != null)
								{
									//LightSource subContext24; //IsContext = True IsNew = False
									
									subContext24.LitUp = (System.Boolean)( (true));
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
			
			var list25 = new System.Collections.Generic.List<Dependency>(1);
			
			{
				list25.Add(new CloserThan().Init(this.root,this.initiator, (1f)));
			}
			return list25;
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar29 = default(System.Boolean); //IsContext = False IsNew = False
			LightSensor StoredVariable26 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable26 != null)
			{
				Actor StoredVariable27 = ((Actor)StoredVariable26.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable27 != null)
				{
					System.Boolean prop28 = StoredVariable27.CanDo(typeof(ScriptedTypes.interaction_lit_up_manual )); //IsContext = False IsNew = False
					if(prop28 != false)
					{
						applicable = true;
						OperandVar29 = applicable;
					}
				}
			}
			return (System.Boolean) (OperandVar29);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			UnityEngine.GameObject OperandVar37 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar31 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop30 = External.AllObjects; //IsContext = False IsNew = False
			if(prop30 != null)
			{
				OperandVar31 = prop30;
			}
			UnityEngine.GameObject prop36 = External.Any( (OperandVar31),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
System.Boolean OperandVar35 = default(System.Boolean); //IsContext = False IsNew = False;
Interactable StoredVariable32 = ((Interactable)go.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False;
if(StoredVariable32 != null)
				{
					UnityEngine.GameObject OperandVar33 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar33 = root;
					System.Boolean prop34 = StoredVariable32.Can(typeof(ScriptedTypes.interaction_lit_up_manual ), (OperandVar33)); //IsContext = False IsNew = False
					if(prop34 != false)
					{
						OperandVar35 = prop34;
					}
				};
return  (OperandVar35);}); //IsContext = False IsNew = False
			if(prop36 != null)
			{
				OperandVar37 = prop36;
			}
			light =  (OperandVar37);
			//UnityEngine.GameObject light; //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar38 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar38 = light;
			if( (OperandVar38))
			{
				
				
				
				System.Single OperandVar41 = default(System.Single); //IsContext = False IsNew = False
				LightSensor StoredVariable39 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable39 != null)
				{
					System.Single prop40 = StoredVariable39.Light; //IsContext = False IsNew = False
					OperandVar41 = prop40;
				}
				ut = ( ( (10f))) - ( ( (OperandVar41)));
			}
			return ut;
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject light; //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar42 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar42 = light;
			var a43 = Actions.Instance.GetAction(typeof(ScriptedTypes.interaction_lit_up_manual ));
			a43.Init();
			(a43 as EventInteraction).Initiator = root;
			a43.Root =  (OperandVar42);
			UnityEngine.Debug.Log(a43.Root);
			UnityEngine.Debug.Log((a43 as EventInteraction).Initiator);
			(root.GetComponent(typeof(Actor)) as Actor).Act(a43);
			while(a43.State != EventAction.ActionState.Finished){ if(a43.State == EventAction.ActionState.Failed) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar47 = default(System.Boolean); //IsContext = False IsNew = False
			LightSensor StoredVariable44 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable44 != null)
			{
				Actor StoredVariable45 = ((Actor)StoredVariable44.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable45 != null)
				{
					System.Boolean prop46 = StoredVariable45.CanDo(typeof(ScriptedTypes.interaction_lit_up_remote )); //IsContext = False IsNew = False
					if(prop46 != false)
					{
						applicable = true;
						OperandVar47 = applicable;
					}
				}
			}
			return (System.Boolean) (OperandVar47);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			UnityEngine.GameObject OperandVar59 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar49 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop48 = External.AllObjects; //IsContext = False IsNew = False
			if(prop48 != null)
			{
				OperandVar49 = prop48;
			}
			UnityEngine.GameObject prop56 = External.Any( (OperandVar49),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
System.Boolean OperandVar55 = default(System.Boolean); //IsContext = False IsNew = False;
Remote StoredVariable50 = ((Remote)go.GetComponent(typeof(Remote))); //IsContext = False IsNew = False;
if(StoredVariable50 != null)
				{
					UnityEngine.GameObject prop51 = StoredVariable50.Controller; //IsContext = False IsNew = False
					if(prop51 != null)
					{
						Interactable StoredVariable52 = ((Interactable)prop51.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
						if(StoredVariable52 != null)
						{
							UnityEngine.GameObject OperandVar53 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar53 = root;
							System.Boolean prop54 = StoredVariable52.Can(typeof(ScriptedTypes.interaction_lit_up_remote ), (OperandVar53)); //IsContext = False IsNew = False
							if(prop54 != false)
							{
								OperandVar55 = prop54;
							}
						}
					}
				};
return  (OperandVar55);}); //IsContext = False IsNew = False
			if(prop56 != null)
			{
				Remote StoredVariable57 = ((Remote)prop56.GetComponent(typeof(Remote))); //IsContext = False IsNew = False
				if(StoredVariable57 != null)
				{
					UnityEngine.GameObject prop58 = StoredVariable57.Controller; //IsContext = False IsNew = False
					if(prop58 != null)
					{
						OperandVar59 = prop58;
					}
				}
			}
			remote_c =  (OperandVar59);
			//UnityEngine.GameObject remote_c; //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar60 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar60 = remote_c;
			if( (OperandVar60))
			{
				
				
				
				System.Single OperandVar63 = default(System.Single); //IsContext = False IsNew = False
				LightSensor StoredVariable61 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable61 != null)
				{
					System.Single prop62 = StoredVariable61.Light; //IsContext = False IsNew = False
					OperandVar63 = prop62;
				}
				ut = ( ( (10f))) - ( ( (OperandVar63)));
			}
			return ut;
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject remote_c; //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar64 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar64 = remote_c;
			var a65 = Actions.Instance.GetAction(typeof(ScriptedTypes.interaction_lit_up_remote ));
			a65.Init();
			(a65 as EventInteraction).Initiator = root;
			a65.Root =  (OperandVar64);
			UnityEngine.Debug.Log(a65.Root);
			UnityEngine.Debug.Log((a65 as EventInteraction).Initiator);
			(root.GetComponent(typeof(Actor)) as Actor).Act(a65);
			while(a65.State != EventAction.ActionState.Finished){ if(a65.State == EventAction.ActionState.Failed) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject target; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			System.Boolean OperandVar67 = default(System.Boolean); //IsContext = False IsNew = False
			Movable StoredVariable66 = ((Movable)root.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
			if(StoredVariable66 != null)
			{
				applicable = true;
				OperandVar67 = applicable;
			}
			return (System.Boolean) (OperandVar67);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject target; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			System.Boolean OperandVar70 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar68 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar68 = target;
			System.Boolean prop69 = External.Has( (OperandVar68)); //IsContext = False IsNew = False
			if(prop69 != false)
			{
				OperandVar70 = prop69;
			}
			if( (OperandVar70))
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject target; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			
			{
				Movable subContext71 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext71 ContextSwitchInterpreter
				if(subContext71 != null)
				{
					//Movable subContext71; //IsContext = True IsNew = False
					System.Single OperandVar72 = default(System.Single); //IsContext = False IsNew = False
					OperandVar72 = distance;
					UnityEngine.GameObject OperandVar73 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar73 = target;
					subContext71.Goto((System.Single)( (OperandVar72)),(UnityEngine.GameObject)( (OperandVar73)));
					System.Boolean OperandVar75 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop74 = subContext71.IsMoving; //IsContext = False IsNew = False
					OperandVar75 = prop74;
					
					System.Boolean OperandVar77 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop76 = subContext71.IsMoving; //IsContext = False IsNew = False
					OperandVar77 = prop76;
					
					System.Boolean OperandVar79 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop78 = subContext71.NearTarget; //IsContext = False IsNew = False
					OperandVar79 = prop78;
					
					while( (OperandVar75)){ if(( (!(OperandVar77))) && ( (!(OperandVar79)))) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
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
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=false, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=true)]
    public class interaction_talk_to : EventAction, EventInteraction {
        
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar84 = default(System.Boolean); //IsContext = False IsNew = False
			Speaker StoredVariable80 = ((Speaker)root.GetComponent(typeof(Speaker))); //IsContext = False IsNew = False
			if(StoredVariable80 != null)
			{
				System.Boolean ifResult81; //IsContext = False IsNew = False
				System.Boolean OperandVar83 = default(System.Boolean); //IsContext = False IsNew = False
				System.Boolean prop82 = StoredVariable80.CanTalk; //IsContext = False IsNew = False
				OperandVar83 = prop82;
				if(ifResult81 =  (OperandVar83))
				{
					applicable = true;
					OperandVar84 = applicable;
				}
			}
			return (System.Boolean) (OperandVar84);
		}
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject initiator; //IsContext = False IsNew = False
			System.Boolean OperandVar98 = default(System.Boolean); //IsContext = False IsNew = False
			Listener StoredVariable85 = ((Listener)root.GetComponent(typeof(Listener))); //IsContext = False IsNew = False
			if(StoredVariable85 != null)
			{
				System.Boolean ifResult86; //IsContext = False IsNew = False
				
				System.Boolean OperandVar88 = default(System.Boolean); //IsContext = False IsNew = False
				System.Boolean prop87 = StoredVariable85.CanTalk; //IsContext = False IsNew = False
				OperandVar88 = prop87;
				
				
				UnityEngine.GameObject OperandVar90 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				UnityEngine.GameObject prop89 = StoredVariable85.TalksTo; //IsContext = False IsNew = False
				if(prop89 != null)
				{
					OperandVar90 = prop89;
				}
				
				UnityEngine.GameObject OperandVar92 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				UnityEngine.GameObject prop91 = External.NoOne(); //IsContext = False IsNew = False
				if(prop91 != null)
				{
					OperandVar92 = prop91;
				}
				
				
				UnityEngine.GameObject OperandVar95 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				Speaker StoredVariable93 = ((Speaker)initiator.GetComponent(typeof(Speaker))); //IsContext = False IsNew = False
				if(StoredVariable93 != null)
				{
					UnityEngine.GameObject prop94 = StoredVariable93.TalksTo; //IsContext = False IsNew = False
					if(prop94 != null)
					{
						OperandVar95 = prop94;
					}
				}
				
				UnityEngine.GameObject OperandVar97 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				UnityEngine.GameObject prop96 = External.NoOne(); //IsContext = False IsNew = False
				if(prop96 != null)
				{
					OperandVar97 = prop96;
				}
				if(ifResult86 = ( ( (OperandVar88))) && ( (( ( (OperandVar90))) == ( ( (OperandVar92))))) && ( (( ( (OperandVar95))) == ( ( (OperandVar97))))))
				{
					applicable = true;
					OperandVar98 = applicable;
				}
			}
			return (System.Boolean) (OperandVar98);
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject initiator; //IsContext = False IsNew = False
			
			{
				//ContextStatement UnityEngine.GameObject initiator ContextSwitchInterpreter
				if(initiator != null)
				{
					//UnityEngine.GameObject initiator; //IsContext = True IsNew = False
					
					{
						Speaker subContext99 = (Speaker)initiator.GetComponent(typeof(Speaker)); //IsContext = True IsNew = False
						//ContextStatement Speaker subContext99 ContextSwitchInterpreter
						if(subContext99 != null)
						{
							//Speaker subContext99; //IsContext = True IsNew = False
							UnityEngine.GameObject OperandVar100 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar100 = root;
							subContext99.TalkTo((UnityEngine.GameObject)( (OperandVar100)));
							
							UnityEngine.GameObject OperandVar102 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							UnityEngine.GameObject prop101 = subContext99.TalksTo; //IsContext = False IsNew = False
							if(prop101 != null)
							{
								OperandVar102 = prop101;
							}
							
							UnityEngine.GameObject OperandVar103 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar103 = initiator;
							
							
							UnityEngine.GameObject OperandVar105 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							UnityEngine.GameObject prop104 = subContext99.TalksTo; //IsContext = False IsNew = False
							if(prop104 != null)
							{
								OperandVar105 = prop104;
							}
							
							UnityEngine.GameObject OperandVar106 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
							OperandVar106 = initiator;
							
							while(( ( (OperandVar102))) == ( ( (OperandVar103)))){ if(!(( ( (OperandVar105))) == ( ( (OperandVar106))))) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
						}
					}
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Action() {
Coroutine = ActionCoroutine(); state = ActionState.Started;
        }
        
        public override System.Collections.Generic.List<Dependency> GetDependencies() {

		{
			
			var list107 = new System.Collections.Generic.List<Dependency>(1);
			
			{
				list107.Add(new CloserThan().Init(this.root,this.initiator, (1f)));
			}
			return list107;
		}
        }
        
        public override void Init() {
base.Init();
this.initiator = default(UnityEngine.GameObject);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=false, OncePerTurn=false, IsAIAction=true, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class talk_to_someone : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar110 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable108 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable108 != null)
			{
				System.Boolean prop109 = StoredVariable108.CanDo(typeof(ScriptedTypes.interaction_talk_to )); //IsContext = False IsNew = False
				if(prop109 != false)
				{
					applicable = true;
					OperandVar110 = applicable;
				}
			}
			return (System.Boolean) (OperandVar110);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			
			return (System.Single) (0.3f);
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			UnityEngine.GameObject OperandVar120 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar112 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop111 = External.AllObjects; //IsContext = False IsNew = False
			if(prop111 != null)
			{
				OperandVar112 = prop111;
			}
			UnityEngine.GameObject prop119 = External.SelectByWeight( (OperandVar112),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
System.Single OperandVar118 = default(System.Single); //IsContext = False IsNew = False;
Interactable StoredVariable113 = ((Interactable)go.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False;
if(StoredVariable113 != null)
				{
					UnityEngine.GameObject OperandVar114 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar114 = root;
					System.Boolean prop115 = StoredVariable113.Can(typeof(ScriptedTypes.interaction_talk_to ), (OperandVar114)); //IsContext = False IsNew = False
					if(prop115 != false)
					{
						UnityEngine.GameObject OperandVar116 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar116 = go;
						var metrics117 = go != null?go.GetComponent<Metrics>():null;
						OperandVar118 = (metrics117 != null? metrics117.Value("talk_desire",  (OperandVar116)) : 0f);
					}
				};
return  (OperandVar118);}); //IsContext = False IsNew = False
			if(prop119 != null)
			{
				OperandVar120 = prop119;
			}
			UnityEngine.GameObject other =  (OperandVar120); //IsContext = False IsNew = False
			System.Boolean OperandVar123 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar121 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar121 = other;
			System.Boolean prop122 = External.Has( (OperandVar121)); //IsContext = False IsNew = False
			if(prop122 != false)
			{
				OperandVar123 = prop122;
			}
			if( (OperandVar123))
			{
				UnityEngine.GameObject OperandVar124 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar124 = other;
				var a125 = Actions.Instance.GetAction(typeof(ScriptedTypes.interaction_talk_to ));
				a125.Init();
				(a125 as EventInteraction).Initiator = root;
				a125.Root =  (OperandVar124);
				UnityEngine.Debug.Log(a125.Root);
				UnityEngine.Debug.Log((a125 as EventInteraction).Initiator);
				(root.GetComponent(typeof(Actor)) as Actor).Act(a125);
				while(a125.State != EventAction.ActionState.Finished){ if(a125.State == EventAction.ActionState.Failed) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
			}
			System.Boolean OperandVar128 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar126 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar126 = other;
			System.Boolean prop127 = External.Has( (OperandVar126)); //IsContext = False IsNew = False
			if(prop127 != false)
			{
				OperandVar128 = prop127;
			}
			if(!(OperandVar128))
			{
				
				
				
				while( (true)){ if( (true)) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Action() {
Coroutine = ActionCoroutine(); state = ActionState.Started;
        }
        
        public override void Init() {
base.Init();

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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			System.Boolean OperandVar144 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable129 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable129 != null)
			{
				Listener StoredVariable130 = ((Listener)StoredVariable129.GetComponent(typeof(Listener))); //IsContext = False IsNew = False
				if(StoredVariable130 != null)
				{
					Markers StoredVariable131 = ((Markers)StoredVariable130.GetComponent(typeof(Markers))); //IsContext = False IsNew = False
					if(StoredVariable131 != null)
					{
						Relationships StoredVariable132 = ((Relationships)StoredVariable131.GetComponent(typeof(Relationships))); //IsContext = False IsNew = False
						if(StoredVariable132 != null)
						{
							ScriptedTypes.personality StoredVariable133 = ((ScriptedTypes.personality)StoredVariable132.GetComponent(typeof(ScriptedTypes.personality))); //IsContext = False IsNew = False
							if(StoredVariable133 != null)
							{
								System.Boolean ifResult134; //IsContext = False IsNew = False
								
								System.Boolean OperandVar136 = default(System.Boolean); //IsContext = False IsNew = False
								System.Boolean prop135 = StoredVariable129.HasRival(); //IsContext = False IsNew = False
								if(prop135 != false)
								{
									OperandVar136 = prop135;
								}
								
								System.Boolean OperandVar138 = default(System.Boolean); //IsContext = False IsNew = False
								if(StoredVariable130 != null)
								{
									System.Boolean prop137 = StoredVariable130.CanTalk; //IsContext = False IsNew = False
									OperandVar138 = prop137;
								}
								
								
								System.Single OperandVar141 = default(System.Single); //IsContext = False IsNew = False
								UnityEngine.GameObject OperandVar139 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar139 = other;
								System.Single prop140 = StoredVariable132.RelationsWith( (OperandVar139)); //IsContext = False IsNew = False
								OperandVar141 = prop140;
								
								System.Single OperandVar143 = default(System.Single); //IsContext = False IsNew = False
								System.Single prop142 = StoredVariable133.Trust; //IsContext = False IsNew = False
								OperandVar143 = prop142;
								if(ifResult134 = ( ( (OperandVar136))) && ( ( (OperandVar138))) && ( (( ( (OperandVar141))) >= ( ( (OperandVar143))))))
								{
									applicable = true;
									OperandVar144 = applicable;
								}
							}
						}
					}
				}
			}
			return (System.Boolean) (OperandVar144);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			
			return (System.Single) (1f);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			
			{
				Listener subContext145 = (Listener)root.GetComponent(typeof(Listener)); //IsContext = True IsNew = False
				//ContextStatement Listener subContext145 ContextSwitchInterpreter
				if(subContext145 != null)
				{
					//Listener subContext145; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext146 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext146 ContextSwitchInterpreter
						if(subContext146 != null)
						{
							//ScriptedTypes.facts subContext146; //IsContext = True IsNew = False
							System.Collections.Generic.List<ScriptedTypes.rival> list147 = subContext146.GetRival; //IsContext = False IsNew = False
							for (int i148 = 0; list147 != null && i148 < list147.Count; i148++)
							{
								ScriptedTypes.rival iter149 = list147[i148]; //IsContext = True IsNew = True
								
								{
									ScriptedTypes.rival subContext150 = iter149; //IsContext = True IsNew = False
									//ContextStatement ScriptedTypes.rival subContext150 ContextPropertySwitchInterpreter
									if(subContext150 != null)
									{
										UnityEngine.GameObject OperandVar152 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
										UnityEngine.GameObject prop151 = subContext150.WhoIs; //IsContext = False IsNew = False
										if(prop151 != null)
										{
											OperandVar152 = prop151;
										}
										UnityEngine.GameObject rival_of_root =  (OperandVar152); //IsContext = False IsNew = False
										
										{
											Dialog FuncCtx153 = subContext145.Dialog();; //IsContext = True IsNew = False
											//ContextStatement Dialog FuncCtx153 ContextPropertySwitchInterpreter
											if(FuncCtx153 != null)
											{
												
												System.String OperandVar154 = default(System.String); //IsContext = False IsNew = False
												OperandVar154 = "rival_story";
												
												System.Int32 OperandVar157 = default(System.Int32); //IsContext = False IsNew = False
												Entity StoredVariable155 = ((Entity)rival_of_root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
												if(StoredVariable155 != null)
												{
													System.Int32 prop156 = StoredVariable155.Id; //IsContext = False IsNew = False
													OperandVar157 = prop156;
												}
												FuncCtx153.Id = (System.String)(( ( (OperandVar154))) + ( ( (OperandVar157))));
												System.String OperandVar158 = default(System.String); //IsContext = False IsNew = False
												OperandVar158 = "looks_anxious";
												FuncCtx153.Hook = (System.String)( (OperandVar158));
												FuncCtx153.Utility = (Dialog.FloatDelegate)(()=>{;
return  (1f);});
												FuncCtx153.Allowed = (Dialog.BoolDelegate)(()=>{System.Boolean OperandVar163 = default(System.Boolean); //IsContext = False IsNew = False;
Markers StoredVariable159 = ((Markers)subContext146.GetComponent(typeof(Markers))); //IsContext = False IsNew = False;
if(StoredVariable159 != null)
													{
														System.String OperandVar161 = default(System.String); //IsContext = False IsNew = False
														if(FuncCtx153 != null)
														{
															System.String prop160 = FuncCtx153.Id; //IsContext = False IsNew = False
															if(prop160 != null)
															{
																OperandVar161 = prop160;
															}
														}
														System.Boolean prop162 = StoredVariable159.HasMarker( (OperandVar161)); //IsContext = False IsNew = False
														if(prop162 != false)
														{
															OperandVar163 = prop162;
														}
													};
return !(OperandVar163);});
												
												{
													DialogLine FuncCtx164 = FuncCtx153.Say();; //IsContext = True IsNew = False
													//ContextStatement DialogLine FuncCtx164 ContextPropertySwitchInterpreter
													if(FuncCtx164 != null)
													{
														LocalizedString OperandVar168 = default(LocalizedString); //IsContext = False IsNew = False
														UnityEngine.GameObject OperandVar167 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
														OperandVar167 = rival_of_root;
														
														var dict165= new System.Collections.Generic.Dictionary<string, object>();
var localizedString166= new LocalizedString("say_about_rival",dict165);dict165.Add("who", (OperandVar167));
dict165.Add("money", (100f));

														OperandVar168 = localizedString166;
														FuncCtx164.String = (LocalizedString)( (OperandVar168));
														VoidDelegate Lambda169 = () => 
														{
															
															{
																Markers subContext170 = (Markers)root.GetComponent(typeof(Markers)); //IsContext = True IsNew = False
																//ContextStatement Markers subContext170 ContextSwitchInterpreter
																if(subContext170 != null)
																{
																	//Markers subContext170; //IsContext = True IsNew = False
																	System.String OperandVar172 = default(System.String); //IsContext = False IsNew = False
																	if(FuncCtx153 != null)
																	{
																		System.String prop171 = FuncCtx153.Id; //IsContext = False IsNew = False
																		if(prop171 != null)
																		{
																			OperandVar172 = prop171;
																		}
																	}
																	subContext170.SetMarker(( (OperandVar172)).ToString());
																}
															}
														};
														FuncCtx164.Reaction = (VoidDelegate)(Lambda169);
													}
												}
											}
										}
									}
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
this.other = default(UnityEngine.GameObject);

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class player_has_controls : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar174 = default(System.Boolean); //IsContext = False IsNew = False
			PlayerMarker StoredVariable173 = ((PlayerMarker)root.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
			if(StoredVariable173 != null)
			{
				applicable = true;
				OperandVar174 = applicable;
			}
			return (System.Boolean) (OperandVar174);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			
			return (System.Single) (1f);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			root.AddComponent<MovableController>();
			Entity EntVar175 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			root.AddComponent<TurnFollowMouseController>();
			
			root.AddComponent<InteractableController>();
			if(EntVar175 != null) EntVar175.ComponentAdded();
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class interactable_is_highlatable : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar177 = default(System.Boolean); //IsContext = False IsNew = False
			Interactable StoredVariable176 = ((Interactable)root.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
			if(StoredVariable176 != null)
			{
				applicable = true;
				OperandVar177 = applicable;
			}
			return (System.Boolean) (OperandVar177);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			
			return (System.Single) (1f);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			root.AddComponent<Highlightable>();
			Entity EntVar178 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			if(EntVar178 != null) EntVar178.ComponentAdded();
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class noble_whore_scenario : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar180 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable179 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable179 != null)
			{
				applicable = true;
				OperandVar180 = applicable;
			}
			return (System.Boolean) (OperandVar180);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			
			return (System.Single) (1f);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			UnityEngine.GameObject OperandVar182 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop181 = External.NoOne(); //IsContext = False IsNew = False
			if(prop181 != null)
			{
				OperandVar182 = prop181;
			}
			UnityEngine.GameObject noble =  (OperandVar182); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar184 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop183 = External.NoOne(); //IsContext = False IsNew = False
			if(prop183 != null)
			{
				OperandVar184 = prop183;
			}
			UnityEngine.GameObject whore =  (OperandVar184); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar186 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop185 = External.NoOne(); //IsContext = False IsNew = False
			if(prop185 != null)
			{
				OperandVar186 = prop185;
			}
			UnityEngine.GameObject noble_wife =  (OperandVar186); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar188 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop187 = External.NoOne(); //IsContext = False IsNew = False
			if(prop187 != null)
			{
				OperandVar188 = prop187;
			}
			UnityEngine.GameObject whore_lover =  (OperandVar188); //IsContext = False IsNew = False
			
			System.Int32 OperandVar191 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable189 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable189 != null)
			{
				System.Int32 prop190 = StoredVariable189.ActorsCount; //IsContext = False IsNew = False
				OperandVar191 = prop190;
			}
			
			System.Int32 OperandVar193 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable189 != null)
			{
				System.Int32 prop192 = StoredVariable189.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar193 = prop192;
			}
			if(( ( (OperandVar191))) > ( ( (OperandVar193))))
			{
				UnityEngine.GameObject OperandVar209 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop208 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar196 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable194 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable194 != null)
					{
						System.Int32 prop195 = StoredVariable194.ScenariosCount; //IsContext = False IsNew = False
						OperandVar196 = prop195;
					};
;
;
;
;
System.Int32 OperandVar199 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable197 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable197 != null)
					{
						System.Int32 prop198 = StoredVariable197.Influence; //IsContext = False IsNew = False
						OperandVar199 = prop198;
					};
;
;
;
;
System.Int32 OperandVar202 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable200 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable200 != null)
					{
						System.Int32 prop201 = StoredVariable200.Age; //IsContext = False IsNew = False
						OperandVar202 = prop201;
					};
;
;
;
ScriptedTypes.man_role OperandVar204 = default(ScriptedTypes.man_role); //IsContext = False IsNew = False;
ScriptedTypes.man_role StoredVariable203 = ((ScriptedTypes.man_role)go.GetComponent(typeof(ScriptedTypes.man_role))); //IsContext = False IsNew = False;
if(StoredVariable203 != null)
					{
						OperandVar204 = StoredVariable203;
					};
;
System.Boolean OperandVar207 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable205 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable205 != null)
					{
						System.Boolean prop206 = StoredVariable205.HasHusbandTo(); //IsContext = False IsNew = False
						if(prop206 != false)
						{
							OperandVar207 = prop206;
						}
					};
return ( (( ( (OperandVar196))) < ( ( (2f))))) && ( (( ( (OperandVar199))) > ( ( (80f))))) && ( (( ( (OperandVar202))) > ( ( (30f))))) && ( ( (OperandVar204))) && ( (!(OperandVar207)));}); //IsContext = False IsNew = False
				if(prop208 != null)
				{
					OperandVar209 = prop208;
				}
				noble =  (OperandVar209);
			}
			
			System.Int32 OperandVar211 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable189 != null)
			{
				System.Int32 prop210 = StoredVariable189.ActorsCount; //IsContext = False IsNew = False
				OperandVar211 = prop210;
			}
			
			System.Int32 OperandVar213 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable189 != null)
			{
				System.Int32 prop212 = StoredVariable189.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar213 = prop212;
			}
			if(( ( (OperandVar211))) > ( ( (OperandVar213))))
			{
				UnityEngine.GameObject OperandVar221 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop220 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
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
ScriptedTypes.woman_role OperandVar219 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.folk_role StoredVariable217 = ((ScriptedTypes.folk_role)go.GetComponent(typeof(ScriptedTypes.folk_role))); //IsContext = False IsNew = False;
if(StoredVariable217 != null)
					{
						ScriptedTypes.woman_role StoredVariable218 = ((ScriptedTypes.woman_role)StoredVariable217.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable218 != null)
						{
							OperandVar219 = StoredVariable218;
						}
					};
return ( (( ( (OperandVar216))) < ( ( (2f))))) && ( ( (OperandVar219)));}); //IsContext = False IsNew = False
				if(prop220 != null)
				{
					OperandVar221 = prop220;
				}
				whore =  (OperandVar221);
			}
			
			System.Int32 OperandVar223 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable189 != null)
			{
				System.Int32 prop222 = StoredVariable189.ActorsCount; //IsContext = False IsNew = False
				OperandVar223 = prop222;
			}
			
			System.Int32 OperandVar225 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable189 != null)
			{
				System.Int32 prop224 = StoredVariable189.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar225 = prop224;
			}
			if(( ( (OperandVar223))) > ( ( (OperandVar225))))
			{
				UnityEngine.GameObject OperandVar236 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop235 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar228 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable226 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable226 != null)
					{
						System.Int32 prop227 = StoredVariable226.ScenariosCount; //IsContext = False IsNew = False
						OperandVar228 = prop227;
					};
;
;
;
ScriptedTypes.woman_role OperandVar231 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable229 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable229 != null)
					{
						ScriptedTypes.woman_role StoredVariable230 = ((ScriptedTypes.woman_role)StoredVariable229.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable230 != null)
						{
							OperandVar231 = StoredVariable230;
						}
					};
;
System.Boolean OperandVar234 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable232 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable232 != null)
					{
						System.Boolean prop233 = StoredVariable232.HasWifeTo(); //IsContext = False IsNew = False
						if(prop233 != false)
						{
							OperandVar234 = prop233;
						}
					};
return ( (( ( (OperandVar228))) < ( ( (2f))))) && ( ( (OperandVar231))) && ( (!(OperandVar234)));}); //IsContext = False IsNew = False
				if(prop235 != null)
				{
					OperandVar236 = prop235;
				}
				noble_wife =  (OperandVar236);
			}
			
			System.Int32 OperandVar238 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable189 != null)
			{
				System.Int32 prop237 = StoredVariable189.ActorsCount; //IsContext = False IsNew = False
				OperandVar238 = prop237;
			}
			
			System.Int32 OperandVar240 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable189 != null)
			{
				System.Int32 prop239 = StoredVariable189.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar240 = prop239;
			}
			if(( ( (OperandVar238))) > ( ( (OperandVar240))))
			{
				UnityEngine.GameObject OperandVar250 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop249 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar243 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable241 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable241 != null)
					{
						System.Int32 prop242 = StoredVariable241.ScenariosCount; //IsContext = False IsNew = False
						OperandVar243 = prop242;
					};
;
;
;
ScriptedTypes.noble_role OperandVar245 = default(ScriptedTypes.noble_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable244 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable244 != null)
					{
						OperandVar245 = StoredVariable244;
					};
;
;
System.Int32 OperandVar248 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable246 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable246 != null)
					{
						System.Int32 prop247 = StoredVariable246.Age; //IsContext = False IsNew = False
						OperandVar248 = prop247;
					};
;
;
return ( (( ( (OperandVar243))) < ( ( (2f))))) && ( ( (OperandVar245))) && ( (( ( (OperandVar248))) < ( ( (30f)))));}); //IsContext = False IsNew = False
				if(prop249 != null)
				{
					OperandVar250 = prop249;
				}
				whore_lover =  (OperandVar250);
			}
			System.Boolean OperandVar253 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar251 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar251 = noble;
			System.Boolean prop252 = External.Has( (OperandVar251)); //IsContext = False IsNew = False
			if(prop252 != false)
			{
				OperandVar253 = prop252;
			}
			if(!(OperandVar253))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx254 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx254 ContextPropertySwitchInterpreter
					if(FuncCtx254 != null)
					{
						UnityEngine.GameObject OperandVar255 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar255 = FuncCtx254;
						noble =  (OperandVar255);
						ScriptedTypes.noble_role ContextVar256 = FuncCtx254.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar256 ContextSwitchInterpreter
							if(ContextVar256 != null)
							{
								//ScriptedTypes.noble_role ContextVar256; //IsContext = True IsNew = False
								
								ContextVar256.Influence = (System.Int32)( (90f));
							}
						}
						Entity EntVar257 = (Entity)FuncCtx254.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						ScriptedTypes.aged ContextVar258 = FuncCtx254.AddComponent<ScriptedTypes.aged>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.aged ContextVar258 ContextSwitchInterpreter
							if(ContextVar258 != null)
							{
								//ScriptedTypes.aged ContextVar258; //IsContext = True IsNew = False
								
								ContextVar258.Age = (System.Int32)( (50f));
							}
						}
						
						FuncCtx254.AddComponent<ScriptedTypes.man_role>();
						if(EntVar257 != null) EntVar257.ComponentAdded();
						
						{
							Entity subContext259 = (Entity)FuncCtx254.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext259 ContextSwitchInterpreter
							if(subContext259 != null)
							{
								//Entity subContext259; //IsContext = True IsNew = False
								
								
								
								subContext259.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
							}
						}
					}
				}
			}
			System.Boolean OperandVar262 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar260 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar260 = whore;
			System.Boolean prop261 = External.Has( (OperandVar260)); //IsContext = False IsNew = False
			if(prop261 != false)
			{
				OperandVar262 = prop261;
			}
			if(!(OperandVar262))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx263 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx263 ContextPropertySwitchInterpreter
					if(FuncCtx263 != null)
					{
						UnityEngine.GameObject OperandVar264 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar264 = FuncCtx263;
						whore =  (OperandVar264);
						FuncCtx263.AddComponent<ScriptedTypes.folk_role>();
						Entity EntVar265 = (Entity)FuncCtx263.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx263.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar265 != null) EntVar265.ComponentAdded();
						
						{
							Entity subContext266 = (Entity)FuncCtx263.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext266 ContextSwitchInterpreter
							if(subContext266 != null)
							{
								//Entity subContext266; //IsContext = True IsNew = False
								
								
								
								subContext266.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
							}
						}
					}
				}
			}
			System.Boolean OperandVar269 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar267 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar267 = noble_wife;
			System.Boolean prop268 = External.Has( (OperandVar267)); //IsContext = False IsNew = False
			if(prop268 != false)
			{
				OperandVar269 = prop268;
			}
			if(!(OperandVar269))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx270 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble_wife")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx270 ContextPropertySwitchInterpreter
					if(FuncCtx270 != null)
					{
						UnityEngine.GameObject OperandVar271 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar271 = FuncCtx270;
						noble_wife =  (OperandVar271);
						FuncCtx270.AddComponent<ScriptedTypes.noble_role>();
						Entity EntVar272 = (Entity)FuncCtx270.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx270.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar272 != null) EntVar272.ComponentAdded();
						
						{
							Entity subContext273 = (Entity)FuncCtx270.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext273 ContextSwitchInterpreter
							if(subContext273 != null)
							{
								//Entity subContext273; //IsContext = True IsNew = False
								
								
								
								subContext273.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject noble_wife ContextSwitchInterpreter
				if(noble_wife != null)
				{
					//UnityEngine.GameObject noble_wife; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext274 = (ScriptedTypes.facts)noble_wife.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext274 ContextSwitchInterpreter
						if(subContext274 != null)
						{
							//ScriptedTypes.facts subContext274; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.wife_to FuncCtx275 = subContext274.AddWifeTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.wife_to FuncCtx275 ContextPropertySwitchInterpreter
								if(FuncCtx275 != null)
								{
									UnityEngine.GameObject OperandVar276 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar276 = noble;
									FuncCtx275.Whom = (UnityEngine.GameObject)( (OperandVar276));
								}
							}
							
							{
								ScriptedTypes.rival FuncCtx277 = subContext274.AddRival();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.rival FuncCtx277 ContextPropertySwitchInterpreter
								if(FuncCtx277 != null)
								{
									UnityEngine.GameObject OperandVar278 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar278 = whore;
									FuncCtx277.WhoIs = (UnityEngine.GameObject)( (OperandVar278));
									UnityEngine.GameObject OperandVar280 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									UnityEngine.GameObject prop279 = FuncCtx277.WhoIs; //IsContext = False IsNew = False
									if(prop279 != null)
									{
										OperandVar280 = prop279;
									}
									External.Log((System.Object)( (OperandVar280)));
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
					//UnityEngine.GameObject noble; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext281 = (ScriptedTypes.facts)noble.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext281 ContextSwitchInterpreter
						if(subContext281 != null)
						{
							//ScriptedTypes.facts subContext281; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.husband_to FuncCtx282 = subContext281.AddHusbandTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.husband_to FuncCtx282 ContextPropertySwitchInterpreter
								if(FuncCtx282 != null)
								{
									UnityEngine.GameObject OperandVar283 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar283 = noble_wife;
									FuncCtx282.Whom = (UnityEngine.GameObject)( (OperandVar283));
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
					//UnityEngine.GameObject noble; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext284 = (ScriptedTypes.facts)noble.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext284 ContextSwitchInterpreter
						if(subContext284 != null)
						{
							//ScriptedTypes.facts subContext284; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.lover FuncCtx285 = subContext284.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx285 ContextPropertySwitchInterpreter
								if(FuncCtx285 != null)
								{
									UnityEngine.GameObject OperandVar286 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar286 = whore;
									FuncCtx285.OfWhom = (UnityEngine.GameObject)( (OperandVar286));
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			System.Boolean OperandVar289 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar287 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar287 = whore_lover;
			System.Boolean prop288 = External.Has( (OperandVar287)); //IsContext = False IsNew = False
			if(prop288 != false)
			{
				OperandVar289 = prop288;
			}
			if(!(OperandVar289))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx290 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore_lover")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx290 ContextPropertySwitchInterpreter
					if(FuncCtx290 != null)
					{
						UnityEngine.GameObject OperandVar291 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar291 = FuncCtx290;
						whore_lover =  (OperandVar291);
						ScriptedTypes.noble_role ContextVar292 = FuncCtx290.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar292 ContextSwitchInterpreter
							if(ContextVar292 != null)
							{
								//ScriptedTypes.noble_role ContextVar292; //IsContext = True IsNew = False
								
								ContextVar292.Influence = (System.Int32)( (40f));
							}
						}
						Entity EntVar293 = (Entity)FuncCtx290.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx290.AddComponent<ScriptedTypes.man_role>();
						if(EntVar293 != null) EntVar293.ComponentAdded();
						
						{
							ScriptedTypes.aged subContext294 = (ScriptedTypes.aged)FuncCtx290.GetComponent(typeof(ScriptedTypes.aged)); //IsContext = True IsNew = False
							//ContextStatement ScriptedTypes.aged subContext294 ContextSwitchInterpreter
							if(subContext294 != null)
							{
								//ScriptedTypes.aged subContext294; //IsContext = True IsNew = False
								
								subContext294.Age = (System.Int32)( (25f));
							}
						}
						
						{
							Entity subContext295 = (Entity)FuncCtx290.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext295 ContextSwitchInterpreter
							if(subContext295 != null)
							{
								//Entity subContext295; //IsContext = True IsNew = False
								
								
								
								subContext295.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject whore_lover ContextSwitchInterpreter
				if(whore_lover != null)
				{
					//UnityEngine.GameObject whore_lover; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext296 = (ScriptedTypes.facts)whore_lover.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext296 ContextSwitchInterpreter
						if(subContext296 != null)
						{
							//ScriptedTypes.facts subContext296; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.lover FuncCtx297 = subContext296.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx297 ContextPropertySwitchInterpreter
								if(FuncCtx297 != null)
								{
									UnityEngine.GameObject OperandVar298 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar298 = whore;
									FuncCtx297.OfWhom = (UnityEngine.GameObject)( (OperandVar298));
									
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
					//UnityEngine.GameObject whore; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext299 = (ScriptedTypes.facts)whore.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext299 ContextSwitchInterpreter
						if(subContext299 != null)
						{
							//ScriptedTypes.facts subContext299; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.lover FuncCtx300 = subContext299.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx300 ContextPropertySwitchInterpreter
								if(FuncCtx300 != null)
								{
									UnityEngine.GameObject OperandVar301 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar301 = noble;
									FuncCtx300.OfWhom = (UnityEngine.GameObject)( (OperandVar301));
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
							
							{
								ScriptedTypes.lover FuncCtx302 = subContext299.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx302 ContextPropertySwitchInterpreter
								if(FuncCtx302 != null)
								{
									UnityEngine.GameObject OperandVar303 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar303 = noble;
									FuncCtx302.OfWhom = (UnityEngine.GameObject)( (OperandVar303));
									
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
    
    
    public class AtScopesimple_wander : SmartScope {
        
        public override int MaxAttempts {
            get {
return 3;
            }
        }
        
        public override string FromMetricName {
            get {
return "wander_to_metric";
            }
        }
    }
    
    public class simple_wanderEngagement : TaskWrapper {
        
        public override System.Type TaskCategory {
            get {
return typeof(ScriptedTypes.with);
            }
        }
        
        public override bool Satisfied() {
return true;
        }
        
        public override void InitTask(Task task) {

		{
			//System.Type TaskCategory; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			var properTask = task as ScriptedTypes.with;
			ScriptedTypes.wander_to fromTask = FromTask as ScriptedTypes.wander_to; //IsContext = True IsNew = False
			UnityEngine.GameObject root = FromTask.Root; //IsContext = True IsNew = False
			UnityEngine.GameObject at = FromTask.At; //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar312 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar312 = root;
			task.Root = (UnityEngine.GameObject) (OperandVar312);
			UnityEngine.GameObject OperandVar313 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar313 = at;
			properTask.Who = (UnityEngine.GameObject) (OperandVar313);
		}
        }
    }
    
    public class simple_wander : PrimitiveTask, ScriptedTypes.wander_to {
        
        private float distance;
        
        private SmartScope smart_scope;
        
        private Movable mov;
        
        private TaskWrapper engagement;
        
        public simple_wander() {
smart_scope = new AtScopesimple_wander();
engagement = new simple_wanderEngagement();
        }
        
        public override string Category {
            get {
return "wander_to";
            }
        }
        
        float ScriptedTypes.wander_to.Distance {
            get {
return distance; 
            }
            set {
distance = value; 
            }
        }
        
        public override bool IsBehaviour {
            get {
return false;
            }
        }
        
        public override InterruptionType Interruption {
            get {
return InterruptionType.Restartable;
            }
        }
        
        public SmartScope SmartScope {
            get {
return smart_scope;
            }
            set {
smart_scope = value;
            }
        }
        
        public override string Animation {
            get {
return "walk";
            }
        }
        
        public TaskWrapper Engagement {
            get {
return engagement;
            }
            set {
engagement = value;
            }
        }
        
        public override TaskWrapper EngageIn {
            get {
return engagement;
            }
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			System.Boolean OperandVar306 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable304 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable304 != null)
			{
				Movable StoredVariable305 = ((Movable)StoredVariable304.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable305 != null)
				{
					applicable = true;
					OperandVar306 = applicable;
				}
			}
			return (System.Boolean) (OperandVar306);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			
			return (System.Single) (0.1f);
		}
        }
        
        public override void Init() {

		{
			//System.String Category; //IsContext = False IsNew = False
			//NullType Distance; //IsContext = False IsNew = False
			//System.Boolean IsBehaviour; //IsContext = False IsNew = False
			//InterruptionType Interruption; //IsContext = False IsNew = False
			//SmartScope SmartScope; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//SmartScope smart_scope; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar308 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop307 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop307 != null)
			{
				OperandVar308 = prop307;
			}
			smart_scope.Scope =  (OperandVar308);
			engagement.FromTask = this;
		}
        }
        
        public override void OnStart() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//SmartScope smart_scope; //IsContext = False IsNew = False
			
			{
				Movable subContext309 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext309 ContextSwitchInterpreter
				if(subContext309 != null)
				{
					//Movable subContext309; //IsContext = True IsNew = False
					
					UnityEngine.GameObject OperandVar310 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar310 = at;
					subContext309.Goto((System.Single)( (0.3f)),(UnityEngine.GameObject)( (OperandVar310)));
					
					subContext309.Speed = (System.Single)( (1f));
					Movable OperandVar311 = default(Movable); //IsContext = False IsNew = False
					OperandVar311 = subContext309;
					mov =  (OperandVar311);
					//Movable mov; //IsContext = False IsNew = False
				}
			}
		}
        }
        
        public override void OnFinish() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//SmartScope smart_scope; //IsContext = False IsNew = False
			//Movable mov; //IsContext = False IsNew = False
			
			{
				//ContextStatement Movable mov ContextSwitchInterpreter
				if(mov != null)
				{
					//Movable mov; //IsContext = True IsNew = False
					
					mov.Clear((System.Boolean)( (true)));
				}
			}
		}
        }
        
        public override void OnTerminate() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//SmartScope smart_scope; //IsContext = False IsNew = False
			//Movable mov; //IsContext = False IsNew = False
			
			{
				//ContextStatement Movable mov ContextSwitchInterpreter
				if(mov != null)
				{
					//Movable mov; //IsContext = True IsNew = False
					
					mov.Clear((System.Boolean)( (true)));
				}
			}
		}
        }
        
        public override bool Finished() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean should = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//SmartScope smart_scope; //IsContext = False IsNew = False
			//Movable mov; //IsContext = False IsNew = False
			//TaskWrapper engagement; //IsContext = False IsNew = False
			System.Boolean OperandVar315 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop314 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar315 = prop314;
			return (System.Boolean) (OperandVar315);
		}
        }
    }
    
    public class wander_around : PrimitiveTask, ScriptedTypes.wander {
        
        private UnityEngine.GameObject around;
        
        private Movable mov;
        
        public override string Category {
            get {
return "wander";
            }
        }
        
        UnityEngine.GameObject ScriptedTypes.wander.Around {
            get {
return around; 
            }
            set {
around = value; 
            }
        }
        
        public override bool IsBehaviour {
            get {
return false;
            }
        }
        
        public override InterruptionType Interruption {
            get {
return InterruptionType.Restartable;
            }
        }
        
        public override string Animation {
            get {
return "walk";
            }
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject around; //IsContext = False IsNew = False
			System.Boolean OperandVar318 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable316 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable316 != null)
			{
				Movable StoredVariable317 = ((Movable)StoredVariable316.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable317 != null)
				{
					applicable = true;
					OperandVar318 = applicable;
				}
			}
			return (System.Boolean) (OperandVar318);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject around; //IsContext = False IsNew = False
			
			return (System.Single) (0.1f);
		}
        }
        
        public override void OnStart() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject around; //IsContext = False IsNew = False
			UnityEngine.Vector2 OperandVar323 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
			UnityEngine.Vector3 OperandVar321 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			Entity StoredVariable319 = ((Entity)around.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable319 != null)
			{
				UnityEngine.Vector3 prop320 = StoredVariable319.Position; //IsContext = False IsNew = False
				OperandVar321 = prop320;
			}
			
			UnityEngine.Vector2 prop322 = External.RandomPoint( (OperandVar321), (1f)); //IsContext = False IsNew = False
			OperandVar323 = prop322;
			UnityEngine.Vector2 point =  (OperandVar323); //IsContext = False IsNew = False
			
			
			
			UnityEngine.GameObject OperandVar324 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar324 = around;
			External.Log((System.Object)(( ( ("wandering around "))) + ( ( (OperandVar324)))));
			
			{
				Movable subContext325 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext325 ContextSwitchInterpreter
				if(subContext325 != null)
				{
					//Movable subContext325; //IsContext = True IsNew = False
					
					UnityEngine.Vector2 OperandVar326 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
					OperandVar326 = point;
					subContext325.GotoPoint((System.Single)( (0.3f)),(UnityEngine.Vector2)( (OperandVar326)));
					
					subContext325.Speed = (System.Single)( (1f));
					Movable OperandVar327 = default(Movable); //IsContext = False IsNew = False
					OperandVar327 = subContext325;
					mov =  (OperandVar327);
					//Movable mov; //IsContext = False IsNew = False
				}
			}
		}
        }
        
        public override void OnFinish() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject around; //IsContext = False IsNew = False
			//Movable mov; //IsContext = False IsNew = False
			
			{
				//ContextStatement Movable mov ContextSwitchInterpreter
				if(mov != null)
				{
					//Movable mov; //IsContext = True IsNew = False
					
					mov.Clear((System.Boolean)( (true)));
				}
			}
		}
        }
        
        public override void OnTerminate() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject around; //IsContext = False IsNew = False
			//Movable mov; //IsContext = False IsNew = False
			
			{
				//ContextStatement Movable mov ContextSwitchInterpreter
				if(mov != null)
				{
					//Movable mov; //IsContext = True IsNew = False
					
					mov.Clear((System.Boolean)( (true)));
				}
			}
		}
        }
        
        public override bool Finished() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean should = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject around; //IsContext = False IsNew = False
			//Movable mov; //IsContext = False IsNew = False
			System.Boolean OperandVar329 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop328 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar329 = prop328;
			return (System.Boolean) (OperandVar329);
		}
        }
    }
    
    public class wander_complex_beh0 : TaskWrapper {
        
        public override System.Type TaskCategory {
            get {
return typeof(ScriptedTypes.wander_to);
            }
        }
        
        public override bool Satisfied() {
return true;
        }
        
        public override void InitTask(Task task) {

		{
			//System.Type TaskCategory; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			//Task task; //IsContext = False IsNew = False
			var properTask = task as ScriptedTypes.wander_to;
			
			properTask.Distance = (System.Single) (1f);
		}
        }
    }
    
    public class wander_complex_beh1 : TaskWrapper {
        
        public override System.Type TaskCategory {
            get {
return typeof(ScriptedTypes.wander_to);
            }
        }
        
        public override bool Satisfied() {
return true;
        }
        
        public override void InitTask(Task task) {

		{
			//System.Type TaskCategory; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			//Task task; //IsContext = False IsNew = False
			var properTask = task as ScriptedTypes.wander_to;
			
			properTask.Distance = (System.Single) (1f);
		}
        }
    }
    
    public class wander_complex_beh2 : TaskWrapper {
        
        public override System.Type TaskCategory {
            get {
return typeof(ScriptedTypes.wander_to);
            }
        }
        
        public override bool Satisfied() {
return true;
        }
        
        public override void InitTask(Task task) {

		{
			//System.Type TaskCategory; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			//Task task; //IsContext = False IsNew = False
			var properTask = task as ScriptedTypes.wander_to;
			
			properTask.Distance = (System.Single) (1f);
		}
        }
    }
    
    public class wander_complex_beh : ComplexTask {
        
        private System.Collections.Generic.List<TaskWrapper> decomposition;
        
        public wander_complex_beh() {
decomposition = new System.Collections.Generic.List<TaskWrapper>();
decomposition.Add(new ScriptedTypes.wander_complex_beh0());
decomposition.Add(new ScriptedTypes.wander_complex_beh1());
decomposition.Add(new ScriptedTypes.wander_complex_beh2());
        }
        
        public override System.Collections.Generic.List<TaskWrapper> Decomposition {
            get {
return decomposition;
            }
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			System.Boolean OperandVar331 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable330 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable330 != null)
			{
				applicable = true;
				OperandVar331 = applicable;
			}
			return (System.Boolean) (OperandVar331);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			
			return (System.Single) (0.1f);
		}
        }
        
        public override void Init() {

		{
			//System.Collections.Generic.List<TaskWrapper> Decomposition; //IsContext = False IsNew = False
			//System.Collections.Generic.List<TaskWrapper> decomposition; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			decomposition[0].FromTask = this;
			decomposition[1].FromTask = this;
			decomposition[2].FromTask = this;
		}
        }
    }
    
    public class simple_interaction0 : TaskWrapper {
        
        public override System.Type TaskCategory {
            get {
return typeof(ScriptedTypes.wander);
            }
        }
        
        public override bool Satisfied() {
return true;
        }
        
        public override void InitTask(Task task) {

		{
			//System.Type TaskCategory; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			var properTask = task as ScriptedTypes.wander;
			ScriptedTypes.with fromTask = FromTask as ScriptedTypes.with; //IsContext = True IsNew = False
			UnityEngine.GameObject root = FromTask.Root; //IsContext = True IsNew = False
			UnityEngine.GameObject at = FromTask.At; //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar335 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop334 = fromTask.Who; //IsContext = False IsNew = False
			if(prop334 != null)
			{
				OperandVar335 = prop334;
			}
			properTask.Around = (UnityEngine.GameObject) (OperandVar335);
		}
        }
    }
    
    public class simple_interaction1 : TaskWrapper {
        
        public override System.Type TaskCategory {
            get {
return typeof(ScriptedTypes.wander);
            }
        }
        
        public override bool Satisfied() {
return true;
        }
        
        public override void InitTask(Task task) {

		{
			//System.Type TaskCategory; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			var properTask = task as ScriptedTypes.wander;
			ScriptedTypes.with fromTask = FromTask as ScriptedTypes.with; //IsContext = True IsNew = False
			UnityEngine.GameObject root = FromTask.Root; //IsContext = True IsNew = False
			UnityEngine.GameObject at = FromTask.At; //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar336 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar336 = root;
			properTask.Around = (UnityEngine.GameObject) (OperandVar336);
		}
        }
    }
    
    public class simple_interaction : ComplexTask, ScriptedTypes.with {
        
        private UnityEngine.GameObject who;
        
        private System.Collections.Generic.List<TaskWrapper> decomposition;
        
        public simple_interaction() {
decomposition = new System.Collections.Generic.List<TaskWrapper>();
decomposition.Add(new ScriptedTypes.simple_interaction0());
decomposition.Add(new ScriptedTypes.simple_interaction1());
        }
        
        public override string Category {
            get {
return "with";
            }
        }
        
        UnityEngine.GameObject ScriptedTypes.with.Who {
            get {
return who; 
            }
            set {
who = value; 
            }
        }
        
        public override bool IsBehaviour {
            get {
return false;
            }
        }
        
        public override System.Collections.Generic.List<TaskWrapper> Decomposition {
            get {
return decomposition;
            }
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject who; //IsContext = False IsNew = False
			System.Boolean OperandVar333 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable332 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable332 != null)
			{
				applicable = true;
				OperandVar333 = applicable;
			}
			return (System.Boolean) (OperandVar333);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			var at = this.at;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject who; //IsContext = False IsNew = False
			
			return (System.Single) (0.1f);
		}
        }
        
        public override void Init() {

		{
			//System.String Category; //IsContext = False IsNew = False
			//NullType Who; //IsContext = False IsNew = False
			//System.Boolean IsBehaviour; //IsContext = False IsNew = False
			//System.Collections.Generic.List<TaskWrapper> Decomposition; //IsContext = False IsNew = False
			//UnityEngine.GameObject who; //IsContext = False IsNew = False
			//System.Collections.Generic.List<TaskWrapper> decomposition; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			decomposition[0].FromTask = this;
			decomposition[1].FromTask = this;
		}
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single val = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			System.Single OperandVar339 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable337 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable337 != null)
			{
				System.Single prop338 = StoredVariable337.Brightness; //IsContext = False IsNew = False
				OperandVar339 = prop338;
			}
			System.Single OperandVar342 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable340 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable340 != null)
			{
				System.Single prop341 = StoredVariable340.Light; //IsContext = False IsNew = False
				OperandVar342 = prop341;
			}
			val = ( (OperandVar339)) * ( (OperandVar342));
			return val;
		}
        }
        
        public override bool RootFilter() {

		{
			var root = this.root;
			var other = this.other;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			System.Boolean OperandVar345 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable343 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable343 != null)
			{
				LightSensor StoredVariable344 = ((LightSensor)StoredVariable343.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable344 != null)
				{
					applicable = true;
					OperandVar345 = applicable;
				}
			}
			return (System.Boolean) (OperandVar345);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			System.Boolean OperandVar348 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable346 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable346 != null)
			{
				LightSource StoredVariable347 = ((LightSource)StoredVariable346.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable347 != null)
				{
					applicable = true;
					OperandVar348 = applicable;
				}
			}
			return (System.Boolean) (OperandVar348);
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single val = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			
			val =  (0.4f);
			return val;
		}
        }
        
        public override bool RootFilter() {

		{
			var root = this.root;
			var other = this.other;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			System.Boolean OperandVar350 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable349 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable349 != null)
			{
				applicable = true;
				OperandVar350 = applicable;
			}
			return (System.Boolean) (OperandVar350);
		}
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var other = this.other;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			System.Boolean OperandVar352 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable351 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable351 != null)
			{
				applicable = true;
				OperandVar352 = applicable;
			}
			return (System.Boolean) (OperandVar352);
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
        
        private TestEvent trigger;
        
        public override Event Event {
            get {
return trigger;
            }
            set {
trigger = value as TestEvent;
            }
        }
        
        public override bool Filter() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//TestEvent trigger; //IsContext = True IsNew = False
			System.Boolean OperandVar355 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop353 = trigger.Target; //IsContext = False IsNew = False
			if(prop353 != null)
			{
				Actor StoredVariable354 = ((Actor)prop353.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable354 != null)
				{
					applicable = true;
					OperandVar355 = applicable;
				}
			}
			return (System.Boolean) (OperandVar355);
		}
        }
        
        public override void Action() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			//TestEvent trigger; //IsContext = True IsNew = False
			
			{
				VisualsFeed subContext356 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext356 ContextPropertySwitchInterpreter
				if(subContext356 != null)
				{
					TestEvent OperandVar357 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar357 = trigger;
					UnityEngine.Vector3 OperandVar361 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(trigger != null)
					{
						UnityEngine.GameObject prop358 = trigger.Target; //IsContext = False IsNew = False
						if(prop358 != null)
						{
							Entity StoredVariable359 = ((Entity)prop358.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
							if(StoredVariable359 != null)
							{
								UnityEngine.Vector3 prop360 = StoredVariable359.Position; //IsContext = False IsNew = False
								OperandVar361 = prop360;
							}
						}
					}
					subContext356.Push((Event)( (OperandVar357)),(UnityEngine.Vector3)( (OperandVar361)));
				}
			}
		}
        }
    }
    
    [ReactionAttribute(IsRepeatable=false, EventType=typeof(TestEvent), EventFeed=typeof(VisualSensor))]
    public class test_common_personal_reaction : PersonalReaction {
        
        private TestEvent trigger;
        
        public override Event Event {
            get {
return trigger;
            }
            set {
trigger = value as TestEvent;
            }
        }
        
        public override bool RootFilter() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root = false; //IsContext = True IsNew = False
			var root = this.root;
			//TestEvent trigger; //IsContext = False IsNew = False
			System.Boolean OperandVar363 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable362 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable362 != null)
			{
				applicable = true;
				OperandVar363 = applicable;
			}
			return (System.Boolean) (OperandVar363);
		}
        }
        
        public override void Action() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root = false; //IsContext = True IsNew = False
			//UnityEngine.GameObject trigger_root = false; //IsContext = False IsNew = False
			var trigger_root = this.trigger.Root;
			var root = this.root;
			//TestEvent trigger; //IsContext = False IsNew = False
			
			{
				ScriptedTypes.facts subContext364 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext364 ContextSwitchInterpreter
				if(subContext364 != null)
				{
					//ScriptedTypes.facts subContext364; //IsContext = True IsNew = False
					System.Boolean OperandVar366 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop365 = subContext364.HasNoticedTestEvent(); //IsContext = False IsNew = False
					if(prop365 != false)
					{
						OperandVar366 = prop365;
					}
					if(!(OperandVar366))
					{
						ScriptedTypes.noticed_test_event OperandVar368 = default(ScriptedTypes.noticed_test_event); //IsContext = False IsNew = False
						ScriptedTypes.noticed_test_event prop367 = subContext364.AddNoticedTestEvent(); //IsContext = False IsNew = False
						if(prop367 != null)
						{
							OperandVar368 = prop367;
						}
						ScriptedTypes.noticed_test_event ev =  (OperandVar368); //IsContext = False IsNew = False
					}
				}
			}
		}
        }
    }
    
    [ReactionAttribute(IsRepeatable=false, EventType=typeof(DialogAccepted))]
    public class player_initiate_dialog : Reaction {
        
        private DialogAccepted trigger;
        
        public override Event Event {
            get {
return trigger;
            }
            set {
trigger = value as DialogAccepted;
            }
        }
        
        public override bool Filter() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//DialogAccepted trigger; //IsContext = True IsNew = False
			System.Boolean OperandVar371 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop369 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop369 != null)
			{
				PlayerMarker StoredVariable370 = ((PlayerMarker)prop369.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable370 != null)
				{
					applicable = true;
					OperandVar371 = applicable;
				}
			}
			return (System.Boolean) (OperandVar371);
		}
        }
        
        public override void Action() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			//DialogAccepted trigger; //IsContext = True IsNew = False
			
			
			
			UnityEngine.GameObject OperandVar373 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop372 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop372 != null)
			{
				OperandVar373 = prop372;
			}
			External.Log((System.Object)(( ( ("init dialog for "))) + ( ( (OperandVar373)))));
			UnityEngine.GameObject OperandVar375 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop374 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop374 != null)
			{
				OperandVar375 = prop374;
			}
			External.InitDialogUi((UnityEngine.GameObject)( (OperandVar375)));
		}
        }
    }
    
    [ReactionAttribute(IsRepeatable=false, EventType=typeof(DialogRejected))]
    public class dialog_rejected_while_talking : Reaction {
        
        private DialogRejected trigger;
        
        public override Event Event {
            get {
return trigger;
            }
            set {
trigger = value as DialogRejected;
            }
        }
        
        public override bool Filter() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//DialogRejected trigger; //IsContext = True IsNew = False
			System.Boolean OperandVar378 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop376 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop376 != null)
			{
				PlayerMarker StoredVariable377 = ((PlayerMarker)prop376.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable377 != null)
				{
					applicable = true;
					OperandVar378 = applicable;
				}
			}
			return (System.Boolean) (OperandVar378);
		}
        }
        
        public override void Action() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			//DialogRejected trigger; //IsContext = True IsNew = False
			
			External.CloseDialogUi((System.Object)( (true)));
		}
        }
    }
    
    [ReactionAttribute(IsRepeatable=false, EventType=typeof(DialogFinished))]
    public class close_on_dialog_finished : Reaction {
        
        private DialogFinished trigger;
        
        public override Event Event {
            get {
return trigger;
            }
            set {
trigger = value as DialogFinished;
            }
        }
        
        public override bool Filter() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//DialogFinished trigger; //IsContext = True IsNew = False
			System.Boolean OperandVar381 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop379 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop379 != null)
			{
				PlayerMarker StoredVariable380 = ((PlayerMarker)prop379.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable380 != null)
				{
					applicable = true;
					OperandVar381 = applicable;
				}
			}
			return (System.Boolean) (OperandVar381);
		}
        }
        
        public override void Action() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			//DialogFinished trigger; //IsContext = True IsNew = False
			
			External.CloseDialogUi((System.Object)( (true)));
		}
        }
    }
    
    [ReactionAttribute(IsRepeatable=false, EventType=typeof(EntityCreated))]
    public class npc_extension_personality : Reaction {
        
        private EntityCreated trigger;
        
        public override Event Event {
            get {
return trigger;
            }
            set {
trigger = value as EntityCreated;
            }
        }
        
        public override bool Filter() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//EntityCreated trigger; //IsContext = True IsNew = False
			System.Boolean OperandVar384 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable382 = ((Actor)trigger_root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable382 != null)
			{
				Entity StoredVariable383 = ((Entity)StoredVariable382.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable383 != null)
				{
					applicable = true;
					OperandVar384 = applicable;
				}
			}
			return (System.Boolean) (OperandVar384);
		}
        }
        
        public override void Action() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			//EntityCreated trigger; //IsContext = True IsNew = False
			
			External.Log((System.Object)( ("Added personality")));
			trigger_root.AddComponent<ScriptedTypes.facts>();
			Entity EntVar385 = (Entity)trigger_root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			trigger_root.AddComponent<ScriptedTypes.backstory>();
			
			trigger_root.AddComponent<ScriptedTypes.personality>();
			if(EntVar385 != null) EntVar385.ComponentAdded();
		}
        }
    }
}
