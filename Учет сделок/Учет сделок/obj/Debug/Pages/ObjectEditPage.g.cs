#pragma checksum "..\..\..\Pages\ObjectEditPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A966265BABFDA344B392EFD7B375C46721AB09DAD3B9851219C5953BED8ADB14"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Учет_сделок.Pages;


namespace Учет_сделок.Pages {
    
    
    /// <summary>
    /// ObjectEditPage
    /// </summary>
    public partial class ObjectEditPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Pages\ObjectEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbTitleObject;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Pages\ObjectEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbPurpose;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\ObjectEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbWorkMode;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\ObjectEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbAddressObject;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\ObjectEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbTitleCompany;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\ObjectEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnReady;
        
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
            System.Uri resourceLocater = new System.Uri("/Учет сделок;component/pages/objecteditpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ObjectEditPage.xaml"
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
            this.TbTitleObject = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\Pages\ObjectEditPage.xaml"
            this.TbTitleObject.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.OnlyLetters);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TbPurpose = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TbWorkMode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TbAddressObject = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CbTitleCompany = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.BtnReady = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Pages\ObjectEditPage.xaml"
            this.BtnReady.Click += new System.Windows.RoutedEventHandler(this.BtnReady_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

