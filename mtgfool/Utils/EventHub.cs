using System;
using System.Collections.Generic;

namespace mtgfool.Utils
{
	public static class EventHub
	{
		private static Dictionary<string,Dictionary<string,Action<IContext,Dictionary<string,string>>>> subjects;
		public static string AddObserver(string subjectName,Action<IContext,Dictionary<string,string>> func) {
			if(subjects == null)
				subjects = new Dictionary<string,Dictionary<string,Action<IContext,Dictionary<string,string>>>>();
			if(!subjects.ContainsKey(subjectName)) 
				subjects[subjectName] = new Dictionary<string, Action<IContext, Dictionary<string, string>>>();

			var id = Guid.NewGuid ().ToString ("N");	
			subjects [subjectName] [id] = func;

			return id;
		}

		public static void Clear() {
			subjects.Clear ();
		}

		public static void Signal(string subjectName,IContext context, Dictionary<string,string> data) {
			if (!subjects.ContainsKey (subjectName))
				return;
			foreach (var action in subjects[subjectName].Values) {
				action (context, data);
			}
		}
	}
}

