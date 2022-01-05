using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Behaviors
{
    public class EmailValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += OnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;  
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;
            var emailEntry = sender as Entry;
            bool isValid;
            try
            {
                MailAddress m = new MailAddress(email);
                isValid =  true;
            }
            catch (FormatException)
            {
                isValid =  false;
            }
            if (!isValid)
            {
                emailEntry.TextColor = Color.IndianRed;
            }
        }
    }
}
