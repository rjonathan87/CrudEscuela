(function($){

    //cargamos los datos a la tabla de materias
    listaDeSesiones(1);


    function listaDeSesiones(Id) {
        //$("#table-data-materias tbody").remove();
        
        $.ajax({
            url: "../../AlumnoMateria/GetMateriasByAlumno",
            type: "post",
            data: {
                Id: Id
            },
            dataType: "json",
            success: function (data) {

                console.log(data);
                                

            }
        });

    }
})(jQuery);