using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MathCalculator;

public partial class MainPage : ContentPage
{
    // Define a field variable to remember the history of expressions

    private ObservableCollection<string> _expList;


    public MainPage()
    {
        InitializeComponent();

        //Initialize field variables on the page
        _expList = new ObservableCollection<string>();

        //Bind the collection view with the list
        _lstExpHistory.ItemsSource = _expList;

    }

    private void OnCalculate(object sender, EventArgs e)
    {
        // Obtain user input from _txtLeftOp _txtRightOp and _pckOperand.

        string leftOperandInput = _txtLeftOp.Text;
        double leftOperand = double.Parse(leftOperandInput);
        
        double rightOperand = double.Parse(_txtRightOp.Text);

        string opInput = (string)_pckOperand.SelectedItem;
        char op = opInput[0];

        //Check the chosen operator and perform the corresponding operator.
        double result = PerformArithmeticOperation(op, leftOperand, rightOperand); 


        //Display the arithmetic expression in the output control.
        string expression = $"{leftOperand} {op} {rightOperand} = {result}";

        //Remember the calculated expression in the calculaotr history
        _expList.Add(expression);

        _lstExpHistory.ItemsSource = null;
        _lstExpHistory.ItemsSource = _expList;
    }

    private double PerformArithmeticOperation(char op, double leftOperand, double rightOperand)
    {
        //Check the type of operand (with op) and perform the corresponding operation

        double result;

        switch (op)
        {
            case '+':
                result = PerformAddition(leftOperand, rightOperand);
                break;

            case '-':
                result = PerformSubtraction(leftOperand, rightOperand);
                break;

            case '*':
                result = PerformMultiplication(leftOperand, rightOperand);
                break;

            case '/':
                result = PerformDivision(leftOperand, rightOperand);
                break;

            case '%':
                result = PerformDivRemainder(leftOperand, rightOperand);
                break;

            default:
                Debug.Assert(false, "Unknown Arithmetic operation. Default result returned.");
                result = 0;
                break;


        }

        return result;
    }

    private double PerformDivision(double leftOperand, double rightOperand)
    {
        //Check whether the division operator is integer or real division.
        
        string divOp = (string)_pckOperand.SelectedItem;
        if (divOp.Contains("int", StringComparison.OrdinalIgnoreCase))
        {
            //Perform an integer division which can only be done by having operands as integers.
            int leftIntOp = (int)leftOperand;
            int rightIntOp = (int)rightOperand;
            int result = leftIntOp / rightIntOp;
            return result;

        }

        else
        {
            //Perform a regular division.
            double result = leftOperand / rightOperand;
            return result;
        }

    }

    private double PerformMultiplication(double leftOperand, double rightOperand)
    {
        double result;
        result = leftOperand * rightOperand;
        return result;
    }

    private double PerformDivRemainder(double leftOperand, double rightOperand)
    {
        double result;
        result = leftOperand % rightOperand;
        return result;
    }

    private double PerformSubtraction(double leftOperand, double rightOperand)
    {
        double result;
        result = leftOperand - rightOperand;
        return result;
    }

    private double PerformAddition(double leftOperand, double rightOperand)
    {
        double result;
        result = leftOperand + rightOperand;
        return result;
    }
}