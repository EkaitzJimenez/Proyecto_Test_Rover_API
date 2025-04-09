using Wpf_Ejercicio_4_Ekaitz_Jimenez.Controllers;
using Xunit;
using System.Threading.Tasks;

public class PhotosControllerTests
{
    [Fact] 
    public async Task Test_GetAllPhotos_ReturnsValidData()
    {
        var controller = new PhotosController();

        // Llamar al método GetAllPhotos de manera asincrona
        var resultado = await controller.GetAllPhotos();

        // comprobar que el resultado no sea nulo
        Assert.NotNull(resultado);

        // comprobar que la lista de fotos no esté vacía
        Assert.NotEmpty(resultado.photos);

        //comptueba que la primera foto tenga un ID válido
        Assert.True(resultado.photos[0].id > 0);
    }
}
