﻿#pragma checksum "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C48DBF975DF8829E52C69D85BF4139B6FC7B8F4B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Final_Project.Forms.Pharmacy.InnerPages;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
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


namespace Final_Project.Forms.Pharmacy.InnerPages {
    
    
    /// <summary>
    /// OrderInvoicePage
    /// </summary>
    public partial class OrderInvoicePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel LabInvoicePdf;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock invoiceno;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock date;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid invoiceitems;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock subtotal;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock discount;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock total;
        
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
            System.Uri resourceLocater = new System.Uri("/Final Project;V1.0.0.0;component/forms/pharmacy/innerpages/orderinvoicepage.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml"
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
            
            #line 17 "..\..\..\..\..\..\Forms\Pharmacy\InnerPages\OrderInvoicePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LabInvoicePdf = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.invoiceno = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.date = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.invoiceitems = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.subtotal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.discount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.total = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

