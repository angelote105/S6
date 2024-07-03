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
}