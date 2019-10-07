using System;
using System.Collections.Generic;

namespace TMM_Asp.Models { 
	public class TeamMembersModel
	{
		public Dictionary<string, int> Employment { get; set; }
		public Dictionary<string, int> Position { get; set; }
		public Dictionary<string, int> Shift { get; set; }
		public Dictionary<string, int> Department { get; set; }
		public Dictionary<string, int> Manager { get; set; }
		public List<MemberModel> Employees { get; set; }

	}
}
