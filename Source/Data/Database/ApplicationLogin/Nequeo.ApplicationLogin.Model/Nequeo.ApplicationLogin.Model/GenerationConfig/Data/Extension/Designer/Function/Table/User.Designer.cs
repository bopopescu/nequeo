// Warning 169 (Disables the 'Never used' warning)
#pragma warning disable 169

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nequeo.DataAccess.ApplicationLogin.Data.Extension
{
    using System;
    using System.Text;
    using System.Data;
    using System.Threading;
    using System.Diagnostics;
    using System.Data.SqlClient;
    using System.Data.OleDb;
    using System.Data.Odbc;
    using System.Collections;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Linq;
    using System.Data.Linq.SqlClient;
    using System.Data.Linq.Mapping;
    using Nequeo.Data.Base.Exception;
    using Nequeo.Data.DataAccess.Control.Generic;
    using Nequeo.Data.DataAccess.Control.Generic.Data;
    using Nequeo.Data.Enumeration;
    using Nequeo.Data.Controller.Custom;
    using Nequeo.Data.Controller.Extension;
    
    
    /// <summary>
    /// The user object class.
    /// </summary>
    public partial class User
    {
        
        /// <summary>
        /// Execute the fn_diagramobjects routine.
        /// </summary>
        /// <returns>The execution result.</returns>
        [FunctionRoutineAttribute("dbo.fn_diagramobjects", FunctionRoutineType.TableFunction)]
        public virtual object fn_diagramobjects()
        {
            IExecuteFunctionResult result = Common.ExecuteFunction(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
            return ((object)(result.ReturnValue));
        }
    }
}
namespace Nequeo.DataAccess.ApplicationLogin.Data.Extended
{
    using System;
    using System.Text;
    using System.Data;
    using System.Threading;
    using System.Diagnostics;
    using System.Data.SqlClient;
    using System.Data.OleDb;
    using System.Data.Odbc;
    using System.Collections;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Linq;
    using System.Data.Linq.SqlClient;
    using System.Data.Linq.Mapping;
    using Nequeo.Data.Base.Exception;
    using Nequeo.Data.DataAccess.Control.Generic;
    using Nequeo.Data.DataAccess.Control.Generic.Data;
    using Nequeo.Data.Enumeration;
    using Nequeo.Data.Controller.Custom;
    using Nequeo.Data.Controller.Extension;
    
}
#pragma warning restore 169

