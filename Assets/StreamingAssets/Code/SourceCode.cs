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
			
			System.Boolean OperandVar11 = default(System.Boolean); //IsContext = False IsNew = False
			Manual StoredVariable10 = ((Manual)root.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
			if(StoredVariable10 != null)
			{
				applicable = true;
				OperandVar11 = applicable;
			}
			return (System.Boolean) (OperandVar11);
		}
        }
        
        public override bool Filter() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Boolean applicable = false; //IsContext = False IsNew = False
			
			
			System.Boolean OperandVar17 = default(System.Boolean); //IsContext = False IsNew = False
			Interactable StoredVariable12 = ((Interactable)root.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
			if(StoredVariable12 != null)
			{
				Manual StoredVariable13 = ((Manual)StoredVariable12.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
				if(StoredVariable13 != null)
				{
					RemoteController StoredVariable14 = ((RemoteController)StoredVariable13.GetComponent(typeof(RemoteController))); //IsContext = False IsNew = False
					if(StoredVariable14 != null)
					{
						System.Boolean ifResult15; //IsContext = False IsNew = False
						RemoteController OperandVar16 = default(RemoteController); //IsContext = False IsNew = False
						OperandVar16 = StoredVariable14;
						if(ifResult15 =  (OperandVar16))
						{
							applicable = true;
							OperandVar17 = applicable;
						}
					}
				}
			}
			return (System.Boolean) (OperandVar17);
		}
        }
        
        public override void Action() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			
			{
				RemoteController subContext18 = (RemoteController)root.GetComponent(typeof(RemoteController)); //IsContext = True IsNew = False
				//ContextStatement RemoteController subContext18 ContextSwitchInterpreter
				if(subContext18 != null)
				{
					
					
					{
						Remote subContext19 = subContext18.Controlled; //IsContext = True IsNew = False
						//ContextStatement Remote subContext19 ContextPropertySwitchInterpreter
						if(subContext19 != null)
						{
							
							{
								LightSource subContext20 = (LightSource)root.GetComponent(typeof(LightSource)); //IsContext = True IsNew = False
								//ContextStatement LightSource subContext20 ContextSwitchInterpreter
								if(subContext20 != null)
								{
									
									
									subContext20.LitUp = (System.Boolean)( (true));
								}
							}
						}
					}
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
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
			
			System.Boolean OperandVar24 = default(System.Boolean); //IsContext = False IsNew = False
			LightSensor StoredVariable21 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable21 != null)
			{
				Actor StoredVariable22 = ((Actor)StoredVariable21.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable22 != null)
				{
					System.Boolean prop23 = StoredVariable22.CanDo(typeof(ScriptedTypes.interaction_lit_up_manual )); //IsContext = False IsNew = False
					applicable = true;
					OperandVar24 = applicable;
				}
			}
			return (System.Boolean) (OperandVar24);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar32 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar27 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			Room StoredVariable25 = ((Room)root.GetComponent(typeof(Room))); //IsContext = False IsNew = False
			if(StoredVariable25 != null)
			{
				System.Collections.Generic.List<UnityEngine.GameObject> prop26 = StoredVariable25.AllObjects; //IsContext = False IsNew = False
				if(prop26 != null)
				{
					OperandVar27 = prop26;
				}
			}
			UnityEngine.GameObject prop31 = External.Any( (OperandVar27),(UnityEngine.GameObject go)=>{;
System.Boolean OperandVar30 = default(System.Boolean); //IsContext = False IsNew = False;
Interactable StoredVariable28 = ((Interactable)go.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False;
if(StoredVariable28 != null)
				{
					System.Boolean prop29 = StoredVariable28.Can(typeof(ScriptedTypes.interaction_lit_up_manual )); //IsContext = False IsNew = False
					OperandVar30 = prop29;
				};
return  (OperandVar30);}); //IsContext = False IsNew = False
			if(prop31 != null)
			{
				OperandVar32 = prop31;
			}
			light =  (OperandVar32);
			
			UnityEngine.GameObject OperandVar33 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar33 = light;
			if( (OperandVar33))
			{
				
				
				
				System.Single OperandVar36 = default(System.Single); //IsContext = False IsNew = False
				LightSensor StoredVariable34 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable34 != null)
				{
					System.Single prop35 = StoredVariable34.Light; //IsContext = False IsNew = False
					OperandVar36 = prop35;
				}
				ut = ( ( (1f))) - ( ( (OperandVar36)));
			}
			return ut;
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			UnityEngine.GameObject OperandVar37 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar37 = light;
			var a38 = Actions.Instance.GetAction(typeof(ScriptedTypes.interaction_lit_up_manual ));
			(a38 as EventInteraction).Initiator = light;
			a38.Root =  (OperandVar37);
			(light.GetComponent(typeof(Actor)) as Actor).Act(a38);
			while(a38.State != EventAction.ActionState.Finished){ if(a38.State == EventAction.ActionState.Failed) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
			this.state = EventAction.ActionState.Finished;
		}
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
			
			System.Boolean OperandVar42 = default(System.Boolean); //IsContext = False IsNew = False
			LightSensor StoredVariable39 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable39 != null)
			{
				Actor StoredVariable40 = ((Actor)StoredVariable39.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
				if(StoredVariable40 != null)
				{
					System.Boolean prop41 = StoredVariable40.CanDo(typeof(ScriptedTypes.interaction_lit_up_remote )); //IsContext = False IsNew = False
					applicable = true;
					OperandVar42 = applicable;
				}
			}
			return (System.Boolean) (OperandVar42);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			UnityEngine.GameObject OperandVar52 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar45 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			Room StoredVariable43 = ((Room)root.GetComponent(typeof(Room))); //IsContext = False IsNew = False
			if(StoredVariable43 != null)
			{
				System.Collections.Generic.List<UnityEngine.GameObject> prop44 = StoredVariable43.AllObjects; //IsContext = False IsNew = False
				if(prop44 != null)
				{
					OperandVar45 = prop44;
				}
			}
			UnityEngine.GameObject prop51 = External.Any( (OperandVar45),(UnityEngine.GameObject go)=>{;
System.Boolean OperandVar50 = default(System.Boolean); //IsContext = False IsNew = False;
Remote StoredVariable46 = ((Remote)go.GetComponent(typeof(Remote))); //IsContext = False IsNew = False;
if(StoredVariable46 != null)
				{
					RemoteController prop47 = StoredVariable46.Controller; //IsContext = False IsNew = False
					if(prop47 != null)
					{
						Interactable StoredVariable48 = ((Interactable)prop47.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
						if(StoredVariable48 != null)
						{
							System.Boolean prop49 = StoredVariable48.Can(typeof(ScriptedTypes.interaction_lit_up_remote )); //IsContext = False IsNew = False
							OperandVar50 = prop49;
						}
					}
				};
return  (OperandVar50);}); //IsContext = False IsNew = False
			if(prop51 != null)
			{
				OperandVar52 = prop51;
			}
			remote_c =  (OperandVar52);
			
			UnityEngine.GameObject OperandVar53 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar53 = remote_c;
			if( (OperandVar53))
			{
				
				
				
				System.Single OperandVar56 = default(System.Single); //IsContext = False IsNew = False
				LightSensor StoredVariable54 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable54 != null)
				{
					System.Single prop55 = StoredVariable54.Light; //IsContext = False IsNew = False
					OperandVar56 = prop55;
				}
				ut = ( ( (1f))) - ( ( (OperandVar56)));
			}
			return ut;
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			UnityEngine.GameObject OperandVar57 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar57 = remote_c;
			var a58 = Actions.Instance.GetAction(typeof(ScriptedTypes.interaction_lit_up_remote ));
			(a58 as EventInteraction).Initiator = remote_c;
			a58.Root =  (OperandVar57);
			(remote_c.GetComponent(typeof(Actor)) as Actor).Act(a58);
			while(a58.State != EventAction.ActionState.Finished){ if(a58.State == EventAction.ActionState.Failed) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
			this.state = EventAction.ActionState.Finished;
		}
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
			
			
			
			System.Boolean OperandVar60 = default(System.Boolean); //IsContext = False IsNew = False
			Movable StoredVariable59 = ((Movable)root.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
			if(StoredVariable59 != null)
			{
				applicable = true;
				OperandVar60 = applicable;
			}
			return (System.Boolean) (OperandVar60);
		}
        }
        
        public override float Utility() {

		{
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			System.Single ut = 0; //IsContext = False IsNew = False
			
			
			
			
			return (System.Single) (0f);
		}
        }
        
        public virtual System.Collections.IEnumerator ActionCoroutine() {

		{
			this.state = EventAction.ActionState.Started;
			var root = this.root;
			
			//ContextStatement External External ContextSwitchInterpreter
			
			
			
			
			{
				Movable subContext61 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext61 ContextSwitchInterpreter
				if(subContext61 != null)
				{
					
					System.Single OperandVar62 = default(System.Single); //IsContext = False IsNew = False
					OperandVar62 = distance;
					UnityEngine.GameObject OperandVar63 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar63 = target;
					subContext61.Goto((System.Single)( (OperandVar62)),(UnityEngine.GameObject)( (OperandVar63)));
					System.Boolean OperandVar65 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop64 = subContext61.IsMoving; //IsContext = False IsNew = False
					OperandVar65 = prop64;
					
					System.Boolean OperandVar67 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop66 = subContext61.IsMoving; //IsContext = False IsNew = False
					OperandVar67 = prop66;
					
					System.Boolean OperandVar69 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop68 = subContext61.NearTarget; //IsContext = False IsNew = False
					OperandVar69 = prop68;
					
					while(!(OperandVar65)){ if(( (!(OperandVar67))) && ( (!(OperandVar69)))) { this.state = EventAction.ActionState.Failed; yield break; } yield return null; }
				}
			}
			this.state = EventAction.ActionState.Finished;
		}
        }
    }
}
namespace ScriptedTypes {
    
    
    public class metrics {
    }
}
