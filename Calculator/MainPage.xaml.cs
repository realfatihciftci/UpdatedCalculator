namespace Calculator;
using System.Globalization;
public partial class MainPage : ContentPage
{
    private double firstNumber = 0;
    private double secondNumber = 0;
    private string currentOperator = ""; // + - * / =
    private bool isFirstNumberAfterOperator = true;
    public MainPage()
    {
        InitializeComponent();
    }


    private void OnNumberPressed(object? sender, EventArgs e)
    {
        Button pressedButton = sender as Button;

        if (pressedButton != null)
        {
            if (isFirstNumberAfterOperator)
            {
                Display.Text = pressedButton.Text;
                isFirstNumberAfterOperator = false;
            }
            else
            {
                Display.Text = Display.Text + pressedButton.Text;
            }
        }
        
    }

    private void OnDecimalPressed(object? sender, EventArgs e)
    {
        if (isFirstNumberAfterOperator)
        {
            Display.Text = "0.";
            isFirstNumberAfterOperator = false;
        }
        else if (!Display.Text.Contains("."))
        {
            Display.Text = Display.Text + ".";
        }
    }
    private void OnClearEntryPressed(object? sender, EventArgs e)
    {
        string currentText = Display.Text;
        if (currentText.Length > 1)
        {
            string newText = currentText.Substring(0, currentText.Length - 1);
            Display.Text = newText;
        }
        else
        {
            Display.Text = "";
            isFirstNumberAfterOperator = true;
        }

    }

    private void OnSquarePressed(object? sender, EventArgs e)
    {
        double currentNumber = double.Parse(Display.Text, CultureInfo.InvariantCulture);
        
        double result = currentNumber * currentNumber;
        result = Math.Round(result, 10);
        Display.Text = result.ToString(CultureInfo.InvariantCulture);
        isFirstNumberAfterOperator = false;
        
    }
    private void OnRootPressed(object? sender, EventArgs e)
    {
        double currentNumber = double.Parse(Display.Text, CultureInfo.InvariantCulture);
        
        double result = Math.Sqrt(currentNumber);
        result = Math.Round(result, 10);
        Display.Text = result.ToString(CultureInfo.InvariantCulture);
        isFirstNumberAfterOperator = false;
    }
    
    private void OnClearPressed(object? sender, EventArgs e)
    {
        Display.Text = "0";
        HistoryLabel.Text = "";
        firstNumber = 0;
        secondNumber = 0;
        currentOperator = "";
        isFirstNumberAfterOperator = true;
    }
    private void OnOperatorPressed(object? sender, EventArgs e)
    {
        Button pressedButton = sender as Button;

        if (isFirstNumberAfterOperator)
        {
            currentOperator = pressedButton.Text;
            return;
        }
        
        isFirstNumberAfterOperator = true;
        if (currentOperator == "")
        {
            currentOperator = pressedButton.Text;
            firstNumber = Double.Parse(Display.Text, CultureInfo.InvariantCulture);
            if (pressedButton.Text != "=")
            {
                HistoryLabel.Text = Display.Text + " " + currentOperator;
            }
        }
        else
        {
            
            secondNumber = Double.Parse(Display.Text, CultureInfo.InvariantCulture);
            double result=0;
            switch (currentOperator)
            {
                case "+" :   result = firstNumber + secondNumber; break;
                case "-" :   result = firstNumber - secondNumber; break;
                case "*" :   result = firstNumber * secondNumber; break;
                case "/" :   result = firstNumber / secondNumber; break;
                
                
            }

            Display.Text = result.ToString(CultureInfo.InvariantCulture);
            if (pressedButton.Text == "=")
            {
                HistoryLabel.Text = firstNumber + currentOperator + secondNumber;
            }
            else
            {
                HistoryLabel.Text =result + "" + pressedButton.Text;
            }
            currentOperator = pressedButton.Text;
            if(pressedButton.Text == "=") currentOperator = "";
            firstNumber = result;
            
        }
    }
}