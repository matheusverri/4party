$(document).ready(function () {
    if ($('#caixa').length) {
        $('#datatable-caixa').DataTable({
            'destroy': true,
            'paging': true,
            'info': false,
            'scrollCollapse': false,
            'filter': true,
            'ordering': true
        })
    }
})