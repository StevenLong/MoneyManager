﻿#pragma checksum "C:\Users\Steven\documents\visual studio 2015\Projects\Money Manager\Money Manager\LoginPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A7EF1415032351F17C612184F5635206"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Money_Manager
{
    partial class LoginPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.tbUserName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 2:
                {
                    this.tbPassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 3:
                {
                    this.btnEnter = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 17 "..\..\..\LoginPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnEnter).Click += this.btnEnter_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.btnNewAccount = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 18 "..\..\..\LoginPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnNewAccount).Click += this.btnNewAccount_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.btnExit = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 19 "..\..\..\LoginPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnExit).Click += this.btnExit_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

