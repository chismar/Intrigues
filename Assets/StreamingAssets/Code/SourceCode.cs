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
												System.String OperandVar165 = default(System.String); //IsContext = False IsNew = False
												System.String prop164 = FuncCtx153.Id; //IsContext = False IsNew = False
												if(prop164 != null)
												{
													OperandVar165 = prop164;
												}
												External.Log((System.Object)( (OperandVar165)));
												
												{
													DialogLine FuncCtx166 = FuncCtx153.Say();; //IsContext = True IsNew = False
													//ContextStatement DialogLine FuncCtx166 ContextPropertySwitchInterpreter
													if(FuncCtx166 != null)
													{
														LocalizedString OperandVar170 = default(LocalizedString); //IsContext = False IsNew = False
														UnityEngine.GameObject OperandVar169 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
														OperandVar169 = rival_of_root;
														var dict167= new System.Collections.Generic.Dictionary<string, object>();
var localizedString168= new LocalizedString("say_about_rival",dict167);dict167.Add("who", (OperandVar169));

														OperandVar170 = localizedString168;
														FuncCtx166.String = (LocalizedString)( (OperandVar170));
														VoidDelegate Lambda171 = () => 
														{
															
															{
																Markers subContext172 = (Markers)root.GetComponent(typeof(Markers)); //IsContext = True IsNew = False
																//ContextStatement Markers subContext172 ContextSwitchInterpreter
																if(subContext172 != null)
																{
																	//Markers subContext172; //IsContext = True IsNew = False
																	System.String OperandVar174 = default(System.String); //IsContext = False IsNew = False
																	if(FuncCtx153 != null)
																	{
																		System.String prop173 = FuncCtx153.Id; //IsContext = False IsNew = False
																		if(prop173 != null)
																		{
																			OperandVar174 = prop173;
																		}
																	}
																	subContext172.SetMarker(( (OperandVar174)).ToString());
																}
															}
														};
														FuncCtx166.Reaction = (VoidDelegate)(Lambda171);
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
			System.Boolean OperandVar176 = default(System.Boolean); //IsContext = False IsNew = False
			PlayerMarker StoredVariable175 = ((PlayerMarker)root.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
			if(StoredVariable175 != null)
			{
				applicable = true;
				OperandVar176 = applicable;
			}
			return (System.Boolean) (OperandVar176);
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
			Entity EntVar177 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			root.AddComponent<TurnFollowMouseController>();
			
			root.AddComponent<InteractableController>();
			if(EntVar177 != null) EntVar177.ComponentAdded();
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
			System.Boolean OperandVar179 = default(System.Boolean); //IsContext = False IsNew = False
			Interactable StoredVariable178 = ((Interactable)root.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
			if(StoredVariable178 != null)
			{
				applicable = true;
				OperandVar179 = applicable;
			}
			return (System.Boolean) (OperandVar179);
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
			Entity EntVar180 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			if(EntVar180 != null) EntVar180.ComponentAdded();
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
			System.Boolean OperandVar182 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable181 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable181 != null)
			{
				applicable = true;
				OperandVar182 = applicable;
			}
			return (System.Boolean) (OperandVar182);
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
			UnityEngine.GameObject OperandVar184 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop183 = External.NoOne(); //IsContext = False IsNew = False
			if(prop183 != null)
			{
				OperandVar184 = prop183;
			}
			UnityEngine.GameObject noble =  (OperandVar184); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar186 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop185 = External.NoOne(); //IsContext = False IsNew = False
			if(prop185 != null)
			{
				OperandVar186 = prop185;
			}
			UnityEngine.GameObject whore =  (OperandVar186); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar188 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop187 = External.NoOne(); //IsContext = False IsNew = False
			if(prop187 != null)
			{
				OperandVar188 = prop187;
			}
			UnityEngine.GameObject noble_wife =  (OperandVar188); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar190 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop189 = External.NoOne(); //IsContext = False IsNew = False
			if(prop189 != null)
			{
				OperandVar190 = prop189;
			}
			UnityEngine.GameObject whore_lover =  (OperandVar190); //IsContext = False IsNew = False
			
			System.Int32 OperandVar193 = default(System.Int32); //IsContext = False IsNew = False
			Story StoredVariable191 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable191 != null)
			{
				System.Int32 prop192 = StoredVariable191.ActorsCount; //IsContext = False IsNew = False
				OperandVar193 = prop192;
			}
			
			System.Int32 OperandVar195 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable191 != null)
			{
				System.Int32 prop194 = StoredVariable191.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar195 = prop194;
			}
			if(( ( (OperandVar193))) > ( ( (OperandVar195))))
			{
				UnityEngine.GameObject OperandVar211 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop210 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar198 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable196 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable196 != null)
					{
						System.Int32 prop197 = StoredVariable196.ScenariosCount; //IsContext = False IsNew = False
						OperandVar198 = prop197;
					};
;
;
;
;
System.Int32 OperandVar201 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable199 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable199 != null)
					{
						System.Int32 prop200 = StoredVariable199.Influence; //IsContext = False IsNew = False
						OperandVar201 = prop200;
					};
;
;
;
;
System.Int32 OperandVar204 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable202 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable202 != null)
					{
						System.Int32 prop203 = StoredVariable202.Age; //IsContext = False IsNew = False
						OperandVar204 = prop203;
					};
;
;
;
ScriptedTypes.man_role OperandVar206 = default(ScriptedTypes.man_role); //IsContext = False IsNew = False;
ScriptedTypes.man_role StoredVariable205 = ((ScriptedTypes.man_role)go.GetComponent(typeof(ScriptedTypes.man_role))); //IsContext = False IsNew = False;
if(StoredVariable205 != null)
					{
						OperandVar206 = StoredVariable205;
					};
;
System.Boolean OperandVar209 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable207 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable207 != null)
					{
						System.Boolean prop208 = StoredVariable207.HasHusbandTo(); //IsContext = False IsNew = False
						if(prop208 != false)
						{
							OperandVar209 = prop208;
						}
					};
return ( (( ( (OperandVar198))) < ( ( (2f))))) && ( (( ( (OperandVar201))) > ( ( (80f))))) && ( (( ( (OperandVar204))) > ( ( (30f))))) && ( ( (OperandVar206))) && ( (!(OperandVar209)));}); //IsContext = False IsNew = False
				if(prop210 != null)
				{
					OperandVar211 = prop210;
				}
				noble =  (OperandVar211);
			}
			
			System.Int32 OperandVar213 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable191 != null)
			{
				System.Int32 prop212 = StoredVariable191.ActorsCount; //IsContext = False IsNew = False
				OperandVar213 = prop212;
			}
			
			System.Int32 OperandVar215 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable191 != null)
			{
				System.Int32 prop214 = StoredVariable191.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar215 = prop214;
			}
			if(( ( (OperandVar213))) > ( ( (OperandVar215))))
			{
				UnityEngine.GameObject OperandVar223 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop222 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar218 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable216 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable216 != null)
					{
						System.Int32 prop217 = StoredVariable216.ScenariosCount; //IsContext = False IsNew = False
						OperandVar218 = prop217;
					};
;
;
;
ScriptedTypes.woman_role OperandVar221 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.folk_role StoredVariable219 = ((ScriptedTypes.folk_role)go.GetComponent(typeof(ScriptedTypes.folk_role))); //IsContext = False IsNew = False;
if(StoredVariable219 != null)
					{
						ScriptedTypes.woman_role StoredVariable220 = ((ScriptedTypes.woman_role)StoredVariable219.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable220 != null)
						{
							OperandVar221 = StoredVariable220;
						}
					};
return ( (( ( (OperandVar218))) < ( ( (2f))))) && ( ( (OperandVar221)));}); //IsContext = False IsNew = False
				if(prop222 != null)
				{
					OperandVar223 = prop222;
				}
				whore =  (OperandVar223);
			}
			
			System.Int32 OperandVar225 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable191 != null)
			{
				System.Int32 prop224 = StoredVariable191.ActorsCount; //IsContext = False IsNew = False
				OperandVar225 = prop224;
			}
			
			System.Int32 OperandVar227 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable191 != null)
			{
				System.Int32 prop226 = StoredVariable191.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar227 = prop226;
			}
			if(( ( (OperandVar225))) > ( ( (OperandVar227))))
			{
				UnityEngine.GameObject OperandVar238 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop237 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar230 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable228 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable228 != null)
					{
						System.Int32 prop229 = StoredVariable228.ScenariosCount; //IsContext = False IsNew = False
						OperandVar230 = prop229;
					};
;
;
;
ScriptedTypes.woman_role OperandVar233 = default(ScriptedTypes.woman_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable231 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable231 != null)
					{
						ScriptedTypes.woman_role StoredVariable232 = ((ScriptedTypes.woman_role)StoredVariable231.GetComponent(typeof(ScriptedTypes.woman_role))); //IsContext = False IsNew = False
						if(StoredVariable232 != null)
						{
							OperandVar233 = StoredVariable232;
						}
					};
;
System.Boolean OperandVar236 = default(System.Boolean); //IsContext = False IsNew = False;
ScriptedTypes.facts StoredVariable234 = ((ScriptedTypes.facts)go.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False;
if(StoredVariable234 != null)
					{
						System.Boolean prop235 = StoredVariable234.HasWifeTo(); //IsContext = False IsNew = False
						if(prop235 != false)
						{
							OperandVar236 = prop235;
						}
					};
return ( (( ( (OperandVar230))) < ( ( (2f))))) && ( ( (OperandVar233))) && ( (!(OperandVar236)));}); //IsContext = False IsNew = False
				if(prop237 != null)
				{
					OperandVar238 = prop237;
				}
				noble_wife =  (OperandVar238);
			}
			
			System.Int32 OperandVar240 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable191 != null)
			{
				System.Int32 prop239 = StoredVariable191.ActorsCount; //IsContext = False IsNew = False
				OperandVar240 = prop239;
			}
			
			System.Int32 OperandVar242 = default(System.Int32); //IsContext = False IsNew = False
			if(StoredVariable191 != null)
			{
				System.Int32 prop241 = StoredVariable191.TargetActorsCount; //IsContext = False IsNew = False
				OperandVar242 = prop241;
			}
			if(( ( (OperandVar240))) > ( ( (OperandVar242))))
			{
				UnityEngine.GameObject OperandVar252 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				
				UnityEngine.GameObject prop251 = External.FindObject( ("npc"),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
;
System.Int32 OperandVar245 = default(System.Int32); //IsContext = False IsNew = False;
Actor StoredVariable243 = ((Actor)go.GetComponent(typeof(Actor))); //IsContext = False IsNew = False;
if(StoredVariable243 != null)
					{
						System.Int32 prop244 = StoredVariable243.ScenariosCount; //IsContext = False IsNew = False
						OperandVar245 = prop244;
					};
;
;
;
ScriptedTypes.noble_role OperandVar247 = default(ScriptedTypes.noble_role); //IsContext = False IsNew = False;
ScriptedTypes.noble_role StoredVariable246 = ((ScriptedTypes.noble_role)go.GetComponent(typeof(ScriptedTypes.noble_role))); //IsContext = False IsNew = False;
if(StoredVariable246 != null)
					{
						OperandVar247 = StoredVariable246;
					};
;
;
System.Int32 OperandVar250 = default(System.Int32); //IsContext = False IsNew = False;
ScriptedTypes.aged StoredVariable248 = ((ScriptedTypes.aged)go.GetComponent(typeof(ScriptedTypes.aged))); //IsContext = False IsNew = False;
if(StoredVariable248 != null)
					{
						System.Int32 prop249 = StoredVariable248.Age; //IsContext = False IsNew = False
						OperandVar250 = prop249;
					};
;
;
return ( (( ( (OperandVar245))) < ( ( (2f))))) && ( ( (OperandVar247))) && ( (( ( (OperandVar250))) < ( ( (30f)))));}); //IsContext = False IsNew = False
				if(prop251 != null)
				{
					OperandVar252 = prop251;
				}
				whore_lover =  (OperandVar252);
			}
			System.Boolean OperandVar255 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar253 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar253 = noble;
			System.Boolean prop254 = External.Has( (OperandVar253)); //IsContext = False IsNew = False
			if(prop254 != false)
			{
				OperandVar255 = prop254;
			}
			if(!(OperandVar255))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx256 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx256 ContextPropertySwitchInterpreter
					if(FuncCtx256 != null)
					{
						UnityEngine.GameObject OperandVar257 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar257 = FuncCtx256;
						noble =  (OperandVar257);
						ScriptedTypes.noble_role ContextVar258 = FuncCtx256.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar258 ContextSwitchInterpreter
							if(ContextVar258 != null)
							{
								//ScriptedTypes.noble_role ContextVar258; //IsContext = True IsNew = False
								
								ContextVar258.Influence = (System.Int32)( (90f));
							}
						}
						Entity EntVar259 = (Entity)FuncCtx256.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						ScriptedTypes.aged ContextVar260 = FuncCtx256.AddComponent<ScriptedTypes.aged>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.aged ContextVar260 ContextSwitchInterpreter
							if(ContextVar260 != null)
							{
								//ScriptedTypes.aged ContextVar260; //IsContext = True IsNew = False
								
								ContextVar260.Age = (System.Int32)( (50f));
							}
						}
						
						FuncCtx256.AddComponent<ScriptedTypes.man_role>();
						if(EntVar259 != null) EntVar259.ComponentAdded();
						
						{
							Entity subContext261 = (Entity)FuncCtx256.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext261 ContextSwitchInterpreter
							if(subContext261 != null)
							{
								//Entity subContext261; //IsContext = True IsNew = False
								
								
								
								subContext261.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
							}
						}
					}
				}
			}
			System.Boolean OperandVar264 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar262 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar262 = whore;
			System.Boolean prop263 = External.Has( (OperandVar262)); //IsContext = False IsNew = False
			if(prop263 != false)
			{
				OperandVar264 = prop263;
			}
			if(!(OperandVar264))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx265 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx265 ContextPropertySwitchInterpreter
					if(FuncCtx265 != null)
					{
						UnityEngine.GameObject OperandVar266 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar266 = FuncCtx265;
						whore =  (OperandVar266);
						FuncCtx265.AddComponent<ScriptedTypes.folk_role>();
						Entity EntVar267 = (Entity)FuncCtx265.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx265.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar267 != null) EntVar267.ComponentAdded();
						
						{
							Entity subContext268 = (Entity)FuncCtx265.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext268 ContextSwitchInterpreter
							if(subContext268 != null)
							{
								//Entity subContext268; //IsContext = True IsNew = False
								
								
								
								subContext268.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
							}
						}
					}
				}
			}
			System.Boolean OperandVar271 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar269 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar269 = noble_wife;
			System.Boolean prop270 = External.Has( (OperandVar269)); //IsContext = False IsNew = False
			if(prop270 != false)
			{
				OperandVar271 = prop270;
			}
			if(!(OperandVar271))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx272 = External.SpawnPrefab(( ("npc")).ToString(),( ("noble_wife")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx272 ContextPropertySwitchInterpreter
					if(FuncCtx272 != null)
					{
						UnityEngine.GameObject OperandVar273 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar273 = FuncCtx272;
						noble_wife =  (OperandVar273);
						FuncCtx272.AddComponent<ScriptedTypes.noble_role>();
						Entity EntVar274 = (Entity)FuncCtx272.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx272.AddComponent<ScriptedTypes.woman_role>();
						if(EntVar274 != null) EntVar274.ComponentAdded();
						
						{
							Entity subContext275 = (Entity)FuncCtx272.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext275 ContextSwitchInterpreter
							if(subContext275 != null)
							{
								//Entity subContext275; //IsContext = True IsNew = False
								
								
								
								subContext275.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
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
						ScriptedTypes.facts subContext276 = (ScriptedTypes.facts)noble_wife.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext276 ContextSwitchInterpreter
						if(subContext276 != null)
						{
							//ScriptedTypes.facts subContext276; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.wife_to FuncCtx277 = subContext276.AddWifeTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.wife_to FuncCtx277 ContextPropertySwitchInterpreter
								if(FuncCtx277 != null)
								{
									UnityEngine.GameObject OperandVar278 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar278 = noble;
									FuncCtx277.Whom = (UnityEngine.GameObject)( (OperandVar278));
								}
							}
							
							{
								ScriptedTypes.rival FuncCtx279 = subContext276.AddRival();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.rival FuncCtx279 ContextPropertySwitchInterpreter
								if(FuncCtx279 != null)
								{
									UnityEngine.GameObject OperandVar280 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar280 = whore;
									FuncCtx279.WhoIs = (UnityEngine.GameObject)( (OperandVar280));
									UnityEngine.GameObject OperandVar282 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									UnityEngine.GameObject prop281 = FuncCtx279.WhoIs; //IsContext = False IsNew = False
									if(prop281 != null)
									{
										OperandVar282 = prop281;
									}
									External.Log((System.Object)( (OperandVar282)));
								}
							}
							System.Collections.Generic.List<ScriptedTypes.rival> list283 = subContext276.GetRival; //IsContext = False IsNew = False
							for (int i284 = 0; list283 != null && i284 < list283.Count; i284++)
							{
								ScriptedTypes.rival iter285 = list283[i284]; //IsContext = True IsNew = True
								
								{
									ScriptedTypes.rival subContext286 = iter285; //IsContext = True IsNew = False
									//ContextStatement ScriptedTypes.rival subContext286 ContextPropertySwitchInterpreter
									if(subContext286 != null)
									{
										UnityEngine.GameObject OperandVar288 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
										UnityEngine.GameObject prop287 = subContext286.WhoIs; //IsContext = False IsNew = False
										if(prop287 != null)
										{
											OperandVar288 = prop287;
										}
										External.Log((System.Object)( (OperandVar288)));
									}
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
						ScriptedTypes.facts subContext289 = (ScriptedTypes.facts)noble.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext289 ContextSwitchInterpreter
						if(subContext289 != null)
						{
							//ScriptedTypes.facts subContext289; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.husband_to FuncCtx290 = subContext289.AddHusbandTo();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.husband_to FuncCtx290 ContextPropertySwitchInterpreter
								if(FuncCtx290 != null)
								{
									UnityEngine.GameObject OperandVar291 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar291 = noble_wife;
									FuncCtx290.Whom = (UnityEngine.GameObject)( (OperandVar291));
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
						ScriptedTypes.facts subContext292 = (ScriptedTypes.facts)noble.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext292 ContextSwitchInterpreter
						if(subContext292 != null)
						{
							//ScriptedTypes.facts subContext292; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.lover FuncCtx293 = subContext292.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx293 ContextPropertySwitchInterpreter
								if(FuncCtx293 != null)
								{
									UnityEngine.GameObject OperandVar294 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar294 = whore;
									FuncCtx293.OfWhom = (UnityEngine.GameObject)( (OperandVar294));
									
									System.Single known_treshold =  (80f); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			System.Boolean OperandVar297 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar295 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar295 = whore_lover;
			System.Boolean prop296 = External.Has( (OperandVar295)); //IsContext = False IsNew = False
			if(prop296 != false)
			{
				OperandVar297 = prop296;
			}
			if(!(OperandVar297))
			{
				
				
				
				{
					UnityEngine.GameObject FuncCtx298 = External.SpawnPrefab(( ("npc")).ToString(),( ("whore_lover")).ToString());; //IsContext = True IsNew = False
					//ContextStatement UnityEngine.GameObject FuncCtx298 ContextPropertySwitchInterpreter
					if(FuncCtx298 != null)
					{
						UnityEngine.GameObject OperandVar299 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
						OperandVar299 = FuncCtx298;
						whore_lover =  (OperandVar299);
						ScriptedTypes.noble_role ContextVar300 = FuncCtx298.AddComponent<ScriptedTypes.noble_role>();; //IsContext = False IsNew = True
						
						{
							//ContextStatement ScriptedTypes.noble_role ContextVar300 ContextSwitchInterpreter
							if(ContextVar300 != null)
							{
								//ScriptedTypes.noble_role ContextVar300; //IsContext = True IsNew = False
								
								ContextVar300.Influence = (System.Int32)( (40f));
							}
						}
						Entity EntVar301 = (Entity)FuncCtx298.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
						
						FuncCtx298.AddComponent<ScriptedTypes.man_role>();
						if(EntVar301 != null) EntVar301.ComponentAdded();
						
						{
							ScriptedTypes.aged subContext302 = (ScriptedTypes.aged)FuncCtx298.GetComponent(typeof(ScriptedTypes.aged)); //IsContext = True IsNew = False
							//ContextStatement ScriptedTypes.aged subContext302 ContextSwitchInterpreter
							if(subContext302 != null)
							{
								//ScriptedTypes.aged subContext302; //IsContext = True IsNew = False
								
								subContext302.Age = (System.Int32)( (25f));
							}
						}
						
						{
							Entity subContext303 = (Entity)FuncCtx298.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
							//ContextStatement Entity subContext303 ContextSwitchInterpreter
							if(subContext303 != null)
							{
								//Entity subContext303; //IsContext = True IsNew = False
								
								
								
								subContext303.RandomPosition((System.Single)( (0f)),(System.Single)( (0f)),(System.Single)( (4f)));
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
						ScriptedTypes.facts subContext304 = (ScriptedTypes.facts)whore_lover.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext304 ContextSwitchInterpreter
						if(subContext304 != null)
						{
							//ScriptedTypes.facts subContext304; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.lover FuncCtx305 = subContext304.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx305 ContextPropertySwitchInterpreter
								if(FuncCtx305 != null)
								{
									UnityEngine.GameObject OperandVar306 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar306 = whore;
									FuncCtx305.OfWhom = (UnityEngine.GameObject)( (OperandVar306));
									
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
						ScriptedTypes.facts subContext307 = (ScriptedTypes.facts)whore.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext307 ContextSwitchInterpreter
						if(subContext307 != null)
						{
							//ScriptedTypes.facts subContext307; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.lover FuncCtx308 = subContext307.AddLover();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.lover FuncCtx308 ContextPropertySwitchInterpreter
								if(FuncCtx308 != null)
								{
									UnityEngine.GameObject OperandVar309 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar309 = noble;
									FuncCtx308.OfWhom = (UnityEngine.GameObject)( (OperandVar309));
									
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
									FuncCtx310.OfWhom = (UnityEngine.GameObject)( (OperandVar311));
									
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Single val = 0; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
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
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
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
			System.Boolean OperandVar330 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop328 = trigger.Target; //IsContext = False IsNew = False
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
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			//TestEvent trigger; //IsContext = True IsNew = False
			
			{
				VisualsFeed subContext331 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext331 ContextPropertySwitchInterpreter
				if(subContext331 != null)
				{
					TestEvent OperandVar332 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar332 = trigger;
					UnityEngine.Vector3 OperandVar336 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(trigger != null)
					{
						UnityEngine.GameObject prop333 = trigger.Target; //IsContext = False IsNew = False
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
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root = false; //IsContext = True IsNew = False
			//UnityEngine.GameObject trigger_root = false; //IsContext = False IsNew = False
			var trigger_root = this.trigger.Root;
			var root = this.root;
			//TestEvent trigger; //IsContext = False IsNew = False
			
			{
				ScriptedTypes.facts subContext339 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext339 ContextSwitchInterpreter
				if(subContext339 != null)
				{
					//ScriptedTypes.facts subContext339; //IsContext = True IsNew = False
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
			System.Boolean OperandVar346 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop344 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop344 != null)
			{
				PlayerMarker StoredVariable345 = ((PlayerMarker)prop344.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable345 != null)
				{
					applicable = true;
					OperandVar346 = applicable;
				}
			}
			return (System.Boolean) (OperandVar346);
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
			
			
			
			UnityEngine.GameObject OperandVar348 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop347 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop347 != null)
			{
				OperandVar348 = prop347;
			}
			External.Log((System.Object)(( ( ("init dialog for "))) + ( ( (OperandVar348)))));
			UnityEngine.GameObject OperandVar350 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop349 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop349 != null)
			{
				OperandVar350 = prop349;
			}
			External.InitDialogUi((UnityEngine.GameObject)( (OperandVar350)));
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
			System.Boolean OperandVar353 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop351 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop351 != null)
			{
				PlayerMarker StoredVariable352 = ((PlayerMarker)prop351.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable352 != null)
				{
					applicable = true;
					OperandVar353 = applicable;
				}
			}
			return (System.Boolean) (OperandVar353);
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
			System.Boolean OperandVar356 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop354 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop354 != null)
			{
				PlayerMarker StoredVariable355 = ((PlayerMarker)prop354.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable355 != null)
				{
					applicable = true;
					OperandVar356 = applicable;
				}
			}
			return (System.Boolean) (OperandVar356);
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
			System.Boolean OperandVar359 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable357 = ((Actor)trigger_root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable357 != null)
			{
				Entity StoredVariable358 = ((Entity)StoredVariable357.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable358 != null)
				{
					applicable = true;
					OperandVar359 = applicable;
				}
			}
			return (System.Boolean) (OperandVar359);
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
			Entity EntVar360 = (Entity)trigger_root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			trigger_root.AddComponent<ScriptedTypes.backstory>();
			
			trigger_root.AddComponent<ScriptedTypes.personality>();
			if(EntVar360 != null) EntVar360.ComponentAdded();
		}
        }
    }
}
