namespace ScriptedTypes {
    
    
    public interface lit_up_room {
    }
    
    public interface big_quest {
    }
    
    public interface quest {
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
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=true, IsInteraction=false)]
    public class monsters_lair_threat : EventAction, big_quest {
        
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
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=true, IsInteraction=false)]
    public class old_altar_threat : EventAction, big_quest {
        
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
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=true, IsInteraction=false)]
    public class burial_disease_threat : EventAction, big_quest {
        
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
    
    [EventActionAttribute(ShouldHaveMaxUtility=false, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=true, IsInteraction=false)]
    public class warriors_worth_quest : EventAction, big_quest {
        
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
    
    [EventActionAttribute(ShouldHaveMaxUtility=true, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class blacksmith_materials_quest : EventAction, quest {
        
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
    
    [EventActionAttribute(ShouldHaveMaxUtility=true, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class artisan_materials_quest : EventAction, quest {
        
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
    
    [EventActionAttribute(ShouldHaveMaxUtility=true, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class old_friend_quest : EventAction, quest {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar283 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable275 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable275 != null)
			{
				System.Boolean ifResult276; //IsContext = False IsNew = False
				
				
				System.Int32 OperandVar278 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop277 = StoredVariable275.Quests; //IsContext = False IsNew = False
				OperandVar278 = prop277;
				
				
				
				
				System.Int32 OperandVar282 = default(System.Int32); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> OperandVar280 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> prop279 = External.AllEntities(); //IsContext = False IsNew = False
				if(prop279 != null)
				{
					OperandVar280 = prop279;
				}
				System.Int32 prop281 = External.Amount((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar280)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
return  (true);}); //IsContext = False IsNew = False
				OperandVar282 = prop281;
				
				
				if(ifResult276 = ( (( ( (OperandVar278))) < ( ( (5f))))) && ( (( ( (OperandVar282))) > ( ( (8f))))))
				{
					applicable = true;
					OperandVar283 = applicable;
				}
			}
			return (System.Boolean) (OperandVar283);
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
			
			
			
			{
				UnityEngine.GameObject FuncCtx284 = External.SpawnPrefab(( ("npc")).ToString(),( ("old_friend")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx284 ContextPropertySwitchInterpreter
				if(FuncCtx284 != null)
				{
					
					{
						Entity subContext285 = (Entity)FuncCtx284.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext285 ContextSwitchInterpreter
						if(subContext285 != null)
						{
							//Entity subContext285; //IsContext = True IsNew = False
							
							subContext285.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx284.AddComponent<ScriptedTypes.artisan>();
					Entity EntVar286 = (Entity)FuncCtx284.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					FuncCtx284.AddComponent<ScriptedTypes.old_friend>();
					if(EntVar286 != null) EntVar286.ComponentAdded();
				}
			}
			
			{
				Story subContext287 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext287 ContextSwitchInterpreter
				if(subContext287 != null)
				{
					//Story subContext287; //IsContext = True IsNew = False
					
					System.Int32 OperandVar289 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop288 = subContext287.Quests; //IsContext = False IsNew = False
					OperandVar289 = prop288;
					
					
					subContext287.Quests = (System.Int32)(( ( (OperandVar289))) + ( ( (1f))));
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=true, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class forest_monster : EventAction, quest {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar294 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable290 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable290 != null)
			{
				System.Boolean ifResult291; //IsContext = False IsNew = False
				
				System.Int32 OperandVar293 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop292 = StoredVariable290.Quests; //IsContext = False IsNew = False
				OperandVar293 = prop292;
				
				
				if(ifResult291 = ( ( (OperandVar293))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar294 = applicable;
				}
			}
			return (System.Boolean) (OperandVar294);
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
			
			
			
			{
				UnityEngine.GameObject FuncCtx295 = External.SpawnPrefab(( ("npc")).ToString(),( ("monster")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx295 ContextPropertySwitchInterpreter
				if(FuncCtx295 != null)
				{
					
					{
						Entity subContext296 = (Entity)FuncCtx295.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext296 ContextSwitchInterpreter
						if(subContext296 != null)
						{
							//Entity subContext296; //IsContext = True IsNew = False
							
							subContext296.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx295.AddComponent<ScriptedTypes.monster>();
					Entity EntVar297 = (Entity)FuncCtx295.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar297 != null) EntVar297.ComponentAdded();
				}
			}
			
			{
				Story subContext298 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext298 ContextSwitchInterpreter
				if(subContext298 != null)
				{
					//Story subContext298; //IsContext = True IsNew = False
					
					System.Int32 OperandVar300 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop299 = subContext298.Quests; //IsContext = False IsNew = False
					OperandVar300 = prop299;
					
					
					subContext298.Quests = (System.Int32)(( ( (OperandVar300))) + ( ( (1f))));
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=true, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class exotic_artifact : EventAction, quest {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar305 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable301 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable301 != null)
			{
				System.Boolean ifResult302; //IsContext = False IsNew = False
				
				System.Int32 OperandVar304 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop303 = StoredVariable301.Quests; //IsContext = False IsNew = False
				OperandVar304 = prop303;
				
				
				if(ifResult302 = ( ( (OperandVar304))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar305 = applicable;
				}
			}
			return (System.Boolean) (OperandVar305);
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
			
			System.String OperandVar306 = default(System.String); //IsContext = False IsNew = False
			OperandVar306 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx307 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar306)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx307 ContextPropertySwitchInterpreter
				if(FuncCtx307 != null)
				{
					
					{
						Entity subContext308 = (Entity)FuncCtx307.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext308 ContextSwitchInterpreter
						if(subContext308 != null)
						{
							//Entity subContext308; //IsContext = True IsNew = False
							
							subContext308.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx307.AddComponent<ScriptedTypes.trader>();
					Entity EntVar309 = (Entity)FuncCtx307.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar309 != null) EntVar309.ComponentAdded();
				}
			}
			
			{
				Story subContext310 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext310 ContextSwitchInterpreter
				if(subContext310 != null)
				{
					//Story subContext310; //IsContext = True IsNew = False
					
					System.Int32 OperandVar312 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop311 = subContext310.Quests; //IsContext = False IsNew = False
					OperandVar312 = prop311;
					
					
					subContext310.Quests = (System.Int32)(( ( (OperandVar312))) + ( ( (1f))));
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=true, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class farm_is_infested : EventAction, quest {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar317 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable313 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable313 != null)
			{
				System.Boolean ifResult314; //IsContext = False IsNew = False
				
				System.Int32 OperandVar316 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop315 = StoredVariable313.Quests; //IsContext = False IsNew = False
				OperandVar316 = prop315;
				
				
				if(ifResult314 = ( ( (OperandVar316))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar317 = applicable;
				}
			}
			return (System.Boolean) (OperandVar317);
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
			UnityEngine.GameObject OperandVar319 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop318 = External.NoOne(); //IsContext = False IsNew = False
			if(prop318 != null)
			{
				OperandVar319 = prop318;
			}
			UnityEngine.GameObject farmer_npc =  (OperandVar319); //IsContext = False IsNew = False
			
			
			
			{
				UnityEngine.GameObject FuncCtx320 = External.SpawnPrefab(( ("npc")).ToString(),( ("human_npc")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx320 ContextPropertySwitchInterpreter
				if(FuncCtx320 != null)
				{
					
					{
						Entity subContext321 = (Entity)FuncCtx320.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext321 ContextSwitchInterpreter
						if(subContext321 != null)
						{
							//Entity subContext321; //IsContext = True IsNew = False
							
							subContext321.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx320.AddComponent<ScriptedTypes.farmer>();
					Entity EntVar322 = (Entity)FuncCtx320.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar322 != null) EntVar322.ComponentAdded();
					UnityEngine.GameObject OperandVar323 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar323 = FuncCtx320;
					farmer_npc =  (OperandVar323);
				}
			}
			UnityEngine.GameObject OperandVar325 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop324 = External.NoOne(); //IsContext = False IsNew = False
			if(prop324 != null)
			{
				OperandVar325 = prop324;
			}
			UnityEngine.GameObject farm_loc =  (OperandVar325); //IsContext = False IsNew = False
			
			
			
			{
				UnityEngine.GameObject FuncCtx326 = External.SpawnPrefab(( ("loc")).ToString(),( ("farm")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx326 ContextPropertySwitchInterpreter
				if(FuncCtx326 != null)
				{
					
					{
						Entity subContext327 = (Entity)FuncCtx326.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext327 ContextSwitchInterpreter
						if(subContext327 != null)
						{
							//Entity subContext327; //IsContext = True IsNew = False
							
							subContext327.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx326.AddComponent<ScriptedTypes.infestation>();
					Entity EntVar328 = (Entity)FuncCtx326.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					FuncCtx326.AddComponent<ScriptedTypes.farm>();
					if(EntVar328 != null) EntVar328.ComponentAdded();
					UnityEngine.GameObject OperandVar329 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar329 = FuncCtx326;
					farm_loc =  (OperandVar329);
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject farm_loc ContextSwitchInterpreter
				if(farm_loc != null)
				{
					//UnityEngine.GameObject farm_loc; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext330 = (ScriptedTypes.facts)farm_loc.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext330 ContextSwitchInterpreter
						if(subContext330 != null)
						{
							//ScriptedTypes.facts subContext330; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.owned FuncCtx331 = subContext330.AddOwned();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.owned FuncCtx331 ContextPropertySwitchInterpreter
								if(FuncCtx331 != null)
								{
									UnityEngine.GameObject OperandVar332 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar332 = farmer_npc;
									UnityEngine.GameObject by =  (OperandVar332); //IsContext = False IsNew = False
								}
							}
						}
					}
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject farmer_npc ContextSwitchInterpreter
				if(farmer_npc != null)
				{
					//UnityEngine.GameObject farmer_npc; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext333 = (ScriptedTypes.facts)farmer_npc.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext333 ContextSwitchInterpreter
						if(subContext333 != null)
						{
							//ScriptedTypes.facts subContext333; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.owner FuncCtx334 = subContext333.AddOwner();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.owner FuncCtx334 ContextPropertySwitchInterpreter
								if(FuncCtx334 != null)
								{
									UnityEngine.GameObject OperandVar335 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar335 = farm_loc;
									FuncCtx334.OfWhat = (UnityEngine.GameObject)( (OperandVar335));
								}
							}
						}
					}
				}
			}
			
			{
				Story subContext336 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext336 ContextSwitchInterpreter
				if(subContext336 != null)
				{
					//Story subContext336; //IsContext = True IsNew = False
					
					System.Int32 OperandVar338 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop337 = subContext336.Quests; //IsContext = False IsNew = False
					OperandVar338 = prop337;
					
					
					subContext336.Quests = (System.Int32)(( ( (OperandVar338))) + ( ( (1f))));
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=true, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class old_world_metal : EventAction, quest {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar343 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable339 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable339 != null)
			{
				System.Boolean ifResult340; //IsContext = False IsNew = False
				
				System.Int32 OperandVar342 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop341 = StoredVariable339.Quests; //IsContext = False IsNew = False
				OperandVar342 = prop341;
				
				
				if(ifResult340 = ( ( (OperandVar342))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar343 = applicable;
				}
			}
			return (System.Boolean) (OperandVar343);
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
			UnityEngine.GameObject OperandVar345 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop344 = External.NoOne(); //IsContext = False IsNew = False
			if(prop344 != null)
			{
				OperandVar345 = prop344;
			}
			UnityEngine.GameObject mine_loc =  (OperandVar345); //IsContext = False IsNew = False
			
			
			
			{
				UnityEngine.GameObject FuncCtx346 = External.SpawnPrefab(( ("loc")).ToString(),( ("mine")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx346 ContextPropertySwitchInterpreter
				if(FuncCtx346 != null)
				{
					
					{
						Entity subContext347 = (Entity)FuncCtx346.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext347 ContextSwitchInterpreter
						if(subContext347 != null)
						{
							//Entity subContext347; //IsContext = True IsNew = False
							
							subContext347.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx346.AddComponent<ScriptedTypes.mine>();
					Entity EntVar348 = (Entity)FuncCtx346.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					FuncCtx346.AddComponent<ScriptedTypes.ancient>();
					if(EntVar348 != null) EntVar348.ComponentAdded();
					UnityEngine.GameObject OperandVar349 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar349 = FuncCtx346;
					mine_loc =  (OperandVar349);
				}
			}
			
			System.String OperandVar350 = default(System.String); //IsContext = False IsNew = False
			OperandVar350 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx351 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar350)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx351 ContextPropertySwitchInterpreter
				if(FuncCtx351 != null)
				{
					
					{
						Entity subContext352 = (Entity)FuncCtx351.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext352 ContextSwitchInterpreter
						if(subContext352 != null)
						{
							//Entity subContext352; //IsContext = True IsNew = False
							
							subContext352.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx351.AddComponent<ScriptedTypes.artisan>();
					Entity EntVar353 = (Entity)FuncCtx351.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar353 != null) EntVar353.ComponentAdded();
					
					{
						ScriptedTypes.facts subContext354 = (ScriptedTypes.facts)FuncCtx351.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext354 ContextSwitchInterpreter
						if(subContext354 != null)
						{
							//ScriptedTypes.facts subContext354; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.wants_old_world_metal FuncCtx355 = subContext354.AddWantsOldWorldMetal();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.wants_old_world_metal FuncCtx355 ContextPropertySwitchInterpreter
								if(FuncCtx355 != null)
								{
									UnityEngine.GameObject OperandVar356 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar356 = mine_loc;
									FuncCtx355.Where = (UnityEngine.GameObject)( (OperandVar356));
								}
							}
						}
					}
				}
			}
			
			{
				Story subContext357 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext357 ContextSwitchInterpreter
				if(subContext357 != null)
				{
					//Story subContext357; //IsContext = True IsNew = False
					
					System.Int32 OperandVar359 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop358 = subContext357.Quests; //IsContext = False IsNew = False
					OperandVar359 = prop358;
					
					
					subContext357.Quests = (System.Int32)(( ( (OperandVar359))) + ( ( (1f))));
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
        
        public override void Init() {
base.Init();

        }
    }
    
    [EventActionAttribute(ShouldHaveMaxUtility=true, OncePerObject=true, OncePerTurn=false, IsAIAction=false, Tooltip="", OnceInCategory=false, IsInteraction=false)]
    public class lost_apprentice : EventAction, quest {
        
        public override bool Filter() {

		{
			var root = this.root;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			//UnityEngine.GameObject root; //IsContext = True IsNew = False
			System.Boolean OperandVar376 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable360 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable360 != null)
			{
				System.Boolean ifResult361; //IsContext = False IsNew = False
				
				
				System.Int32 OperandVar363 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop362 = StoredVariable360.Quests; //IsContext = False IsNew = False
				OperandVar363 = prop362;
				
				
				
				
				
				
				System.Int32 OperandVar369 = default(System.Int32); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> OperandVar365 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> prop364 = External.AllEntities(); //IsContext = False IsNew = False
				if(prop364 != null)
				{
					OperandVar365 = prop364;
				}
				System.Int32 prop368 = External.Amount((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar365)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.blacksmith OperandVar367 = default(ScriptedTypes.blacksmith); //IsContext = False IsNew = False;
ScriptedTypes.blacksmith StoredVariable366 = ((ScriptedTypes.blacksmith)go.GetComponent(typeof(ScriptedTypes.blacksmith))); //IsContext = False IsNew = False;
if(StoredVariable366 != null)
					{
						OperandVar367 = StoredVariable366;
					};
return  (OperandVar367);}); //IsContext = False IsNew = False
				OperandVar369 = prop368;
				
				
				
				
				System.Int32 OperandVar375 = default(System.Int32); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> OperandVar371 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> prop370 = External.AllEntities(); //IsContext = False IsNew = False
				if(prop370 != null)
				{
					OperandVar371 = prop370;
				}
				System.Int32 prop374 = External.Amount((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar371)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.artisan OperandVar373 = default(ScriptedTypes.artisan); //IsContext = False IsNew = False;
ScriptedTypes.artisan StoredVariable372 = ((ScriptedTypes.artisan)go.GetComponent(typeof(ScriptedTypes.artisan))); //IsContext = False IsNew = False;
if(StoredVariable372 != null)
					{
						OperandVar373 = StoredVariable372;
					};
return  (OperandVar373);}); //IsContext = False IsNew = False
				OperandVar375 = prop374;
				
				
				if(ifResult361 = ( (( ( (OperandVar363))) < ( ( (5f))))) && ( ( (( (( ( (OperandVar369))) > ( ( (0f))))) || ( (( ( (OperandVar375))) > ( ( (0f)))))))))
				{
					applicable = true;
					OperandVar376 = applicable;
				}
			}
			return (System.Boolean) (OperandVar376);
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
			UnityEngine.GameObject OperandVar382 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar378 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop377 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop377 != null)
			{
				OperandVar378 = prop377;
			}
			UnityEngine.GameObject prop381 = External.Any((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar378)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.blacksmith OperandVar380 = default(ScriptedTypes.blacksmith); //IsContext = False IsNew = False;
ScriptedTypes.blacksmith StoredVariable379 = ((ScriptedTypes.blacksmith)go.GetComponent(typeof(ScriptedTypes.blacksmith))); //IsContext = False IsNew = False;
if(StoredVariable379 != null)
				{
					OperandVar380 = StoredVariable379;
				};
return  (OperandVar380);}); //IsContext = False IsNew = False
			if(prop381 != null)
			{
				OperandVar382 = prop381;
			}
			UnityEngine.GameObject master =  (OperandVar382); //IsContext = False IsNew = False
			System.Boolean OperandVar385 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar383 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar383 = master;
			System.Boolean prop384 = External.Has((UnityEngine.GameObject)( (OperandVar383))); //IsContext = False IsNew = False
			if(prop384 != false)
			{
				OperandVar385 = prop384;
			}
			if(!(OperandVar385))
			{
				UnityEngine.GameObject OperandVar391 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> OperandVar387 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> prop386 = External.AllEntities(); //IsContext = False IsNew = False
				if(prop386 != null)
				{
					OperandVar387 = prop386;
				}
				UnityEngine.GameObject prop390 = External.Any((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar387)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.artisan OperandVar389 = default(ScriptedTypes.artisan); //IsContext = False IsNew = False;
ScriptedTypes.artisan StoredVariable388 = ((ScriptedTypes.artisan)go.GetComponent(typeof(ScriptedTypes.artisan))); //IsContext = False IsNew = False;
if(StoredVariable388 != null)
					{
						OperandVar389 = StoredVariable388;
					};
return  (OperandVar389);}); //IsContext = False IsNew = False
				if(prop390 != null)
				{
					OperandVar391 = prop390;
				}
				master =  (OperandVar391);
			}
			UnityEngine.GameObject OperandVar393 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop392 = External.NoOne(); //IsContext = False IsNew = False
			if(prop392 != null)
			{
				OperandVar393 = prop392;
			}
			UnityEngine.GameObject app =  (OperandVar393); //IsContext = False IsNew = False
			
			System.String OperandVar394 = default(System.String); //IsContext = False IsNew = False
			OperandVar394 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx395 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar394)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx395 ContextPropertySwitchInterpreter
				if(FuncCtx395 != null)
				{
					
					{
						Entity subContext396 = (Entity)FuncCtx395.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext396 ContextSwitchInterpreter
						if(subContext396 != null)
						{
							//Entity subContext396; //IsContext = True IsNew = False
							
							subContext396.RandomOffset((System.Single)( (10f)));
						}
					}
					System.Int32 OperandVar398 = default(System.Int32); //IsContext = False IsNew = False
					
					
					System.Int32 prop397 = External.RandomRange((System.Int32)( (0f)),(System.Int32)( (2f))); //IsContext = False IsNew = False
					OperandVar398 = prop397;
					System.Int32 r =  (OperandVar398); //IsContext = False IsNew = False
					UnityEngine.GameObject OperandVar399 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar399 = FuncCtx395;
					app =  (OperandVar399);
					
					{
						//ContextStatement UnityEngine.GameObject app ContextSwitchInterpreter
						if(app != null)
						{
							//UnityEngine.GameObject app; //IsContext = True IsNew = False
							app.AddComponent<ScriptedTypes.artisan>();
							Entity EntVar400 = (Entity)app.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
							if(EntVar400 != null) EntVar400.ComponentAdded();
						}
					}
					
					{
						//ContextStatement UnityEngine.GameObject app ContextSwitchInterpreter
						if(app != null)
						{
							//UnityEngine.GameObject app; //IsContext = True IsNew = False
							ScriptedTypes.apprentice ContextVar401 = app.AddComponent<ScriptedTypes.apprentice>();; //IsContext = False IsNew = True
							
							{
								//ContextStatement ScriptedTypes.apprentice ContextVar401 ContextSwitchInterpreter
								if(ContextVar401 != null)
								{
									//ScriptedTypes.apprentice ContextVar401; //IsContext = True IsNew = False
									UnityEngine.GameObject OperandVar402 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar402 = master;
									ContextVar401.Of = (UnityEngine.GameObject)( (OperandVar402));
								}
							}
							Entity EntVar403 = (Entity)app.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
							if(EntVar403 != null) EntVar403.ComponentAdded();
						}
					}
					
					{
						//ContextStatement UnityEngine.GameObject master ContextSwitchInterpreter
						if(master != null)
						{
							//UnityEngine.GameObject master; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.artisan subContext404 = (ScriptedTypes.artisan)master.GetComponent(typeof(ScriptedTypes.artisan)); //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.artisan subContext404 ContextSwitchInterpreter
								if(subContext404 != null)
								{
									//ScriptedTypes.artisan subContext404; //IsContext = True IsNew = False
									UnityEngine.GameObject OperandVar405 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar405 = app;
									subContext404.OwnApprentice = (UnityEngine.GameObject)( (OperandVar405));
								}
							}
							
							{
								ScriptedTypes.blacksmith subContext406 = (ScriptedTypes.blacksmith)master.GetComponent(typeof(ScriptedTypes.blacksmith)); //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.blacksmith subContext406 ContextSwitchInterpreter
								if(subContext406 != null)
								{
									//ScriptedTypes.blacksmith subContext406; //IsContext = True IsNew = False
									UnityEngine.GameObject OperandVar407 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar407 = app;
									subContext406.OwnApprentice = (UnityEngine.GameObject)( (OperandVar407));
								}
							}
						}
					}
				}
			}
			
			{
				Story subContext408 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext408 ContextSwitchInterpreter
				if(subContext408 != null)
				{
					//Story subContext408; //IsContext = True IsNew = False
					
					System.Int32 OperandVar410 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop409 = subContext408.Quests; //IsContext = False IsNew = False
					OperandVar410 = prop409;
					
					
					subContext408.Quests = (System.Int32)(( ( (OperandVar410))) + ( ( (1f))));
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
			LocalizedString OperandVar428 = default(LocalizedString); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar425 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar425 = root;
			UnityEngine.GameObject OperandVar426 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar426 = other;
			System.Single OperandVar427 = default(System.Single); //IsContext = False IsNew = False
			OperandVar427 = distance;
			var dict423= new System.Collections.Generic.Dictionary<string, object>();
var localizedString424= new LocalizedString("should_be_near",dict423);dict423.Add("who", (OperandVar425));
dict423.Add("other", (OperandVar426));
dict423.Add("distance", (OperandVar427));

			OperandVar428 = localizedString424;
			return  (OperandVar428);
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
				Entity OperandVar412 = default(Entity); //IsContext = False IsNew = False
				Entity StoredVariable411 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable411 != null)
				{
					OperandVar412 = StoredVariable411;
				}
				s =  (OperandVar412);
			}
			
			{
				Entity OperandVar414 = default(Entity); //IsContext = False IsNew = False
				Entity StoredVariable413 = ((Entity)other.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable413 != null)
				{
					OperandVar414 = StoredVariable413;
				}
				o =  (OperandVar414);
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
				System.Single OperandVar415 = default(System.Single); //IsContext = False IsNew = False
				OperandVar415 = distance;
				properTask.OkDistance =  (OperandVar415);
			}
			
			{
				UnityEngine.GameObject OperandVar416 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar416 = other;
				properTask.Who =  (OperandVar416);
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
			
			System.Single OperandVar422 = default(System.Single); //IsContext = False IsNew = False
			
			UnityEngine.Vector3 OperandVar418 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			UnityEngine.Vector3 prop417 = s.Position; //IsContext = False IsNew = False
			OperandVar418 = prop417;
			
			UnityEngine.Vector3 OperandVar420 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			UnityEngine.Vector3 prop419 = o.Position; //IsContext = False IsNew = False
			OperandVar420 = prop419;
			System.Single prop421 = External.Mag((UnityEngine.Vector3)(( ( (OperandVar418))) - ( ( (OperandVar420))))); //IsContext = False IsNew = False
			OperandVar422 = prop421;
			
			
			return (System.Boolean)(( ( (OperandVar422))) <=( ( (1f))));
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
			System.Boolean OperandVar433 = default(System.Boolean); //IsContext = False IsNew = False
			LightSource StoredVariable429 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable429 != null)
			{
				System.Boolean ifResult430; //IsContext = False IsNew = False
				System.Boolean OperandVar432 = default(System.Boolean); //IsContext = False IsNew = False
				System.Boolean prop431 = StoredVariable429.LitUp; //IsContext = False IsNew = False
				OperandVar432 = prop431;
				if(ifResult430 = !(OperandVar432))
				{
					applicable = true;
					OperandVar433 = applicable;
				}
			}
			return (System.Boolean) (OperandVar433);
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
			System.Boolean OperandVar435 = default(System.Boolean); //IsContext = False IsNew = False
			Manual StoredVariable434 = ((Manual)root.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
			if(StoredVariable434 != null)
			{
				applicable = true;
				OperandVar435 = applicable;
			}
			return (System.Boolean) (OperandVar435);
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
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar437 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop436 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop436 != null)
			{
				OperandVar437 = prop436;
			}
			smart_scope.Scope =  (OperandVar437);
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
						LightSource subContext438 = (LightSource)other.GetComponent(typeof(LightSource)); //IsContext = True IsNew = False
						//ContextStatement LightSource subContext438 ContextSwitchInterpreter
						if(subContext438 != null)
						{
							//LightSource subContext438; //IsContext = True IsNew = False
							
							subContext438.LitUp = (System.Boolean)( (true));
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
			UnityEngine.GameObject OperandVar447 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar447 = root;
			task.Root = (UnityEngine.GameObject) (OperandVar447);
			UnityEngine.GameObject OperandVar448 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar448 = at;
			properTask.Who = (UnityEngine.GameObject) (OperandVar448);
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
			System.Boolean OperandVar441 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable439 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable439 != null)
			{
				Movable StoredVariable440 = ((Movable)StoredVariable439.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable440 != null)
				{
					applicable = true;
					OperandVar441 = applicable;
				}
			}
			return (System.Boolean) (OperandVar441);
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
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar443 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop442 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop442 != null)
			{
				OperandVar443 = prop442;
			}
			smart_scope.Scope =  (OperandVar443);
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
				Movable subContext444 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext444 ContextSwitchInterpreter
				if(subContext444 != null)
				{
					//Movable subContext444; //IsContext = True IsNew = False
					
					UnityEngine.GameObject OperandVar445 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar445 = at;
					subContext444.Goto((System.Single)( (1f)),(UnityEngine.GameObject)( (OperandVar445)));
					
					subContext444.Speed = (System.Single)( (1f));
					Movable OperandVar446 = default(Movable); //IsContext = False IsNew = False
					OperandVar446 = subContext444;
					mov =  (OperandVar446);
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
			System.Boolean OperandVar450 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop449 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar450 = prop449;
			return (System.Boolean) (OperandVar450);
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
			System.Boolean OperandVar453 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable451 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable451 != null)
			{
				Movable StoredVariable452 = ((Movable)StoredVariable451.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable452 != null)
				{
					applicable = true;
					OperandVar453 = applicable;
				}
			}
			return (System.Boolean) (OperandVar453);
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
			UnityEngine.Vector2 OperandVar458 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
			UnityEngine.Vector3 OperandVar456 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			Entity StoredVariable454 = ((Entity)around.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable454 != null)
			{
				UnityEngine.Vector3 prop455 = StoredVariable454.Position; //IsContext = False IsNew = False
				OperandVar456 = prop455;
			}
			
			UnityEngine.Vector2 prop457 = External.RandomPoint((UnityEngine.Vector2)( (OperandVar456)),(System.Single)( (4f))); //IsContext = False IsNew = False
			OperandVar458 = prop457;
			UnityEngine.Vector2 point =  (OperandVar458); //IsContext = False IsNew = False
			
			{
				Movable subContext459 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext459 ContextSwitchInterpreter
				if(subContext459 != null)
				{
					//Movable subContext459; //IsContext = True IsNew = False
					
					UnityEngine.Vector2 OperandVar460 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
					OperandVar460 = point;
					subContext459.GotoPoint((System.Single)( (1f)),(UnityEngine.Vector2)( (OperandVar460)));
					
					subContext459.Speed = (System.Single)( (1f));
					Movable OperandVar461 = default(Movable); //IsContext = False IsNew = False
					OperandVar461 = subContext459;
					mov =  (OperandVar461);
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
			System.Boolean OperandVar463 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop462 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar463 = prop462;
			return (System.Boolean) (OperandVar463);
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
			System.Boolean OperandVar465 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable464 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable464 != null)
			{
				applicable = true;
				OperandVar465 = applicable;
			}
			return (System.Boolean) (OperandVar465);
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
			UnityEngine.GameObject OperandVar469 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop468 = fromTask.Who; //IsContext = False IsNew = False
			if(prop468 != null)
			{
				OperandVar469 = prop468;
			}
			properTask.Around = (UnityEngine.GameObject) (OperandVar469);
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
			UnityEngine.GameObject OperandVar470 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar470 = root;
			properTask.Around = (UnityEngine.GameObject) (OperandVar470);
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
			System.Boolean OperandVar467 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable466 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable466 != null)
			{
				applicable = true;
				OperandVar467 = applicable;
			}
			return (System.Boolean) (OperandVar467);
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
			System.Boolean OperandVar473 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable471 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable471 != null)
			{
				Movable StoredVariable472 = ((Movable)StoredVariable471.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable472 != null)
				{
					applicable = true;
					OperandVar473 = applicable;
				}
			}
			return (System.Boolean) (OperandVar473);
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
				Movable subContext474 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext474 ContextSwitchInterpreter
				if(subContext474 != null)
				{
					//Movable subContext474; //IsContext = True IsNew = False
					System.Single OperandVar475 = default(System.Single); //IsContext = False IsNew = False
					OperandVar475 = ok_distance;
					UnityEngine.GameObject OperandVar476 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar476 = who;
					subContext474.Goto((System.Single)( (OperandVar475)),(UnityEngine.GameObject)( (OperandVar476)));
					
					subContext474.Speed = (System.Single)( (1f));
					Movable OperandVar477 = default(Movable); //IsContext = False IsNew = False
					OperandVar477 = subContext474;
					mov =  (OperandVar477);
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
			System.Boolean OperandVar479 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop478 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar479 = prop478;
			return (System.Boolean) (OperandVar479);
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
			System.Single OperandVar482 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable480 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable480 != null)
			{
				System.Single prop481 = StoredVariable480.Brightness; //IsContext = False IsNew = False
				OperandVar482 = prop481;
			}
			System.Single OperandVar485 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable483 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable483 != null)
			{
				System.Single prop484 = StoredVariable483.Light; //IsContext = False IsNew = False
				OperandVar485 = prop484;
			}
			val = ( (OperandVar482)) * ( (OperandVar485));
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
			System.Boolean OperandVar488 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable486 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable486 != null)
			{
				LightSensor StoredVariable487 = ((LightSensor)StoredVariable486.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable487 != null)
				{
					applicable = true;
					OperandVar488 = applicable;
				}
			}
			return (System.Boolean) (OperandVar488);
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
			System.Boolean OperandVar491 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable489 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable489 != null)
			{
				LightSource StoredVariable490 = ((LightSource)StoredVariable489.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable490 != null)
				{
					applicable = true;
					OperandVar491 = applicable;
				}
			}
			return (System.Boolean) (OperandVar491);
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
			System.Boolean OperandVar493 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable492 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable492 != null)
			{
				applicable = true;
				OperandVar493 = applicable;
			}
			return (System.Boolean) (OperandVar493);
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
			System.Boolean OperandVar495 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable494 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable494 != null)
			{
				applicable = true;
				OperandVar495 = applicable;
			}
			return (System.Boolean) (OperandVar495);
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
			System.Boolean OperandVar498 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop496 = trigger.Target; //IsContext = False IsNew = False
			if(prop496 != null)
			{
				Entity StoredVariable497 = ((Entity)prop496.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable497 != null)
				{
					applicable = true;
					OperandVar498 = applicable;
				}
			}
			return (System.Boolean) (OperandVar498);
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
				VisualsFeed subContext499 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext499 ContextPropertySwitchInterpreter
				if(subContext499 != null)
				{
					TestEvent OperandVar500 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar500 = trigger;
					UnityEngine.Vector3 OperandVar504 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(trigger != null)
					{
						UnityEngine.GameObject prop501 = trigger.Target; //IsContext = False IsNew = False
						if(prop501 != null)
						{
							Entity StoredVariable502 = ((Entity)prop501.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
							if(StoredVariable502 != null)
							{
								UnityEngine.Vector3 prop503 = StoredVariable502.Position; //IsContext = False IsNew = False
								OperandVar504 = prop503;
							}
						}
					}
					subContext499.Push((Event)( (OperandVar500)),(UnityEngine.Vector3)( (OperandVar504)));
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
			System.Boolean OperandVar506 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable505 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable505 != null)
			{
				applicable = true;
				OperandVar506 = applicable;
			}
			return (System.Boolean) (OperandVar506);
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
				ScriptedTypes.facts subContext507 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext507 ContextSwitchInterpreter
				if(subContext507 != null)
				{
					//ScriptedTypes.facts subContext507; //IsContext = True IsNew = False
					System.Boolean OperandVar509 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop508 = subContext507.HasNoticedTestEvent(); //IsContext = False IsNew = False
					if(prop508 != false)
					{
						OperandVar509 = prop508;
					}
					if(!(OperandVar509))
					{
						ScriptedTypes.noticed_test_event OperandVar511 = default(ScriptedTypes.noticed_test_event); //IsContext = False IsNew = False
						ScriptedTypes.noticed_test_event prop510 = subContext507.AddNoticedTestEvent(); //IsContext = False IsNew = False
						if(prop510 != null)
						{
							OperandVar511 = prop510;
						}
						ScriptedTypes.noticed_test_event ev =  (OperandVar511); //IsContext = False IsNew = False
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
			System.Boolean OperandVar514 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop512 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop512 != null)
			{
				PlayerMarker StoredVariable513 = ((PlayerMarker)prop512.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable513 != null)
				{
					applicable = true;
					OperandVar514 = applicable;
				}
			}
			return (System.Boolean) (OperandVar514);
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
			
			
			
			UnityEngine.GameObject OperandVar516 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop515 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop515 != null)
			{
				OperandVar516 = prop515;
			}
			External.Log((System.Object)(( ( ("init dialog for "))) + ( ( (OperandVar516)))));
			UnityEngine.GameObject OperandVar518 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop517 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop517 != null)
			{
				OperandVar518 = prop517;
			}
			External.InitDialogUi((UnityEngine.GameObject)( (OperandVar518)));
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
			System.Boolean OperandVar521 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop519 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop519 != null)
			{
				PlayerMarker StoredVariable520 = ((PlayerMarker)prop519.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable520 != null)
				{
					applicable = true;
					OperandVar521 = applicable;
				}
			}
			return (System.Boolean) (OperandVar521);
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
			System.Boolean OperandVar524 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop522 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop522 != null)
			{
				PlayerMarker StoredVariable523 = ((PlayerMarker)prop522.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable523 != null)
				{
					applicable = true;
					OperandVar524 = applicable;
				}
			}
			return (System.Boolean) (OperandVar524);
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
			System.Boolean OperandVar526 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable525 = ((Entity)trigger_root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable525 != null)
			{
				applicable = true;
				OperandVar526 = applicable;
			}
			return (System.Boolean) (OperandVar526);
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
			Entity EntVar527 = (Entity)trigger_root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			trigger_root.AddComponent<ScriptedTypes.backstory>();
			
			trigger_root.AddComponent<ScriptedTypes.personality>();
			if(EntVar527 != null) EntVar527.ComponentAdded();
		}
        }
    }
    
    [ReactionAttribute(IsRepeatable=false, EventType=typeof(EntityPostCreated))]
    public class player_extension_controls : Reaction {
        
        private EntityPostCreated trigger;
        
        public override Event Event {
            get {
return trigger;
            }
            set {
trigger = value as EntityPostCreated;
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
			//EntityPostCreated trigger; //IsContext = True IsNew = False
			System.Boolean OperandVar529 = default(System.Boolean); //IsContext = False IsNew = False
			PlayerMarker StoredVariable528 = ((PlayerMarker)trigger_root.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
			if(StoredVariable528 != null)
			{
				applicable = true;
				OperandVar529 = applicable;
			}
			return (System.Boolean) (OperandVar529);
		}
        }
        
        public override void Action() {

		{
			var trigger = this.trigger;
			//External External; //IsContext = False IsNew = False
			//ContextStatement External External ContextSwitchInterpreter
			//UnityEngine.GameObject trigger_root = false; //IsContext = True IsNew = False
			var trigger_root = this.trigger.Root;
			//EntityPostCreated trigger; //IsContext = True IsNew = False
			trigger_root.AddComponent<MovableController>();
			Entity EntVar530 = (Entity)trigger_root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			if(EntVar530 != null) EntVar530.ComponentAdded();
		}
        }
    }
}
