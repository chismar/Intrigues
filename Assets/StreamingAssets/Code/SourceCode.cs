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
    public class interactable_is_highlatable : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar174 = default(System.Boolean); //IsContext = False IsNew = False
			Interactable StoredVariable173 = ((Interactable)root.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
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
			root.AddComponent<Highlightable>();
			Entity EntVar175 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			if(EntVar175 != null) EntVar175.ComponentAdded();
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
			System.Boolean OperandVar177 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable176 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
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
			UnityEngine.GameObject OperandVar179 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop178 = External.NoOne(); //IsContext = False IsNew = False
			if(prop178 != null)
			{
				OperandVar179 = prop178;
			}
			UnityEngine.GameObject noble =  (OperandVar179); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar181 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop180 = External.NoOne(); //IsContext = False IsNew = False
			if(prop180 != null)
			{
				OperandVar181 = prop180;
			}
			UnityEngine.GameObject whore =  (OperandVar181); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar183 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop182 = External.NoOne(); //IsContext = False IsNew = False
			if(prop182 != null)
			{
				OperandVar183 = prop182;
			}
			UnityEngine.GameObject noble_wife =  (OperandVar183); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar185 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop184 = External.NoOne(); //IsContext = False IsNew = False
			if(prop184 != null)
			{
				OperandVar185 = prop184;
			}
			UnityEngine.GameObject whore_lover =  (OperandVar185); //IsContext = False IsNew = False
			
			System.Int32 OperandVar188 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable186 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable186 != null)
			{
				System.Int32 prop187 = StoredVariable186.ActorsCount; //IsContext = False IsNew = False
				OperandVar188 = prop187;
			}
			
			System.Int32 OperandVar190 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable186 != null)
			{
				System.Int32 prop189 = StoredVariable186.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar190 = prop189;
			}
			if(( ( (OperandVar188))) > ( ( (OperandVar190))))
			{
				UnityEngine.GameObject OperandVar206 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop205 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar193 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable191 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable191 != null)
					{
						System.Int32 prop192 = StoredVariable191.ScenariosCount; //IsContext = False IsNew = False
						OperandVar193 = prop192;
					};
;
;
;
;
System.Int32 OperandVar196 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable194 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable194 != null)
					{
						System.Int32 prop195 = StoredVariable194.Influence; //IsContext = False IsNew = False
						OperandVar196 = prop195;
					};
;
;
;
;
System.Int32 OperandVar199 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable197 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable197 != null)
					{
						System.Int32 prop198 = StoredVariable197.Age; //IsContext = False IsNew = False
						OperandVar199 = prop198;
					};
;
;
;
ScriptedTypes.man_role OperandVar201 = default(ScriptedTypes.man_role); //IsContext = False IsNew = False;
ScriptedTypes.man_role StoredVariable200 = ((ScriptedTypes.man_role)go.GetComponent(typeof(ScriptedTypes.man_role))); //IsContext = False IsNew = False;
if(StoredVariable200 != null)
					{
						OperandVar201 = StoredVariable200;
					};
;
System.Boolean OperandVar204 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable202 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable202 != null)
					{
						System.Boolean prop203 = StoredVariable202.HasHusbandTo(); //IsContext = False IsNew = False
						if(prop203 != false)
						{
							OperandVar204 = prop203;
						}
					};
return ( (( ( (OperandVar193))) < ( ( (2f))))) && ( (( ( (OperandVar196))) > ( ( (80f))))) && ( (( ( (OperandVar199))) > ( ( (30f))))) && ( ( (OperandVar201))) && ( (!(OperandVar204)));}); //IsContext = False IsNew = False
				if(prop205 != null)
				{
					OperandVar206 = prop205;
				}
				noble =  (OperandVar206);
			}
			
			System.Int32 OperandVar208 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable186 != null)
			{
				System.Int32 prop207 = StoredVariable186.ActorsCount; //IsContext = False IsNew = False
				OperandVar208 = prop207;
			}
			
			System.Int32 OperandVar210 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable186 != null)
			{
				System.Int32 prop209 = StoredVariable186.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar210 = prop209;
			}
			if(( ( (OperandVar208))) > ( ( (OperandVar210))))
			{
				UnityEngine.GameObject OperandVar218 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop217 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar213 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable211 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable211 != null)
					{
						System.Int32 prop212 = StoredVariable211.ScenariosCount; //IsContext = False IsNew = False
						OperandVar213 = prop212;
					};
;
;
;
ScriptedTypes.woman_role OperandVar216 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.folk_role StoredVariable214 = ((ScriptedTypes.folk_role)go.GetComponent(typeof(ScriptedTypes.folk_role))); //IsContext = False IsNew = False;
if(StoredVariable214 != null)
					{
						ScriptedTypes.woman_role StoredVariable215 = ((ScriptedTypes.woman_role)StoredVariable214.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable215 != null)
						{
							OperandVar216 = StoredVariable215;
						}
					};
return ( (( ( (OperandVar213))) < ( ( (2f))))) && ( ( (OperandVar216)));}); //IsContext = False IsNew = False
				if(prop217 != null)
				{
					OperandVar218 = prop217;
				}
				whore =  (OperandVar218);
			}
			
			System.Int32 OperandVar220 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable186 != null)
			{
				System.Int32 prop219 = StoredVariable186.ActorsCount; //IsContext = False IsNew = False
				OperandVar220 = prop219;
			}
			
			System.Int32 OperandVar222 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable186 != null)
			{
				System.Int32 prop221 = StoredVariable186.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar222 = prop221;
			}
			if(( ( (OperandVar220))) > ( ( (OperandVar222))))
			{
				UnityEngine.GameObject OperandVar233 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop232 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar225 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable223 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable223 != null)
					{
						System.Int32 prop224 = StoredVariable223.ScenariosCount; //IsContext = False IsNew = False
						OperandVar225 = prop224;
					};
;
;
;
ScriptedTypes.woman_role OperandVar228 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable226 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable226 != null)
					{
						ScriptedTypes.woman_role StoredVariable227 = ((ScriptedTypes.woman_role)StoredVariable226.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable227 != null)
						{
							OperandVar228 = StoredVariable227;
						}
					};
;
System.Boolean OperandVar231 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable229 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable229 != null)
					{
						System.Boolean prop230 = StoredVariable229.HasWifeTo(); //IsContext = False IsNew = False
						if(prop230 != false)
						{
							OperandVar231 = prop230;
						}
					};
return ( (( ( (OperandVar225))) < ( ( (2f))))) && ( ( (OperandVar228))) && ( (!(OperandVar231)));}); //IsContext = False IsNew = False
				if(prop232 != null)
				{
					OperandVar233 = prop232;
				}
				noble_wife =  (OperandVar233);
			}
			
			System.Int32 OperandVar235 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable186 != null)
			{
				System.Int32 prop234 = StoredVariable186.ActorsCount; //IsContext = False IsNew = False
				OperandVar235 = prop234;
			}
			
			System.Int32 OperandVar237 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable186 != null)
			{
				System.Int32 prop236 = StoredVariable186.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar237 = prop236;
			}
			if(( ( (OperandVar235))) > ( ( (OperandVar237))))
			{
				UnityEngine.GameObject OperandVar247 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop246 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar240 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable238 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable238 != null)
					{
						System.Int32 prop239 = StoredVariable238.ScenariosCount; //IsContext = False IsNew = False
						OperandVar240 = prop239;
					};
;
;
;
ScriptedTypes.noble_role OperandVar242 = default(ScriptedTypes.noble_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable241 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable241 != null)
					{
						OperandVar242 = StoredVariable241;
					};
;
;
System.Int32 OperandVar245 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable243 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable243 != null)
					{
						System.Int32 prop244 = StoredVariable243.Age; //IsContext = False IsNew = False
						OperandVar245 = prop244;
					};
;
;
return ( (( ( (OperandVar240))) < ( ( (2f))))) && ( ( (OperandVar242))) && ( (( ( (OperandVar245))) < ( ( (30f)))));}); //IsContext = False IsNew = False
				if(prop246 != null)
				{
					OperandVar247 = prop246;
				}
				whore_lover =  (OperandVar247);
			}
			System.Boolean OperandVar250 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar248 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar248 = noble;
			System.Boolean prop249 = External.Has( (OperandVar248)); //IsContext = False IsNew = False
			if(prop249 != false)
			{
				OperandVar250 = prop249;
			}
			if(!(OperandVar250))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx251 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx251 ContextPropertySwitchInterpreter
					if(FuncCtx251 != null)
					{
						UnityEngine.GameObject OperandVar252 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar252 = FuncCtx251;
						noble =  (OperandVar252);
						ScriptedTypes.noble_role ContextVar253 = FuncCtx251.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar253 ContextSwitchInterpreter
							if(ContextVar253 != null)
							{
								//ScriptedTypes.noble_role ContextVar253; //IsContext = True IsNew = False
								
								ContextVar253.Influence = (System.Int32)( (90f));
							}
						}
						Entity EntVar254 = (Entity)FuncCtx251.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						ScriptedTypes.aged ContextVar255 = FuncCtx251.AddComponent<ScriptedTypes.aged>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.aged ContextVar255 ContextSwitchInterpreter
							if(ContextVar255 != null)
							{
								//ScriptedTypes.aged ContextVar255; //IsContext = True IsNew = False
								
								ContextVar255.Age = (System.Int32)( (50f));
							}
						}
						
						FuncCtx251.AddComponent<ScriptedTypes.man_role>();
						if(EntVar254 != null) EntVar254.ComponentAdded();
						
						{
							Entity subContext256 = (Entity)FuncCtx251.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext256 ContextSwitchInterpreter
							if(subContext256 != null)
							{
								//Entity subContext256; //IsContext = True IsNew = False
								
								
								
								subContext256.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
							}
						}
					}
				}
			}
			System.Boolean OperandVar259 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar257 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar257 = whore;
			System.Boolean prop258 = External.Has( (OperandVar257)); //IsContext = False IsNew = False
			if(prop258 != false)
			{
				OperandVar259 = prop258;
			}
			if(!(OperandVar259))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx260 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx260 ContextPropertySwitchInterpreter
					if(FuncCtx260 != null)
					{
						UnityEngine.GameObject OperandVar261 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar261 = FuncCtx260;
						whore =  (OperandVar261);
						FuncCtx260.AddComponent<ScriptedTypes.folk_role>();
						Entity EntVar262 = (Entity)FuncCtx260.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx260.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar262 != null) EntVar262.ComponentAdded();
						
						{
							Entity subContext263 = (Entity)FuncCtx260.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext263 ContextSwitchInterpreter
							if(subContext263 != null)
							{
								//Entity subContext263; //IsContext = True IsNew = False
								
								
								
								subContext263.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
							}
						}
					}
				}
			}
			System.Boolean OperandVar266 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar264 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar264 = noble_wife;
			System.Boolean prop265 = External.Has( (OperandVar264)); //IsContext = False IsNew = False
			if(prop265 != false)
			{
				OperandVar266 = prop265;
			}
			if(!(OperandVar266))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx267 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble_wife")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx267 ContextPropertySwitchInterpreter
					if(FuncCtx267 != null)
					{
						UnityEngine.GameObject OperandVar268 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar268 = FuncCtx267;
						noble_wife =  (OperandVar268);
						FuncCtx267.AddComponent<ScriptedTypes.noble_role>();
						Entity EntVar269 = (Entity)FuncCtx267.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx267.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar269 != null) EntVar269.ComponentAdded();
						
						{
							Entity subContext270 = (Entity)FuncCtx267.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext270 ContextSwitchInterpreter
							if(subContext270 != null)
							{
								//Entity subContext270; //IsContext = True IsNew = False
								
								
								
								subContext270.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
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
						ScriptedTypes.facts subContext271 = (ScriptedTypes.facts)noble_wife.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext271 ContextSwitchInterpreter
						if(subContext271 != null)
						{
							//ScriptedTypes.facts subContext271; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.wife_to FuncCtx272 = subContext271.AddWifeTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.wife_to FuncCtx272 ContextPropertySwitchInterpreter
								if(FuncCtx272 != null)
								{
									UnityEngine.GameObject OperandVar273 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar273 = noble;
									FuncCtx272.Whom = (UnityEngine.GameObject)( (OperandVar273));
								}
							}
							
							{
								ScriptedTypes.rival FuncCtx274 = subContext271.AddRival();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.rival FuncCtx274 ContextPropertySwitchInterpreter
								if(FuncCtx274 != null)
								{
									UnityEngine.GameObject OperandVar275 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar275 = whore;
									FuncCtx274.WhoIs = (UnityEngine.GameObject)( (OperandVar275));
									UnityEngine.GameObject OperandVar277 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									UnityEngine.GameObject prop276 = FuncCtx274.WhoIs; //IsContext = False IsNew = False
									if(prop276 != null)
									{
										OperandVar277 = prop276;
									}
									External.Log((System.Object)( (OperandVar277)));
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
						ScriptedTypes.facts subContext278 = (ScriptedTypes.facts)noble.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext278 ContextSwitchInterpreter
						if(subContext278 != null)
						{
							//ScriptedTypes.facts subContext278; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.husband_to FuncCtx279 = subContext278.AddHusbandTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.husband_to FuncCtx279 ContextPropertySwitchInterpreter
								if(FuncCtx279 != null)
								{
									UnityEngine.GameObject OperandVar280 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar280 = noble_wife;
									FuncCtx279.Whom = (UnityEngine.GameObject)( (OperandVar280));
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
								ScriptedTypes.lover FuncCtx282 = subContext281.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx282 ContextPropertySwitchInterpreter
								if(FuncCtx282 != null)
								{
									UnityEngine.GameObject OperandVar283 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar283 = whore;
									FuncCtx282.OfWhom = (UnityEngine.GameObject)( (OperandVar283));
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			System.Boolean OperandVar286 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar284 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar284 = whore_lover;
			System.Boolean prop285 = External.Has( (OperandVar284)); //IsContext = False IsNew = False
			if(prop285 != false)
			{
				OperandVar286 = prop285;
			}
			if(!(OperandVar286))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx287 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore_lover")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx287 ContextPropertySwitchInterpreter
					if(FuncCtx287 != null)
					{
						UnityEngine.GameObject OperandVar288 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar288 = FuncCtx287;
						whore_lover =  (OperandVar288);
						ScriptedTypes.noble_role ContextVar289 = FuncCtx287.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar289 ContextSwitchInterpreter
							if(ContextVar289 != null)
							{
								//ScriptedTypes.noble_role ContextVar289; //IsContext = True IsNew = False
								
								ContextVar289.Influence = (System.Int32)( (40f));
							}
						}
						Entity EntVar290 = (Entity)FuncCtx287.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx287.AddComponent<ScriptedTypes.man_role>();
						if(EntVar290 != null) EntVar290.ComponentAdded();
						
						{
							ScriptedTypes.aged subContext291 = (ScriptedTypes.aged)FuncCtx287.GetComponent(typeof(ScriptedTypes.aged)); //IsContext = True IsNew = False
							//ContextStatement ScriptedTypes.aged subContext291 ContextSwitchInterpreter
							if(subContext291 != null)
							{
								//ScriptedTypes.aged subContext291; //IsContext = True IsNew = False
								
								subContext291.Age = (System.Int32)( (25f));
							}
						}
						
						{
							Entity subContext292 = (Entity)FuncCtx287.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext292 ContextSwitchInterpreter
							if(subContext292 != null)
							{
								//Entity subContext292; //IsContext = True IsNew = False
								
								
								
								subContext292.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
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
						ScriptedTypes.facts subContext293 = (ScriptedTypes.facts)whore_lover.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext293 ContextSwitchInterpreter
						if(subContext293 != null)
						{
							//ScriptedTypes.facts subContext293; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.lover FuncCtx294 = subContext293.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx294 ContextPropertySwitchInterpreter
								if(FuncCtx294 != null)
								{
									UnityEngine.GameObject OperandVar295 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar295 = whore;
									FuncCtx294.OfWhom = (UnityEngine.GameObject)( (OperandVar295));
									
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
						ScriptedTypes.facts subContext296 = (ScriptedTypes.facts)whore.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
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
									OperandVar298 = noble;
									FuncCtx297.OfWhom = (UnityEngine.GameObject)( (OperandVar298));
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
							
							{
								ScriptedTypes.lover FuncCtx299 = subContext296.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx299 ContextPropertySwitchInterpreter
								if(FuncCtx299 != null)
								{
									UnityEngine.GameObject OperandVar300 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar300 = noble;
									FuncCtx299.OfWhom = (UnityEngine.GameObject)( (OperandVar300));
									
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
    
    
    public class near : TaskWrapper {
        
        private float distance;
        
        private UnityEngine.GameObject other;
        
        private Entity s;
        
        private Entity o;
        
        public float Distance {
            get {
return distance;
            }
            set {
distance = value;
            }
        }
        
        public UnityEngine.GameObject Other {
            get {
return other;
            }
            set {
other = value;
            }
        }
        
        public Entity S {
            get {
return s;
            }
            set {
s = value;
            }
        }
        
        public Entity O {
            get {
return o;
            }
            set {
o = value;
            }
        }
        
        public override System.Type TaskCategory {
            get {
return typeof(ScriptedTypes.follow);
            }
        }
        
        public override LocalizedString Serialized {
            get {

		{
			//System.Single Distance; //IsContext = False IsNew = False
			//UnityEngine.GameObject Other; //IsContext = False IsNew = False
			//Entity S; //IsContext = False IsNew = False
			//Entity O; //IsContext = False IsNew = False
			//System.Type TaskCategory; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			//Entity s; //IsContext = False IsNew = False
			//Entity o; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			var root = this.Root;
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			var other = this.Other;
			//UnityEngine.GameObject other; //IsContext = True IsNew = False
			LocalizedString OperandVar318 = default(LocalizedString); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar315 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar315 = root;
			UnityEngine.GameObject OperandVar316 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar316 = other;
			System.Single OperandVar317 = default(System.Single); //IsContext = False IsNew = False
			OperandVar317 = distance;
			var dict313= new System.Collections.Generic.Dictionary<string, object>();
var localizedString314= new LocalizedString("should_be_near",dict313);dict313.Add("who", (OperandVar315));
dict313.Add("other", (OperandVar316));
dict313.Add("distance", (OperandVar317));

			OperandVar318 = localizedString314;
			return  (OperandVar318);
		}
            }
        }
        
        public override void Init() {

		{
			//System.Single Distance; //IsContext = False IsNew = False
			//UnityEngine.GameObject Other; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			var root = this.Root;
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			var other = this.Other;
			//UnityEngine.GameObject other; //IsContext = True IsNew = False
			
			{
				Entity OperandVar302 = default(Entity); //IsContext = False IsNew = False
				Entity StoredVariable301 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable301 != null)
				{
					OperandVar302 = StoredVariable301;
				}
				s =  (OperandVar302);
			}
			
			{
				Entity OperandVar304 = default(Entity); //IsContext = False IsNew = False
				Entity StoredVariable303 = ((Entity)other.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable303 != null)
				{
					OperandVar304 = StoredVariable303;
				}
				o =  (OperandVar304);
			}
		}
        }
        
        public override void InitTask(Task task) {

		{
			//System.Single Distance; //IsContext = False IsNew = False
			//UnityEngine.GameObject Other; //IsContext = False IsNew = False
			//Entity S; //IsContext = False IsNew = False
			//Entity O; //IsContext = False IsNew = False
			//System.Type TaskCategory; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			//Entity s; //IsContext = False IsNew = False
			//Entity o; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			var root = this.Root;
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			var other = this.Other;
			//UnityEngine.GameObject other; //IsContext = True IsNew = False
			var properTask = task as ScriptedTypes.follow;
			
			{
				System.Single OperandVar305 = default(System.Single); //IsContext = False IsNew = False
				OperandVar305 = distance;
				properTask.OkDistance =  (OperandVar305);
			}
			
			{
				UnityEngine.GameObject OperandVar306 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar306 = other;
				properTask.Who =  (OperandVar306);
			}
		}
        }
        
        public override bool Satisfied() {

		{
			var root = this.Root;
			var other = this.Other;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean satisfied = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = True IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			//Entity s; //IsContext = False IsNew = False
			//Entity o; //IsContext = False IsNew = False
			
			System.Single OperandVar312 = default(System.Single); //IsContext = False IsNew = False
			
			UnityEngine.Vector3 OperandVar308 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			UnityEngine.Vector3 prop307 = s.Position; //IsContext = False IsNew = False
			OperandVar308 = prop307;
			
			UnityEngine.Vector3 OperandVar310 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			UnityEngine.Vector3 prop309 = o.Position; //IsContext = False IsNew = False
			OperandVar310 = prop309;
			System.Single prop311 = External.Mag(( ( (OperandVar308))) - ( ( (OperandVar310)))); //IsContext = False IsNew = False
			OperandVar312 = prop311;
			
			
			return (System.Boolean)(( ( (OperandVar312))) <=( ( (1f))));
		}
        }
    }
    
    public interface do_stuff {
    }
    
    public class AtScopelit_up_interaction : SmartScope {
        
        public override int MaxAttempts {
            get {
return 3;
            }
        }
        
        public override string FromMetricName {
            get {
return "lit_up_metric";
            }
        }
        
        public override bool ForInteraction {
            get {
return true;
            }
        }
    }
    
    public class lit_up_interaction : InteractionTask, do_stuff {
        
        private SmartScope smart_scope;
        
        private System.Collections.Generic.List<TaskWrapper> cons;
        
        public lit_up_interaction() {
smart_scope = new AtScopelit_up_interaction();
cons = new System.Collections.Generic.List<TaskWrapper>();
cons.Add(new ScriptedTypes.near());
        }
        
        public override string Category {
            get {
return "do_stuff";
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
        
        public override SmartScope AtScope {
            get {
return smart_scope;
            }
        }
        
        public System.Collections.Generic.List<TaskWrapper> Cons {
            get {
return cons;
            }
            set {
cons = value;
            }
        }
        
        public override System.Collections.Generic.List<TaskWrapper> Constraints {
            get {
return cons;
            }
        }
        
        public override string Animation {
            get {
return "crouch";
            }
        }
        
        public override string OtherAnimation {
            get {
return "none";
            }
        }
        
        public override float Timed {
            get {
return 5f;
            }
        }
        
        public override bool OtherFilter() {

		{
			var root = this.root;
			var at = this.at;
			var other = this.other;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = False IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject other; //IsContext = True IsNew = False
			System.Boolean OperandVar320 = default(System.Boolean); //IsContext = False IsNew = False
			LightSource StoredVariable319 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable319 != null)
			{
				applicable = true;
				OperandVar320 = applicable;
			}
			return (System.Boolean) (OperandVar320);
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
			System.Boolean OperandVar322 = default(System.Boolean); //IsContext = False IsNew = False
			Manual StoredVariable321 = ((Manual)root.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
			if(StoredVariable321 != null)
			{
				applicable = true;
				OperandVar322 = applicable;
			}
			return (System.Boolean) (OperandVar322);
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
			
			return (System.Single) (0.2f);
		}
        }
        
        public override void Init() {

		{
			//System.String Category; //IsContext = False IsNew = False
			//InterruptionType Interruption; //IsContext = False IsNew = False
			//SmartScope SmartScope; //IsContext = False IsNew = False
			//SmartScope AtScope; //IsContext = False IsNew = False
			//SmartScope smart_scope; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar324 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop323 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop323 != null)
			{
				OperandVar324 = prop323;
			}
			smart_scope.Scope =  (OperandVar324);
			if(!smart_scope.SelectNext(this, root.GetComponent<Agent>())) State = TaskState.Failed;
			var indexedWrapper0 = cons[0] as ScriptedTypes.near;
			
			indexedWrapper0.Distance = (System.Single)( (1f));
			indexedWrapper0.Root = this.Root;
			indexedWrapper0.Other = this.Other;
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
			//SmartScope smart_scope; //IsContext = False IsNew = False
			
			{
				//ContextStatement UnityEngine.GameObject at ContextSwitchInterpreter
				if(at != null)
				{
					//UnityEngine.GameObject at; //IsContext = True IsNew = False
					
					{
						LightSource subContext325 = (LightSource)at.GetComponent(typeof(LightSource)); //IsContext = True IsNew = False
						//ContextStatement LightSource subContext325 ContextSwitchInterpreter
						if(subContext325 != null)
						{
							//LightSource subContext325; //IsContext = True IsNew = False
							
							subContext325.LitUp = (System.Boolean)( (true));
						}
					}
				}
			}
			
			
			
			UnityEngine.GameObject OperandVar326 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar326 = at;
			External.Log((System.Object)(( ( ("finished lighting "))) + ( ( (OperandVar326)))));
		}
        }
    }
    
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
			UnityEngine.GameObject OperandVar335 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar335 = root;
			task.Root = (UnityEngine.GameObject) (OperandVar335);
			UnityEngine.GameObject OperandVar336 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar336 = at;
			properTask.Who = (UnityEngine.GameObject) (OperandVar336);
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
        
        public override SmartScope AtScope {
            get {
return smart_scope;
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
			System.Boolean OperandVar329 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable327 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable327 != null)
			{
				Movable StoredVariable328 = ((Movable)StoredVariable327.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable328 != null)
				{
					applicable = true;
					OperandVar329 = applicable;
				}
			}
			return (System.Boolean) (OperandVar329);
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
			//SmartScope AtScope; //IsContext = False IsNew = False
			//System.Single distance; //IsContext = False IsNew = False
			//SmartScope smart_scope; //IsContext = False IsNew = False
			//External External; //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar331 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop330 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop330 != null)
			{
				OperandVar331 = prop330;
			}
			smart_scope.Scope =  (OperandVar331);
			if(!smart_scope.SelectNext(this, root.GetComponent<Agent>())) State = TaskState.Failed;
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
				Movable subContext332 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext332 ContextSwitchInterpreter
				if(subContext332 != null)
				{
					//Movable subContext332; //IsContext = True IsNew = False
					
					UnityEngine.GameObject OperandVar333 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar333 = at;
					subContext332.Goto((System.Single)( (1f)),(UnityEngine.GameObject)( (OperandVar333)));
					
					subContext332.Speed = (System.Single)( (1f));
					Movable OperandVar334 = default(Movable); //IsContext = False IsNew = False
					OperandVar334 = subContext332;
					mov =  (OperandVar334);
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
			System.Boolean OperandVar338 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop337 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar338 = prop337;
			return (System.Boolean) (OperandVar338);
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
			System.Boolean OperandVar341 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable339 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable339 != null)
			{
				Movable StoredVariable340 = ((Movable)StoredVariable339.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable340 != null)
				{
					applicable = true;
					OperandVar341 = applicable;
				}
			}
			return (System.Boolean) (OperandVar341);
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
			UnityEngine.Vector2 OperandVar346 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
			UnityEngine.Vector3 OperandVar344 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			Entity StoredVariable342 = ((Entity)around.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable342 != null)
			{
				UnityEngine.Vector3 prop343 = StoredVariable342.Position; //IsContext = False IsNew = False
				OperandVar344 = prop343;
			}
			
			UnityEngine.Vector2 prop345 = External.RandomPoint( (OperandVar344), (4f)); //IsContext = False IsNew = False
			OperandVar346 = prop345;
			UnityEngine.Vector2 point =  (OperandVar346); //IsContext = False IsNew = False
			
			{
				Movable subContext347 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext347 ContextSwitchInterpreter
				if(subContext347 != null)
				{
					//Movable subContext347; //IsContext = True IsNew = False
					
					UnityEngine.Vector2 OperandVar348 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
					OperandVar348 = point;
					subContext347.GotoPoint((System.Single)( (1f)),(UnityEngine.Vector2)( (OperandVar348)));
					
					subContext347.Speed = (System.Single)( (1f));
					Movable OperandVar349 = default(Movable); //IsContext = False IsNew = False
					OperandVar349 = subContext347;
					mov =  (OperandVar349);
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
			System.Boolean OperandVar351 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop350 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar351 = prop350;
			return (System.Boolean) (OperandVar351);
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
			System.Boolean OperandVar353 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable352 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable352 != null)
			{
				applicable = true;
				OperandVar353 = applicable;
			}
			return (System.Boolean) (OperandVar353);
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
			UnityEngine.GameObject OperandVar357 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop356 = fromTask.Who; //IsContext = False IsNew = False
			if(prop356 != null)
			{
				OperandVar357 = prop356;
			}
			properTask.Around = (UnityEngine.GameObject) (OperandVar357);
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
			UnityEngine.GameObject OperandVar358 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar358 = root;
			properTask.Around = (UnityEngine.GameObject) (OperandVar358);
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
			System.Boolean OperandVar355 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable354 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable354 != null)
			{
				applicable = true;
				OperandVar355 = applicable;
			}
			return (System.Boolean) (OperandVar355);
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
    
    public class simple_move : PrimitiveTask, ScriptedTypes.follow {
        
        private UnityEngine.GameObject who;
        
        private float ok_distance;
        
        private Movable mov;
        
        public override string Category {
            get {
return "follow";
            }
        }
        
        UnityEngine.GameObject ScriptedTypes.follow.Who {
            get {
return who; 
            }
            set {
who = value; 
            }
        }
        
        float ScriptedTypes.follow.OkDistance {
            get {
return ok_distance; 
            }
            set {
ok_distance = value; 
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
			//UnityEngine.GameObject who; //IsContext = False IsNew = False
			//System.Single ok_distance; //IsContext = False IsNew = False
			System.Boolean OperandVar361 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable359 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable359 != null)
			{
				Movable StoredVariable360 = ((Movable)StoredVariable359.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable360 != null)
				{
					applicable = true;
					OperandVar361 = applicable;
				}
			}
			return (System.Boolean) (OperandVar361);
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
			//System.Single ok_distance; //IsContext = False IsNew = False
			
			return (System.Single) (0.2f);
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
			//UnityEngine.GameObject who; //IsContext = False IsNew = False
			//System.Single ok_distance; //IsContext = False IsNew = False
			
			{
				Movable subContext362 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext362 ContextSwitchInterpreter
				if(subContext362 != null)
				{
					//Movable subContext362; //IsContext = True IsNew = False
					System.Single OperandVar363 = default(System.Single); //IsContext = False IsNew = False
					OperandVar363 = ok_distance;
					UnityEngine.GameObject OperandVar364 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar364 = who;
					subContext362.Goto((System.Single)( (OperandVar363)),(UnityEngine.GameObject)( (OperandVar364)));
					
					subContext362.Speed = (System.Single)( (1f));
					Movable OperandVar365 = default(Movable); //IsContext = False IsNew = False
					OperandVar365 = subContext362;
					mov =  (OperandVar365);
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
			//UnityEngine.GameObject who; //IsContext = False IsNew = False
			//System.Single ok_distance; //IsContext = False IsNew = False
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
			//UnityEngine.GameObject who; //IsContext = False IsNew = False
			//System.Single ok_distance; //IsContext = False IsNew = False
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
			//UnityEngine.GameObject who; //IsContext = False IsNew = False
			//System.Single ok_distance; //IsContext = False IsNew = False
			//Movable mov; //IsContext = False IsNew = False
			System.Boolean OperandVar367 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop366 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar367 = prop366;
			return (System.Boolean) (OperandVar367);
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
			System.Single OperandVar370 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable368 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable368 != null)
			{
				System.Single prop369 = StoredVariable368.Brightness; //IsContext = False IsNew = False
				OperandVar370 = prop369;
			}
			System.Single OperandVar373 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable371 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable371 != null)
			{
				System.Single prop372 = StoredVariable371.Light; //IsContext = False IsNew = False
				OperandVar373 = prop372;
			}
			val = ( (OperandVar370)) * ( (OperandVar373));
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
			System.Boolean OperandVar376 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable374 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable374 != null)
			{
				LightSensor StoredVariable375 = ((LightSensor)StoredVariable374.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable375 != null)
				{
					applicable = true;
					OperandVar376 = applicable;
				}
			}
			return (System.Boolean) (OperandVar376);
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
			System.Boolean OperandVar379 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable377 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable377 != null)
			{
				LightSource StoredVariable378 = ((LightSource)StoredVariable377.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable378 != null)
				{
					applicable = true;
					OperandVar379 = applicable;
				}
			}
			return (System.Boolean) (OperandVar379);
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
			System.Boolean OperandVar381 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable380 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable380 != null)
			{
				applicable = true;
				OperandVar381 = applicable;
			}
			return (System.Boolean) (OperandVar381);
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
			System.Boolean OperandVar383 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable382 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable382 != null)
			{
				applicable = true;
				OperandVar383 = applicable;
			}
			return (System.Boolean) (OperandVar383);
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
			System.Boolean OperandVar386 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop384 = trigger.Target; //IsContext = False IsNew = False
			if(prop384 != null)
			{
				Actor StoredVariable385 = ((Actor)prop384.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable385 != null)
				{
					applicable = true;
					OperandVar386 = applicable;
				}
			}
			return (System.Boolean) (OperandVar386);
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
				VisualsFeed subContext387 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext387 ContextPropertySwitchInterpreter
				if(subContext387 != null)
				{
					TestEvent OperandVar388 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar388 = trigger;
					UnityEngine.Vector3 OperandVar392 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(trigger != null)
					{
						UnityEngine.GameObject prop389 = trigger.Target; //IsContext = False IsNew = False
						if(prop389 != null)
						{
							Entity StoredVariable390 = ((Entity)prop389.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
							if(StoredVariable390 != null)
							{
								UnityEngine.Vector3 prop391 = StoredVariable390.Position; //IsContext = False IsNew = False
								OperandVar392 = prop391;
							}
						}
					}
					subContext387.Push((Event)( (OperandVar388)),(UnityEngine.Vector3)( (OperandVar392)));
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
			System.Boolean OperandVar394 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable393 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable393 != null)
			{
				applicable = true;
				OperandVar394 = applicable;
			}
			return (System.Boolean) (OperandVar394);
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
				ScriptedTypes.facts subContext395 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext395 ContextSwitchInterpreter
				if(subContext395 != null)
				{
					//ScriptedTypes.facts subContext395; //IsContext = True IsNew = False
					System.Boolean OperandVar397 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop396 = subContext395.HasNoticedTestEvent(); //IsContext = False IsNew = False
					if(prop396 != false)
					{
						OperandVar397 = prop396;
					}
					if(!(OperandVar397))
					{
						ScriptedTypes.noticed_test_event OperandVar399 = default(ScriptedTypes.noticed_test_event); //IsContext = False IsNew = False
						ScriptedTypes.noticed_test_event prop398 = subContext395.AddNoticedTestEvent(); //IsContext = False IsNew = False
						if(prop398 != null)
						{
							OperandVar399 = prop398;
						}
						ScriptedTypes.noticed_test_event ev =  (OperandVar399); //IsContext = False IsNew = False
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
			System.Boolean OperandVar402 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop400 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop400 != null)
			{
				PlayerMarker StoredVariable401 = ((PlayerMarker)prop400.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable401 != null)
				{
					applicable = true;
					OperandVar402 = applicable;
				}
			}
			return (System.Boolean) (OperandVar402);
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
			
			
			
			UnityEngine.GameObject OperandVar404 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop403 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop403 != null)
			{
				OperandVar404 = prop403;
			}
			External.Log((System.Object)(( ( ("init dialog for "))) + ( ( (OperandVar404)))));
			UnityEngine.GameObject OperandVar406 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop405 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop405 != null)
			{
				OperandVar406 = prop405;
			}
			External.InitDialogUi((UnityEngine.GameObject)( (OperandVar406)));
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
			System.Boolean OperandVar409 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop407 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop407 != null)
			{
				PlayerMarker StoredVariable408 = ((PlayerMarker)prop407.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable408 != null)
				{
					applicable = true;
					OperandVar409 = applicable;
				}
			}
			return (System.Boolean) (OperandVar409);
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
			System.Boolean OperandVar412 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop410 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop410 != null)
			{
				PlayerMarker StoredVariable411 = ((PlayerMarker)prop410.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable411 != null)
				{
					applicable = true;
					OperandVar412 = applicable;
				}
			}
			return (System.Boolean) (OperandVar412);
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
			System.Boolean OperandVar415 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable413 = ((Actor)trigger_root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable413 != null)
			{
				Entity StoredVariable414 = ((Entity)StoredVariable413.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable414 != null)
				{
					applicable = true;
					OperandVar415 = applicable;
				}
			}
			return (System.Boolean) (OperandVar415);
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
			Entity EntVar416 = (Entity)trigger_root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			trigger_root.AddComponent<ScriptedTypes.backstory>();
			
			trigger_root.AddComponent<ScriptedTypes.personality>();
			if(EntVar416 != null) EntVar416.ComponentAdded();
		}
        }
    }
}
