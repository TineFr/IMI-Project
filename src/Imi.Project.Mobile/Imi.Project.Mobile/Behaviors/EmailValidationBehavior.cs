using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Behaviors
{
    public class EmailValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Unfocused += OnLeave;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Unfocused -= OnLeave;  
        }

        private void OnLeave(object sender, FocusEventArgs e)
        {
            var emailEntry = sender as Entry;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailEntry.Text);
            if (!match.Success)
            {
                emailEntry.TextColor = Color.IndianRed;
            }
            else emailEntry.TextColor = Color.Black;  

        }
    }
}
