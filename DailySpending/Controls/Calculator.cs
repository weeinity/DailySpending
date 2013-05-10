using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Windows.Input;
using System.Globalization;
using System.Windows;


namespace DailySpending
{
    public class Calculator : Control
    {
        private const string PART_CalculatorButtonPanel = "PART_CalculatorButtonPanel";

        #region Members

        private ContentControl _buttonPanel;
        private bool _showNewNumber = true;
        private decimal _previousValue;
        private Operation _lastOperation = Operation.None;
        private readonly Dictionary<Button, DispatcherTimer> _timers = new Dictionary<Button, DispatcherTimer>();

        #endregion //Members

        #region Enumerations

        public enum CalculatorButtonType
        {
            Add,
            Back,
            Cancel,
            Clear,
            Decimal,
            Divide,
            Eight,
            Equal,
            Five,
            Four,
            Fraction,
            MAdd,
            MC,
            MR,
            MS,
            MSub,
            Multiply,
            Negate,
            Nine,
            None,
            One,
            Percent,
            Seven,
            Six,
            Sqrt,
            Subtract,
            Three,
            Two,
            Zero
        }

        public enum Operation
        {
            Add,
            Subtract,
            Divide,
            Multiply,
            Percent,
            Sqrt,
            Fraction,
            None,
            Clear,
            Negate
        }

        #endregion //Enumerations

        #region Properties

        #region CalculatorButtonType

        //public static readonly DependencyProperty CalculatorButtonTypeProperty = DependencyProperty.RegisterAttached("CalculatorButtonType", typeof(CalculatorButtonType), typeof(Calculator), new UIPropertyMetadata(CalculatorButtonType.None, OnCalculatorButtonTypeChanged));
        //public static CalculatorButtonType GetCalculatorButtonType(DependencyObject target)
        //{
        //    return (CalculatorButtonType)target.GetValue(CalculatorButtonTypeProperty);
        //}
        //public static void SetCalculatorButtonType(DependencyObject target, CalculatorButtonType value)
        //{
        //    target.SetValue(CalculatorButtonTypeProperty, value);
        //}
        private static void OnCalculatorButtonTypeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            OnCalculatorButtonTypeChanged(o, (CalculatorButtonType)e.OldValue, (CalculatorButtonType)e.NewValue);
        }
        private static void OnCalculatorButtonTypeChanged(DependencyObject o, CalculatorButtonType oldValue, CalculatorButtonType newValue)
        {
            Button button = o as Button;
            button.CommandParameter = newValue;
            button.Content = CalculatorUtilities.GetCalculatorButtonContent(newValue);
        }

        #endregion //CalculatorButtonType

        #region DisplayText

        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register("DisplayText", typeof(string), typeof(Calculator), null);//new UIPropertyMetadata("0", OnDisplayTextChanged));
        public string DisplayText
        {
            get
            {
                return (string)GetValue(DisplayTextProperty);
            }
            set
            {
                SetValue(DisplayTextProperty, value);
            }
        }

        private static void OnDisplayTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Calculator calculator = o as Calculator;
            if (calculator != null)
                calculator.OnDisplayTextChanged((string)e.OldValue, (string)e.NewValue);
        }

        protected virtual void OnDisplayTextChanged(string oldValue, string newValue)
        {
            // TODO: Add your property changed side-effects. Descendants can override as well.
        }

        #endregion //DisplayText

        #region Memory

        public static readonly DependencyProperty MemoryProperty = DependencyProperty.Register("Memory", typeof(decimal), typeof(Calculator), null);//new UIPropertyMetadata(default(decimal)));
        public decimal Memory
        {
            get
            {
                return (decimal)GetValue(MemoryProperty);
            }
            set
            {
                SetValue(MemoryProperty, value);
            }
        }

        #endregion //Memory

        #region Precision

        public static readonly DependencyProperty PrecisionProperty = DependencyProperty.Register("Precision", typeof(int), typeof(Calculator), null); //new UIPropertyMetadata(6));
        public int Precision
        {
            get
            {
                return (int)GetValue(PrecisionProperty);
            }
            set
            {
                SetValue(PrecisionProperty, value);
            }
        }

        #endregion //Precision

        #region Value

        //public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(decimal?), typeof(Calculator), new FrameworkPropertyMetadata(default(decimal), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));
        //public decimal? Value
        //{
        //    get
        //    {
        //        return (decimal?)GetValue(ValueProperty);
        //    }
        //    set
        //    {
        //        SetValue(ValueProperty, value);
        //    }
        //}

        private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            //Calculator calculator = o as Calculator;
            //if (calculator != null)
            //    calculator.OnValueChanged((decimal?)e.OldValue, (decimal?)e.NewValue);
        }

        //protected virtual void OnValueChanged(decimal? oldValue, decimal? newValue)
        //{
        //    SetDisplayText(newValue);

        //    RoutedPropertyChangedEventArgs<object> args = new RoutedPropertyChangedEventArgs<object>(oldValue, newValue);
        //    args.RoutedEvent = ValueChangedEvent;
        //    RaiseEvent(args);
        //}

        #endregion //Value

        #endregion //Properties

        #region Constructors

        static Calculator()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(Calculator), new FrameworkPropertyMetadata(typeof(Calculator)));
        }

        public Calculator()
        {
            //CommandBindings.Add(new CommandBinding(CalculatorCommands.CalculatorButtonClick, ExecuteCalculatorButtonClick));
            //AddHandler(MouseDownEvent, new MouseButtonEventHandler(Calculator_OnMouseDown), true);
        }

        #endregion //Constructors

        #region Base Class Overrides

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _buttonPanel = GetTemplateChild(PART_CalculatorButtonPanel) as ContentControl;
        }

        //protected override void OnTextInput(TextCompositionEventArgs e)
        //{
        //    var buttonType = CalculatorUtilities.GetCalculatorButtonTypeFromText(e.Text);
        //    if (buttonType != CalculatorButtonType.None)
        //    {
        //        SimulateCalculatorButtonClick(buttonType);
        //        ProcessCalculatorButton(buttonType);
        //    }
        //}

        #endregion //Base Class Overrides

        #region Event Handlers

        //private void Calculator_OnMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (!IsFocused)
        //    {
        //        Focus();
        //        e.Handled = true;
        //    }
        //}

        //void Timer_Tick(object sender, EventArgs e)
        //{
        //    DispatcherTimer timer = (DispatcherTimer)sender;
        //    timer.Stop();
        //    timer.Tick -= Timer_Tick;

        //    if (_timers.ContainsValue(timer))
        //    {
        //        var button = _timers.Where(x => x.Value == timer).Select(x => x.Key).FirstOrDefault();
        //        if (button != null)
        //        {
        //            //VisualStateManager.GoToState(button, button.IsMouseOver ? "MouseOver" : "Normal", true);
        //            _timers.Remove(button);
        //        }
        //    }
        //}

        #endregion //Event Handlers

        #region Methods

        internal void InitializeToValue(decimal? value)
        {
            _previousValue = 0;
            _lastOperation = Operation.None;
            _showNewNumber = true;
            //Value = value;
            // Since the display text may be out of sync
            // with "Value", this call will force the
            // text update if Value was already equal to
            // the value parameter.
            this.SetDisplayText(value);
        }

        private void Calculate()
        {
            if (_lastOperation == Operation.None)
                return;

            try
            {
                //Value = Decimal.Round(CalculateValue(_lastOperation), Precision);
                //SetDisplayText(Value); //Set DisplayText even when Value doesn't change
            }
            catch
            {
                //Value = null;
                DisplayText = "ERROR";
            }
        }

        private void SetDisplayText(decimal? newValue)
        {
            if (newValue.HasValue && (newValue.Value != 0))
                DisplayText = newValue.ToString();
            else
                DisplayText = "0";
        }

        private void Calculate(Operation newOperation)
        {
            if (!_showNewNumber)
                Calculate();

            _lastOperation = newOperation;
        }

        private void Calculate(Operation currentOperation, Operation newOperation)
        {
            _lastOperation = currentOperation;
            Calculate();
            _lastOperation = newOperation;
        }

        private decimal CalculateValue(Operation operation)
        {
            decimal newValue = decimal.Zero;
            decimal currentValue = CalculatorUtilities.ParseDecimal(DisplayText);

            switch (operation)
            {
                case Operation.Add:
                    newValue = CalculatorUtilities.Add(_previousValue, currentValue);
                    break;
                case Operation.Subtract:
                    newValue = CalculatorUtilities.Subtract(_previousValue, currentValue);
                    break;
                case Operation.Multiply:
                    newValue = CalculatorUtilities.Multiply(_previousValue, currentValue);
                    break;
                case Operation.Divide:
                    newValue = CalculatorUtilities.Divide(_previousValue, currentValue);
                    break;
                //case Operation.Percent:
                //    newValue = CalculatorUtilities.Percent(_previousValue, currentValue);
                //    break;
                case Operation.Sqrt:
                    newValue = CalculatorUtilities.SquareRoot(currentValue);
                    break;
                case Operation.Fraction:
                    newValue = CalculatorUtilities.Fraction(currentValue);
                    break;
                case Operation.Negate:
                    newValue = CalculatorUtilities.Negate(currentValue);
                    break;
                default:
                    newValue = decimal.Zero;
                    break;
            }

            return newValue;
        }

        void ProcessBackKey()
        {
            string displayText;
            if (DisplayText.Length > 1 && !(DisplayText.Length == 2 && DisplayText[0] == '-'))
            {
                displayText = DisplayText.Remove(DisplayText.Length - 1, 1);
            }
            else
            {
                displayText = "0";
                _showNewNumber = true;
            }

            DisplayText = displayText;
        }

        private void ProcessCalculatorButton(CalculatorButtonType buttonType)
        {
            if (CalculatorUtilities.IsDigit(buttonType))
                ProcessDigitKey(buttonType);
            else if ((CalculatorUtilities.IsMemory(buttonType)))
                ProcessMemoryKey(buttonType);
            else
                ProcessOperationKey(buttonType);
        }

        private void ProcessDigitKey(CalculatorButtonType buttonType)
        {
            if (_showNewNumber)
                DisplayText = CalculatorUtilities.GetCalculatorButtonContent(buttonType);
            else
                DisplayText += CalculatorUtilities.GetCalculatorButtonContent(buttonType);

            _showNewNumber = false;
        }

        private void ProcessMemoryKey(Calculator.CalculatorButtonType buttonType)
        {
            decimal currentValue = CalculatorUtilities.ParseDecimal(DisplayText);

            switch (buttonType)
            {
                case Calculator.CalculatorButtonType.MAdd:
                    Memory += currentValue;
                    break;
                case Calculator.CalculatorButtonType.MC:
                    Memory = decimal.Zero;
                    break;
                case Calculator.CalculatorButtonType.MR:
                    DisplayText = Memory.ToString();
                    break;
                case Calculator.CalculatorButtonType.MS:
                    Memory = currentValue;
                    break;
                case Calculator.CalculatorButtonType.MSub:
                    Memory -= currentValue;
                    break;
                default:
                    break;
            }

            _showNewNumber = true;
        }

        private void ProcessOperationKey(CalculatorButtonType buttonType)
        {
            switch (buttonType)
            {
                case CalculatorButtonType.Add:
                    Calculate(Operation.Add);
                    break;
                case CalculatorButtonType.Subtract:
                    Calculate(Operation.Subtract);
                    break;
                case CalculatorButtonType.Multiply:
                    Calculate(Operation.Multiply);
                    break;
                case CalculatorButtonType.Divide:
                    Calculate(Operation.Divide);
                    break;
                case CalculatorButtonType.Percent:
                    if (_lastOperation != Operation.None)
                    {
                        decimal currentValue = CalculatorUtilities.ParseDecimal(DisplayText);
                        decimal newValue = CalculatorUtilities.Percent(_previousValue, currentValue);
                        DisplayText = newValue.ToString();
                    }
                    else
                    {
                        DisplayText = "0";
                        _showNewNumber = true;
                    }
                    return;
                case CalculatorButtonType.Sqrt:
                    Calculate(Operation.Sqrt, Operation.None);
                    break;
                case CalculatorButtonType.Fraction:
                    Calculate(Operation.Fraction, Operation.None);
                    break;
                case CalculatorButtonType.Negate:
                    Calculate(Operation.Negate, Operation.None);
                    break;
                case CalculatorButtonType.Equal:
                    Calculate(Operation.None);
                    break;
                case CalculatorButtonType.Clear:
                    Calculate(Operation.Clear, Operation.None);
                    break;
                case CalculatorButtonType.Cancel:
                    DisplayText = _previousValue.ToString();
                    _lastOperation = Operation.None;
                    _showNewNumber = true;
                    return;
                case CalculatorButtonType.Back:
                    ProcessBackKey();
                    return;
                default:
                    break;
            }

            Decimal.TryParse(DisplayText, out _previousValue);
            _showNewNumber = true;
        }

        private void SimulateCalculatorButtonClick(CalculatorButtonType buttonType)
        {
            var button = CalculatorUtilities.FindButtonByCalculatorButtonType(_buttonPanel, buttonType);
            if (button != null)
            {
                VisualStateManager.GoToState(button, "Pressed", true);
                DispatcherTimer timer;
                if (_timers.ContainsKey(button))
                {
                    timer = _timers[button];
                    timer.Stop();
                }
                else
                {
                    timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(100);
                    //timer.Tick += Timer_Tick;
                    _timers.Add(button, timer);
                }

                timer.Start();
            }
        }

        #endregion //Methods

        #region Events

        //Due to a bug in Visual Studio, you cannot create event handlers for nullable args in XAML, so I have to use object instead.
        //public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(Calculator));
        //public event RoutedPropertyChangedEventHandler<object> ValueChanged
        //{
        //    add
        //    {
        //        AddHandler(ValueChangedEvent, value);
        //    }
        //    remove
        //    {
        //        RemoveHandler(ValueChangedEvent, value);
        //    }
        //}

        #endregion //Events

        #region Commands

        //private void ExecuteCalculatorButtonClick(object sender, ExecutedRoutedEventArgs e)
        //{
        //    var buttonType = (CalculatorButtonType)e.Parameter;
        //    ProcessCalculatorButton(buttonType);
        //}

        #endregion //Commands
    }
    static class CalculatorUtilities
    {
        public static Calculator.CalculatorButtonType GetCalculatorButtonTypeFromText(string text)
        {
            switch (text)
            {
                case "0":
                    return Calculator.CalculatorButtonType.Zero;
                case "1":
                    return Calculator.CalculatorButtonType.One;
                case "2":
                    return Calculator.CalculatorButtonType.Two;
                case "3":
                    return Calculator.CalculatorButtonType.Three;
                case "4":
                    return Calculator.CalculatorButtonType.Four;
                case "5":
                    return Calculator.CalculatorButtonType.Five;
                case "6":
                    return Calculator.CalculatorButtonType.Six;
                case "7":
                    return Calculator.CalculatorButtonType.Seven;
                case "8":
                    return Calculator.CalculatorButtonType.Eight;
                case "9":
                    return Calculator.CalculatorButtonType.Nine;
                case "+":
                    return Calculator.CalculatorButtonType.Add;
                case "-":
                    return Calculator.CalculatorButtonType.Subtract;
                case "*":
                    return Calculator.CalculatorButtonType.Multiply;
                case "/":
                    return Calculator.CalculatorButtonType.Divide;
                case "%":
                    return Calculator.CalculatorButtonType.Percent;
                case "\b":
                    return Calculator.CalculatorButtonType.Back;
                case "\r":
                case "=":
                    return Calculator.CalculatorButtonType.Equal;
            }

            //the check for the decimal is not in the switch statement. To help localize we check against the current culture's decimal seperator
            if (text == CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
                return Calculator.CalculatorButtonType.Decimal;

            //check for the escape key
            if (text == ((char)27).ToString())
                return Calculator.CalculatorButtonType.Clear;

            return Calculator.CalculatorButtonType.None;
        }

        public static Button FindButtonByCalculatorButtonType(DependencyObject parent, Calculator.CalculatorButtonType type)
        {
            //for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            //{
            //    var child = VisualTreeHelper.GetChild(parent, i);

            //    object buttonType = child.GetValue(Button.CommandParameterProperty);

            //    if (buttonType != null && (Calculator.CalculatorButtonType)buttonType == type)
            //    {
            //        return child as Button;
            //    }
            //    else
            //    {
            //        var result = FindButtonByCalculatorButtonType(child, type);

            //        if (result != null)
            //            return result;
            //    }
            //}
            return null;
        }

        public static string GetCalculatorButtonContent(Calculator.CalculatorButtonType type)
        {
            string content = string.Empty;
            switch (type)
            {
                case Calculator.CalculatorButtonType.Add:
                    content = "+";
                    break;
                case Calculator.CalculatorButtonType.Back:
                    content = "Back";
                    break;
                case Calculator.CalculatorButtonType.Cancel:
                    content = "CE";
                    break;
                case Calculator.CalculatorButtonType.Clear:
                    content = "C";
                    break;
                case Calculator.CalculatorButtonType.Decimal:
                    content = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                    break;
                case Calculator.CalculatorButtonType.Divide:
                    content = "/";
                    break;
                case Calculator.CalculatorButtonType.Eight:
                    content = "8";
                    break;
                case Calculator.CalculatorButtonType.Equal:
                    content = "=";
                    break;
                case Calculator.CalculatorButtonType.Five:
                    content = "5";
                    break;
                case Calculator.CalculatorButtonType.Four:
                    content = "4";
                    break;
                case Calculator.CalculatorButtonType.Fraction:
                    content = "1/x";
                    break;
                case Calculator.CalculatorButtonType.MAdd:
                    content = "M+";
                    break;
                case Calculator.CalculatorButtonType.MC:
                    content = "MC";
                    break;
                case Calculator.CalculatorButtonType.MR:
                    content = "MR";
                    break;
                case Calculator.CalculatorButtonType.MS:
                    content = "MS";
                    break;
                case Calculator.CalculatorButtonType.MSub:
                    content = "M-";
                    break;
                case Calculator.CalculatorButtonType.Multiply:
                    content = "*";
                    break;
                case Calculator.CalculatorButtonType.Nine:
                    content = "9";
                    break;
                case Calculator.CalculatorButtonType.None:
                    break;
                case Calculator.CalculatorButtonType.One:
                    content = "1";
                    break;
                case Calculator.CalculatorButtonType.Percent:
                    content = "%";
                    break;
                case Calculator.CalculatorButtonType.Seven:
                    content = "7";
                    break;
                case Calculator.CalculatorButtonType.Negate:
                    content = "+/-";
                    break;
                case Calculator.CalculatorButtonType.Six:
                    content = "6";
                    break;
                case Calculator.CalculatorButtonType.Sqrt:
                    content = "Sqrt";
                    break;
                case Calculator.CalculatorButtonType.Subtract:
                    content = "-";
                    break;
                case Calculator.CalculatorButtonType.Three:
                    content = "3";
                    break;
                case Calculator.CalculatorButtonType.Two:
                    content = "2";
                    break;
                case Calculator.CalculatorButtonType.Zero:
                    content = "0";
                    break;
            }
            return content;
        }

        public static bool IsDigit(Calculator.CalculatorButtonType buttonType)
        {
            switch (buttonType)
            {
                case Calculator.CalculatorButtonType.Zero:
                case Calculator.CalculatorButtonType.One:
                case Calculator.CalculatorButtonType.Two:
                case Calculator.CalculatorButtonType.Three:
                case Calculator.CalculatorButtonType.Four:
                case Calculator.CalculatorButtonType.Five:
                case Calculator.CalculatorButtonType.Six:
                case Calculator.CalculatorButtonType.Seven:
                case Calculator.CalculatorButtonType.Eight:
                case Calculator.CalculatorButtonType.Nine:
                case Calculator.CalculatorButtonType.Decimal:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsMemory(Calculator.CalculatorButtonType buttonType)
        {
            switch (buttonType)
            {
                case Calculator.CalculatorButtonType.MAdd:
                case Calculator.CalculatorButtonType.MC:
                case Calculator.CalculatorButtonType.MR:
                case Calculator.CalculatorButtonType.MS:
                case Calculator.CalculatorButtonType.MSub:
                    return true;
                default:
                    return false;
            }
        }

        public static decimal ParseDecimal(string text)
        {
            return Decimal.Parse(text, CultureInfo.CurrentCulture);
        }

        public static decimal Add(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public static decimal Subtract(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public static decimal Multiply(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public static decimal Divide(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber / secondNumber;
        }

        public static decimal Percent(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber * secondNumber / 100M;
        }

        public static decimal SquareRoot(decimal operand)
        {
            return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(operand)));
        }

        public static decimal Fraction(decimal operand)
        {
            return 1 / operand;
        }

        public static decimal Negate(decimal operand)
        {
            return operand * -1M;
        }
    }
}
