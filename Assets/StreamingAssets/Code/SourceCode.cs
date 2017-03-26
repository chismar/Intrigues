namespace ScriptedTypes {
    
    
    public interface big_quest {
    }
    
    public interface quest {
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
			System.Boolean OperandVar15 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable0 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable0 != null)
			{
				Listener StoredVariable1 = ((Listener)StoredVariable0.GetComponent(typeof(Listener))); //IsContext = False IsNew = False
				if(StoredVariable1 != null)
				{
					Markers StoredVariable2 = ((Markers)StoredVariable1.GetComponent(typeof(Markers))); //IsContext = False IsNew = False
					if(StoredVariable2 != null)
					{
						Relationships StoredVariable3 = ((Relationships)StoredVariable2.GetComponent(typeof(Relationships))); //IsContext = False IsNew = False
						if(StoredVariable3 != null)
						{
							ScriptedTypes.personality StoredVariable4 = ((ScriptedTypes.personality)StoredVariable3.GetComponent(typeof(ScriptedTypes.personality))); //IsContext = False IsNew = False
							if(StoredVariable4 != null)
							{
								System.Boolean ifResult5; //IsContext = False IsNew = False
								
								System.Boolean OperandVar7 = default(System.Boolean); //IsContext = False IsNew = False
								System.Boolean prop6 = StoredVariable0.HasRival(); //IsContext = False IsNew = False
								if(prop6 != false)
								{
									OperandVar7 = prop6;
								}
								
								System.Boolean OperandVar9 = default(System.Boolean); //IsContext = False IsNew = False
								if(StoredVariable1 != null)
								{
									System.Boolean prop8 = StoredVariable1.CanTalk; //IsContext = False IsNew = False
									OperandVar9 = prop8;
								}
								
								
								System.Single OperandVar12 = default(System.Single); //IsContext = False IsNew = False
								UnityEngine.GameObject OperandVar10 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
								OperandVar10 = other;
								System.Single prop11 = StoredVariable3.RelationsWith((UnityEngine.GameObject)( (OperandVar10))); //IsContext = False IsNew = False
								OperandVar12 = prop11;
								
								System.Single OperandVar14 = default(System.Single); //IsContext = False IsNew = False
								System.Single prop13 = StoredVariable4.Trust; //IsContext = False IsNew = False
								OperandVar14 = prop13;
								if(ifResult5 = ( ( (OperandVar7))) && ( ( (OperandVar9))) && ( (( ( (OperandVar12))) >= ( ( (OperandVar14))))))
								{
									applicable = true;
									OperandVar15 = applicable;
								}
							}
						}
					}
				}
			}
			return (System.Boolean) (OperandVar15);
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
				Listener subContext16 = (Listener)root.GetComponent(typeof(Listener)); //IsContext = True IsNew = False
				//ContextStatement Listener subContext16 ContextSwitchInterpreter
				if(subContext16 != null)
				{
					//Listener subContext16; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext17 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext17 ContextSwitchInterpreter
						if(subContext17 != null)
						{
							//ScriptedTypes.facts subContext17; //IsContext = True IsNew = False
							System.Collections.Generic.List<ScriptedTypes.rival> list18 = subContext17.GetRival; //IsContext = False IsNew = False
							for (int i19 = 0; list18 != null && i19 < list18.Count; i19++)
							{
								ScriptedTypes.rival iter20 = list18[i19]; //IsContext = True IsNew = True
								
								{
									ScriptedTypes.rival subContext21 = iter20; //IsContext = True IsNew = False
									//ContextStatement ScriptedTypes.rival subContext21 ContextPropertySwitchInterpreter
									if(subContext21 != null)
									{
										UnityEngine.GameObject OperandVar23 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
										UnityEngine.GameObject prop22 = subContext21.WhoIs; //IsContext = False IsNew = False
										if(prop22 != null)
										{
											OperandVar23 = prop22;
										}
										UnityEngine.GameObject rival_of_root =  (OperandVar23); //IsContext = False IsNew = False
										
										{
											Dialog FuncCtx24 = subContext16.Dialog();; //IsContext = True IsNew = False
											//ContextStatement Dialog FuncCtx24 ContextPropertySwitchInterpreter
											if(FuncCtx24 != null)
											{
												
												System.String OperandVar25 = default(System.String); //IsContext = False IsNew = False
												OperandVar25 = "rival_story";
												
												System.Int32 OperandVar28 = default(System.Int32); //IsContext = False IsNew = False
												Entity StoredVariable26 = ((Entity)rival_of_root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
												if(StoredVariable26 != null)
												{
													System.Int32 prop27 = StoredVariable26.Id; //IsContext = False IsNew = False
													OperandVar28 = prop27;
												}
												FuncCtx24.Id = (System.String)(( ( (OperandVar25))) + ( ( (OperandVar28))));
												System.String OperandVar29 = default(System.String); //IsContext = False IsNew = False
												OperandVar29 = "looks_anxious";
												FuncCtx24.Hook = (System.String)( (OperandVar29));
												FuncCtx24.Utility = (Dialog.FloatDelegate)(()=>{;
return  (1f);});
												FuncCtx24.Allowed = (Dialog.BoolDelegate)(()=>{System.Boolean OperandVar34 = default(System.Boolean); //IsContext = False IsNew = False;
Markers StoredVariable30 = ((Markers)subContext17.GetComponent(typeof(Markers))); //IsContext = False IsNew = False;
if(StoredVariable30 != null)
													{
														System.String OperandVar32 = default(System.String); //IsContext = False IsNew = False
														if(FuncCtx24 != null)
														{
															System.String prop31 = FuncCtx24.Id; //IsContext = False IsNew = False
															if(prop31 != null)
															{
																OperandVar32 = prop31;
															}
														}
														System.Boolean prop33 = StoredVariable30.HasMarker((System.String)( (OperandVar32))); //IsContext = False IsNew = False
														if(prop33 != false)
														{
															OperandVar34 = prop33;
														}
													};
return !(OperandVar34);});
												
												{
													DialogLine FuncCtx35 = FuncCtx24.Say();; //IsContext = True IsNew = False
													//ContextStatement DialogLine FuncCtx35 ContextPropertySwitchInterpreter
													if(FuncCtx35 != null)
													{
														LocalizedString OperandVar39 = default(LocalizedString); //IsContext = False IsNew = False
														UnityEngine.GameObject OperandVar38 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
														OperandVar38 = rival_of_root;
														
														var dict36= new System.Collections.Generic.Dictionary<string, object>();
var localizedString37= new LocalizedString("say_about_rival",dict36);dict36.Add("who", (OperandVar38));
dict36.Add("money", (100f));

														OperandVar39 = localizedString37;
														FuncCtx35.String = (LocalizedString)( (OperandVar39));
														VoidDelegate Lambda40 = () => 
														{
															
															{
																Markers subContext41 = (Markers)root.GetComponent(typeof(Markers)); //IsContext = True IsNew = False
																//ContextStatement Markers subContext41 ContextSwitchInterpreter
																if(subContext41 != null)
																{
																	//Markers subContext41; //IsContext = True IsNew = False
																	System.String OperandVar43 = default(System.String); //IsContext = False IsNew = False
																	if(FuncCtx24 != null)
																	{
																		System.String prop42 = FuncCtx24.Id; //IsContext = False IsNew = False
																		if(prop42 != null)
																		{
																			OperandVar43 = prop42;
																		}
																	}
																	subContext41.SetMarker(( (OperandVar43)).ToString());
																}
															}
														};
														FuncCtx35.Reaction = (VoidDelegate)(Lambda40);
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
			System.Boolean OperandVar45 = default(System.Boolean); //IsContext = False IsNew = False
			Interactable StoredVariable44 = ((Interactable)root.GetComponent(typeof(Interactable))); //IsContext = False IsNew = False
			if(StoredVariable44 != null)
			{
				applicable = true;
				OperandVar45 = applicable;
			}
			return (System.Boolean) (OperandVar45);
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
			Entity EntVar46 = (Entity)root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			if(EntVar46 != null) EntVar46.ComponentAdded();
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
			System.Boolean OperandVar48 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable47 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable47 != null)
			{
				applicable = true;
				OperandVar48 = applicable;
			}
			return (System.Boolean) (OperandVar48);
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
			
			System.String OperandVar49 = default(System.String); //IsContext = False IsNew = False
			OperandVar49 = "player";
			
			{
				UnityEngine.GameObject FuncCtx50 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar49)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx50 ContextPropertySwitchInterpreter
				if(FuncCtx50 != null)
				{
					
					{
						Entity subContext51 = (Entity)FuncCtx50.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext51 ContextSwitchInterpreter
						if(subContext51 != null)
						{
							//Entity subContext51; //IsContext = True IsNew = False
							
							subContext51.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx50.AddComponent<PlayerMarker>();
					Entity EntVar52 = (Entity)FuncCtx50.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					
					{
						Entity subContext53 = (Entity)FuncCtx50.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext53 ContextSwitchInterpreter
						if(subContext53 != null)
						{
							//Entity subContext53; //IsContext = True IsNew = False
							
							subContext53.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx50.AddComponent<ScriptedTypes.chief>();
					if(EntVar52 != null) EntVar52.ComponentAdded();
				}
			}
			
			System.String OperandVar54 = default(System.String); //IsContext = False IsNew = False
			OperandVar54 = "shaman_npc";
			
			{
				UnityEngine.GameObject FuncCtx55 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar54)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx55 ContextPropertySwitchInterpreter
				if(FuncCtx55 != null)
				{
					
					{
						Entity subContext56 = (Entity)FuncCtx55.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext56 ContextSwitchInterpreter
						if(subContext56 != null)
						{
							//Entity subContext56; //IsContext = True IsNew = False
							
							subContext56.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx55.AddComponent<ScriptedTypes.shaman>();
					Entity EntVar57 = (Entity)FuncCtx55.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar57 != null) EntVar57.ComponentAdded();
				}
			}
			
			System.String OperandVar58 = default(System.String); //IsContext = False IsNew = False
			OperandVar58 = "healer_npc";
			
			{
				UnityEngine.GameObject FuncCtx59 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar58)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx59 ContextPropertySwitchInterpreter
				if(FuncCtx59 != null)
				{
					
					{
						Entity subContext60 = (Entity)FuncCtx59.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext60 ContextSwitchInterpreter
						if(subContext60 != null)
						{
							//Entity subContext60; //IsContext = True IsNew = False
							
							subContext60.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx59.AddComponent<ScriptedTypes.healer>();
					Entity EntVar61 = (Entity)FuncCtx59.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar61 != null) EntVar61.ComponentAdded();
				}
			}
			
			System.String OperandVar62 = default(System.String); //IsContext = False IsNew = False
			OperandVar62 = "lair";
			
			{
				UnityEngine.GameObject FuncCtx63 = External.SpawnPrefab(( ("loc")).ToString(),( (OperandVar62)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx63 ContextPropertySwitchInterpreter
				if(FuncCtx63 != null)
				{
					
					{
						Entity subContext64 = (Entity)FuncCtx63.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext64 ContextSwitchInterpreter
						if(subContext64 != null)
						{
							//Entity subContext64; //IsContext = True IsNew = False
							
							subContext64.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx63.AddComponent<ScriptedTypes.monsters_lair>();
					Entity EntVar65 = (Entity)FuncCtx63.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar65 != null) EntVar65.ComponentAdded();
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
			System.Boolean OperandVar67 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable66 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
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
			
			System.String OperandVar68 = default(System.String); //IsContext = False IsNew = False
			OperandVar68 = "player_npc";
			
			{
				UnityEngine.GameObject FuncCtx69 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar68)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx69 ContextPropertySwitchInterpreter
				if(FuncCtx69 != null)
				{
					
					{
						Entity subContext70 = (Entity)FuncCtx69.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext70 ContextSwitchInterpreter
						if(subContext70 != null)
						{
							//Entity subContext70; //IsContext = True IsNew = False
							
							subContext70.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx69.AddComponent<PlayerMarker>();
					Entity EntVar71 = (Entity)FuncCtx69.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					
					{
						Entity subContext72 = (Entity)FuncCtx69.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext72 ContextSwitchInterpreter
						if(subContext72 != null)
						{
							//Entity subContext72; //IsContext = True IsNew = False
							
							subContext72.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx69.AddComponent<ScriptedTypes.shaman>();
					if(EntVar71 != null) EntVar71.ComponentAdded();
				}
			}
			
			System.String OperandVar73 = default(System.String); //IsContext = False IsNew = False
			OperandVar73 = "chief_npc";
			
			{
				UnityEngine.GameObject FuncCtx74 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar73)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx74 ContextPropertySwitchInterpreter
				if(FuncCtx74 != null)
				{
					
					{
						Entity subContext75 = (Entity)FuncCtx74.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext75 ContextSwitchInterpreter
						if(subContext75 != null)
						{
							//Entity subContext75; //IsContext = True IsNew = False
							
							subContext75.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx74.AddComponent<ScriptedTypes.chief>();
					Entity EntVar76 = (Entity)FuncCtx74.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar76 != null) EntVar76.ComponentAdded();
				}
			}
			
			System.String OperandVar77 = default(System.String); //IsContext = False IsNew = False
			OperandVar77 = "healer_npc";
			
			{
				UnityEngine.GameObject FuncCtx78 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar77)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx78 ContextPropertySwitchInterpreter
				if(FuncCtx78 != null)
				{
					
					{
						Entity subContext79 = (Entity)FuncCtx78.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext79 ContextSwitchInterpreter
						if(subContext79 != null)
						{
							//Entity subContext79; //IsContext = True IsNew = False
							
							subContext79.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx78.AddComponent<ScriptedTypes.healer>();
					Entity EntVar80 = (Entity)FuncCtx78.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar80 != null) EntVar80.ComponentAdded();
				}
			}
			
			System.String OperandVar81 = default(System.String); //IsContext = False IsNew = False
			OperandVar81 = "altar";
			
			{
				UnityEngine.GameObject FuncCtx82 = External.SpawnPrefab(( ("loc")).ToString(),( (OperandVar81)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx82 ContextPropertySwitchInterpreter
				if(FuncCtx82 != null)
				{
					
					{
						Entity subContext83 = (Entity)FuncCtx82.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext83 ContextSwitchInterpreter
						if(subContext83 != null)
						{
							//Entity subContext83; //IsContext = True IsNew = False
							
							subContext83.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx82.AddComponent<ScriptedTypes.ancient_altar>();
					Entity EntVar84 = (Entity)FuncCtx82.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar84 != null) EntVar84.ComponentAdded();
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
			
			System.String OperandVar87 = default(System.String); //IsContext = False IsNew = False
			OperandVar87 = "player_npc";
			
			{
				UnityEngine.GameObject FuncCtx88 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar87)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx88 ContextPropertySwitchInterpreter
				if(FuncCtx88 != null)
				{
					
					{
						Entity subContext89 = (Entity)FuncCtx88.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext89 ContextSwitchInterpreter
						if(subContext89 != null)
						{
							//Entity subContext89; //IsContext = True IsNew = False
							
							subContext89.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx88.AddComponent<PlayerMarker>();
					Entity EntVar90 = (Entity)FuncCtx88.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					
					{
						Entity subContext91 = (Entity)FuncCtx88.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext91 ContextSwitchInterpreter
						if(subContext91 != null)
						{
							//Entity subContext91; //IsContext = True IsNew = False
							
							subContext91.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx88.AddComponent<ScriptedTypes.healer>();
					if(EntVar90 != null) EntVar90.ComponentAdded();
				}
			}
			
			System.String OperandVar92 = default(System.String); //IsContext = False IsNew = False
			OperandVar92 = "chief_npc";
			
			{
				UnityEngine.GameObject FuncCtx93 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar92)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx93 ContextPropertySwitchInterpreter
				if(FuncCtx93 != null)
				{
					
					{
						Entity subContext94 = (Entity)FuncCtx93.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext94 ContextSwitchInterpreter
						if(subContext94 != null)
						{
							//Entity subContext94; //IsContext = True IsNew = False
							
							subContext94.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx93.AddComponent<ScriptedTypes.chief>();
					Entity EntVar95 = (Entity)FuncCtx93.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar95 != null) EntVar95.ComponentAdded();
				}
			}
			
			System.String OperandVar96 = default(System.String); //IsContext = False IsNew = False
			OperandVar96 = "shaman_npc";
			
			{
				UnityEngine.GameObject FuncCtx97 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar96)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx97 ContextPropertySwitchInterpreter
				if(FuncCtx97 != null)
				{
					
					{
						Entity subContext98 = (Entity)FuncCtx97.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext98 ContextSwitchInterpreter
						if(subContext98 != null)
						{
							//Entity subContext98; //IsContext = True IsNew = False
							
							subContext98.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx97.AddComponent<ScriptedTypes.shaman>();
					Entity EntVar99 = (Entity)FuncCtx97.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar99 != null) EntVar99.ComponentAdded();
				}
			}
			
			System.String OperandVar100 = default(System.String); //IsContext = False IsNew = False
			OperandVar100 = "kurgan";
			
			{
				UnityEngine.GameObject FuncCtx101 = External.SpawnPrefab(( ("loc")).ToString(),( (OperandVar100)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx101 ContextPropertySwitchInterpreter
				if(FuncCtx101 != null)
				{
					
					{
						Entity subContext102 = (Entity)FuncCtx101.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext102 ContextSwitchInterpreter
						if(subContext102 != null)
						{
							//Entity subContext102; //IsContext = True IsNew = False
							
							subContext102.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx101.AddComponent<ScriptedTypes.evil_kurgan>();
					Entity EntVar103 = (Entity)FuncCtx101.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar103 != null) EntVar103.ComponentAdded();
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
			System.Boolean OperandVar108 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable104 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable104 != null)
			{
				System.Boolean ifResult105; //IsContext = False IsNew = False
				
				System.Int32 OperandVar107 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop106 = StoredVariable104.Quests; //IsContext = False IsNew = False
				OperandVar107 = prop106;
				
				
				if(ifResult105 = ( ( (OperandVar107))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar108 = applicable;
				}
			}
			return (System.Boolean) (OperandVar108);
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
			System.Int32 OperandVar114 = default(System.Int32); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar110 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop109 = External.AllActors; //IsContext = False IsNew = False
			if(prop109 != null)
			{
				OperandVar110 = prop109;
			}
			System.Int32 prop113 = External.Amount((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar110)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.warrior OperandVar112 = default(ScriptedTypes.warrior); //IsContext = False IsNew = False;
ScriptedTypes.warrior StoredVariable111 = ((ScriptedTypes.warrior)go.GetComponent(typeof(ScriptedTypes.warrior))); //IsContext = False IsNew = False;
if(StoredVariable111 != null)
				{
					OperandVar112 = StoredVariable111;
				};
return  (OperandVar112);}); //IsContext = False IsNew = False
			OperandVar114 = prop113;
			System.Int32 a =  (OperandVar114); //IsContext = False IsNew = False
			
			System.Int32 OperandVar115 = default(System.Int32); //IsContext = False IsNew = False
			OperandVar115 = a;
			
			
			if(( ( (OperandVar115))) < ( ( (3f))))
			{
				System.Int32 OperandVar119 = default(System.Int32); //IsContext = False IsNew = False
				
				
				
				System.Int32 OperandVar116 = default(System.Int32); //IsContext = False IsNew = False
				OperandVar116 = a;
				
				
				
				System.Int32 OperandVar117 = default(System.Int32); //IsContext = False IsNew = False
				OperandVar117 = a;
				System.Int32 prop118 = External.RandomRange((System.Int32)(( ( (3f))) - ( ( (OperandVar116)))),(System.Int32)(( ( (5f))) - ( ( (OperandVar117))))); //IsContext = False IsNew = False
				OperandVar119 = prop118;
				for (int i120 = 0; i120 <  (OperandVar119); i120++)
				{
					
					System.String OperandVar121 = default(System.String); //IsContext = False IsNew = False
					OperandVar121 = "human_npc";
					
					{
						UnityEngine.GameObject FuncCtx122 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar121)).ToString());; //IsContext = True IsNew = False
						//ContextStatement UnityEngine.GameObject FuncCtx122 ContextPropertySwitchInterpreter
						if(FuncCtx122 != null)
						{
							
							{
								Entity subContext123 = (Entity)FuncCtx122.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
								//ContextStatement Entity subContext123 ContextSwitchInterpreter
								if(subContext123 != null)
								{
									//Entity subContext123; //IsContext = True IsNew = False
									
									subContext123.RandomOffset((System.Single)( (10f)));
								}
							}
							FuncCtx122.AddComponent<ScriptedTypes.warrior>();
							Entity EntVar124 = (Entity)FuncCtx122.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
							if(EntVar124 != null) EntVar124.ComponentAdded();
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
			System.Boolean OperandVar129 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable125 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable125 != null)
			{
				System.Boolean ifResult126; //IsContext = False IsNew = False
				
				System.Int32 OperandVar128 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop127 = StoredVariable125.Quests; //IsContext = False IsNew = False
				OperandVar128 = prop127;
				
				
				if(ifResult126 = ( ( (OperandVar128))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar129 = applicable;
				}
			}
			return (System.Boolean) (OperandVar129);
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
			
			System.String OperandVar130 = default(System.String); //IsContext = False IsNew = False
			OperandVar130 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx131 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar130)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx131 ContextPropertySwitchInterpreter
				if(FuncCtx131 != null)
				{
					
					{
						Entity subContext132 = (Entity)FuncCtx131.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext132 ContextSwitchInterpreter
						if(subContext132 != null)
						{
							//Entity subContext132; //IsContext = True IsNew = False
							
							subContext132.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx131.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar133 = (Entity)FuncCtx131.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar133 != null) EntVar133.ComponentAdded();
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
			System.Boolean OperandVar138 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable134 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable134 != null)
			{
				System.Boolean ifResult135; //IsContext = False IsNew = False
				
				System.Int32 OperandVar137 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop136 = StoredVariable134.Quests; //IsContext = False IsNew = False
				OperandVar137 = prop136;
				
				
				if(ifResult135 = ( ( (OperandVar137))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar138 = applicable;
				}
			}
			return (System.Boolean) (OperandVar138);
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
			
			System.String OperandVar139 = default(System.String); //IsContext = False IsNew = False
			OperandVar139 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx140 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar139)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx140 ContextPropertySwitchInterpreter
				if(FuncCtx140 != null)
				{
					
					{
						Entity subContext141 = (Entity)FuncCtx140.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext141 ContextSwitchInterpreter
						if(subContext141 != null)
						{
							//Entity subContext141; //IsContext = True IsNew = False
							
							subContext141.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx140.AddComponent<ScriptedTypes.blacksmith>();
					Entity EntVar142 = (Entity)FuncCtx140.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar142 != null) EntVar142.ComponentAdded();
				}
			}
			
			{
				Story subContext143 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext143 ContextSwitchInterpreter
				if(subContext143 != null)
				{
					//Story subContext143; //IsContext = True IsNew = False
					
					System.Int32 OperandVar145 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop144 = subContext143.Quests; //IsContext = False IsNew = False
					OperandVar145 = prop144;
					
					
					subContext143.Quests = (System.Int32)(( ( (OperandVar145))) + ( ( (1f))));
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
			System.Boolean OperandVar154 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable146 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable146 != null)
			{
				System.Boolean ifResult147; //IsContext = False IsNew = False
				
				
				System.Int32 OperandVar149 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop148 = StoredVariable146.Quests; //IsContext = False IsNew = False
				OperandVar149 = prop148;
				
				
				
				
				System.Int32 OperandVar153 = default(System.Int32); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> OperandVar151 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> prop150 = External.AllEntities(); //IsContext = False IsNew = False
				if(prop150 != null)
				{
					OperandVar151 = prop150;
				}
				System.Int32 prop152 = External.Amount((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar151)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
;
return  (true);}); //IsContext = False IsNew = False
				OperandVar153 = prop152;
				
				
				if(ifResult147 = ( (( ( (OperandVar149))) < ( ( (5f))))) && ( (( ( (OperandVar153))) > ( ( (8f))))))
				{
					applicable = true;
					OperandVar154 = applicable;
				}
			}
			return (System.Boolean) (OperandVar154);
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
				UnityEngine.GameObject FuncCtx155 = External.SpawnPrefab(( ("npc")).ToString(),( ("old_friend")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx155 ContextPropertySwitchInterpreter
				if(FuncCtx155 != null)
				{
					
					{
						Entity subContext156 = (Entity)FuncCtx155.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext156 ContextSwitchInterpreter
						if(subContext156 != null)
						{
							//Entity subContext156; //IsContext = True IsNew = False
							
							subContext156.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx155.AddComponent<ScriptedTypes.artisan>();
					Entity EntVar157 = (Entity)FuncCtx155.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					FuncCtx155.AddComponent<ScriptedTypes.old_friend>();
					if(EntVar157 != null) EntVar157.ComponentAdded();
				}
			}
			
			{
				Story subContext158 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext158 ContextSwitchInterpreter
				if(subContext158 != null)
				{
					//Story subContext158; //IsContext = True IsNew = False
					
					System.Int32 OperandVar160 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop159 = subContext158.Quests; //IsContext = False IsNew = False
					OperandVar160 = prop159;
					
					
					subContext158.Quests = (System.Int32)(( ( (OperandVar160))) + ( ( (1f))));
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
			System.Boolean OperandVar165 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable161 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable161 != null)
			{
				System.Boolean ifResult162; //IsContext = False IsNew = False
				
				System.Int32 OperandVar164 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop163 = StoredVariable161.Quests; //IsContext = False IsNew = False
				OperandVar164 = prop163;
				
				
				if(ifResult162 = ( ( (OperandVar164))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar165 = applicable;
				}
			}
			return (System.Boolean) (OperandVar165);
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
				UnityEngine.GameObject FuncCtx166 = External.SpawnPrefab(( ("npc")).ToString(),( ("monster")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx166 ContextPropertySwitchInterpreter
				if(FuncCtx166 != null)
				{
					
					{
						Entity subContext167 = (Entity)FuncCtx166.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext167 ContextSwitchInterpreter
						if(subContext167 != null)
						{
							//Entity subContext167; //IsContext = True IsNew = False
							
							subContext167.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx166.AddComponent<ScriptedTypes.monster>();
					Entity EntVar168 = (Entity)FuncCtx166.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar168 != null) EntVar168.ComponentAdded();
				}
			}
			
			{
				Story subContext169 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext169 ContextSwitchInterpreter
				if(subContext169 != null)
				{
					//Story subContext169; //IsContext = True IsNew = False
					
					System.Int32 OperandVar171 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop170 = subContext169.Quests; //IsContext = False IsNew = False
					OperandVar171 = prop170;
					
					
					subContext169.Quests = (System.Int32)(( ( (OperandVar171))) + ( ( (1f))));
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
			System.Boolean OperandVar176 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable172 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable172 != null)
			{
				System.Boolean ifResult173; //IsContext = False IsNew = False
				
				System.Int32 OperandVar175 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop174 = StoredVariable172.Quests; //IsContext = False IsNew = False
				OperandVar175 = prop174;
				
				
				if(ifResult173 = ( ( (OperandVar175))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar176 = applicable;
				}
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
			
			System.String OperandVar177 = default(System.String); //IsContext = False IsNew = False
			OperandVar177 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx178 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar177)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx178 ContextPropertySwitchInterpreter
				if(FuncCtx178 != null)
				{
					
					{
						Entity subContext179 = (Entity)FuncCtx178.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext179 ContextSwitchInterpreter
						if(subContext179 != null)
						{
							//Entity subContext179; //IsContext = True IsNew = False
							
							subContext179.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx178.AddComponent<ScriptedTypes.trader>();
					Entity EntVar180 = (Entity)FuncCtx178.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar180 != null) EntVar180.ComponentAdded();
				}
			}
			
			{
				Story subContext181 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext181 ContextSwitchInterpreter
				if(subContext181 != null)
				{
					//Story subContext181; //IsContext = True IsNew = False
					
					System.Int32 OperandVar183 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop182 = subContext181.Quests; //IsContext = False IsNew = False
					OperandVar183 = prop182;
					
					
					subContext181.Quests = (System.Int32)(( ( (OperandVar183))) + ( ( (1f))));
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
			System.Boolean OperandVar188 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable184 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable184 != null)
			{
				System.Boolean ifResult185; //IsContext = False IsNew = False
				
				System.Int32 OperandVar187 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop186 = StoredVariable184.Quests; //IsContext = False IsNew = False
				OperandVar187 = prop186;
				
				
				if(ifResult185 = ( ( (OperandVar187))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar188 = applicable;
				}
			}
			return (System.Boolean) (OperandVar188);
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
			UnityEngine.GameObject OperandVar190 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop189 = External.NoOne(); //IsContext = False IsNew = False
			if(prop189 != null)
			{
				OperandVar190 = prop189;
			}
			UnityEngine.GameObject farmer_npc =  (OperandVar190); //IsContext = False IsNew = False
			
			
			
			{
				UnityEngine.GameObject FuncCtx191 = External.SpawnPrefab(( ("npc")).ToString(),( ("human_npc")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx191 ContextPropertySwitchInterpreter
				if(FuncCtx191 != null)
				{
					
					{
						Entity subContext192 = (Entity)FuncCtx191.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext192 ContextSwitchInterpreter
						if(subContext192 != null)
						{
							//Entity subContext192; //IsContext = True IsNew = False
							
							subContext192.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx191.AddComponent<ScriptedTypes.farmer>();
					Entity EntVar193 = (Entity)FuncCtx191.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar193 != null) EntVar193.ComponentAdded();
					UnityEngine.GameObject OperandVar194 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar194 = FuncCtx191;
					farmer_npc =  (OperandVar194);
				}
			}
			UnityEngine.GameObject OperandVar196 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop195 = External.NoOne(); //IsContext = False IsNew = False
			if(prop195 != null)
			{
				OperandVar196 = prop195;
			}
			UnityEngine.GameObject farm_loc =  (OperandVar196); //IsContext = False IsNew = False
			
			
			
			{
				UnityEngine.GameObject FuncCtx197 = External.SpawnPrefab(( ("loc")).ToString(),( ("farm")).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx197 ContextPropertySwitchInterpreter
				if(FuncCtx197 != null)
				{
					
					{
						Entity subContext198 = (Entity)FuncCtx197.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext198 ContextSwitchInterpreter
						if(subContext198 != null)
						{
							//Entity subContext198; //IsContext = True IsNew = False
							
							subContext198.RandomOffset((System.Single)( (10f)));
						}
					}
					FuncCtx197.AddComponent<ScriptedTypes.infestation>();
					Entity EntVar199 = (Entity)FuncCtx197.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					FuncCtx197.AddComponent<ScriptedTypes.farm>();
					if(EntVar199 != null) EntVar199.ComponentAdded();
					UnityEngine.GameObject OperandVar200 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar200 = FuncCtx197;
					farm_loc =  (OperandVar200);
				}
			}
			
			{
				//ContextStatement UnityEngine.GameObject farm_loc ContextSwitchInterpreter
				if(farm_loc != null)
				{
					//UnityEngine.GameObject farm_loc; //IsContext = True IsNew = False
					
					{
						ScriptedTypes.facts subContext201 = (ScriptedTypes.facts)farm_loc.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext201 ContextSwitchInterpreter
						if(subContext201 != null)
						{
							//ScriptedTypes.facts subContext201; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.owned FuncCtx202 = subContext201.AddOwned();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.owned FuncCtx202 ContextPropertySwitchInterpreter
								if(FuncCtx202 != null)
								{
									UnityEngine.GameObject OperandVar203 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar203 = farmer_npc;
									UnityEngine.GameObject by =  (OperandVar203); //IsContext = False IsNew = False
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
						ScriptedTypes.facts subContext204 = (ScriptedTypes.facts)farmer_npc.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext204 ContextSwitchInterpreter
						if(subContext204 != null)
						{
							//ScriptedTypes.facts subContext204; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.owner FuncCtx205 = subContext204.AddOwner();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.owner FuncCtx205 ContextPropertySwitchInterpreter
								if(FuncCtx205 != null)
								{
									UnityEngine.GameObject OperandVar206 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar206 = farm_loc;
									FuncCtx205.OfWhat = (UnityEngine.GameObject)( (OperandVar206));
								}
							}
						}
					}
				}
			}
			
			{
				Story subContext207 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext207 ContextSwitchInterpreter
				if(subContext207 != null)
				{
					//Story subContext207; //IsContext = True IsNew = False
					
					System.Int32 OperandVar209 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop208 = subContext207.Quests; //IsContext = False IsNew = False
					OperandVar209 = prop208;
					
					
					subContext207.Quests = (System.Int32)(( ( (OperandVar209))) + ( ( (1f))));
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
			System.Boolean OperandVar214 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable210 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable210 != null)
			{
				System.Boolean ifResult211; //IsContext = False IsNew = False
				
				System.Int32 OperandVar213 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop212 = StoredVariable210.Quests; //IsContext = False IsNew = False
				OperandVar213 = prop212;
				
				
				if(ifResult211 = ( ( (OperandVar213))) < ( ( (5f))))
				{
					applicable = true;
					OperandVar214 = applicable;
				}
			}
			return (System.Boolean) (OperandVar214);
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
			UnityEngine.GameObject OperandVar216 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop215 = External.NoOne(); //IsContext = False IsNew = False
			if(prop215 != null)
			{
				OperandVar216 = prop215;
			}
			UnityEngine.GameObject mine_loc =  (OperandVar216); //IsContext = False IsNew = False
			
			
			
			{
				UnityEngine.GameObject FuncCtx217 = External.SpawnPrefab(( ("loc")).ToString(),( ("mine")).ToString());; //IsContext = True IsNew = False
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
					FuncCtx217.AddComponent<ScriptedTypes.mine>();
					Entity EntVar219 = (Entity)FuncCtx217.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					
					FuncCtx217.AddComponent<ScriptedTypes.ancient>();
					if(EntVar219 != null) EntVar219.ComponentAdded();
					UnityEngine.GameObject OperandVar220 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar220 = FuncCtx217;
					mine_loc =  (OperandVar220);
				}
			}
			
			System.String OperandVar221 = default(System.String); //IsContext = False IsNew = False
			OperandVar221 = "human_npc";
			
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
					FuncCtx222.AddComponent<ScriptedTypes.artisan>();
					Entity EntVar224 = (Entity)FuncCtx222.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
					if(EntVar224 != null) EntVar224.ComponentAdded();
					
					{
						ScriptedTypes.facts subContext225 = (ScriptedTypes.facts)FuncCtx222.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
						//ContextStatement ScriptedTypes.facts subContext225 ContextSwitchInterpreter
						if(subContext225 != null)
						{
							//ScriptedTypes.facts subContext225; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.wants_old_world_metal FuncCtx226 = subContext225.AddWantsOldWorldMetal();; //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.wants_old_world_metal FuncCtx226 ContextPropertySwitchInterpreter
								if(FuncCtx226 != null)
								{
									UnityEngine.GameObject OperandVar227 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar227 = mine_loc;
									FuncCtx226.Where = (UnityEngine.GameObject)( (OperandVar227));
								}
							}
						}
					}
				}
			}
			
			{
				Story subContext228 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext228 ContextSwitchInterpreter
				if(subContext228 != null)
				{
					//Story subContext228; //IsContext = True IsNew = False
					
					System.Int32 OperandVar230 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop229 = subContext228.Quests; //IsContext = False IsNew = False
					OperandVar230 = prop229;
					
					
					subContext228.Quests = (System.Int32)(( ( (OperandVar230))) + ( ( (1f))));
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
			System.Boolean OperandVar247 = default(System.Boolean); //IsContext = False IsNew = False
			Story StoredVariable231 = ((Story)root.GetComponent(typeof(Story))); //IsContext = False IsNew = False
			if(StoredVariable231 != null)
			{
				System.Boolean ifResult232; //IsContext = False IsNew = False
				
				
				System.Int32 OperandVar234 = default(System.Int32); //IsContext = False IsNew = False
				System.Int32 prop233 = StoredVariable231.Quests; //IsContext = False IsNew = False
				OperandVar234 = prop233;
				
				
				
				
				
				
				System.Int32 OperandVar240 = default(System.Int32); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> OperandVar236 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> prop235 = External.AllEntities(); //IsContext = False IsNew = False
				if(prop235 != null)
				{
					OperandVar236 = prop235;
				}
				System.Int32 prop239 = External.Amount((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar236)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.blacksmith OperandVar238 = default(ScriptedTypes.blacksmith); //IsContext = False IsNew = False;
ScriptedTypes.blacksmith StoredVariable237 = ((ScriptedTypes.blacksmith)go.GetComponent(typeof(ScriptedTypes.blacksmith))); //IsContext = False IsNew = False;
if(StoredVariable237 != null)
					{
						OperandVar238 = StoredVariable237;
					};
return  (OperandVar238);}); //IsContext = False IsNew = False
				OperandVar240 = prop239;
				
				
				
				
				System.Int32 OperandVar246 = default(System.Int32); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> OperandVar242 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> prop241 = External.AllEntities(); //IsContext = False IsNew = False
				if(prop241 != null)
				{
					OperandVar242 = prop241;
				}
				System.Int32 prop245 = External.Amount((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar242)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.artisan OperandVar244 = default(ScriptedTypes.artisan); //IsContext = False IsNew = False;
ScriptedTypes.artisan StoredVariable243 = ((ScriptedTypes.artisan)go.GetComponent(typeof(ScriptedTypes.artisan))); //IsContext = False IsNew = False;
if(StoredVariable243 != null)
					{
						OperandVar244 = StoredVariable243;
					};
return  (OperandVar244);}); //IsContext = False IsNew = False
				OperandVar246 = prop245;
				
				
				if(ifResult232 = ( (( ( (OperandVar234))) < ( ( (5f))))) && ( ( (( (( ( (OperandVar240))) > ( ( (0f))))) || ( (( ( (OperandVar246))) > ( ( (0f)))))))))
				{
					applicable = true;
					OperandVar247 = applicable;
				}
			}
			return (System.Boolean) (OperandVar247);
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
			UnityEngine.GameObject OperandVar253 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar249 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop248 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop248 != null)
			{
				OperandVar249 = prop248;
			}
			UnityEngine.GameObject prop252 = External.Any((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar249)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.blacksmith OperandVar251 = default(ScriptedTypes.blacksmith); //IsContext = False IsNew = False;
ScriptedTypes.blacksmith StoredVariable250 = ((ScriptedTypes.blacksmith)go.GetComponent(typeof(ScriptedTypes.blacksmith))); //IsContext = False IsNew = False;
if(StoredVariable250 != null)
				{
					OperandVar251 = StoredVariable250;
				};
return  (OperandVar251);}); //IsContext = False IsNew = False
			if(prop252 != null)
			{
				OperandVar253 = prop252;
			}
			UnityEngine.GameObject master =  (OperandVar253); //IsContext = False IsNew = False
			System.Boolean OperandVar256 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar254 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar254 = master;
			System.Boolean prop255 = External.Has((UnityEngine.GameObject)( (OperandVar254))); //IsContext = False IsNew = False
			if(prop255 != false)
			{
				OperandVar256 = prop255;
			}
			if(!(OperandVar256))
			{
				UnityEngine.GameObject OperandVar262 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> OperandVar258 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
				System.Collections.Generic.List<UnityEngine.GameObject> prop257 = External.AllEntities(); //IsContext = False IsNew = False
				if(prop257 != null)
				{
					OperandVar258 = prop257;
				}
				UnityEngine.GameObject prop261 = External.Any((System.Collections.Generic.List<UnityEngine.GameObject>)( (OperandVar258)),(UnityEngine.GameObject go)=>{//UnityEngine.GameObject go; //IsContext = True IsNew = False;
ScriptedTypes.artisan OperandVar260 = default(ScriptedTypes.artisan); //IsContext = False IsNew = False;
ScriptedTypes.artisan StoredVariable259 = ((ScriptedTypes.artisan)go.GetComponent(typeof(ScriptedTypes.artisan))); //IsContext = False IsNew = False;
if(StoredVariable259 != null)
					{
						OperandVar260 = StoredVariable259;
					};
return  (OperandVar260);}); //IsContext = False IsNew = False
				if(prop261 != null)
				{
					OperandVar262 = prop261;
				}
				master =  (OperandVar262);
			}
			UnityEngine.GameObject OperandVar264 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop263 = External.NoOne(); //IsContext = False IsNew = False
			if(prop263 != null)
			{
				OperandVar264 = prop263;
			}
			UnityEngine.GameObject app =  (OperandVar264); //IsContext = False IsNew = False
			
			System.String OperandVar265 = default(System.String); //IsContext = False IsNew = False
			OperandVar265 = "human_npc";
			
			{
				UnityEngine.GameObject FuncCtx266 = External.SpawnPrefab(( ("npc")).ToString(),( (OperandVar265)).ToString());; //IsContext = True IsNew = False
				//ContextStatement UnityEngine.GameObject FuncCtx266 ContextPropertySwitchInterpreter
				if(FuncCtx266 != null)
				{
					
					{
						Entity subContext267 = (Entity)FuncCtx266.GetComponent(typeof(Entity)); //IsContext = True IsNew = False
						//ContextStatement Entity subContext267 ContextSwitchInterpreter
						if(subContext267 != null)
						{
							//Entity subContext267; //IsContext = True IsNew = False
							
							subContext267.RandomOffset((System.Single)( (10f)));
						}
					}
					System.Int32 OperandVar269 = default(System.Int32); //IsContext = False IsNew = False
					
					
					System.Int32 prop268 = External.RandomRange((System.Int32)( (0f)),(System.Int32)( (2f))); //IsContext = False IsNew = False
					OperandVar269 = prop268;
					System.Int32 r =  (OperandVar269); //IsContext = False IsNew = False
					UnityEngine.GameObject OperandVar270 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar270 = FuncCtx266;
					app =  (OperandVar270);
					
					{
						//ContextStatement UnityEngine.GameObject app ContextSwitchInterpreter
						if(app != null)
						{
							//UnityEngine.GameObject app; //IsContext = True IsNew = False
							app.AddComponent<ScriptedTypes.artisan>();
							Entity EntVar271 = (Entity)app.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
							if(EntVar271 != null) EntVar271.ComponentAdded();
						}
					}
					
					{
						//ContextStatement UnityEngine.GameObject app ContextSwitchInterpreter
						if(app != null)
						{
							//UnityEngine.GameObject app; //IsContext = True IsNew = False
							ScriptedTypes.apprentice ContextVar272 = app.AddComponent<ScriptedTypes.apprentice>();; //IsContext = False IsNew = True
							
							{
								//ContextStatement ScriptedTypes.apprentice ContextVar272 ContextSwitchInterpreter
								if(ContextVar272 != null)
								{
									//ScriptedTypes.apprentice ContextVar272; //IsContext = True IsNew = False
									UnityEngine.GameObject OperandVar273 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar273 = master;
									ContextVar272.Of = (UnityEngine.GameObject)( (OperandVar273));
								}
							}
							Entity EntVar274 = (Entity)app.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
							if(EntVar274 != null) EntVar274.ComponentAdded();
						}
					}
					
					{
						//ContextStatement UnityEngine.GameObject master ContextSwitchInterpreter
						if(master != null)
						{
							//UnityEngine.GameObject master; //IsContext = True IsNew = False
							
							{
								ScriptedTypes.artisan subContext275 = (ScriptedTypes.artisan)master.GetComponent(typeof(ScriptedTypes.artisan)); //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.artisan subContext275 ContextSwitchInterpreter
								if(subContext275 != null)
								{
									//ScriptedTypes.artisan subContext275; //IsContext = True IsNew = False
									UnityEngine.GameObject OperandVar276 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar276 = app;
									subContext275.OwnApprentice = (UnityEngine.GameObject)( (OperandVar276));
								}
							}
							
							{
								ScriptedTypes.blacksmith subContext277 = (ScriptedTypes.blacksmith)master.GetComponent(typeof(ScriptedTypes.blacksmith)); //IsContext = True IsNew = False
								//ContextStatement ScriptedTypes.blacksmith subContext277 ContextSwitchInterpreter
								if(subContext277 != null)
								{
									//ScriptedTypes.blacksmith subContext277; //IsContext = True IsNew = False
									UnityEngine.GameObject OperandVar278 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
									OperandVar278 = app;
									subContext277.OwnApprentice = (UnityEngine.GameObject)( (OperandVar278));
								}
							}
						}
					}
				}
			}
			
			{
				Story subContext279 = (Story)root.GetComponent(typeof(Story)); //IsContext = True IsNew = False
				//ContextStatement Story subContext279 ContextSwitchInterpreter
				if(subContext279 != null)
				{
					//Story subContext279; //IsContext = True IsNew = False
					
					System.Int32 OperandVar281 = default(System.Int32); //IsContext = False IsNew = False
					System.Int32 prop280 = subContext279.Quests; //IsContext = False IsNew = False
					OperandVar281 = prop280;
					
					
					subContext279.Quests = (System.Int32)(( ( (OperandVar281))) + ( ( (1f))));
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
			LocalizedString OperandVar300 = default(LocalizedString); //IsContext = False IsNew = False
			UnityEngine.GameObject OperandVar297 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar297 = root;
			UnityEngine.GameObject OperandVar298 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar298 = other;
			System.Single OperandVar299 = default(System.Single); //IsContext = False IsNew = False
			OperandVar299 = distance;
			var dict295= new System.Collections.Generic.Dictionary<string, object>();
var localizedString296= new LocalizedString("should_be_near",dict295);dict295.Add("who", (OperandVar297));
dict295.Add("other", (OperandVar298));
dict295.Add("distance", (OperandVar299));

			OperandVar300 = localizedString296;
			return  (OperandVar300);
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
				Entity OperandVar283 = default(Entity); //IsContext = False IsNew = False
				Entity StoredVariable282 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable282 != null)
				{
					OperandVar283 = StoredVariable282;
				}
				s =  (OperandVar283);
			}
			
			{
				Entity OperandVar285 = default(Entity); //IsContext = False IsNew = False
				Entity StoredVariable284 = ((Entity)other.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable284 != null)
				{
					OperandVar285 = StoredVariable284;
				}
				o =  (OperandVar285);
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
				System.Single OperandVar286 = default(System.Single); //IsContext = False IsNew = False
				OperandVar286 = distance;
				properTask.OkDistance =  (OperandVar286);
			}
			
			{
				UnityEngine.GameObject OperandVar287 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
				OperandVar287 = other;
				properTask.Who =  (OperandVar287);
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
			
			System.Single OperandVar293 = default(System.Single); //IsContext = False IsNew = False
			
			UnityEngine.Vector3 OperandVar289 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			UnityEngine.Vector3 prop288 = s.Position; //IsContext = False IsNew = False
			OperandVar289 = prop288;
			
			UnityEngine.Vector3 OperandVar291 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			UnityEngine.Vector3 prop290 = o.Position; //IsContext = False IsNew = False
			OperandVar291 = prop290;
			System.Single prop292 = External.Mag((UnityEngine.Vector3)(( ( (OperandVar289))) - ( ( (OperandVar291))))); //IsContext = False IsNew = False
			OperandVar293 = prop292;
			
			
			
			System.Single OperandVar294 = default(System.Single); //IsContext = False IsNew = False
			OperandVar294 = distance;
			
			
			return (System.Boolean)(( ( (OperandVar293))) <=( ( (( ( (OperandVar294))) + ( ( (0.1f)))))));
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
			System.Boolean OperandVar305 = default(System.Boolean); //IsContext = False IsNew = False
			LightSource StoredVariable301 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable301 != null)
			{
				System.Boolean ifResult302; //IsContext = False IsNew = False
				System.Boolean OperandVar304 = default(System.Boolean); //IsContext = False IsNew = False
				System.Boolean prop303 = StoredVariable301.LitUp; //IsContext = False IsNew = False
				OperandVar304 = prop303;
				if(ifResult302 = !(OperandVar304))
				{
					applicable = true;
					OperandVar305 = applicable;
				}
			}
			return (System.Boolean) (OperandVar305);
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
			System.Boolean OperandVar307 = default(System.Boolean); //IsContext = False IsNew = False
			Manual StoredVariable306 = ((Manual)root.GetComponent(typeof(Manual))); //IsContext = False IsNew = False
			if(StoredVariable306 != null)
			{
				applicable = true;
				OperandVar307 = applicable;
			}
			return (System.Boolean) (OperandVar307);
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
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar309 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop308 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop308 != null)
			{
				OperandVar309 = prop308;
			}
			smart_scope.Scope =  (OperandVar309);
			if(!OtherIsProvided){
			if(!smart_scope.SelectNext(this, root.GetComponent<Agent>())) State = TaskState.Failed;
			} else {
			smart_scope.SelectNext(this);
			}
			var indexedWrapper0 = cons[0] as ScriptedTypes.near;
			
			indexedWrapper0.Distance = (System.Single)( (2f));
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
						LightSource subContext310 = (LightSource)other.GetComponent(typeof(LightSource)); //IsContext = True IsNew = False
						//ContextStatement LightSource subContext310 ContextSwitchInterpreter
						if(subContext310 != null)
						{
							//LightSource subContext310; //IsContext = True IsNew = False
							
							subContext310.LitUp = (System.Boolean)( (true));
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
			UnityEngine.GameObject OperandVar319 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar319 = root;
			task.Root = (UnityEngine.GameObject) (OperandVar319);
			UnityEngine.GameObject OperandVar320 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar320 = at;
			properTask.Who = (UnityEngine.GameObject) (OperandVar320);
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
			System.Boolean OperandVar313 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable311 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable311 != null)
			{
				Movable StoredVariable312 = ((Movable)StoredVariable311.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable312 != null)
				{
					applicable = true;
					OperandVar313 = applicable;
				}
			}
			return (System.Boolean) (OperandVar313);
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
			System.Collections.Generic.List<UnityEngine.GameObject> OperandVar315 = default(System.Collections.Generic.List<UnityEngine.GameObject>); //IsContext = False IsNew = False
			System.Collections.Generic.List<UnityEngine.GameObject> prop314 = External.AllEntities(); //IsContext = False IsNew = False
			if(prop314 != null)
			{
				OperandVar315 = prop314;
			}
			smart_scope.Scope =  (OperandVar315);
			if(!OtherIsProvided){
			if(!smart_scope.SelectNext(this, root.GetComponent<Agent>())) State = TaskState.Failed;
			} else {
			smart_scope.SelectNext(this);
			}
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
				Movable subContext316 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext316 ContextSwitchInterpreter
				if(subContext316 != null)
				{
					//Movable subContext316; //IsContext = True IsNew = False
					
					UnityEngine.GameObject OperandVar317 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar317 = at;
					subContext316.Goto((System.Single)( (2f)),(UnityEngine.GameObject)( (OperandVar317)));
					
					subContext316.Speed = (System.Single)( (1f));
					Movable OperandVar318 = default(Movable); //IsContext = False IsNew = False
					OperandVar318 = subContext316;
					mov =  (OperandVar318);
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
			System.Boolean OperandVar322 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop321 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar322 = prop321;
			return (System.Boolean) (OperandVar322);
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
			System.Boolean OperandVar325 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable323 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable323 != null)
			{
				Movable StoredVariable324 = ((Movable)StoredVariable323.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable324 != null)
				{
					applicable = true;
					OperandVar325 = applicable;
				}
			}
			return (System.Boolean) (OperandVar325);
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
			UnityEngine.Vector2 OperandVar330 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
			UnityEngine.Vector3 OperandVar328 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
			Entity StoredVariable326 = ((Entity)around.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable326 != null)
			{
				UnityEngine.Vector3 prop327 = StoredVariable326.Position; //IsContext = False IsNew = False
				OperandVar328 = prop327;
			}
			
			UnityEngine.Vector2 prop329 = External.RandomPoint((UnityEngine.Vector2)( (OperandVar328)),(System.Single)( (4f))); //IsContext = False IsNew = False
			OperandVar330 = prop329;
			UnityEngine.Vector2 point =  (OperandVar330); //IsContext = False IsNew = False
			
			{
				Movable subContext331 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext331 ContextSwitchInterpreter
				if(subContext331 != null)
				{
					//Movable subContext331; //IsContext = True IsNew = False
					
					UnityEngine.Vector2 OperandVar332 = default(UnityEngine.Vector2); //IsContext = False IsNew = False
					OperandVar332 = point;
					subContext331.GotoPoint((System.Single)( (2f)),(UnityEngine.Vector2)( (OperandVar332)));
					
					subContext331.Speed = (System.Single)( (1f));
					Movable OperandVar333 = default(Movable); //IsContext = False IsNew = False
					OperandVar333 = subContext331;
					mov =  (OperandVar333);
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
			System.Boolean OperandVar335 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop334 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar335 = prop334;
			return (System.Boolean) (OperandVar335);
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
			System.Boolean OperandVar337 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable336 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable336 != null)
			{
				applicable = true;
				OperandVar337 = applicable;
			}
			return (System.Boolean) (OperandVar337);
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
			UnityEngine.GameObject OperandVar341 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop340 = fromTask.Who; //IsContext = False IsNew = False
			if(prop340 != null)
			{
				OperandVar341 = prop340;
			}
			properTask.Around = (UnityEngine.GameObject) (OperandVar341);
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
			UnityEngine.GameObject OperandVar342 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			OperandVar342 = root;
			properTask.Around = (UnityEngine.GameObject) (OperandVar342);
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
			System.Boolean OperandVar339 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable338 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable338 != null)
			{
				applicable = true;
				OperandVar339 = applicable;
			}
			return (System.Boolean) (OperandVar339);
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
			System.Boolean OperandVar345 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable343 = ((Entity)root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable343 != null)
			{
				Movable StoredVariable344 = ((Movable)StoredVariable343.GetComponent(typeof(Movable))); //IsContext = False IsNew = False
				if(StoredVariable344 != null)
				{
					applicable = true;
					OperandVar345 = applicable;
				}
			}
			return (System.Boolean) (OperandVar345);
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
				Movable subContext346 = (Movable)root.GetComponent(typeof(Movable)); //IsContext = True IsNew = False
				//ContextStatement Movable subContext346 ContextSwitchInterpreter
				if(subContext346 != null)
				{
					//Movable subContext346; //IsContext = True IsNew = False
					System.Single OperandVar347 = default(System.Single); //IsContext = False IsNew = False
					OperandVar347 = ok_distance;
					UnityEngine.GameObject OperandVar348 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
					OperandVar348 = who;
					subContext346.Goto((System.Single)( (OperandVar347)),(UnityEngine.GameObject)( (OperandVar348)));
					
					subContext346.Speed = (System.Single)( (1f));
					Movable OperandVar349 = default(Movable); //IsContext = False IsNew = False
					OperandVar349 = subContext346;
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
			System.Boolean OperandVar351 = default(System.Boolean); //IsContext = False IsNew = False
			System.Boolean prop350 = mov.NearTarget; //IsContext = False IsNew = False
			OperandVar351 = prop350;
			return (System.Boolean) (OperandVar351);
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
			System.Single OperandVar354 = default(System.Single); //IsContext = False IsNew = False
			LightSource StoredVariable352 = ((LightSource)other.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
			if(StoredVariable352 != null)
			{
				System.Single prop353 = StoredVariable352.Brightness; //IsContext = False IsNew = False
				OperandVar354 = prop353;
			}
			System.Single OperandVar357 = default(System.Single); //IsContext = False IsNew = False
			LightSensor StoredVariable355 = ((LightSensor)root.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
			if(StoredVariable355 != null)
			{
				System.Single prop356 = StoredVariable355.Light; //IsContext = False IsNew = False
				OperandVar357 = prop356;
			}
			val = ( (OperandVar354)) * ( (OperandVar357));
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
			System.Boolean OperandVar360 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable358 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable358 != null)
			{
				LightSensor StoredVariable359 = ((LightSensor)StoredVariable358.GetComponent(typeof(LightSensor))); //IsContext = False IsNew = False
				if(StoredVariable359 != null)
				{
					applicable = true;
					OperandVar360 = applicable;
				}
			}
			return (System.Boolean) (OperandVar360);
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
			System.Boolean OperandVar363 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable361 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable361 != null)
			{
				LightSource StoredVariable362 = ((LightSource)StoredVariable361.GetComponent(typeof(LightSource))); //IsContext = False IsNew = False
				if(StoredVariable362 != null)
				{
					applicable = true;
					OperandVar363 = applicable;
				}
			}
			return (System.Boolean) (OperandVar363);
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
			System.Boolean OperandVar365 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable364 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable364 != null)
			{
				applicable = true;
				OperandVar365 = applicable;
			}
			return (System.Boolean) (OperandVar365);
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
			System.Boolean OperandVar367 = default(System.Boolean); //IsContext = False IsNew = False
			Actor StoredVariable366 = ((Actor)root.GetComponent(typeof(Actor))); //IsContext = False IsNew = False
			if(StoredVariable366 != null)
			{
				applicable = true;
				OperandVar367 = applicable;
			}
			return (System.Boolean) (OperandVar367);
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
			System.Boolean OperandVar370 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop368 = trigger.Target; //IsContext = False IsNew = False
			if(prop368 != null)
			{
				Entity StoredVariable369 = ((Entity)prop368.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
				if(StoredVariable369 != null)
				{
					applicable = true;
					OperandVar370 = applicable;
				}
			}
			return (System.Boolean) (OperandVar370);
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
				VisualsFeed subContext371 = External.VisualsFeed; //IsContext = True IsNew = False
				//ContextStatement VisualsFeed subContext371 ContextPropertySwitchInterpreter
				if(subContext371 != null)
				{
					TestEvent OperandVar372 = default(TestEvent); //IsContext = False IsNew = False
					OperandVar372 = trigger;
					UnityEngine.Vector3 OperandVar376 = default(UnityEngine.Vector3); //IsContext = False IsNew = False
					if(trigger != null)
					{
						UnityEngine.GameObject prop373 = trigger.Target; //IsContext = False IsNew = False
						if(prop373 != null)
						{
							Entity StoredVariable374 = ((Entity)prop373.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
							if(StoredVariable374 != null)
							{
								UnityEngine.Vector3 prop375 = StoredVariable374.Position; //IsContext = False IsNew = False
								OperandVar376 = prop375;
							}
						}
					}
					subContext371.Push((Event)( (OperandVar372)),(UnityEngine.Vector3)( (OperandVar376)));
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
			System.Boolean OperandVar378 = default(System.Boolean); //IsContext = False IsNew = False
			ScriptedTypes.facts StoredVariable377 = ((ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts))); //IsContext = False IsNew = False
			if(StoredVariable377 != null)
			{
				applicable = true;
				OperandVar378 = applicable;
			}
			return (System.Boolean) (OperandVar378);
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
				ScriptedTypes.facts subContext379 = (ScriptedTypes.facts)root.GetComponent(typeof(ScriptedTypes.facts)); //IsContext = True IsNew = False
				//ContextStatement ScriptedTypes.facts subContext379 ContextSwitchInterpreter
				if(subContext379 != null)
				{
					//ScriptedTypes.facts subContext379; //IsContext = True IsNew = False
					System.Boolean OperandVar381 = default(System.Boolean); //IsContext = False IsNew = False
					System.Boolean prop380 = subContext379.HasNoticedTestEvent(); //IsContext = False IsNew = False
					if(prop380 != false)
					{
						OperandVar381 = prop380;
					}
					if(!(OperandVar381))
					{
						ScriptedTypes.noticed_test_event OperandVar383 = default(ScriptedTypes.noticed_test_event); //IsContext = False IsNew = False
						ScriptedTypes.noticed_test_event prop382 = subContext379.AddNoticedTestEvent(); //IsContext = False IsNew = False
						if(prop382 != null)
						{
							OperandVar383 = prop382;
						}
						ScriptedTypes.noticed_test_event ev =  (OperandVar383); //IsContext = False IsNew = False
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
			System.Boolean OperandVar386 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop384 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop384 != null)
			{
				PlayerMarker StoredVariable385 = ((PlayerMarker)prop384.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
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
			//DialogAccepted trigger; //IsContext = True IsNew = False
			
			
			
			UnityEngine.GameObject OperandVar388 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop387 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop387 != null)
			{
				OperandVar388 = prop387;
			}
			External.Log((System.Object)(( ( ("init dialog for "))) + ( ( (OperandVar388)))));
			UnityEngine.GameObject OperandVar390 = default(UnityEngine.GameObject); //IsContext = False IsNew = False
			UnityEngine.GameObject prop389 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop389 != null)
			{
				OperandVar390 = prop389;
			}
			External.InitDialogUi((UnityEngine.GameObject)( (OperandVar390)));
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
			System.Boolean OperandVar393 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop391 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop391 != null)
			{
				PlayerMarker StoredVariable392 = ((PlayerMarker)prop391.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable392 != null)
				{
					applicable = true;
					OperandVar393 = applicable;
				}
			}
			return (System.Boolean) (OperandVar393);
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
			System.Boolean OperandVar396 = default(System.Boolean); //IsContext = False IsNew = False
			UnityEngine.GameObject prop394 = trigger.Initiator; //IsContext = False IsNew = False
			if(prop394 != null)
			{
				PlayerMarker StoredVariable395 = ((PlayerMarker)prop394.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
				if(StoredVariable395 != null)
				{
					applicable = true;
					OperandVar396 = applicable;
				}
			}
			return (System.Boolean) (OperandVar396);
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
			System.Boolean OperandVar398 = default(System.Boolean); //IsContext = False IsNew = False
			Entity StoredVariable397 = ((Entity)trigger_root.GetComponent(typeof(Entity))); //IsContext = False IsNew = False
			if(StoredVariable397 != null)
			{
				applicable = true;
				OperandVar398 = applicable;
			}
			return (System.Boolean) (OperandVar398);
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
			Entity EntVar399 = (Entity)trigger_root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			trigger_root.AddComponent<ScriptedTypes.backstory>();
			
			trigger_root.AddComponent<ScriptedTypes.personality>();
			if(EntVar399 != null) EntVar399.ComponentAdded();
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
			System.Boolean OperandVar401 = default(System.Boolean); //IsContext = False IsNew = False
			PlayerMarker StoredVariable400 = ((PlayerMarker)trigger_root.GetComponent(typeof(PlayerMarker))); //IsContext = False IsNew = False
			if(StoredVariable400 != null)
			{
				applicable = true;
				OperandVar401 = applicable;
			}
			return (System.Boolean) (OperandVar401);
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
			Entity EntVar402 = (Entity)trigger_root.GetComponent(typeof(Entity));; //IsContext = False IsNew = False
			
			trigger_root.AddComponent<InteractableController>();
			if(EntVar402 != null) EntVar402.ComponentAdded();
		}
        }
    }
}
