using Newtonsoft.Json;
using Semana6.modelos;
using System.Collections.ObjectModel;

namespace Semana6.VIstas;

public partial class vHome : ContentPage
{
	private const string url = "http://10.90.9.92:81/Semana6/estudiantews.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estu;
	public vHome()
	{
		InitializeComponent();
		obtener();
	}

	public async void obtener()
	{
		var content = await cliente.GetStringAsync(url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<modelos.Estudiante>>(content);
		estu = new ObservableCollection<Estudiante>(mostrarEst);

		listaEstudiantes.ItemsSource = estu;
	}

    private void btnIngresar_Clicked(object sender, EventArgs e)
    {
		Estudiante nuevoEstudiante = new Estudiante
		{
			nombre = txtNombre.Text,
			apellido = txtApellido.Text,
			edad = int.Parse(txtEdad.Text),
            // Otras propiedades del estudiante
            
        };
        estu.Add(nuevoEstudiante);

        listaEstudiantes.ItemsSource = null; 
        listaEstudiantes.ItemsSource = estu;
    }
}