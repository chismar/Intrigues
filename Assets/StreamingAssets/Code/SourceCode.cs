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
			UnityEngine.GameObject prop36 = External.Any((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar31)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
System.Boolean OperandVar35 = default(System.Boolean); //IsContext = False IsNew = False;
Interactable StoredVariable32 = ((Interactable)go.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False;
if(StoredVariable32 != null)
				{
					UnityEngine.GameObject OperandVar33 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar33 = root;
					System.Boolean prop34 = StoredVariable32.Can(typeof(ScriptedTypes.interaction_lit_up_manual ),(UnityEngine.GameObject)( (OperandVar33))); //IsContext = False IsNew = False
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
			UnityEngine.GameObject prop56 = External.Any((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar49)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
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
							System.Boolean prop54 = StoredVariable52.Can(typeof(ScriptedTypes.interaction_lit_up_remote ),(UnityEngine.GameObject)( (OperandVar53))); //IsContext = False IsNew = False
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
			System.Boolean prop69 = External.Has((UnityEngine.GameObject)( (OperandVar68))); //IsContext = False IsNew = False
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
			UnityEngine.GameObject prop119 = External.SelectByWeight((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar112)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
System.Single OperandVar118 = default(System.Single); //IsContext = False IsNew = False;
Interactable StoredVariable113 = ((Interactable)go.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False;
if(StoredVariable113 != null)
				{
					UnityEngine.GameObject OperandVar114 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar114 = root;
					System.Boolean prop115 = StoredVariable113.Can(typeof(ScriptedTypes.interaction_talk_to ),(UnityEngine.GameObject)( (OperandVar114))); //IsContext = False IsNew = False
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
			System.Boolean prop122 = External.Has((UnityEngine.GameObject)( (OperandVar121))); //IsContext = False IsNew = False
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
			System.Boolean prop127 = External.Has((UnityEngine.GameObject)( (OperandVar126))); //IsContext = False IsNew = False
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
								System.Single prop140 = StoredVariable132.RelationsWith((UnityEngine.GameObject)( (OperandVar139))); //IsContext = False IsNew = False
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
														System.Boolean prop162 = StoredVariable159.HasMarker((System.String)( (OperandVar161))); //IsContext = False IsNew = False
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
    public class monsters_lair_threat : EventAction {
        
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
			
			System.String OperandVar178 = default(System.String); //IsContext = False IsNew = False
			OperandVar178 = "player";
			
			{
				UnityEngine.GameObject FuncCtx179 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar178)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx179 ContextPropertySwitchInterpreter
				if(FuncCtx179 != null)
				{
					
					{
						Entity subContext180 = (Entity)FuncCtx179.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext180 ContextSwitchInterpreter
						if(subContext180 != null)
						{
							//Entity subContext180; //IsContext = True IsNew = False
							
							subContext180.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx179.AddComponent<PlayerMarker>();
					Entity EntVar181 = (Entity)FuncCtx179.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					
					{
						Entity subContext182 = (Entity)FuncCtx179.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext182 ContextSwitchInterpreter
						if(subContext182 != null)
						{
							//Entity subContext182; //IsContext = True IsNew = False
							
							subContext182.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx179.AddComponent<ScriptedTypes.chief>();
					if(EntVar181 != null) EntVar181.ComponentAdded();
				}
			}
			
			System.String OperandVar183 = default(System.String); //IsContext = False IsNew = False
			OperandVar183 = "shaman_npc";
			
			{
				UnityEngine.GameObject FuncCtx184 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar183)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx184 ContextPropertySwitchInterpreter
				if(FuncCtx184 != null)
				{
					
					{
						Entity subContext185 = (Entity)FuncCtx184.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext185 ContextSwitchInterpreter
						if(subContext185 != null)
						{
							//Entity subContext185; //IsContext = True IsNew = False
							
							subContext185.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx184.AddComponent<ScriptedTypes.shaman>();
					Entity EntVar186 = (Entity)FuncCtx184.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar186 != null) EntVar186.ComponentAdded();
				}
			}
			
			System.String OperandVar187 = default(System.String); //IsContext = False IsNew = False
			OperandVar187 = "healer_npc";
			
			{
				UnityEngine.GameObject FuncCtx188 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar187)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx188 ContextPropertySwitchInterpreter
				if(FuncCtx188 != null)
				{
					
					{
						Entity subContext189 = (Entity)FuncCtx188.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext189 ContextSwitchInterpreter
						if(subContext189 != null)
						{
							//Entity subContext189; //IsContext = True IsNew = False
							
							subContext189.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx188.AddComponent<ScriptedTypes.healer>();
					Entity EntVar190 = (Entity)FuncCtx188.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar190 != null) EntVar190.ComponentAdded();
				}
			}
			
			System.String OperandVar191 = default(System.String); //IsContext = False IsNew = False
			OperandVar191 = "lair";
			
			{
				UnityEngine.GameObject FuncCtx192 = External.SpawnPrefab(( ("loc")).ToString(),( (OperandVar191)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx192 ContextPropertySwitchInterpreter
				if(FuncCtx192 != null)
				{
					
					{
						Entity subContext193 = (Entity)FuncCtx192.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext193 ContextSwitchInterpreter
						if(subContext193 != null)
						{
							//Entity subContext193; //IsContext = True IsNew = False
							
							subContext193.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx192.AddComponent<ScriptedTypes.monsters_lair>();
					Entity EntVar194 = (Entity)FuncCtx192.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar194 != null) EntVar194.ComponentAdded();
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
    public class old_altar_threat : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar196 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable195 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable195 != null)
			{
				applicable = true;
				OperandVar196 = applicable;
			}
			return (System.Boolean) (OperandVar196);
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
			
			System.String OperandVar197 = default(System.String); //IsContext = False IsNew = False
			OperandVar197 = "player_npc";
			
			{
				UnityEngine.GameObject FuncCtx198 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar197)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx198 ContextPropertySwitchInterpreter
				if(FuncCtx198 != null)
				{
					
					{
						Entity subContext199 = (Entity)FuncCtx198.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext199 ContextSwitchInterpreter
						if(subContext199 != null)
						{
							//Entity subContext199; //IsContext = True IsNew = False
							
							subContext199.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx198.AddComponent<PlayerMarker>();
					Entity EntVar200 = (Entity)FuncCtx198.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					
					{
						Entity subContext201 = (Entity)FuncCtx198.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext201 ContextSwitchInterpreter
						if(subContext201 != null)
						{
							//Entity subContext201; //IsContext = True IsNew = False
							
							subContext201.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx198.AddComponent<ScriptedTypes.shaman>();
					if(EntVar200 != null) EntVar200.ComponentAdded();
				}
			}
			
			System.String OperandVar202 = default(System.String); //IsContext = False IsNew = False
			OperandVar202 = "chief_npc";
			
			{
				UnityEngine.GameObject FuncCtx203 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar202)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx203 ContextPropertySwitchInterpreter
				if(FuncCtx203 != null)
				{
					
					{
						Entity subContext204 = (Entity)FuncCtx203.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext204 ContextSwitchInterpreter
						if(subContext204 != null)
						{
							//Entity subContext204; //IsContext = True IsNew = False
							
							subContext204.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx203.AddComponent<ScriptedTypes.chief>();
					Entity EntVar205 = (Entity)FuncCtx203.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar205 != null) EntVar205.ComponentAdded();
				}
			}
			
			System.String OperandVar206 = default(System.String); //IsContext = False IsNew = False
			OperandVar206 = "healer_npc";
			
			{
				UnityEngine.GameObject FuncCtx207 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar206)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx207 ContextPropertySwitchInterpreter
				if(FuncCtx207 != null)
				{
					
					{
						Entity subContext208 = (Entity)FuncCtx207.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext208 ContextSwitchInterpreter
						if(subContext208 != null)
						{
							//Entity subContext208; //IsContext = True IsNew = False
							
							subContext208.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx207.AddComponent<ScriptedTypes.healer>();
					Entity EntVar209 = (Entity)FuncCtx207.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar209 != null) EntVar209.ComponentAdded();
				}
			}
			
			System.String OperandVar210 = default(System.String); //IsContext = False IsNew = False
			OperandVar210 = "altar";
			
			{
				UnityEngine.GameObject FuncCtx211 = External.SpawnPrefab(( ("loc")).ToString(),( (OperandVar210)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx211 ContextPropertySwitchInterpreter
				if(FuncCtx211 != null)
				{
					
					{
						Entity subContext212 = (Entity)FuncCtx211.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext212 ContextSwitchInterpreter
						if(subContext212 != null)
						{
							//Entity subContext212; //IsContext = True IsNew = False
							
							subContext212.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx211.AddComponent<ScriptedTypes.ancient_altar>();
					Entity EntVar213 = (Entity)FuncCtx211.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar213 != null) EntVar213.ComponentAdded();
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
    public class burial_disease_threat : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar215 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable214 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable214 != null)
			{
				applicable = true;
				OperandVar215 = applicable;
			}
			return (System.Boolean) (OperandVar215);
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
			
			System.String OperandVar216 = default(System.String); //IsContext = False IsNew = False
			OperandVar216 = "player_npc";
			
			{
				UnityEngine.GameObject FuncCtx217 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar216)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx217 ContextPropertySwitchInterpreter
				if(FuncCtx217 != null)
				{
					
					{
						Entity subContext218 = (Entity)FuncCtx217.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext218 ContextSwitchInterpreter
						if(subContext218 != null)
						{
							//Entity subContext218; //IsContext = True IsNew = False
							
							subContext218.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx217.AddComponent<PlayerMarker>();
					Entity EntVar219 = (Entity)FuncCtx217.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					
					{
						Entity subContext220 = (Entity)FuncCtx217.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext220 ContextSwitchInterpreter
						if(subContext220 != null)
						{
							//Entity subContext220; //IsContext = True IsNew = False
							
							subContext220.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx217.AddComponent<ScriptedTypes.healer>();
					if(EntVar219 != null) EntVar219.ComponentAdded();
				}
			}
			
			System.String OperandVar221 = default(System.String); //IsContext = False IsNew = False
			OperandVar221 = "chief_npc";
			
			{
				UnityEngine.GameObject FuncCtx222 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar221)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx222 ContextPropertySwitchInterpreter
				if(FuncCtx222 != null)
				{
					
					{
						Entity subContext223 = (Entity)FuncCtx222.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext223 ContextSwitchInterpreter
						if(subContext223 != null)
						{
							//Entity subContext223; //IsContext = True IsNew = False
							
							subContext223.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx222.AddComponent<ScriptedTypes.chief>();
					Entity EntVar224 = (Entity)FuncCtx222.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar224 != null) EntVar224.ComponentAdded();
				}
			}
			
			System.String OperandVar225 = default(System.String); //IsContext = False IsNew = False
			OperandVar225 = "shaman_npc";
			
			{
				UnityEngine.GameObject FuncCtx226 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar225)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx226 ContextPropertySwitchInterpreter
				if(FuncCtx226 != null)
				{
					
					{
						Entity subContext227 = (Entity)FuncCtx226.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext227 ContextSwitchInterpreter
						if(subContext227 != null)
						{
							//Entity subContext227; //IsContext = True IsNew = False
							
							subContext227.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx226.AddComponent<ScriptedTypes.shaman>();
					Entity EntVar228 = (Entity)FuncCtx226.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar228 != null) EntVar228.ComponentAdded();
				}
			}
			
			System.String OperandVar229 = default(System.String); //IsContext = False IsNew = False
			OperandVar229 = "kurgan";
			
			{
				UnityEngine.GameObject FuncCtx230 = External.SpawnPrefab(( ("loc")).ToString(),( (OperandVar229)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx230 ContextPropertySwitchInterpreter
				if(FuncCtx230 != null)
				{
					
					{
						Entity subContext231 = (Entity)FuncCtx230.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext231 ContextSwitchInterpreter
						if(subContext231 != null)
						{
							//Entity subContext231; //IsContext = True IsNew = False
							
							subContext231.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx230.AddComponent<ScriptedTypes.evil_kurgan>();
					Entity EntVar232 = (Entity)FuncCtx230.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar232 != null) EntVar232.ComponentAdded();
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
    public class warriors_worth_quest : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar237 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable233 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable233 != null)
			{
				System.Boolean ifResult234; //IsContext = False IsNew = False
				
				System.Int32 OperandVar236 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop235 = StoredVariable233.Quests; //IsContext = False IsNew = False
				OperandVar236 = prop235;
				
				
				if(ifResult234 = ( ( (OperandVar236))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar237 = applicable;
				}
			}
			return (System.Boolean) (OperandVar237);
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
			System.Int32 OperandVar243 = default(System.Int32); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar239 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop238 = External.AllActors; //IsContext = False IsNew = False
			if(prop238 != null)
			{
				OperandVar239 = prop238;
			}
			System.Int32 prop242 = External.Amount((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar239)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.warrior OperandVar241 = default(ScriptedTypes.warrior); //IsContext = False IsNew = False;
ScriptedTypes.warrior StoredVariable240 = ((ScriptedTypes.warrior)go.GetComponent(typeof(ScriptedTypes.warrior))); //IsContext = False IsNew = False;
if(StoredVariable240 != null)
				{
					OperandVar241 = StoredVariable240;
				};
return  (OperandVar241);}); //IsContext = False IsNew = False
			OperandVar243 = prop242;
			System.Int32 a =  (OperandVar243); //IsContext = False IsNew = False
			
			System.Int32 OperandVar244 = default(System.Int32); //IsContext = False IsNew = False
			OperandVar244 = a;
			
			
			if(( ( (OperandVar244))) < ( ( (3f))))
			{
				System.Int32 OperandVar248 = default(System.Int32); //IsContext = False IsNew = False
				
				
				
				System.Int32 OperandVar245 = default(System.Int32); //IsContext = False IsNew = False
				OperandVar245 = a;
				
				
				
				System.Int32 OperandVar246 = default(System.Int32); //IsContext = False IsNew = False
				OperandVar246 = a;
				System.Int32 prop247 = External.RandomRange((System.Int32)(( ( (3f))) - ( ( (OperandVar245)))),(System.Int32)(( ( (5f))) - ( ( (OperandVar246))))); //IsContext = False IsNew = False
				OperandVar248 = prop247;
				for (int i249 = 0; i249 <  (OperandVar248); i249++)
				{
					
					System.String OperandVar250 = default(System.String); //IsContext = False IsNew = False
					OperandVar250 = "human_npc";
					
					{
						UnityEngine.GameObject FuncCtx251 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar250)).ToString());; //IsContext = True IsNew = False
						//ContextStatement UnityEngine.GameObject FuncCtx251 ContextPropertySwitchInterpreter
						if(FuncCtx251 != null)
						{
							
							{
								Entity subContext252 = (Entity)FuncCtx251.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
								//ContextStatement Entity subContext252 ContextSwitchInterpreter
								if(subContext252 != null)
								{
									//Entity subContext252; //IsContext = True IsNew = False
									
									subContext252.RandomOffset((System.Single)( (10f)));
								}
							}
							FuncCtx251.AddComponent<ScriptedTypes.warrior>();
							Entity EntVar253 = (Entity)FuncCtx251.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
							if(EntVar253 != null) EntVar253.ComponentAdded();
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
    public class blacksmith_materials_quest : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar258 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable254 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable254 != null)
			{
				System.Boolean ifResult255; //IsContext = False IsNew = False
				
				System.Int32 OperandVar257 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop256 = StoredVariable254.Quests; //IsContext = False IsNew = False
				OperandVar257 = prop256;
				
				
				if(ifResult255 = ( ( (OperandVar257))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar258 = applicable;
				}
			}
			return (System.Boolean) (OperandVar258);
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
			
			System.String OperandVar259 = default(System.String); //IsContext = False IsNew = False
			OperandVar259 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx260 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar259)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx260 ContextPropertySwitchInterpreter
				if(FuncCtx260 != null)
				{
					
					{
						Entity subContext261 = (Entity)FuncCtx260.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext261 ContextSwitchInterpreter
						if(subContext261 != null)
						{
							//Entity subContext261; //IsContext = True IsNew = False
							
							subContext261.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx260.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar262 = (Entity)FuncCtx260.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar262 != null) EntVar262.ComponentAdded();
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
    public class artisan_materials_quest : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar267 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable263 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable263 != null)
			{
				System.Boolean ifResult264; //IsContext = False IsNew = False
				
				System.Int32 OperandVar266 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop265 = StoredVariable263.Quests; //IsContext = False IsNew = False
				OperandVar266 = prop265;
				
				
				if(ifResult264 = ( ( (OperandVar266))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar267 = applicable;
				}
			}
			return (System.Boolean) (OperandVar267);
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
			
			System.String OperandVar268 = default(System.String); //IsContext = False IsNew = False
			OperandVar268 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx269 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar268)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx269 ContextPropertySwitchInterpreter
				if(FuncCtx269 != null)
				{
					
					{
						Entity subContext270 = (Entity)FuncCtx269.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext270 ContextSwitchInterpreter
						if(subContext270 != null)
						{
							//Entity subContext270; //IsContext = True IsNew = False
							
							subContext270.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx269.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar271 = (Entity)FuncCtx269.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar271 != null) EntVar271.ComponentAdded();
				}
			}
			
			{
				Story subContext272 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext272 ContextSwitchInterpreter
				if(subContext272 != null)
				{
					//Story subContext272; //IsContext = True IsNew = False
					
					System.Int32 OperandVar274 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop273 = subContext272.Quests; //IsContext = False IsNew = False
					OperandVar274 = prop273;
					
					
					subContext272.Quests = (System.Int32)(( ( (OperandVar274))) + ( ( (1f))));
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
    public class old_friend_quest : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar279 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable275 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable275 != null)
			{
				System.Boolean ifResult276; //IsContext = False IsNew = False
				
				System.Int32 OperandVar278 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop277 = StoredVariable275.Quests; //IsContext = False IsNew = False
				OperandVar278 = prop277;
				
				
				if(ifResult276 = ( ( (OperandVar278))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar279 = applicable;
				}
			}
			return (System.Boolean) (OperandVar279);
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
			
			System.String OperandVar280 = default(System.String); //IsContext = False IsNew = False
			OperandVar280 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx281 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar280)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx281 ContextPropertySwitchInterpreter
				if(FuncCtx281 != null)
				{
					
					{
						Entity subContext282 = (Entity)FuncCtx281.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext282 ContextSwitchInterpreter
						if(subContext282 != null)
						{
							//Entity subContext282; //IsContext = True IsNew = False
							
							subContext282.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx281.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar283 = (Entity)FuncCtx281.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar283 != null) EntVar283.ComponentAdded();
				}
			}
			
			{
				Story subContext284 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext284 ContextSwitchInterpreter
				if(subContext284 != null)
				{
					//Story subContext284; //IsContext = True IsNew = False
					
					System.Int32 OperandVar286 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop285 = subContext284.Quests; //IsContext = False IsNew = False
					OperandVar286 = prop285;
					
					
					subContext284.Quests = (System.Int32)(( ( (OperandVar286))) + ( ( (1f))));
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
    public class forest_monster : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar291 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable287 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable287 != null)
			{
				System.Boolean ifResult288; //IsContext = False IsNew = False
				
				System.Int32 OperandVar290 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop289 = StoredVariable287.Quests; //IsContext = False IsNew = False
				OperandVar290 = prop289;
				
				
				if(ifResult288 = ( ( (OperandVar290))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar291 = applicable;
				}
			}
			return (System.Boolean) (OperandVar291);
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
			
			System.String OperandVar292 = default(System.String); //IsContext = False IsNew = False
			OperandVar292 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx293 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar292)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx293 ContextPropertySwitchInterpreter
				if(FuncCtx293 != null)
				{
					
					{
						Entity subContext294 = (Entity)FuncCtx293.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext294 ContextSwitchInterpreter
						if(subContext294 != null)
						{
							//Entity subContext294; //IsContext = True IsNew = False
							
							subContext294.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx293.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar295 = (Entity)FuncCtx293.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar295 != null) EntVar295.ComponentAdded();
				}
			}
			
			{
				Story subContext296 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext296 ContextSwitchInterpreter
				if(subContext296 != null)
				{
					//Story subContext296; //IsContext = True IsNew = False
					
					System.Int32 OperandVar298 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop297 = subContext296.Quests; //IsContext = False IsNew = False
					OperandVar298 = prop297;
					
					
					subContext296.Quests = (System.Int32)(( ( (OperandVar298))) + ( ( (1f))));
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
    public class exotic_artifact : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar303 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable299 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable299 != null)
			{
				System.Boolean ifResult300; //IsContext = False IsNew = False
				
				System.Int32 OperandVar302 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop301 = StoredVariable299.Quests; //IsContext = False IsNew = False
				OperandVar302 = prop301;
				
				
				if(ifResult300 = ( ( (OperandVar302))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar303 = applicable;
				}
			}
			return (System.Boolean) (OperandVar303);
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
			
			System.String OperandVar304 = default(System.String); //IsContext = False IsNew = False
			OperandVar304 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx305 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar304)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx305 ContextPropertySwitchInterpreter
				if(FuncCtx305 != null)
				{
					
					{
						Entity subContext306 = (Entity)FuncCtx305.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext306 ContextSwitchInterpreter
						if(subContext306 != null)
						{
							//Entity subContext306; //IsContext = True IsNew = False
							
							subContext306.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx305.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar307 = (Entity)FuncCtx305.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar307 != null) EntVar307.ComponentAdded();
				}
			}
			
			{
				Story subContext308 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext308 ContextSwitchInterpreter
				if(subContext308 != null)
				{
					//Story subContext308; //IsContext = True IsNew = False
					
					System.Int32 OperandVar310 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop309 = subContext308.Quests; //IsContext = False IsNew = False
					OperandVar310 = prop309;
					
					
					subContext308.Quests = (System.Int32)(( ( (OperandVar310))) + ( ( (1f))));
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
    public class farm_is_infested : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar315 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable311 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable311 != null)
			{
				System.Boolean ifResult312; //IsContext = False IsNew = False
				
				System.Int32 OperandVar314 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop313 = StoredVariable311.Quests; //IsContext = False IsNew = False
				OperandVar314 = prop313;
				
				
				if(ifResult312 = ( ( (OperandVar314))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar315 = applicable;
				}
			}
			return (System.Boolean) (OperandVar315);
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
			
			System.String OperandVar316 = default(System.String); //IsContext = False IsNew = False
			OperandVar316 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx317 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar316)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx317 ContextPropertySwitchInterpreter
				if(FuncCtx317 != null)
				{
					
					{
						Entity subContext318 = (Entity)FuncCtx317.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext318 ContextSwitchInterpreter
						if(subContext318 != null)
						{
							//Entity subContext318; //IsContext = True IsNew = False
							
							subContext318.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx317.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar319 = (Entity)FuncCtx317.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar319 != null) EntVar319.ComponentAdded();
				}
			}
			
			{
				Story subContext320 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext320 ContextSwitchInterpreter
				if(subContext320 != null)
				{
					//Story subContext320; //IsContext = True IsNew = False
					
					System.Int32 OperandVar322 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop321 = subContext320.Quests; //IsContext = False IsNew = False
					OperandVar322 = prop321;
					
					
					subContext320.Quests = (System.Int32)(( ( (OperandVar322))) + ( ( (1f))));
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
    public class old_world_metal : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar327 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable323 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable323 != null)
			{
				System.Boolean ifResult324; //IsContext = False IsNew = False
				
				System.Int32 OperandVar326 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop325 = StoredVariable323.Quests; //IsContext = False IsNew = False
				OperandVar326 = prop325;
				
				
				if(ifResult324 = ( ( (OperandVar326))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar327 = applicable;
				}
			}
			return (System.Boolean) (OperandVar327);
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
			
			System.String OperandVar328 = default(System.String); //IsContext = False IsNew = False
			OperandVar328 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx329 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar328)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx329 ContextPropertySwitchInterpreter
				if(FuncCtx329 != null)
				{
					
					{
						Entity subContext330 = (Entity)FuncCtx329.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext330 ContextSwitchInterpreter
						if(subContext330 != null)
						{
							//Entity subContext330; //IsContext = True IsNew = False
							
							subContext330.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx329.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar331 = (Entity)FuncCtx329.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar331 != null) EntVar331.ComponentAdded();
				}
			}
			
			{
				Story subContext332 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext332 ContextSwitchInterpreter
				if(subContext332 != null)
				{
					//Story subContext332; //IsContext = True IsNew = False
					
					System.Int32 OperandVar334 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop333 = subContext332.Quests; //IsContext = False IsNew = False
					OperandVar334 = prop333;
					
					
					subContext332.Quests = (System.Int32)(( ( (OperandVar334))) + ( ( (1f))));
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
    public class lost_apprentice : EventAction {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar339 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable335 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable335 != null)
			{
				System.Boolean ifResult336; //IsContext = False IsNew = False
				
				System.Int32 OperandVar338 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop337 = StoredVariable335.Quests; //IsContext = False IsNew = False
				OperandVar338 = prop337;
				
				
				if(ifResult336 = ( ( (OperandVar338))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar339 = applicable;
				}
			}
			return (System.Boolean) (OperandVar339);
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
			
			System.String OperandVar340 = default(System.String); //IsContext = False IsNew = False
			OperandVar340 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx341 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar340)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx341 ContextPropertySwitchInterpreter
				if(FuncCtx341 != null)
				{
					
					{
						Entity subContext342 = (Entity)FuncCtx341.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext342 ContextSwitchInterpreter
						if(subContext342 != null)
						{
							//Entity subContext342; //IsContext = True IsNew = False
							
							subContext342.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx341.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar343 = (Entity)FuncCtx341.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar343 != null) EntVar343.ComponentAdded();
				}
			}
			
			{
				Story subContext344 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext344 ContextSwitchInterpreter
				if(subContext344 != null)
				{
					//Story subContext344; //IsContext = True IsNew = False
					
					System.Int32 OperandVar346 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop345 = subContext344.Quests; //IsContext = False IsNew = False
					OperandVar346 = prop345;
					
					
					subContext344.Quests = (System.Int32)(( ( (OperandVar346))) + ( ( (1f))));
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
			LocalizedString OperandVar364 = default(LocalizedString); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar361 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar361 = root;
			UnityEngine.GameObject OperandVar362 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar362 = other;
			System.Single OperandVar363 = default(System.Single); //IsContext = False IsNew = False
			OperandVar363 = distance;
			var dict359= new System.Collections.Generic.Dictionary<string, object>();
var localizedString360= new LocalizedString("should_be_near",dict359);dict359.Add("who", (OperandVar361));
dict359.Add("other", (OperandVar362));
dict359.Add("distance", (OperandVar363));

			OperandVar364 = localizedString360;
			return  (OperandVar364);
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
				Entity OperandVar348 = default(Entity); //IsContext = False IsNew = False
				Entity StoredVariable347 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable347 != null)
				{
					OperandVar348 = StoredVariable347;
				}
				s =  (OperandVar348);
			}
			
			{
				Entity OperandVar350 = default(Entity); //IsContext = False IsNew = False
				Entity StoredVariable349 = ((Entity)other.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable349 != null)
				{
					OperandVar350 = StoredVariable349;
				}
				o =  (OperandVar350);
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
				System.Single OperandVar351 = default(System.Single); //IsContext = False IsNew = False
				OperandVar351 = distance;
				properTask.OkDistance =  (OperandVar351);
			}
			
			{
				UnityEngine.GameObject OperandVar352 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar352 = other;
				properTask.Who =  (OperandVar352);
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
			
			System.Single OperandVar358 = default(System.Single); //IsContext = False IsNew = False
			
			UnityEngine.Vector3 OperandVar354 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			UnityEngine.Vector3 prop353 = s.Position; //IsContext = False IsNew = False
			OperandVar354 = prop353;
			
			UnityEngine.Vector3 OperandVar356 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			UnityEngine.Vector3 prop355 = o.Position; //IsContext = False IsNew = False
			OperandVar356 = prop355;
			System.Single prop357 = External.Mag((UnityEngine.Vector3)(( ( (OperandVar354))) - ( ( (OperandVar356))))); //IsContext = False IsNew = False
			OperandVar358 = prop357;
			
			
			return (System.Boolean)(( ( (OperandVar358))) <=( ( (1f))));
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
return "use";
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
			System.Boolean OperandVar369 = default(System.Boolean); //IsContext = False IsNew = False
			LightSource StoredVariable365 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable365 != null)
			{
				System.Boolean ifResult366; //IsContext = False IsNew = False
				System.Boolean OperandVar368 = default(System.Boolean); //IsContext = False IsNew = False
				System.Boolean prop367 = StoredVariable365.LitUp; //IsContext = False IsNew = False
				OperandVar368 = prop367;
				if(ifResult366 = !(OperandVar368))
				{
					applicable = true;
					OperandVar369 = applicable;
				}
			}
			return (System.Boolean) (OperandVar369);
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
			System.Boolean OperandVar371 = default(System.Boolean); //IsContext = False IsNew = False
			Manual StoredVariable370 = ((Manual)root.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
			if(StoredVariable370 != null)
			{
				applicable = true;
				OperandVar371 = applicable;
			}
			return (System.Boolean) (OperandVar371);
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
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar373 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop372 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop372 != null)
			{
				OperandVar373 = prop372;
			}
			smart_scope.Scope =  (OperandVar373);
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
			var other = this.other;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			//UnityEngine.GameObject at; //IsContext = False IsNew = False
			//UnityEngine.GameObject other; //IsContext = False IsNew = False
			//SmartScope smart_scope; //IsContext = False IsNew = False
			
			{
				//ContextStatement UnityEngine.GameObject other ContextSwitchInterpreter
				if(other != null)
				{
					//UnityEngine.GameObject other; //IsContext = True IsNew = False
					
					{
						LightSource subContext374 = (LightSource)other.GetComponent(typeof(LightSource)); //IsContext = True IsNew = False
						//ContextStatement LightSource subContext374 ContextSwitchInterpreter
						if(subContext374 != null)
						{
							//LightSource subContext374; //IsContext = True IsNew = False
							
							subContext374.LitUp = (System.Boolean)( (true));
						}
					}
				}
			}
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
			UnityEngine.GameObject OperandVar383 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar383 = root;
			task.Root = (UnityEngine.GameObject) (OperandVar383);
			UnityEngine.GameObject OperandVar384 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar384 = at;
			properTask.Who = (UnityEngine.GameObject) (OperandVar384);
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
			System.Boolean OperandVar377 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable375 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable375 != null)
			{
				Movable StoredVariable376 = ((Movable)StoredVariable375.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable376 != null)
				{
					applicable = true;
					OperandVar377 = applicable;
				}
			}
			return (System.Boolean) (OperandVar377);
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
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar379 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop378 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop378 != null)
			{
				OperandVar379 = prop378;
			}
			smart_scope.Scope =  (OperandVar379);
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
				Movable subContext380 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext380 ContextSwitchInterpreter
				if(subContext380 != null)
				{
					//Movable subContext380; //IsContext = True IsNew = False
					
					UnityEngine.GameObject OperandVar381 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar381 = at;
					subContext380.Goto((System.Single)( (1f)),(UnityEngine.GameObject)( (OperandVar381)));
					
					subContext380.Speed = (System.Single)( (1f));
					Movable OperandVar382 = default(Movable); //IsContext = False IsNew = False
					OperandVar382 = subContext380;
					mov =  (OperandVar382);
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
			System.Boolean OperandVar386 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop385 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar386 = prop385;
			return (System.Boolean) (OperandVar386);
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
			System.Boolean OperandVar389 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable387 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable387 != null)
			{
				Movable StoredVariable388 = ((Movable)StoredVariable387.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable388 != null)
				{
					applicable = true;
					OperandVar389 = applicable;
				}
			}
			return (System.Boolean) (OperandVar389);
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
			UnityEngine.Vector2 OperandVar394 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
			UnityEngine.Vector3 OperandVar392 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			Entity StoredVariable390 = ((Entity)around.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable390 != null)
			{
				UnityEngine.Vector3 prop391 = StoredVariable390.Position; //IsContext = False IsNew = False
				OperandVar392 = prop391;
			}
			
			UnityEngine.Vector2 prop393 = External.RandomPoint((UnityEngine.Vector2)( (OperandVar392)),(System.Single)( (4f))); //IsContext = False IsNew = False
			OperandVar394 = prop393;
			UnityEngine.Vector2 point =  (OperandVar394); //IsContext = False IsNew = False
			
			{
				Movable subContext395 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext395 ContextSwitchInterpreter
				if(subContext395 != null)
				{
					//Movable subContext395; //IsContext = True IsNew = False
					
					UnityEngine.Vector2 OperandVar396 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
					OperandVar396 = point;
					subContext395.GotoPoint((System.Single)( (1f)),(UnityEngine.Vector2)( (OperandVar396)));
					
					subContext395.Speed = (System.Single)( (1f));
					Movable OperandVar397 = default(Movable); //IsContext = False IsNew = False
					OperandVar397 = subContext395;
					mov =  (OperandVar397);
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
			System.Boolean OperandVar399 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop398 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar399 = prop398;
			return (System.Boolean) (OperandVar399);
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
			System.Boolean OperandVar401 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable400 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable400 != null)
			{
				applicable = true;
				OperandVar401 = applicable;
			}
			return (System.Boolean) (OperandVar401);
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
			UnityEngine.GameObject OperandVar405 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop404 = fromTask.Who; //IsContext = False IsNew = False
			if(prop404 != null)
			{
				OperandVar405 = prop404;
			}
			properTask.Around = (UnityEngine.GameObject) (OperandVar405);
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
			UnityEngine.GameObject OperandVar406 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar406 = root;
			properTask.Around = (UnityEngine.GameObject) (OperandVar406);
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
			System.Boolean OperandVar403 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable402 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable402 != null)
			{
				applicable = true;
				OperandVar403 = applicable;
			}
			return (System.Boolean) (OperandVar403);
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
			System.Boolean OperandVar409 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable407 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable407 != null)
			{
				Movable StoredVariable408 = ((Movable)StoredVariable407.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable408 != null)
				{
					applicable = true;
					OperandVar409 = applicable;
				}
			}
			return (System.Boolean) (OperandVar409);
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
				Movable subContext410 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext410 ContextSwitchInterpreter
				if(subContext410 != null)
				{
					//Movable subContext410; //IsContext = True IsNew = False
					System.Single OperandVar411 = default(System.Single); //IsContext = False IsNew = False
					OperandVar411 = ok_distance;
					UnityEngine.GameObject OperandVar412 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar412 = who;
					subContext410.Goto((System.Single)( (OperandVar411)),(UnityEngine.GameObject)( (OperandVar412)));
					
					subContext410.Speed = (System.Single)( (1f));
					Movable OperandVar413 = default(Movable); //IsContext = False IsNew = False
					OperandVar413 = subContext410;
					mov =  (OperandVar413);
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
			System.Boolean OperandVar415 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop414 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar415 = prop414;
			return (System.Boolean) (OperandVar415);
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
			System.Single OperandVar418 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable416 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable416 != null)
			{
				System.Single prop417 = StoredVariable416.Brightness; //IsContext = False IsNew = False
				OperandVar418 = prop417;
			}
			System.Single OperandVar421 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable419 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable419 != null)
			{
				System.Single prop420 = StoredVariable419.Light; //IsContext = False IsNew = False
				OperandVar421 = prop420;
			}
			val = ( (OperandVar418)) * ( (OperandVar421));
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
			System.Boolean OperandVar424 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable422 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable422 != null)
			{
				LightSensor StoredVariable423 = ((LightSensor)StoredVariable422.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable423 != null)
				{
					applicable = true;
					OperandVar424 = applicable;
				}
			}
			return (System.Boolean) (OperandVar424);
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
			System.Boolean OperandVar427 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable425 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable425 != null)
			{
				LightSource StoredVariable426 = ((LightSource)StoredVariable425.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable426 != null)
				{
					applicable = true;
					OperandVar427 = applicable;
				}
			}
			return (System.Boolean) (OperandVar427);
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
			System.Boolean OperandVar429 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable428 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable428 != null)
			{
				applicable = true;
				OperandVar429 = applicable;
			}
			return (System.Boolean) (OperandVar429);
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
			System.Boolean OperandVar431 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable430 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable430 != null)
			{
				applicable = true;
				OperandVar431 = applicable;
			}
			return (System.Boolean) (OperandVar431);
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
			System.Boolean OperandVar434 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop432 = trigger.Target; //IsContext = False IsNew = False
			if(prop432 != null)
			{
				Actor StoredVariable433 = ((Actor)prop432.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable433 != null)
				{
					applicable = true;
					OperandVar434 = applicable;
				}
			}
			return (System.Boolean) (OperandVar434);
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
				VisualsFeed subContext435 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext435 ContextPropertySwitchInterpreter
				if(subContext435 != null)
				{
					TestEvent OperandVar436 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar436 = trigger;
					UnityEngine.Vector3 OperandVar440 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(trigger != null)
					{
						UnityEngine.GameObject prop437 = trigger.Target; //IsContext = False IsNew = False
						if(prop437 != null)
						{
							Entity StoredVariable438 = ((Entity)prop437.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
							if(StoredVariable438 != null)
							{
								UnityEngine.Vector3 prop439 = StoredVariable438.Position; //IsContext = False IsNew = False
								OperandVar440 = prop439;
							}
						}
					}
					subContext435.Push((Event)( (OperandVar436)),(UnityEngine.Vector3)( (OperandVar440)));
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
			System.Boolean OperandVar442 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable441 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable441 != null)
			{
				applicable = true;
				OperandVar442 = applicable;
			}
			return (System.Boolean) (OperandVar442);
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
				ScriptedTypes.facts subContext443 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext443 ContextSwitchInterpreter
				if(subContext443 != null)
				{
					//ScriptedTypes.facts subContext443; //IsContext = True IsNew = False
					System.Boolean OperandVar445 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop444 = subContext443.HasNoticedTestEvent(); //IsContext = False IsNew = False
					if(prop444 != false)
					{
						OperandVar445 = prop444;
					}
					if(!(OperandVar445))
					{
						ScriptedTypes.noticed_test_event OperandVar447 = default(ScriptedTypes.noticed_test_event); //IsContext = False IsNew = False
						ScriptedTypes.noticed_test_event prop446 = subContext443.AddNoticedTestEvent(); //IsContext = False IsNew = False
						if(prop446 != null)
						{
							OperandVar447 = prop446;
						}
						ScriptedTypes.noticed_test_event ev =  (OperandVar447); //IsContext = False IsNew = False
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
			System.Boolean OperandVar450 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop448 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop448 != null)
			{
				PlayerMarker StoredVariable449 = ((PlayerMarker)prop448.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable449 != null)
				{
					applicable = true;
					OperandVar450 = applicable;
				}
			}
			return (System.Boolean) (OperandVar450);
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
			
			
			
			UnityEngine.GameObject OperandVar452 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop451 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop451 != null)
			{
				OperandVar452 = prop451;
			}
			External.Log((System.Object)(( ( ("init dialog for "))) + ( ( (OperandVar452)))));
			UnityEngine.GameObject OperandVar454 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop453 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop453 != null)
			{
				OperandVar454 = prop453;
			}
			External.InitDialogUi((UnityEngine.GameObject)( (OperandVar454)));
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
			System.Boolean OperandVar457 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop455 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop455 != null)
			{
				PlayerMarker StoredVariable456 = ((PlayerMarker)prop455.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable456 != null)
				{
					applicable = true;
					OperandVar457 = applicable;
				}
			}
			return (System.Boolean) (OperandVar457);
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
			System.Boolean OperandVar460 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop458 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop458 != null)
			{
				PlayerMarker StoredVariable459 = ((PlayerMarker)prop458.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable459 != null)
				{
					applicable = true;
					OperandVar460 = applicable;
				}
			}
			return (System.Boolean) (OperandVar460);
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
			System.Boolean OperandVar463 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable461 = ((Actor)trigger_root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable461 != null)
			{
				Entity StoredVariable462 = ((Entity)StoredVariable461.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable462 != null)
				{
					applicable = true;
					OperandVar463 = applicable;
				}
			}
			return (System.Boolean) (OperandVar463);
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
			Entity EntVar464 = (Entity)trigger_root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			trigger_root.AddComponent<ScriptedTypes.backstory>();
			
			trigger_root.AddComponent<ScriptedTypes.personality>();
			if(EntVar464 != null) EntVar464.ComponentAdded();
		}
        }
    }
}
