﻿#pragma checksum "C:\Users\Steven\documents\visual studio 2015\Projects\Money Manager\Money Manager\NewAccountPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E4F1878B1807995881E67410485ABD66"
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
    partial class NewAccountPage : 
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
                    this.btnDone = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 61 "..\..\..\NewAccountPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnDone).Click += this.btnDone_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.btnCancel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 62 "..\..\..\NewAccountPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCancel).Click += this.btnCancel_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.tblCurrency = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.tbStartingBalance = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.tbStartingBalanceSmall = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.spCurrencyRadios = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7:
                {
                    this.rbEuro = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 37 "..\..\..\NewAccountPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rbEuro).Checked += this.rbEuro_Checked;
                    #line default
                }
                break;
            case 8:
                {
                    this.rbDollar = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 38 "..\..\..\NewAccountPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rbDollar).Checked += this.rbDollar_Checked;
                    #line default
                }
                break;
            case 9:
                {
                    this.rbPound = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 39 "..\..\..\NewAccountPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rbPound).Checked += this.rbPound_Checked;
                    #line default
                }
                break;
            case 10:
                {
                    this.tbPassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 11:
                {
                    this.tbPasswordRetype = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 12:
                {
                    this.tbUserName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13:
                {
                    this.tbLastName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14:
                {
                    this.tbFirstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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
