﻿#pragma checksum "..\..\..\..\..\Assets\MVVM\Views\UserChatView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9738115C07C0674098667FE42F6ECE90A1ED2BBFC30447E60EEBAC7F0CBC0A81"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FreelancePlatform.Assets.MVVM.Views;
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


namespace FreelancePlatform.Assets.MVVM.Views {
    
    
    /// <summary>
    /// UserChatView
    /// </summary>
    public partial class UserChatView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
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
            System.Uri resourceLocater = new System.Uri("/FreelancePlatform;component/assets/mvvm/views/userchatview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Assets\MVVM\Views\UserChatView.xaml"
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
            
            #line 56 "..\..\..\..\..\Assets\MVVM\Views\UserChatView.xaml"
            ((System.Windows.Controls.ListView)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.ListView_SizeChanged);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\..\..\Assets\MVVM\Views\UserChatView.xaml"
            ((System.Windows.Controls.ListView)(target)).SourceUpdated += new System.EventHandler<System.Windows.Data.DataTransferEventArgs>(this.ListView_SourceUpdated);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

