using Newtonsoft.Json;
using Wpf_Ejercicio_4_Ekaitz_Jimenez.Models;

public class PhotosController
{
    private HttpClient client;

    //constructor
    public PhotosController()
    {
        client = new HttpClient();
    }

    // Método de GetAllPhotos
    public async Task<Photos> GetAllPhotos()
    {
        try
        {
            Photos photos = new Photos();

            // Simulación de una respuesta de la API con un dato mal
            // una foto con id incorrecto
            var responseJson = @"
                {
                    'photos': [
                        {
                            'id': 0,  // ID incompleto
                            'earth_date': '2015-05-30',
                            'img_src': 'http://mars.jpl.nasa.gov/msl-raw-images/proj/msl/r'
                        }
                    ]
                }";
            photos = JsonConvert.DeserializeObject<Photos>(responseJson);

            // Simulo un caso donde la foto no tiene un ID correcto
            if (photos.photos.Any(photo => photo.id <= 0))
            {
                return null;  // Si hay incompletos, devuelveme null
            }

            return photos;
        }
        catch (Exception ex)
        {
            // Si ocurre una excepción, devolvemos null
            return null;
        }
    }
}
