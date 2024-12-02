namespace ExamenIIMateoPuga;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        // Opcional: Agregar valores al Picker
        FromUnitPicker.ItemsSource = new List<string> { "Metros", "Kilómetros", "Pulgadas", "Centímetros" };
        ToUnitPicker.ItemsSource = new List<string> { "Metros", "Kilómetros", "Pulgadas", "Centímetros" };
    }

    private void OnConvertClicked(object sender, EventArgs e)
    {
        double input;
        if (double.TryParse(InputEntry.Text, out input))
        {
            string fromUnit = FromUnitPicker.SelectedItem?.ToString();
            string toUnit = ToUnitPicker.SelectedItem?.ToString();

            if (fromUnit != null && toUnit != null)
            {
                double result = 0;

                // Agregar lógica de conversión
                if (fromUnit == "Metros" && toUnit == "Kilómetros")
                    result = input / 1000;
                else if (fromUnit == "Metros" && toUnit == "Pulgadas")
                    result = input * 39.3701;
                else if (fromUnit == "Metros" && toUnit == "Centímetros")
                    result = input * 100;

                else if (fromUnit == "Kilómetros" && toUnit == "Metros")
                    result = input * 1000;
                else if (fromUnit == "Kilómetros" && toUnit == "Pulgadas")
                    result = input * 39370.1;
                else if (fromUnit == "Kilómetros" && toUnit == "Centímetros")
                    result = input * 100000;

                else if (fromUnit == "Pulgadas" && toUnit == "Metros")
                    result = input * 0.0254;
                else if (fromUnit == "Pulgadas" && toUnit == "Kilómetros")
                    result = input * 0.0000254;
                else if (fromUnit == "Pulgadas" && toUnit == "Centímetros")
                    result = input * 2.54;

                else if (fromUnit == "Centímetros" && toUnit == "Metros")
                    result = input * 0.01;
                else if (fromUnit == "Centímetros" && toUnit == "Kilómetros")
                    result = input * 0.00001;
                else if (fromUnit == "Centímetros" && toUnit == "Pulgadas")
                    result = input * 0.393701;
                // Agrega más conversiones según sea necesario

                ResultLabel.Text = $"{input} {fromUnit} = {result} {toUnit}";
            }
            else
            {
                ResultLabel.Text = "Seleccione unidades válidas.";
            }
        }
        else
        {
            ResultLabel.Text = "Ingrese un valor válido.";
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        InputEntry.Text = string.Empty;
        ResultLabel.Text = string.Empty;
        FromUnitPicker.SelectedItem = null;
        ToUnitPicker.SelectedItem = null;
    }
}
