﻿#pragma checksum "..\..\..\..\Forms\Laboratory.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1DC848594628D5F5049EA678CF23747299A0C4AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Final_Project.Forms;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Final_Project.Forms {
    
    
    /// <summary>
    /// Laboratory
    /// </summary>
    public partial class Laboratory : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\..\Forms\Laboratory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Final Project;V1.0.0.0;component/forms/laboratory.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\Laboratory.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 23 "..\..\..\..\Forms\Laboratory.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenAppointmentListPage);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 28 "..\..\..\..\Forms\Laboratory.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenPatientListPage);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 33 "..\..\..\..\Forms\Laboratory.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenDoctorPage);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 45 "..\..\..\..\Forms\Laboratory.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenBedListPage);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 46 "..\..\..\..\Forms\Laboratory.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenBedAllotmentListPage);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 47 "..\..\..\..\Forms\Laboratory.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenDepartmentListPage);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 48 "..\..\..\..\Forms\Laboratory.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenDeathReportsPage);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 49 "..\..\..\..\Forms\Laboratory.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenBirthReportPage);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

