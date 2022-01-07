using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Behaviors
{
    internal class PasswordValidationBehavior : Behavior<Entry>
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
            var passwordEntry = sender as Entry;
            bool isValid =
               passwordEntry.Text.Count() >= 8 &&
               passwordEntry.Text.Any(c => char.IsLower(c)) &&
               passwordEntry.Text.Any(c => char.IsUpper(c)) &&
               passwordEntry.Text.Any(c => char.IsDigit(c));
            if (!isValid) passwordEntry.TextColor = Color.IndianRed;
            else passwordEntry.TextColor = Color.Black;
        }
    }
}
