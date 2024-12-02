namespace ExamenIIMateoPuga;

public partial class MP_MainPage : ContentPage
{
    public MP_MainPage()
    {
        InitializeComponent();

        // Opciones para los pickers
        MP_FromUnitPicker.ItemsSource = new List<string> { "Metros cuadrados", "Hectáreas", "Acres" };
        MP_ToUnitPicker.ItemsSource = new List<string> { "Metros cuadrados", "Hectáreas", "Acres" };
    }

    private void OnConvertClicked(object sender, EventArgs e)
    {
        double input;
        if (double.TryParse(MP_InputEntry.Text, out input))
        {
            string fromUnit = MP_FromUnitPicker.SelectedItem?.ToString();
            string toUnit = MP_ToUnitPicker.SelectedItem?.ToString();

            if (fromUnit != null && toUnit != null)
            {
                double result = 0;

                // Conversión
                if (fromUnit == "Metros cuadrados" && toUnit == "Hectáreas")
                    result = input / 10000;
                else if (fromUnit == "Metros cuadrados" && toUnit == "Acres")
                    result = input / 4046.86;
                else if (fromUnit == "Hectáreas" && toUnit == "Metros cuadrados")
                    result = input * 10000;
                else if (fromUnit == "Hectáreas" && toUnit == "Acres")
                    result = input * 2.47105;
                else if (fromUnit == "Acres" && toUnit == "Metros cuadrados")
                    result = input * 4046.86;
                else if (fromUnit == "Acres" && toUnit == "Hectáreas")
                    result = input / 2.47105;
                else
                    result = input; // Si son la misma unidad

                MP_ResultLabel.Text = $"{input} {fromUnit} = {result:F2} {toUnit}";
            }
            else
            {
                MP_ResultLabel.Text = "Seleccione unidades válidas.";
            }
        }
        else
        {
            MP_ResultLabel.Text = "Ingrese un valor válido.";
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        MP_InputEntry.Text = string.Empty;
        MP_ResultLabel.Text = string.Empty;
        MP_FromUnitPicker.SelectedItem = null;
        MP_ToUnitPicker.SelectedItem = null;
    }
}
