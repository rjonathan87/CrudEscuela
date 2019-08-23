(function($){

    //cargamos los datos a la tabla de materias
    var Id = $("#Id").val();
    
    listaDeSesiones(Id); //aquí se carga el id que viene de la url


    function listaDeSesiones(Id) {
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
                
                let table = document.getElementById("table-data-materias");
                tbody = table.createTBody();

                $.each(data, function (i, con) {
                    
                    var row = tbody.insertRow();

                    var cell1 = row.insertCell(0);
                    var cell2 = row.insertCell(1);
                    var cell3 = row.insertCell(2);

                    cell1.innerHTML = con.nombreMateria;
                    cell2.innerHTML = con.costo;

                    cell3.innerHTML = `
                                        <button class='btn btn-danger btn_materia_delete' 
                                            data-idAlumno=${ Id }
                                            data-idMateria=${ con.id } 
                                            role='button' title='Eliminar'>
                                            Borrar
                                        </button>
                                        `;
                });
            }
        });

    }
})(jQuery);