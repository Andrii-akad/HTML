﻿#pragma checksum "..\..\RegistrationForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EC73AD0D77C0BA6EEEF15B0FA916581C1DC01CBE0020B3A1D0CBE5156F69C262"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Messenger;
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


namespace Messenger {
    
    
    /// <summary>
    /// RegistrationForm
    /// </summary>
    public partial class RegistrationForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEmail;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLogin;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox tbPassword;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox tbPassword2;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush image;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\RegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImage;
        
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
            System.Uri resourceLocater = new System.Uri("/Messenger;component/registrationform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegistrationForm.xaml"
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
            this.panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.tbEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\RegistrationForm.xaml"
            this.tbEmail.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\RegistrationForm.xaml"
            this.tbName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbLogin = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\RegistrationForm.xaml"
            this.tbLogin.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 40 "..\..\RegistrationForm.xaml"
            this.tbPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.FloatingConfirmBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tbPassword2 = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 43 "..\..\RegistrationForm.xaml"
            this.tbPassword2.PasswordChanged += new System.Windows.RoutedEventHandler(this.FloatingConfirmBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 44 "..\..\RegistrationForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Registrate_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 48 "..\..\RegistrationForm.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.Hyperlink_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.image = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 10:
            this.btnImage = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\RegistrationForm.xaml"
            this.btnImage.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

