﻿#pragma checksum "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D4721422215C8CDFEB60A50095B587D22D7B7E0E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Final_Project.Forms.OPD.InnerPages;
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


namespace Final_Project.Forms.OPD.InnerPages {
    
    
    /// <summary>
    /// ApponitmentPage
    /// </summary>
    public partial class ApponitmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hours;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minutes;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox am;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox status;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox selectdoctorcombo;
        
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
            System.Uri resourceLocater = new System.Uri("/Final Project;component/forms/opd/innerpages/apponitmentpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml"
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
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.hours = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.minutes = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.am = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.status = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.selectdoctorcombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 106 "..\..\..\..\..\..\Forms\OPD\InnerPages\ApponitmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
