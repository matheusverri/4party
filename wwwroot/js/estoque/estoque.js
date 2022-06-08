$(document).ready(function () {
    if ($('#estoque').length) {
        $('#datatable-saida').DataTable({
            'destroy': true,
            'paging': true,
            'info': false,
            'scrollCollapse': false,
            'filter': true,
            'ordering': true
        })
    }
})