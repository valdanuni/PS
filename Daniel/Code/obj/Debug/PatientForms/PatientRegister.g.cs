﻿#pragma checksum "..\..\..\PatientForms\PatientRegister.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FA3756371BC2916C6FDD877A5DB8A5A1D30455684E069701E8EF3EBC07F3342A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PS_Hospital_System_Project_2019;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PS_Hospital_System_Project_2019 {
    
    
    /// <summary>
    /// PatientRegister
    /// </summary>
    public partial class PatientRegister : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\PatientForms\PatientRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\PatientForms\PatientRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MiddleName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\PatientForms\PatientRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FamilyName;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\PatientForms\PatientRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Age;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\PatientForms\PatientRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Egn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\PatientForms\PatientRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Address;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\PatientForms\PatientRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MobilePhone;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\PatientForms\PatientRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\PatientForms\PatientRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MinimizeBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PS_Hospital_System_Project_2019;component/patientforms/patientregister.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PatientForms\PatientRegister.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\PatientForms\PatientRegister.xaml"
            ((PS_Hospital_System_Project_2019.PatientRegister)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\PatientForms\PatientRegister.xaml"
            this.Name.LostFocus += new System.Windows.RoutedEventHandler(this.FirstName_LostFocus_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MiddleName = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\PatientForms\PatientRegister.xaml"
            this.MiddleName.LostFocus += new System.Windows.RoutedEventHandler(this.MiddleName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FamilyName = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\PatientForms\PatientRegister.xaml"
            this.FamilyName.LostFocus += new System.Windows.RoutedEventHandler(this.LastName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Age = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\PatientForms\PatientRegister.xaml"
            this.Age.LostFocus += new System.Windows.RoutedEventHandler(this.Age_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Egn = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\PatientForms\PatientRegister.xaml"
            this.Egn.LostFocus += new System.Windows.RoutedEventHandler(this.EGN_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.MobilePhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\PatientForms\PatientRegister.xaml"
            this.MobilePhone.LostFocus += new System.Windows.RoutedEventHandler(this.MobilePhone_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 38 "..\..\..\PatientForms\PatientRegister.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RegisterBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ExitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\PatientForms\PatientRegister.xaml"
            this.ExitBtn.Click += new System.Windows.RoutedEventHandler(this.ExitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.MinimizeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\PatientForms\PatientRegister.xaml"
            this.MinimizeBtn.Click += new System.Windows.RoutedEventHandler(this.MinimizeBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

