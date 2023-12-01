$(window).on("load", function () {
    $(document).ready(function () {
        $.ajax({
            url: 'https://localhost:44351/api/toyota/ListadoDeDetalles',
            type: 'GET',
            crossDomain: true,
            xhrFields: {
                withCredentials: true
            },
            success: function (data) {
                console.log("Datos recibidos:", data);  // Agrega esta línea para verificar los datos en la consola

                data.forEach((item, indice) => {
                    let htmlRow = "<tr>";
                    htmlRow += "<td>" + (item.precio !== undefined ? item.precio : "Precio no disponible") + "</td>";
                    htmlRow += "<td>" + (item.status ? "Si" : "No") + "</td>";

                    if (item.autos !== null && typeof item.autos === 'object') {
                        htmlRow += "<td>" + (item.autos.codigo !== undefined ? item.autos.codigo : "Código no disponible") + "</td>";
                        htmlRow += "<td>" + item.autos.numero_Serie + "</td>";
                        htmlRow += "<td>" + item.autos.nombre + "</td>";
                        htmlRow += "<td>" + item.autos.precio + "</td>";
                        htmlRow += "<td>" + item.autos.stock + "</td>";
                        htmlRow += "<td>" + (item.autos.envioDomicilio ? "Si" : "No") + "</td>";
                        htmlRow += "<td>" + (item.autos.retiroEnTienda ? "Si" : "No") + "</td>";
                        htmlRow += `<td><img src="${item.autos.imagen}" alt="Imagen de Auto" style="max-width: 100px; max-height: 100px;"></td>`;
                        htmlRow += "<td>" + item.autos.descripcion + "</td>";
                        
                    } else {
                        htmlRow += "<td colspan='9'>Autos no disponible</td>";
                    }

                    htmlRow += "</tr>";

                    $("#autos tbody").append(htmlRow);
                });
            },
            error: function () {
                console.error("Error al realizar la solicitud AJAX");  // Agrega esta línea para verificar errores en la consola
            }
        });
    });
});