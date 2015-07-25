using System;

namespace mtgfool.Core
{
	public enum COLOR { White, Blue, Black, Green, Red, Colorless }
	public enum LOCATION { Library, Hand, Battlefield, Graveyard, Exiled, Stack }
	public enum PHASE { Beginning, FirstMain, Combat, SecondMain, End}
	public enum STEP { Untap, Upkeep, Draw, FirstMain, BeginCombat, DeclareAttackers, DeclareBlockers, CombatDamage, CombatEnd, SecondMain, End, CleanUp }
}

