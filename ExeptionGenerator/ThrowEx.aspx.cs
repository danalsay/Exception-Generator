using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Data.Edm;

namespace ExeptionGenerator
{
    /// <summary>
    /// This Class is a module that allows the user to generate or simulate an exception so that an implemented Exception handling system can be tested.
    /// 
    /// </summary>
    public partial class ThrowEx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillExceptionDDL();
            }

        }
       
        private void fillExceptionDDL()
        {
            ddlExceptions.DataSource = FindAllDerivedTypes<SystemException>();
            ddlExceptions.DataTextField = "Name";
            ddlExceptions.DataValueField = "Name";
            ddlExceptions.DataBind();
            ddlExceptions.Items.Insert(0, "Select Exception to Throw");
        }

        protected void ddlExcep_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList Exceptions = (DropDownList)sender;  //list of SystemException.Exception (from assembly  System.SystemException)
            string exc = Exceptions.SelectedValue.Replace("System.", "");
            ThrowException(Exceptions.SelectedItem.ToString());         
        }

        private Exception ThrowException(string exc)
        {
            List<Type> ExTypes = GetExceptionList(); 
            Type ExcType = (from E in ExTypes where E.Name == exc select E).FirstOrDefault();
            throw (SystemException)Activator.CreateInstance(ExcType);
        }


        public static List<Type> FindAllDerivedTypes<T>()
        {
            Assembly Assem =  Assembly.GetAssembly(typeof(T));
            return FindAllDerivedTypes<T>(Assembly.GetAssembly(typeof(T)));
        }

        public static List<Type> FindAllDerivedTypes<T>(Assembly assembly)
        {
            var derivedType = typeof(T);
            return assembly
                .GetTypes()
                .Where(t =>
                    t != derivedType &&
                    derivedType.IsAssignableFrom(t)
                    ).ToList();

        } 

        private List<Type> GetExceptionList()
        {
            List<Type> listExTypes = FindAllDerivedTypes<SystemException>();
            return listExTypes;
        }

        protected void ddlExceptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList Exceptions = (DropDownList)sender;
            string exc = Exceptions.SelectedValue.Replace("System.", "");
            ThrowException(exc);
        }


    }

    
}