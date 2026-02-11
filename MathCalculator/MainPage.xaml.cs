namespace MathCalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCalculate(object sender, EventArgs e)
    {
        // Obtain user input from _txtLeftOp _txtRightOp and _pckOperand.

        string leftOperandInput = _txtLeftOp.Text;
        double leftOperand = double.Parse(leftOperandInput);
        
        double rightOperand = double.Parse(_txtRightOp.Text);

        string opInput = (string)_pckOperand.SelectedItem;

        //Check the chosen operator and perform the corresponding operator.
        double result = PerformArithmeticOperation(opInput, leftOperand, rightOperand); 


        //Display the arithmetic expression in the output control.
        _txtMathExp.Text = result.ToString(); 

    }

    private double PerformArithmeticOperation(string opInput, double leftOperand, double rightOperand)
    {

        //TODO: Implement the calculation of the operands and return the result.

        return 4.125;
        throw new NotImplementedException();
    }
}