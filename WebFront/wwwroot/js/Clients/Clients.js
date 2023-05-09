$(document).ready(function () {
    $('#clients').DataTable(
        {
            ajax: {
                url: 'https://localhost:7175/api/clients',
                dataSrc: ""
            },
            columns: [
                { data: 'id', title: 'Id' },
                { data: 'name', title: 'Nombre' },
                { data: 'lastName', title: 'Apellido' },
                {
                    data: function (data) {
                        return moment(data.birthDate).format('DD/MM/YYYY');
                    }, title: 'Fecha de Nacimiento'
                },
                { data: 'mail', title: 'Mail' },
            ],
            language: {
                url: 'https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json',
            },
        }
    );
});