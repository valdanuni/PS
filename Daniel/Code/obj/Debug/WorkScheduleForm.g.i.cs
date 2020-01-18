﻿#pragma checksum "..\..\WorkScheduleForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2D3478A73236337EA4E284C75B47B24FB4C027DC3ADDFE241FF6B727606AB5BD"
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
    /// WorkScheduleForm
    /// </summary>
    public partial class WorkScheduleForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\WorkScheduleForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DoctorWSForm;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\WorkScheduleForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DoctorWSTitle;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WorkScheduleForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DoctorWSDate;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\WorkScheduleForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker DoctorWSTime;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\WorkScheduleForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DoctorWSHospital;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\WorkScheduleForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DoctorWSRoom;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\WorkScheduleForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBtn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\WorkScheduleForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimizeBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\WorkScheduleForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/PS_Hospital_System_Project_2019;component/workscheduleform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WorkScheduleForm.xaml"
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
            
            #line 9 "..\..\WorkScheduleForm.xaml"
            ((PS_Hospital_System_Project_2019.WorkScheduleForm)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DoctorWSForm = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.DoctorWSTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.DoctorWSDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.DoctorWSTime = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 6:
            this.DoctorWSHospital = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.DoctorWSRoom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ExitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\WorkScheduleForm.xaml"
            this.ExitBtn.Click += new System.Windows.RoutedEventHandler(this.ExitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.minimizeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\WorkScheduleForm.xaml"
            this.minimizeBtn.Click += new System.Windows.RoutedEventHandler(this.MinimizeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.saveBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
