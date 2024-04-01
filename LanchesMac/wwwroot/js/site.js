$(document).ready(function () {
    $('#myTable').DataTable(
        {
            ajax: {
                url: "AdminCategorias/BuscaCategoriaDataTable",
                type: "POST",
            },
            processing: true,
            serverSide: true,
            filter: true,
            aaSorting: [[0, 'desc']],
            columns: [
                { data: "categoriaNome", name: "categoriaNome", title: "Categoria" },
                { data: "descricao", name: "descricao", title: "Descricao" },
                {
                    render: function (data, type, full, meta) {
                        return `
                           <a class="textPrimary" href="/AdminCategorias/Edit?id=${full.id}&tp=view">Editar</a>
                           <a asp-action="Edit" asp-route-id="${full.id}">Edit</a> |
                           <a asp-action="Details" asp-route-id="${full.id}">Details</a> |
                           <a asp-action="Delete" asp-route-id="${full.id}">Delete</a>
                           `;
                    }, "width": '30%', "title": "#", "name": "id"
                },
            ],
            language: {
                "url": "//cdn.datatables.net/plug-ins/1.10.24/i18n/Portuguese-Brasil.json"
            },
            lengthMenu: [[5, 10, 25, 50, 100, 200, 500, -1], [5, 10, 25, 50, 100, 200, 500, "Tudo"]]
        }
    );
});
