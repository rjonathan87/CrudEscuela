(function ($) {

    //cargamos los datos a la tabla de materias
    var Id = $("#Id").val();

    listaDeMaterias(Id); //aquí se carga el id que viene de la url

    function listaDeMaterias(Id) {
        $("#table-data-materias tbody").remove();

        $.ajax({
            url: "../../AlumnoMateria/GetMateriasByAlumno",
            type: "post",
            data: {
                Id: Id
            },
            dataType: "json",
            success: function (data) {
                console.log(data);
                var total = 0;

                let table = document.getElementById("table-data-materias");
                tbody = table.createTBody();

                $.each(data, function (i, con) {

                    var row = tbody.insertRow();

                    var cell1 = row.insertCell(0);
                    var cell2 = row.insertCell(1);
                    var cell3 = row.insertCell(2);

                    total += con.costo;

                    cell1.innerHTML = con.nombreMateria;
                    cell2.innerHTML = con.costo;

                    cell3.innerHTML = `
                                        <button class='btn btn-danger btn_materia_delete' 
                                            data-idAlumno=${ Id}
                                            data-idMateria=${ con.id} 
                                            role='button' title='Eliminar'>
                                            Borrar
                                        </button>
                                        `;
                    $("#totalCosto").text(total);
                });
            }
        });

    }

    /**Autocomplete Materias disponibles */
    $("#materiasDisponibles").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../Materia/MateriasDisponibles",
                type: "POST",
                dataType: "json",
                data: { search: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            value: item.id,
                            label: item.nombreMateria,
                            activo: item.activo,
                            costo: item.costo
                        }
                    }))
                }
            })
        },
        select: function (event, ui) {
            addMateria(ui);
        }
    });

    function addMateria(datos) {
        // let materiaAdd = datos.item.value;

        var AlumnoId = Id;
        var MateriaId = datos.item.value;

        $.ajax({
            url: "../../AlumnoMateria/PostAlumnoMateria",
            type: "POST",
            dataType: "json",
            data: {
                "AlumnoId": AlumnoId,
                "MateriaId": MateriaId
            },
            success: function (data) {
                console.log(data);
                listaDeMaterias(Id);
                $("#materiasDisponibles").val('');
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Solicitud Erronea, no puedes duplicar Materias!!');
        });

    }

    /** Delete Materias del alumno */
    $("#table-data-materias").on('click', '.btn_materia_delete', function (e) {
        if (confirm("Está seguro de eliminar la materia?")) {
            let IdAlumno = $(this).data("idalumno");
            let IdMateria = $(this).data("idmateria");

            $.ajax({
                url: "../../AlumnoMateria/Delete",
                type: "DELETE",
                dataType: "json",
                data: {
                    idAlumno: IdAlumno,
                    idMateria: IdMateria
                },
                success: (data) => {
                    console.log(data);
                    listaDeMaterias(Id);
                }
            }).fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrow);

            });
        }
    });


})(jQuery);
