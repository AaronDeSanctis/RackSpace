﻿#pragma checksum "..\..\bindingtester.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1683AF3A15BDAF6086443CB5C10AA8D9000BC21AF294BE71AAEA10C99AC21D02"
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
    /// bindingtester
    /// </summary>
    public partial class bindingtester : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\bindingtester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBarTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\bindingtester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ItemsListBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\bindingtester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ItemListGrid;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\bindingtester.xaml"
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
            System.Uri resourceLocater = new System.Uri("/RackSpaceWPF;component/bindingtester.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\bindingtester.xaml"
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
            this.SearchBarTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\bindingtester.xaml"
            this.SearchBarTextBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.SearchBarTextBox_KeyUp);
            
            #line default
            #line hidden
            
            #line 48 "..\..\bindingtester.xaml"
            this.SearchBarTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBarTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ItemsListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.ItemListGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 52 "..\..\bindingtester.xaml"
            this.ItemListGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ItemsListGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 56 "..\..\bindingtester.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CustomizeRacks_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.homeButton = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\bindingtester.xaml"
            this.homeButton.Click += new System.Windows.RoutedEventHandler(this.HomeButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 81 "..\..\bindingtester.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 85 "..\..\bindingtester.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveItem_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 89 "..\..\bindingtester.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuTester2_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
