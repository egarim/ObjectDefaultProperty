using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Actions;
using System.Diagnostics;
using System.ComponentModel;
namespace CurrentNameSpace
{
    public class MyViewController : ViewController
    {
        public MyViewController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
            #region GetDefaultPropertyITypeInfo
            SimpleAction GetDefaultPropertyITypeInfo = new SimpleAction(this, "GetDefaultPropertyITypeInfo", "View");
            GetDefaultPropertyITypeInfo.Execute += GetDefaultPropertyITypeInfo_Execute;
            void GetDefaultPropertyITypeInfo_Execute(object GetDefaultPropertyITypeInfo_sender, SimpleActionExecuteEventArgs GetDefaultPropertyITypeInfo_e)
            {
                 var DefaultPropertyName=  this.View.ObjectTypeInfo.DefaultMember;
                 System.Diagnostics.Debug.WriteLine(DefaultPropertyName);
                 // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
            }
            #endregion
        
            #region Reflection
            SimpleAction Reflection = new SimpleAction(this, "Reflection", "View");
            Reflection.Execute += Reflection_Execute;
            void Reflection_Execute(object Reflection_sender, SimpleActionExecuteEventArgs Reflection_e)
            {
              
              //Instead this.View.CurrentObject you can use typeof() to get the type information
              var DefaultPropertyInstance=  this.View.CurrentObject.GetType().GetCustomAttributes(true)
              .FirstOrDefault(at=>at.GetType()==typeof(System.ComponentModel.DefaultPropertyAttribute)
              )  as System.ComponentModel.DefaultPropertyAttribute;
                 // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
            
            
               Debug.WriteLine(DefaultPropertyInstance.Name);
            }
           
            #endregion 
            #region XpClassInfo
            SimpleAction XpClassInfo = new SimpleAction(this, "XpClassInfo", "View");
            XpClassInfo.Execute += XpClassInfo_Execute;
            void XpClassInfo_Execute(object XpClassInfo_sender, SimpleActionExecuteEventArgs XpClassInfo_e)
            {
                //HACK you can also cast to a lower level IXPClassInfoAndSessionProvider
                var CurrentObjectInstace=this.View.CurrentObject as DevExpress.Persistent.BaseImpl.BaseObject;
                DefaultPropertyAttribute DefaultInstance=CurrentObjectInstace.ClassInfo.GetAttributeInfo(typeof(DefaultPropertyAttribute)) as DefaultPropertyAttribute;
            
                var DefaultPropertyValue= CurrentObjectInstace.ClassInfo.GetMember(DefaultInstance.Name).GetValue(CurrentObjectInstace);
            
               
                 // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
            }
            #endregion       
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }
}