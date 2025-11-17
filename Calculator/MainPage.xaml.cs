namespace Calculator;

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

    private void OnClearEntryPressed(object? sender, EventArgs e)
    {
        string currentText = Display.Text;
        if (currentText.Length > 1)
        {
            string newText = currentText.Substring(1, currentText.Length - 1);
            Display.Text = newText;
        }
        else
        {
            Display.Text = "";
            isFirstNumberAfterOperator = true;
        }
        

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
            firstNumber = Double.Parse(Display.Text);
          
        }
        else
        {
            
            secondNumber = Double.Parse(Display.Text);
            double result=0;
            switch (currentOperator)
            {
                case "+" :   result = firstNumber + secondNumber; break;
                case "-" :   result = firstNumber - secondNumber; break;
                case "*" :   result = firstNumber * secondNumber; break;
                case "/" :   result = firstNumber / secondNumber; break;
                
                
            }

            Display.Text = result.ToString();
            currentOperator = pressedButton.Text;
            if(pressedButton.Text == "=") currentOperator = "";
            firstNumber = result;
            
        }
    }
}