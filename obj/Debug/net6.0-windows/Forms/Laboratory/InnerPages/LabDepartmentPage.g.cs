﻿#pragma checksum "..\..\..\..\..\..\Forms\Laboratory\InnerPages\LabDepartmentPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E6B0686EEB777A8D8902E35BAB9728E5DBD7B97B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Final_Project.Forms.Laboratory.InnerPages;
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


namespace Final_Project.Forms.Laboratory.InnerPages {
    
    
    /// <summary>
    /// LabDepartmentPage
    /// </summary>
    public partial class LabDepartmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\..\Forms\Laboratory\InnerPages\LabDepartmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addbtn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\..\Forms\Laboratory\InnerPages\LabDepartmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel adddepartmentform;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\..\Forms\Laboratory\InnerPages\LabDepartmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox departname;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\..\Forms\Laboratory\InnerPages\LabDepartmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DepartmentGridview;
        
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
            System.Uri resourceLocater = new System.Uri("/Final Project;component/forms/laboratory/innerpages/labdepartmentpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Forms\Laboratory\InnerPages\LabDepartmentPage.xaml"
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
            this.addbtn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\..\..\Forms\Laboratory\InnerPages\LabDepartmentPage.xaml"
            this.addbtn.Click += new System.Windows.RoutedEventHandler(this.ShowDepartmentFormButton);
            
            #line default
            #line hidden
            return;
            case 2:
            this.adddepartmentform = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.departname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 21 "..\..\..\..\..\..\Forms\Laboratory\InnerPages\LabDepartmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddDepartment);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 22 "..\..\..\..\..\..\Forms\Laboratory\InnerPages\LabDepartmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelDepartmentFormButton);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DepartmentGridview = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

