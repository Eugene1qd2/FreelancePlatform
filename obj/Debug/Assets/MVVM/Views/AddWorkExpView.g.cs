#pragma checksum "..\..\..\..\..\Assets\MVVM\Views\AddWorkExpView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "66CC72C7B20865EAD7EBF70D5B2B4E083140A5E091FC0BE17E72F431EE3061B4"
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
    /// AddWorkExpView
    /// </summary>
    public partial class AddWorkExpView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 120 "..\..\..\..\..\Assets\MVVM\Views\AddWorkExpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textB;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\..\Assets\MVVM\Views\AddWorkExpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock btn;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\..\..\Assets\MVVM\Views\AddWorkExpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rect;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\..\Assets\MVVM\Views\AddWorkExpView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox list;
        
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
            System.Uri resourceLocater = new System.Uri("/FreelancePlatform;component/assets/mvvm/views/addworkexpview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Assets\MVVM\Views\AddWorkExpView.xaml"
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
            
            #line 109 "..\..\..\..\..\Assets\MVVM\Views\AddWorkExpView.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MaleDropdown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.btn = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.rect = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.list = ((System.Windows.Controls.ListBox)(target));
            
            #line 128 "..\..\..\..\..\Assets\MVVM\Views\AddWorkExpView.xaml"
            this.list.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.list_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

