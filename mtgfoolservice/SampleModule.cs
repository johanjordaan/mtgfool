using System;
using System.Collections.Generic;
using Nancy;

namespace mtgfoolservice
{
	public class Game:mtgfool.Utils.IdObject
	{
		public Game():base() {
		}

		public void Join(string name) {
		}

		public List<string> GetValidActions(string player) {
			var retVal =  new List<string>();
			return retVal;
		}

		public void Do(string actionId) {
		}
	}

	public class Match:mtgfool.Utils.IdObject
	{
		public string Player { get; private set; }
		public string Opponent { get; private set; }

		public Dictionary<string,Game> Games { get; private set; }
		public Game CurrentGame { get; private set; }

		public Match(string player):base() {
			Player = player;
			Games = new Dictionary<string, Game> ();
			CurrentGame = new Game ();
			Games[CurrentGame.Id] = CurrentGame;
		}

		public void Join(string opponent) {
			Opponent = opponent; 
		}
	}

	public class SampleModule : Nancy.NancyModule
	{
		public static Dictionary<string,Match> data = new Dictionary<string, Match> ();

		public SampleModule()
		{
			Get ["/list"] = _ => {
				return Response.AsJson (data);
			};

			Get["/create"] = _ => {
				var match = new Match(Request.Query["name"]);	
				data[match.Id] = match; 
				return String.Format("created [{0}], current game is [{1}]",match.Id, match.CurrentGame.Id);
			};

			Get ["/{match_id}/join"] = parameters => {
				var match = data [parameters.match_id];
				match.Join(Request.Query ["name"]);
				return String.Format ("joined [{0}], current game is [{1}]",match.Id, match.CurrentGame.Id);
			};

			Get ["/{match_id}/{game_id}/join"] = parameters => {
				var game = data [parameters.match_id].Games [parameters.game_id];
				game.Join (Request.Query ["name"]);
				return String.Format ("joined game [{0}]", game.Id);
			};

			Get ["/{match_id}/{game_id}/valid_actions"] = parameters => {
				var game = data [parameters.match_id].Games [parameters.game_id];
				List<string> actions = game.GetValidActions(Request.Query ["name"]);
				return Response.AsJson(actions);
			};

			Get ["/{match_id}/{game_id}/submit_action"] = parameters => {
				var game = data [parameters.match_id].Games [parameters.game_id];
				game.Do(Request.Query["action_id"]);
				return "Ok";
			};

		}
	}
}

