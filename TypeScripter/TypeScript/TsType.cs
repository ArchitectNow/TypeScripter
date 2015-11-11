using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScripter.TypeScript
{
	/// <summary>
	/// The base class for all TypeScript types
	/// </summary>
	public abstract class TsType : TsObject
	{
		#region Creation
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name">The name of the type</param>
		protected TsType(TsName name)
			: base(name)
		{
            IsNullable = false;
		}
        #endregion

        public bool IsNullable { get; set; }

        #region Method
        public override string ToString()
		{
            var _name = this.Name.FullName;

            return _name;
		}
		#endregion
	}
}
