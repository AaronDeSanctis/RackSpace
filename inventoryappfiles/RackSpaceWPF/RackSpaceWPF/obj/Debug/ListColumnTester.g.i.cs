﻿#pragma checksum "..\..\ListColumnTester.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF17880FBC0E0CD89135ACB1C3A901AAB1E3CA93ACCDC50BE8D663D5B58C23EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RackSpaceWPF;
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


namespace RackSpaceWPF {
    
    
    /// <summary>
    /// ListColumnTester
    /// </summary>
    public partial class ListColumnTester : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\ListColumnTester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt1;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\ListColumnTester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBarTextBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\ListColumnTester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ItemsListBox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\ListColumnTester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ItemListGrid;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\ListColumnTester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button homeButton;
        
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
            System.Uri resourceLocater = new System.Uri("/RackSpaceWPF;component/listcolumntester.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ListColumnTester.xaml"
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
            this.txt1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.SearchBarTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\ListColumnTester.xaml"
            this.SearchBarTextBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.SearchBarTextBox_KeyUp);
            
            #line default
            #line hidden
            
            #line 55 "..\..\ListColumnTester.xaml"
            this.SearchBarTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBarTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ItemsListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.ItemListGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 62 "..\..\ListColumnTester.xaml"
            this.ItemListGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ItemsListGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.homeButton = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\ListColumnTester.xaml"
            this.homeButton.Click += new System.Windows.RoutedEventHandler(this.HomeButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
