using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarPartsMobileApp.Behaviors
{
    class EventToCommandBehavior : BehaviorBase<VisualElement>
    {
        Delegate eventHandler;

        public static readonly BindableProperty EventNameProperty = BindableProperty.Create("EventName", typeof(string), typeof(EventToCommandBehavior), null, propertyChanged: OnEventNameChanged);
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(EventToCommandBehavior), null);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(EventToCommandBehavior), null);
        public static readonly BindableProperty InputConverterProperty = BindableProperty.Create("Converter", typeof(IValueConverter), typeof(EventToCommandBehavior), null);

        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(InputConverterProperty); }
            set { SetValue(InputConverterProperty, value); }
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            EventRegister(EventName);
        }
        protected override void OnDetachingFrom(VisualElement bindable)
        {

            EventDeregister(EventName);
            base.OnDetachingFrom(bindable);
        }

        void EventRegister(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            EventInfo eventInf = AssociatedObject.GetType().GetRuntimeEvent(name);
            if (eventInf == null)
            {
                throw new ArgumentException(string.Format("EventToCommandBehavior: Cannot register the '{0}' event.", EventName));
            }
            MethodInfo methodInf = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");
            eventHandler = methodInf.CreateDelegate(eventInf.EventHandlerType, this);
            eventInf.AddEventHandler(AssociatedObject, eventHandler);
        }

        void EventDeregister(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            if (eventHandler == null)
            {
                return;
            }
            EventInfo eventInf = AssociatedObject.GetType().GetRuntimeEvent(name);
            if (eventInf == null)
            {
                throw new ArgumentException(string.Format("EventToCommandBehavior: Cannot deregister the '{0}' event.", EventName));
            }
            eventInf.RemoveEventHandler(AssociatedObject, eventHandler);
            eventHandler = null;
        }

        void OnEvent(object sender, object EventArgs)
        {
            if (Command == null)
            {
                return;
            }

            object resolvedParameter;
            if (CommandParameter != null)
            {
                resolvedParameter = CommandParameter;
            }
            else if (Converter != null)
            {
                resolvedParameter = Converter.Convert(EventArgs, typeof(object), null, null);
            }
            else 
            {
                resolvedParameter = EventArgs;
            }

            if (Command.CanExecute(resolvedParameter))
            {
                Command.Execute(resolvedParameter);
            }
        }

        static void OnEventNameChanged(BindableObject bindable, object previousValue, object newValue) 
        {
            var behavior = (EventToCommandBehavior)bindable;
            if (behavior.AssociatedObject==null)
            {
                return;
            }

            string previousEventName = (string)previousValue;
            string newEventName = (string)newValue;

            behavior.EventDeregister(previousEventName);
            behavior.EventRegister(newEventName);

        }
    }
}
