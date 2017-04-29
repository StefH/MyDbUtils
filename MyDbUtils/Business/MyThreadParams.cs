using System.Collections.Generic;

namespace MyDbUtils.Business
{
	public class MyThreadParams
	{
		public GenerateMode Mode { set; get; }

		public bool MultipleFiles { set; get; }

		public bool AddUseStatement { set; get; }

		public string PathOrFilename { set; get; }

		public string DatabaseName { set; get; }

		public List<MyInfo> SelectedItems { set; get; }

		public bool IncludeDependencies { set; get; }
	}
}