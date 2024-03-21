$(document).ready(function () {
    $('#myTable').DataTable(
        {
            ajax: {
                url: "AdminCategoria/BuscaCategoriaDataTable",
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
                           <a class="textPrimary" href="/Admin/Edit?id=${full.id}&tp=view>Editar</a> |
                           <a class="textPrimary" href="/Admin/Details?id=${full.id}&tp=view>Detalhes</a> |
                           <a class="textPrimary" href="/Admin/Delete?id=${full.id}&tp=view>Deletar</a>
                           `;
                    }, "width": '3%', "title": "#", "name": "id"
                },
            ],
            language: {
                "url": "//cdn.datatables.net/plug-ins/1.10.24/i18n/Portuguese-Brasil.json"
            },
            lengthMenu: [[5, 10, 25, 50, 100, 200, 500, -1], [5, 10, 25, 50, 100, 200, 500, "Tudo"]]
        }
    );
});
