﻿#pragma checksum "..\..\..\NewAcc.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AC2169707064E76DE0E5AF0ED10EC4F23996CC4C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using EzStream;
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


namespace EzStream {
    
    
    /// <summary>
    /// NewAcc
    /// </summary>
    public partial class NewAcc : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\NewAcc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Channel_Name;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\NewAcc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stream_key;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\NewAcc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Plarfomr_sel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\NewAcc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cb1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\NewAcc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cb2;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\NewAcc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Codec_sel;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\NewAcc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bittrate;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\NewAcc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fps;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EzStreaming;V2.0.5.1;component/newacc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NewAcc.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Channel_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.stream_key = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Plarfomr_sel = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cb1 = ((System.Windows.Controls.CheckBox)(target));
            
            #line 23 "..\..\..\NewAcc.xaml"
            this.cb1.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\NewAcc.xaml"
            this.cb1.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cb2 = ((System.Windows.Controls.CheckBox)(target));
            
            #line 24 "..\..\..\NewAcc.xaml"
            this.cb2.Checked += new System.Windows.RoutedEventHandler(this.CheckBox2_Checked);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\NewAcc.xaml"
            this.cb2.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox2_unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 25 "..\..\..\NewAcc.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Codec_sel = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.bittrate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.fps = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

