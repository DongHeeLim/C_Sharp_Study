﻿#pragma checksum "..\..\..\..\..\View\TabPanels\DrillingTab.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "794A52C548C759DA8E68D00F94192173881B4B48"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPF_RobotArm_2.View.TabPanels;


namespace WPF_RobotArm_2.View.TabPanels {
    
    
    /// <summary>
    /// DrillingTab
    /// </summary>
    public partial class DrillingTab : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\..\View\TabPanels\DrillingTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox drill_length_Input;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\View\TabPanels\DrillingTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label current_drill_length;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF_RobotArm_2;component/view/tabpanels/drillingtab.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\TabPanels\DrillingTab.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.drill_length_Input = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\..\..\View\TabPanels\DrillingTab.xaml"
            this.drill_length_Input.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.drill_length_Input_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\..\..\View\TabPanels\DrillingTab.xaml"
            this.drill_length_Input.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.drill_length_Input_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.current_drill_length = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

