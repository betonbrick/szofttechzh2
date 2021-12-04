﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace CarPartsMobileApp.Behaviors
{
    class OnlyLettersValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChangedEvent;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom( Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChangedEvent;
        }

        public void OnEntryTextChangedEvent(object sender, TextChangedEventArgs args)
        {
            bool isValid = Regex.IsMatch(args.NewTextValue, @"^[a-z A-Z]+ $");
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
